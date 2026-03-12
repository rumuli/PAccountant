using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.ExpenseTypes;

namespace Application.Services.ExpenseTypes
{
    public interface IExpenseTypeService
    {
       Task <List<ExpenseType>> GetAllExpenseTypesAsync();
        Task <ExpenseType?> GetExpenseTypeByIdAsync(int id);
        Task<int> CreateExpenseTypeAsync(CreateExpenseTypeDTO expenseTypeDTO);

        // Add this
        Task<List<ExpenseType>> GetExpenseTypesByMonthAsync(int month, int year);

        
}
}