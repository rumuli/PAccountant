using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IExpenseType
    {
        Task <List<ExpenseType>> GetAllExpenseTypesAsync();
        Task <ExpenseType?> GetExpenseTypeByIdAsync(int id);
        Task<int> CreateExpenseTypeAsync(CreateExpenseTypeDTO expenseTypeDTO);
    }
}