using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IDebt
    {
        Task<List<Debt>> GetAllDebtsAsync();
        Task<Debt?> GetDebtByIdAsync(int id);   
        Task<int> CreateDebtAsync(CreateDebtDTO debtDTO);
        Task DebtRepayment(int id, DebtRepaymentDTO dto);
    }
}
