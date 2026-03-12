using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IExpenseType
    {
        Task <List<ExpenseType>> GetAllExpenseTypesAsync();
        Task <ExpenseType?> GetExpenseTypeByIdAsync(int id);
        Task<int> CreateExpenseTypeAsync(CreateExpenseTypeDTO expenseTypeDTO);
        // Add this
        Task<List<ExpenseType>> GetExpenseTypesByMonthAsync(int month, int year);
        
    }
}