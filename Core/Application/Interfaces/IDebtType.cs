using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces

{
    public interface IDebtType
    {
        Task <List<DebtType>> GetAllDebtTypesAsync();
        Task <DebtType?> GetDebtTypeByIdAsync(int id);
        Task <int> CreateDebtTypeAsync(CreateDebtTypeDTO debtTypeDTO);
    }
    
}