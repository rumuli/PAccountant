using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ExpenseTypeRepository : IExpenseType
    {
        private readonly ApplicationDbContext _dbContext;

        public ExpenseTypeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<ExpenseType>> GetAllExpenseTypesAsync()
        {
            return await _dbContext.ExpenseTypes.ToListAsync();
        }

        public async Task<ExpenseType?> GetExpenseTypeByIdAsync(int id)
        {
            return await _dbContext.ExpenseTypes.FindAsync(id);
        }

        public async Task<int> CreateExpenseTypeAsync(CreateExpenseTypeDTO dto)
        {
            var expenseType = new ExpenseType
            {
                ExpenseTypeName = dto.ExpenseTypeName,
                IsActive = true,
                CreatedAt = DateTime.Now 
            };

            _dbContext.ExpenseTypes.Add(expenseType);
            await _dbContext.SaveChangesAsync();
            return expenseType.Id;
        }

        /// <summary>
        /// Compatibility method: Uses the 15th to find a month's budget.
        /// </summary>
        public async Task<List<ExpenseType>> GetExpenseTypesByMonthAsync(int month, int year)
        {
            var fallbackDate = new DateTime(year, month, 15);
            return await GetExpenseTypesByDateAsync(fallbackDate);
        }

        /// <summary>
        /// THE FINAL FIX: Uses strict .Date comparison.
        /// If you select March 1st, and the budget starts March 5th, 
        /// the condition (3/1 >= 3/5) will be FALSE, and the list will be empty.
        /// </summary>
        public async Task<List<ExpenseType>> GetExpenseTypesByDateAsync(DateTime selectedDate)
        {
            // 1. Find the Budget period that covers the EXACT day selected.
            // We compare only the Date component to avoid midnight/time-offset issues.
            var budget = await _dbContext.Budgets
                .FirstOrDefaultAsync(b => selectedDate.Date >= b.StartingAt.Date 
                                       && selectedDate.Date <= b.EndingAt.Date);

            // 2. If no budget exists for March 1st (because yours starts on the 5th), 
            // return an empty list immediately.
            if (budget == null) return new List<ExpenseType>();

            // 3. Return only the types planned for this specific budget window.
            return await _dbContext.ExpensePlannings
                .Where(ep => ep.BudgetId == budget.Id)
                .Include(ep => ep.ExpenseType)
                .Select(ep => ep.ExpenseType)
                .Where(t => t != null) 
                .Distinct()
                .ToListAsync();
        }
    }
}