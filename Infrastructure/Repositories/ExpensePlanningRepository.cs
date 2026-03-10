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
            .Include(e => e.Budget)
            .Include(e => e.ExpenseType)
            .ToListAsync();
        }
        public async Task AddExpensePlanningAsync(CreateExpensePlanningDTO dto)
        {
            ExpensePlanning newexpenseplanning = new()
            {
                Budget = await _dbcontext.Budgets.FindAsync(dto.BudgetId),
                ExpenseType = await _dbcontext.ExpenseTypes.FindAsync(dto.ExpenseTypeId),
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