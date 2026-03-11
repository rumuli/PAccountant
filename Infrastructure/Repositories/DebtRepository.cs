using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DebtRepository : IDebt

    {
        private readonly ApplicationDbContext _dbContext;
        public DebtRepository(ApplicationDbContext context) 
        {
            _dbContext = context;
        }

        public async Task<List<Debt>> GetAllDebtsAsync() 
        {
           return await _dbContext.Debts
           .Include(d => d.DebtType)
           .ToListAsync();
        }

        public async Task<Debt?> GetDebtByIdAsync(int id)
        {
            return await _dbContext.Debts
            .Include(d => d.DebtType)
            .FirstOrDefaultAsync(d => d.Id == id);
    
        }
        
        public async Task<int> CreateDebtAsync(CreateDebtDTO debtDTO)
        {
            
            var debt = new Debt
            {
                DebtTypeId = debtDTO.DebtTypeId,
                Amount = debtDTO.Amount,
                Creditor = debtDTO.Creditor,
                DueDate = debtDTO.DueDate ?? DateTime.Today, 
                DateIncurred = debtDTO.DateIncurred ?? DateTime.Today,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Debts.Add(debt);
            await _dbContext.SaveChangesAsync();

            return debt.Id;
        }
    }
}