using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IIncome
    {
        Task<List<Income>> GetAllIncomesAsync();
        Task<Income?> GetIncomeByIdAsync(int id);
        Task<int> CreateIncomeAsync(CreateIncomeDTO incomeDTO);

    }
}
