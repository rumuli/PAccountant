using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

namespace Application.Services.DebtTypes
{
    public class DebtTypeService : IDebtTypeService
    {
        private readonly IDebtType _debtType;

        public DebtTypeService(IDebtType debtType)
        {
            _debtType = debtType;
        }

        public async Task<List<DebtType>> GetAllDebtTypesAsync()
        {
            return await _debtType.GetAllDebtTypesAsync();
        }

        public async Task<int> CreateDebtTypeAsync(CreateDebtTypeDTO debtTypeDTO)
        {
            return await _debtType.CreateDebtTypeAsync(debtTypeDTO);
        }

        // ✅ Implement the missing interface method
        public async Task<DebtType?> GetDebtTypeByIdAsync(int id)
        {
            return await _debtType.GetDebtTypeByIdAsync(id);
        }
    }
}
