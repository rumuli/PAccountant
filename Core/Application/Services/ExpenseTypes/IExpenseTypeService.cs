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

    
         Task<List<ExpenseType>> GetExpenseTypesByMonthAsync(int month, int year);

        // ADD THIS: This allows the UI to pass the exact date (e.g., March 1st)
        // to check if it falls within your custom budget range (March 5th - April 3rd).
        Task<List<ExpenseType>> GetExpenseTypesByDateAsync(DateTime selectedDate);

        
}
}