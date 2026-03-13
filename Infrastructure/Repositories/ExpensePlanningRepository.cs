using Application.DTO.ExpensePlanning;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;
using Infrastructure.Identity;

namespace Infrastructure.Repositories
{
    public class ExpensePlanningRepository:IExpensePlanning
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserContext _userContext;
        public ExpensePlanningRepository (ApplicationDbContext context, UserContext userContext)
        {
            _dbcontext= context;
            _userContext = userContext;
        }
        public async Task<List<ExpensePlanning>> GetExpensePlanningsAsync()
        {
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }
            return await _dbcontext.ExpensePlannings
            .Include(e => e.Budget)
            .Include(e => e.ExpenseType)
            .Where(x => x.Budget.PersonId == _userContext.Id)
            .ToListAsync();
        }
        public async Task AddExpensePlanningAsync(CreateExpensePlanningDTO dto)
        {
            var budget = await _dbcontext.Budgets.FindAsync(dto.BudgetId);
            var expenseType = await _dbcontext.ExpenseTypes.FindAsync(dto.ExpenseTypeId);
            bool exist = await _dbcontext.ExpensePlannings.AnyAsync(e => e.Budget.Id == dto.BudgetId && e.ExpenseType.Id == dto.ExpenseTypeId);  
            if (exist)
            {
                throw new Exception($"Expense planning for this budget and expense type already exists.");
            }
            if(budget == null)
            {
                throw new Exception("Budget not found");    
            }
            if(expenseType == null)
            {
                throw new Exception("Expense type not found");
            }
            
            decimal potentialexpenseplanned = budget.PlannedExpense + dto.Amount;
            if(potentialexpenseplanned > budget.PlannedIncome)
            {
                throw new Exception("Planned expense exceeds the budget's planned income");
            }
            ExpensePlanning newexpenseplanning = new()
            {
                Budget = budget,
                ExpenseType = expenseType,
                Amount = dto.Amount,
                Description = dto.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserAdded = 1

            };

            budget.PlannedExpense += dto.Amount;
            _dbcontext.ExpensePlannings.Add(newexpenseplanning);
            await _dbcontext.SaveChangesAsync();

        }
    
        public async Task <List<ExpensePlanning>> GetSummaryExpensePlanningAsync(int BudgetId)
        {
            return await _dbcontext.ExpensePlannings
            .Include(x => x.ExpenseType)
            .Where(x=>x.Budget.Id == BudgetId)
            .GroupBy(x=> x.ExpenseType.Id)
            .Select(g => new ExpensePlanning
            {
                BudgetId= g.FirstOrDefault().Budget.Id,
                ExpenseTypeId= g.FirstOrDefault().ExpenseType.Id,
                Amount= g.Sum(x=> x.Amount),
                ExpenseType = g.FirstOrDefault().ExpenseType
            })
            .ToListAsync();
        } 
        public async Task<List<ExpensePlanning>>GetExpenseTypePlannedByMonthAsync( DateTime date)
        {
            return await _dbcontext.ExpensePlannings
                    .Include(e => e.Budget)
                    .Include(e => e.ExpenseType)
                    .Where(e => e.Budget.StartingAt <= date && e.Budget.EndingAt >= date)
                    .GroupBy(e => e.ExpenseType.Id)
                    .Select(g => new ExpensePlanning
                    {
                        ExpenseTypeId = g.FirstOrDefault().ExpenseType.Id,
                        ExpenseType = g.FirstOrDefault().ExpenseType,
                        Amount = g.Sum(e => e.Amount),
                    })
                    .ToListAsync();
        }
    }
}