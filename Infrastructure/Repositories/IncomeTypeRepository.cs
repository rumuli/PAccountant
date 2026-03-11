using Domain.Entities;
using Application.DTO;
using Application.Interfaces;
using Application.Services.IncomeTypes;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class IncomeTypeRepository : IIncomeType
    {
        private readonly ApplicationDbContext _dbContext;

        public IncomeTypeRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<IncomeType>> GetAllIncomeTypesAsync()
        {
            return await _dbContext.IncomeTypes.ToListAsync();
        }

        public async Task<IncomeType?> GetIncomeTypeByIdAsync(int id)
        {
            return await _dbContext.IncomeTypes.FirstOrDefaultAsync(i => i.Id == id);
        }

        // create new income type
        public async Task<int> CreateIncomeTypeAsync(CreateIncomeTypeDTO incomeTypeDTO)
        {
            var incomeType = new IncomeType
            {
                IncomeTypeName = incomeTypeDTO.IncomeTypeName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
                
            };

            _dbContext.IncomeTypes.Add(incomeType);
            await _dbContext.SaveChangesAsync();

            return incomeType.Id;
        }
    }
}
