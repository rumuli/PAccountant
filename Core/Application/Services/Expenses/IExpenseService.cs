using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Expenses;

namespace Application.Services.Expenses
{
   public interface IExpenseService
{
    Task<Expense?> GetExpenseByIdAsync(int id);
    Task<List<Expense>> GetAllExpensesAsync();
    Task CreateExpenseAsync(CreateExpenseDTO expenseDTO); // ✅ corrected
    Task<decimal> GetRemainingBudgetAsync(int expenseTypeId, DateTime date);
}


}