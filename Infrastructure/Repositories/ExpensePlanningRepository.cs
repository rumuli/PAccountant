using Application.DTO.ExpensePlanning;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

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
            ExpensePlanning newexpenseplanning = new()
            {
                // Budget = await _dbcontext.Budgets.FindAsync(dto.BudgetId),
                // ExpenseType = await _dbcontext.ExpenseTypes.FindAsync(dto.ExpenseTypeId),
                Amount = dto.Amount,
                Description = dto.Description,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserAdded = 1

            };
            _dbcontext.ExpensePlannings.Add(newexpenseplanning);
            await _dbcontext.SaveChangesAsync();

        }
    }
}