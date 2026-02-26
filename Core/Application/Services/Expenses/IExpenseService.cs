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
    Task<int> CreateExpenseAsync(CreateExpenseDTO expenseDTO); // ✅ corrected
}


}