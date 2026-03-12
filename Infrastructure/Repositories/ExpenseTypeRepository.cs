using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.ExpenseTypes;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
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
        return await _dbContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<int> CreateExpenseTypeAsync(CreateExpenseTypeDTO expenseTypeDTO)
    {
        var expenseType = new ExpenseType
        {
            ExpenseTypeName = expenseTypeDTO.ExpenseTypeName,
            IsActive = true,
            CreatedAt = DateTime.UtcNow
        };

        _dbContext.ExpenseTypes.Add(expenseType);
        await _dbContext.SaveChangesAsync();

        return expenseType.Id; // return the generated primary key
    }
    // ExpenseTypeRepository.cs
    public async Task<List<ExpenseType>> GetExpenseTypesByMonthAsync(int month, int year)
    {
    // Assuming you have an Expense table to check which types were used in a month
    var expenseTypesInMonth = await _dbContext.Expenses
        .Where(e => e.Date.HasValue &&
                    e.Date.Value.Month == month &&
                    e.Date.Value.Year == year)
        .Select(e => e.ExpenseType)
        .Distinct()
        .ToListAsync();

    return expenseTypesInMonth;
    }
   }

 
}   