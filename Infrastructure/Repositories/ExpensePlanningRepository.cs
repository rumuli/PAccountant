using Application.DTO.ExpensePlanning;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;

namespace Infrastructure.Repositories
{
    public class ExpensePlanningRepository:IExpensePlanning
    {
        private readonly ApplicationDbContext _dbcontext;
        public ExpensePlanningRepository (ApplicationDbContext context)
        {
            _dbcontext= context;
        }
        public async Task<List<ExpensePlanning>> GetExpensePlanningsAsync()
        {
            return await _dbcontext.ExpensePlannings
            // .Include(e => e.Budget)
            // .Include(e => e.ExpenseType)
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
            budget.Status= BudgetStatus.Running;
            _dbcontext.ExpensePlannings.Add(newexpenseplanning);
            _dbcontext.Entry(budget).Property(x => x.Status).IsModified = true;
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
    }
}