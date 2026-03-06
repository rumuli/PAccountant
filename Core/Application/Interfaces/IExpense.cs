using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IExpense
    {
        Task <List<Expense>> GetAllExpensesAsync();
        Task <Expense?> GetExpenseByIdAsync(int id);
        Task CreateExpenseAsync(CreateExpenseDTO expenseDTO);
        Task<decimal> GetRemainingBudgetAsync(int expenseTypeId, DateTime date);
    }
    
    }