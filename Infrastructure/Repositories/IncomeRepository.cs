using Domain.Entities;
using Application.DTO;
using Application.Services.Incomes;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IncomeRepository : IIncome
    {
        private readonly ApplicationDbContext _dbContext;

        public IncomeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        // Get all incomes with related IncomeType and PaymentMethod
        public async Task<List<Income>> GetAllIncomesAsync()
        {
            return await _dbContext.Incomes
                .Include(i => i.IncomeType)
                .Include(i => i.PaymentMethod)
                .ToListAsync();
        }

        // Get single income by ID
        public async Task<Income?> GetIncomeByIdAsync(int id)
        {
            return await _dbContext.Incomes
                .Include(i => i.IncomeType)
                .Include(i => i.PaymentMethod)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        // Create new income and return its ID
        public async Task<int> CreateIncomeAsync(CreateIncomeDTO incomeDTO)
        {
            var income = new Income
            {
                IncomeTypeId = incomeDTO.IncomeTypeId,
        // If Date is nullable in DTO, use Value or fallback to Now
        Date = incomeDTO.Date ?? DateTime.Today, 
       AmountPaid = incomeDTO.AmountPaid ,
        Source = incomeDTO.Source,
        PaymentMethodId = incomeDTO.PaymentMethodId,
        DepositedAccount = incomeDTO.DepositedAccount,
        IsActive = true,
        // Keep CreatedAt as UtcNow for database tracking
        CreatedAt = DateTime.UtcNow
            };

            _dbContext.Incomes.Add(income);
            await _dbContext.SaveChangesAsync();

            return income.Id; // return new primary key
        }

        public void UpdateIncome(int id, UpdateIncomeDTO incomeDTO)
        {
            var income = _dbContext.Incomes.Find(id);
            if (income != null) return;
            {
                // Update fields as needed
                income.IncomeTypeId = incomeDTO.IncomeTypeId;
                income.AmountPaid = incomeDTO.AmountPaid;
                income.Source = incomeDTO.Source;
                income.PaymentMethodId = incomeDTO.PaymentMethodId;
                income.DepositedAccount = incomeDTO.DepositedAccount;
                _dbContext.SaveChanges();
            }
        }
    }
}

