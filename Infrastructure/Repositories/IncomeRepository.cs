using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces;
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

        // Get all incomes with related IncomeType, PaymentMethod, and AccountType
        public async Task<List<Income>> GetAllIncomesAsync()
        {
            return await _dbContext.Incomes
                .Include(i => i.IncomeType)
                .Include(i => i.PaymentMethod)
                .Include(i => i.Account)
                .ToListAsync();
        }

        // Get single income by ID
        public async Task<Income?> GetIncomeByIdAsync(int id)
        {
            return await _dbContext.Incomes
                .Include(i => i.IncomeType)
                .Include(i => i.PaymentMethod)
                .Include(i => i.Account)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        // Create new income and return its ID
        public async Task<int> CreateIncomeAsync(CreateIncomeDTO incomeDTO)
{
    var income = new Income
    {
        IncomeTypeId = incomeDTO.IncomeTypeId,
        Date = incomeDTO.Date,
        AmountPaid = incomeDTO.AmountPaid,
        Source = incomeDTO.Source,
        PaymentMethodId = incomeDTO.PaymentMethodId,
        AccountId = incomeDTO.AccountId,
        
        IsActive = true,
        CreatedAt = DateTime.UtcNow,
        UpdatedAt = DateTime.UtcNow
    };

    _dbContext.Incomes.Add(income);

    // Update Account balance using AccountTypeId
    var account = await _dbContext.Accounts
        .FirstOrDefaultAsync(a => a.Id == incomeDTO.AccountId);

    if (account != null)
    {
        account.Balance += incomeDTO.AmountPaid; 
        _dbContext.Accounts.Update(account);
    }

    await _dbContext.SaveChangesAsync();
    return income.Id;
}


    }
}
