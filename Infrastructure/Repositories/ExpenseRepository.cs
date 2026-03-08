using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExpenseRepository : IExpense
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // Get all expenses with related ExpenseType and Account
        public async Task<List<Expense>> GetAllExpensesAsync()
        {
            return await _dbContext.Expenses
                .Include(e => e.ExpenseType)
                .Include(e => e.Account)
                .ToListAsync();
        }

        // Get single expense by ID
        public async Task<Expense?> GetExpenseByIdAsync(int id)
        {
            return await _dbContext.Expenses
                .Include(e => e.ExpenseType)
                .Include(e => e.Account)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        // Create new expense and return its ID

        public async Task CreateExpenseAsync(CreateExpenseDTO expenseDTO)
{
    if (expenseDTO == null) throw new ArgumentNullException(nameof(expenseDTO));
    
    if (!expenseDTO.Date.HasValue) 
    {
        throw new Exception("Please select a valid date for the expense.");
    }
    // 1. Validate Account existence and balance
    var account = await _dbContext.Accounts
        .FirstOrDefaultAsync(a => a.Id == expenseDTO.AccountId);

    if (account == null) throw new Exception("Account not found");
    if (account.Balance < expenseDTO.Amount) throw new Exception("Expense amount exceeds account balance.");

    // 2. Find the Budget period that covers the Expense Date
    var budget = await _dbContext.Budgets
        .Where(b => expenseDTO.Date >= b.StartingAt && expenseDTO.Date <= b.EndingAt)
        .FirstOrDefaultAsync();

    if (budget == null)
    {
        throw new Exception($"No budget period defined for "
            + $"{expenseDTO.Date?.ToString("MMMM yyyy")}");
    }

    // 3. Verify that this ExpenseType exists in the Planning for that Budget
    var planning = await _dbContext.ExpensePlannings
        .FirstOrDefaultAsync(ep => ep.BudgetId == budget.Id && ep.ExpenseTypeId == expenseDTO.ExpenseTypeId);

    if (planning== null)
    {
        throw new Exception($"The expense type is not authorized for the '{budget.Name}' budget period.");
    }
    var totalSpentSoFar = await _dbContext.Expenses
        .Where(e => e.ExpenseTypeId == expenseDTO.ExpenseTypeId && 
                    e.Date >= budget.StartingAt && 
                    e.Date <= budget.EndingAt &&
                    e.IsActive) // Only count active expenses
        .SumAsync(e => e.Amount);

    if (totalSpentSoFar + expenseDTO.Amount > planning.Amount)
    {
        decimal remaining = planning.Amount - totalSpentSoFar;
        throw new Exception($"You are trying to spend the amount that exceed the budget planned. You have Planned To Spend: {planning.Amount}. You Have Already Spent: {totalSpentSoFar} So Far. There Is A Remaining: {remaining} To Spent For {planning.ExpenseType.ExpenseTypeName}");
    }

    var expense = new Expense
    {
        Date = expenseDTO.Date ?? DateTime.UtcNow,
        ExpenseTypeId = expenseDTO.ExpenseTypeId,
        Amount = expenseDTO.Amount,
        AccountId = expenseDTO.AccountId,
        PaidTo = expenseDTO.PaidTo,
        Description = expenseDTO.Description,
        IsActive = true,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    _dbContext.Expenses.Add(expense);
    
    // Update the account balance
    account.Balance -= expenseDTO.Amount;

    await _dbContext.SaveChangesAsync();

}
        public async Task<decimal> GetRemainingBudgetAsync(int expenseTypeId, DateTime date)
        {
            var budget = await _dbContext.Budgets
                .FirstOrDefaultAsync(b => date >= b.StartingAt && date <= b.EndingAt);

            if (budget == null) return 0;

            var planning = await _dbContext.ExpensePlannings
                .FirstOrDefaultAsync(ep => ep.BudgetId == budget.Id && ep.ExpenseTypeId == expenseTypeId);

            if (planning == null) return 0;

            var spent = await _dbContext.Expenses
                .Where(e => e.ExpenseTypeId == expenseTypeId && e.Date >= budget.StartingAt && e.Date <= budget.EndingAt && e.IsActive)
                .SumAsync(e => (decimal?)e.Amount) ?? 0;

            return planning.Amount - spent;
        }
    }
}

