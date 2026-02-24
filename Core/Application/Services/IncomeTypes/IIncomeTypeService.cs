using Domain.Entities;
using Application.DTO;

namespace Application.Services.IncomeTypes
{
    public interface IIncomeTypeService
    {
        Task<List<IncomeType>> GetAllIncomeTypesAsync();
        Task<IncomeType?> GetIncomeTypeByIdAsync(int id);
        Task CreateIncomeTypeAsync(CreateIncomeTypeDTO incomeTypeDTO);
    }
}

