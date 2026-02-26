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
        public async Task<int> CreateExpenseAsync(CreateExpenseDTO expenseDTO)
        {
            var expense = new Expense
            {
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

            // Update Account balance (reduce by expense amount)
            var account = await _dbContext.Accounts
                .FirstOrDefaultAsync(a => a.Id == expenseDTO.AccountId);

            if (account != null)
            {
                // ✅ Ensure Balance is decimal in Account entity
               account.Balance -= (double)expenseDTO.Amount; // ✅ no error now

                // ✅ Update Account
                _dbContext.Accounts.Update(account);
            }

            await _dbContext.SaveChangesAsync();
            return expense.Id;
        }
    }
}

