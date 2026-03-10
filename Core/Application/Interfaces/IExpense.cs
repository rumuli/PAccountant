using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IExpenseServices
    {
        public List<Expense> GetAllExpenses();
        public Expense GetExpenseById(int id);
        void CreateExpense(CreateExpenseDTO expenseDTO);
    }
    
    }