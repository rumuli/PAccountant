using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.ExpenseTypes;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
namespace Infrastructure.Repositories
{
    public class ExpenseTypeRepository : IExpenseType
    {
        private readonly ApplicationDbContext _dbContext;
        public ExpenseTypeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
    
        public List<ExpenseType> GetAllExpenseTypes()
        {
            List<ExpenseType> expenseTypes = _dbContext.ExpenseTypes.ToList();
            return expenseTypes;
        }
        public ExpenseType GetExpenseTypeById(int id)
        {
            return _dbContext.ExpenseTypes.FirstOrDefault(e => e.Id == id);
        }
        public void CreateExpenseType(CreateExpenseTypeDTO expenseTypeDTO)
        {
            ExpenseType expenseType = new ExpenseType
            {
                ExpenseTypeName = expenseTypeDTO.ExpenseTypeName,
                IsActive = true,
                CreatedAt = DateTime.Now    
            };
            _dbContext.ExpenseTypes.Add(expenseType);
            _dbContext.SaveChanges();
        }
    }

   
}   