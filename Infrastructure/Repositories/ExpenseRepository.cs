using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Expenses;
using Infrastructure.DependencyInjection;
using Infrastructure.Data;


namespace Infrastructure.Repositories
{
    public class ExpenseRepository : IExpense
    {
        private readonly ApplicationDbContext _dbContext;
        public ExpenseRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Expense> GetAllExpenses()
        {
            List<Expense> _expenses = _dbContext.Expenses.ToList();
            return _expenses;
        }
        public Expense GetExpenseById(int id)
        {
            return _dbContext.Expenses.FirstOrDefault(e => e.Id == id);

        }
        public void CreateExpense(CreateExpenseDTO expenseDTO)
        {
            Expense expense = new()
            {
              ExpenseType= _dbContext.ExpenseTypes.Find(expenseDTO.ExpenseTypeId),
              Amount = expenseDTO.Amount,
              Account = expenseDTO.Account,
              PaidTo = expenseDTO.PaidTo,
              Description = expenseDTO.Description,
               IsActive = true,
                CreatedAt = DateTime.Now
                
            };
            _dbContext.Expenses.Add(expense);
            _dbContext.SaveChanges();
        }

        public List<Expense> GetAllEpenses()
        {
            throw new NotImplementedException();
        }
    }
}