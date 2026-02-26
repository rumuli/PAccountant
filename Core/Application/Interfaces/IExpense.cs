using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IExpense
    {
        Task <List<Expense>> GetAllExpensesAsync();
        Task <Expense?> GetExpenseByIdAsync(int id);
        Task<int> CreateExpenseAsync(CreateExpenseDTO expenseDTO);
    }
    
    }