using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.ExpenseTypes
{
    public class ExpenseTypeService : IExpenseTypeService
    {
        private readonly IExpenseType _expenseType;

        public ExpenseTypeService(IExpenseType expenseType)
        {
            _expenseType = expenseType;
        }


        public async Task<ExpenseType?> GetExpenseTypeByIdAsync(int id)
        {
            return await _expenseType.GetExpenseTypeByIdAsync(id);
        }

        public async Task<List<ExpenseType>> GetAllExpenseTypesAsync()
        {
            return await _expenseType.GetAllExpenseTypesAsync();
        }

        public async Task<int> CreateExpenseTypeAsync(CreateExpenseTypeDTO expenseTypeDTO)
        {
            return await _expenseType.CreateExpenseTypeAsync(expenseTypeDTO);
        }

         // Add implementation
       public async Task<List<ExpenseType>> GetExpenseTypesByMonthAsync(int month, int year)
       {
        return await _expenseType.GetExpenseTypesByMonthAsync(month, year);
       }
        
    }
}
