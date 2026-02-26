using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IExpenseType
    {
        Task <List<ExpenseType>> GetAllExpenseTypesAsync();
        public ExpenseType GetExpenseTypeById(int id);
        void CreateExpenseType(CreateExpenseTypeDTO expenseTypeDTO);
    }
}