using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Expenses;

namespace Application.Services.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpense _expense;
        public ExpenseService(IExpense expense)
        {
            _expense = expense;
        }

        public Expense GetExpenseById(int id)
        {
            return _expense.GetExpenseById(id);
        }

        public List<Expense> GetAllExpenses()
        {
            List<Expense> expenses = _expense.GetAllEpenses();
            return expenses;
        }
        public void CreateExpense(CreateExpenseDTO expenseDTO)
        {
            _expense.CreateExpense(expenseDTO);
        }
    }

    public interface IExpense
    {
        void CreateExpense(CreateExpenseDTO expenseDTO);
        List<Expense> GetAllEpenses();
        Expense GetExpenseById(int id);
    }
}



