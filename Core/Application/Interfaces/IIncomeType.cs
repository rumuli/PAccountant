using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IIncomeType
    {
        Task<List<IncomeType>> GetAllIncomeTypesAsync();
        Task<IncomeType?> GetIncomeTypeByIdAsync(int id);
        Task CreateIncomeTypeAsync(CreateIncomeTypeDTO incomeTypeDTO);
    }
}

