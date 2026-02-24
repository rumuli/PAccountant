using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Expenses;

namespace Application.Services.Expenses
{
    public interface IExpenseService
    {
        public List<Expense> GetAllExpenses();
        public Expense GetExpenseById(int id);
        void CreateExpense(CreateExpenseDTO expenseDTO);
    }
}