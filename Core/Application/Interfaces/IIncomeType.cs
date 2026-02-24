using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IIncomeTypeService
    {
        Task<List<IncomeType>> GetAllIncomeTypesAsync();
        Task<IncomeType?> GetIncomeTypeByIdAsync(int id);
        Task<int> CreateIncomeTypeAsync(CreateIncomeTypeDTO incomeTypeDTO);
    }
}

