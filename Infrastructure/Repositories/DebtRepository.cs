using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;

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
            // Use AsNoTracking for performance on read-only lists
            return await _dbContext.Debts
                .Include(d => d.DebtType)
                .AsNoTracking() 
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
            // Calculate interest once to ensure precision
            decimal interestFactor = debtDTO.InterestRate / 100;
            decimal totalAmount = debtDTO.PrincipalAmount + (debtDTO.PrincipalAmount * interestFactor);

            var debt = new Debt
            {
                DebtTypeId = debtDTO.DebtTypeId,
                PrincipalAmount = debtDTO.PrincipalAmount,
                InterestRate = debtDTO.InterestRate,
                TotalAmount = totalAmount,
                AmountPaid = 0,
                RemainingAmount = totalAmount,
                Status = DebtStatus.Running,
                Creditor = debtDTO.Creditor,
                DueDate = debtDTO.DueDate ?? DateTime.UtcNow.AddMonths(1),
                DateIncurred = debtDTO.DateIncurred ?? DateTime.UtcNow,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.Debts.Add(debt);
            await _dbContext.SaveChangesAsync();

            return debt.Id;
        }

        /// <summary>
        /// Handles debt repayment and returns the updated Debt object 
        /// so the UI cards can update the RemainingAmount instantly.
        /// </summary>
        public async Task DebtRepayment(int id, DebtRepaymentDTO dto)
        {
            var debt = await _dbContext.Debts
                .Include(d => d.DebtType)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (debt == null) 
                throw new KeyNotFoundException($"Debt with ID {id} was not found.");

            // 1. Prevent overpayment (Logic Guard)
            if (dto.AmountPaid > debt.RemainingAmount)
            {
                throw new InvalidOperationException(
                    $"Payment of {dto.AmountPaid} exceeds the remaining balance of {debt.RemainingAmount}.");
            }

            // 2. Update totals
            debt.AmountPaid += dto.AmountPaid;
            debt.RemainingAmount = debt.TotalAmount - debt.AmountPaid;

            // 3. Status Management
            if (debt.RemainingAmount <= 0)
            {
                debt.Status = DebtStatus.Paid;
                debt.IsActive = false;
            }

            _dbContext.Debts.Update(debt);
            await _dbContext.SaveChangesAsync();
        }
    }
}

// using Domain.Entities;
// using Application.DTO;
// using Application.Interfaces;
// using Infrastructure.Data;
// using Microsoft.EntityFrameworkCore;
// using Infrastructure.Identity;
// using Domain.ValueObjects;

// namespace Infrastructure.Repositories
// {
//     public class DebtRepository : IDebt

//     {
//         private readonly ApplicationDbContext _dbContext;
//         public DebtRepository(ApplicationDbContext context) 
//         {
//             _dbContext = context;
//         }

//         public async Task<List<Debt>> GetAllDebtsAsync() 
//         {
//            return await _dbContext.Debts
//            .Include(d => d.DebtType)
//            .ToListAsync();
//         }

//         public async Task<Debt?> GetDebtByIdAsync(int id)
//         {
//             return await _dbContext.Debts
//             .Include(d => d.DebtType)
//             .FirstOrDefaultAsync(d => d.Id == id);
    
//         }
        
//         public async Task<int> CreateDebtAsync(CreateDebtDTO debtDTO)
//         {
            
//             var debt = new Debt
//             {
//                 DebtTypeId = debtDTO.DebtTypeId,
//                 PrincipalAmount = debtDTO.PrincipalAmount,
//                 InterestRate = debtDTO.InterestRate,
//                 TotalAmount = debtDTO.PrincipalAmount * (debtDTO.InterestRate / 100)+ debtDTO.PrincipalAmount, // Simple interest calculation
//                 AmountPaid = 0,
//                 RemainingAmount = debtDTO.PrincipalAmount * (debtDTO.InterestRate / 100)+ debtDTO.PrincipalAmount, // Simple interest calculation,
//                 Status = DebtStatus.Running,
//                 Creditor = debtDTO.Creditor,
//                 DueDate = debtDTO.DueDate ?? DateTime.Today, 
//                 DateIncurred = debtDTO.DateIncurred ?? DateTime.Today,
//                 IsActive = true,
//                 CreatedAt = DateTime.UtcNow
//             };

//             _dbContext.Debts.Add(debt);
//             await _dbContext.SaveChangesAsync();

//             return debt.Id;
//         }
//         // public async Task DebtRepayment(int id, DebtRepaymentDTO dto)
//         // {

//         //     var debt = await _dbContext.Debts.FindAsync(id);
            
//         //     if (debt == null) throw new Exception("Debt not found");
            
//         //     debt.AmountPaid += dto.AmountPaid;
//         //     debt.RemainingAmount = debt.TotalAmount - debt.AmountPaid;

//         //     _dbContext.Debts.Update(debt);
//         //     await _dbContext.SaveChangesAsync();
//         // }
//         public async Task DebtRepayment(int id, DebtRepaymentDTO dto)
// {
//     var debt = await _dbContext.Debts.FindAsync(id);
    
//     if (debt == null) throw new Exception("Debt not found");

//     // 1. Prevent overpayment
//     if (dto.AmountPaid > debt.RemainingAmount)
//     {
//         throw new InvalidOperationException($"Payment exceeds remaining balance. Remaining: {debt.RemainingAmount}");
//     }

//     // 2. Update totals
//     debt.AmountPaid += dto.AmountPaid;
//     debt.RemainingAmount = debt.TotalAmount - debt.AmountPaid;

//     // 3. Automatically update status to Paid if balance is zero
//     if (debt.RemainingAmount <= 0)
//     {
//         debt.Status = DebtStatus.Paid;
//         debt.IsActive = false;
//     }

//     _dbContext.Debts.Update(debt);
//     await _dbContext.SaveChangesAsync();
// }
//     }
// }