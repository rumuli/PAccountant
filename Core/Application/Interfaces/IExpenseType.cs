using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IExpenseTypeServices
    {
        public List<ExpenseType> GetAllExpenseTypes();
        public ExpenseType GetExpenseTypeById(int id);
        void CreateExpenseType(CreateExpenseTypeDTO expenseTypeDTO);
    }
}