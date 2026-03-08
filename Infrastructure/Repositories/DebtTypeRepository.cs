using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.DebtTypes;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore; 

namespace Infrastructure.Repositories
{
    public class DebtTypeRepository : IDebtType
    {
        private readonly ApplicationDbContext _dbContext;

        public DebtTypeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public async Task<List<DebtType>> GetAllDebtTypesAsync() 
        {
            return await _dbContext.DebtTypes.ToListAsync();
        }

        public async Task<DebtType?> GetDebtTypeByIdAsync(int id) 
        {
            return await _dbContext.DebtTypes.FirstOrDefaultAsync(d => d.Id == id);
        }
        public async Task<int> CreateDebtTypeAsync(CreateDebtTypeDTO debtTypeDTO) 
        {
            var debtType = new DebtType
            {
                DebtTypeName = debtTypeDTO.DebtTypeName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _dbContext.DebtTypes.Add(debtType);
            await _dbContext.SaveChangesAsync();

            return debtType.Id; // return the generated primary key
        }
    }
}