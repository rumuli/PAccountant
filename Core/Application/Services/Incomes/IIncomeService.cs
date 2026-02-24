using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.Incomes;

namespace Application.Services.Incomes
{
    public interface IIncomeService
    {
        Task<List<Income>> GetAllIncomesAsync();
        Task<Income?> GetIncomeByIdAsync(int id);
        Task<int> CreateIncomeAsync(CreateIncomeDTO incomeDTO);

         void UpdateIncome(int id, UpdateIncomeDTO customerDTO);
    }

}