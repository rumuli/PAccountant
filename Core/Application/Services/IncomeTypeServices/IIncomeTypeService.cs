using Domain.Entities;
using Application.DTO;
using Application.Services.IncomeTypes;


namespace Application.Services.IncomeTypes
{
    public interface IIncomeTypeService
    {
        Task<List<IncomeType>> GetAllIncomeTypesAsync();
        Task<IncomeType?> GetIncomeTypeByIdAsync(int id);
        Task<int> CreateIncomeTypeAsync(CreateIncomeTypeDTO incomeTypeDTO);
    }
}
