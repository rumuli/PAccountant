using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.Expenses
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpense _expense;

        public ExpenseService(IExpense expense)
        {
            _expense = expense;
        }

        public async Task <Expense?> GetExpenseByIdAsync(int id)
        {
            return await _expense.GetExpenseByIdAsync(id);
        }

        public async Task<List<Expense>> GetAllExpensesAsync() 
        {
           return await _expense.GetAllExpensesAsync();
        }
        public async Task CreateExpenseAsync(CreateExpenseDTO expenseDTO)
        {
            await _expense.CreateExpenseAsync(expenseDTO);
            
        }
        public async Task<decimal> GetRemainingBudgetAsync(int expenseTypeId, DateTime date)
        {
            return await _expense.GetRemainingBudgetAsync(expenseTypeId, date);
        }

    }

   
}



