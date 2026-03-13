using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.Debts
{
    public class DebtService : IDebtService
    {
        private readonly IDebt _debt;
        public DebtService(IDebt debt)
        {
            _debt = debt;
        }

        public async Task<Debt?> GetDebtByIdAsync(int id)
        {
            return await _debt.GetDebtByIdAsync(id);
        }

        public async Task<List<Debt>> GetAllDebtsAsync()
        {
            return await _debt.GetAllDebtsAsync();
        }

        public async Task<int> CreateDebtAsync(CreateDebtDTO debtDTO)
        {
            return await _debt.CreateDebtAsync(debtDTO);
        }
        public async Task DebtRepayment(int id, DebtRepaymentDTO dto)
        {
            await _debt.DebtRepayment(id, dto);
        }

       
    }
}