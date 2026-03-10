using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.ExpenseTypes;

namespace Application.Services.ExpenseTypes
{
    public interface IExpenseTypeService
    {
        Task<List<ExpenseType>> GetAllExpenseTypesAsync();
        public ExpenseType GetExpenseTypeById(int id);
        void CreateExpenseType(CreateExpenseTypeDTO expenseTypeDTO);
}
}