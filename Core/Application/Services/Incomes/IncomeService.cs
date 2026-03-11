using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.Incomes
{
    public class IncomeService : IIncomeService
    {
        private readonly IIncome _income;

        public IncomeService(IIncome income)
        {
            _income = income;
        }


        public async Task<Income?> GetIncomeByIdAsync(int id)
        {
            return await _income.GetIncomeByIdAsync(id);
        }

        public async Task<List<Income>> GetAllIncomesAsync()
        {
            return await _income.GetAllIncomesAsync();
        }

        public async Task<int> CreateIncomeAsync(CreateIncomeDTO incomeDTO)
        {
            // Let repository handle creation and return the new ID
            return await _income.CreateIncomeAsync(incomeDTO);
        }

       
    }

    
}
