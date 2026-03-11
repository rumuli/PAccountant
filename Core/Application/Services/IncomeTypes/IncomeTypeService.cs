using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.IncomeTypes
{
    public class IncomeTypeService : IIncomeTypeService
    {
        private readonly IIncomeType _incomeType;

        public IncomeTypeService(IIncomeType incomeType)
        {
            _incomeType = incomeType;
        }

        public async Task<IncomeType?> GetIncomeTypeByIdAsync(int id)
        {
            return await _incomeType.GetIncomeTypeByIdAsync(id);
        }

        public async Task<List<IncomeType>> GetAllIncomeTypesAsync()
        {
            return await _incomeType.GetAllIncomeTypesAsync();
        }

        public async Task<int> CreateIncomeTypeAsync(CreateIncomeTypeDTO incomeTypeDTO)
        {
            return await _incomeType.CreateIncomeTypeAsync(incomeTypeDTO);
        }
    }

   
}

