using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Debts;

namespace Application.Services.Debts
{
    public interface IDebtService
    {
        Task<List<Debt>> GetAllDebtsAsync();
        Task<Debt?> GetDebtByIdAsync(int id);   
        Task<int> CreateDebtAsync(CreateDebtDTO debtDTO);
        Task DebtRepayment(int id, DebtRepaymentDTO dto);
    }
}