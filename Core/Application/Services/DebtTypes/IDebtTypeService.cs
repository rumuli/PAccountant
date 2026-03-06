using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.DebtTypes;

namespace Application.Services.DebtTypes
{
    public interface IDebtTypeService
    {
         Task <List<DebtType>> GetAllDebtTypesAsync();
        Task <DebtType?> GetDebtTypeByIdAsync(int id);
        Task <int> CreateDebtTypeAsync(CreateDebtTypeDTO debtTypeDTO);
    }
}