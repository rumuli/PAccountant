using System.Security.Cryptography.X509Certificates;
using Application.DTO.Budget;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repository
{
    public class BudgetRepository : IBudget
    {
        private readonly ApplicationDbContext _dbcontext;
        public BudgetRepository(ApplicationDbContext context)
        {
            _dbcontext = context;
        }
        public async Task<List<GetBudgetDTO>> GetBudgetsAsync()
        {
            return await _dbcontext.Budgets
                    .Select(b => new GetBudgetDTO 
                    {
                        Id = b.Id,
                        Name = b.Name,
                        StartingAt = b.StartingAt,
                        EndingAt = b.EndingAt
                    })
                    .ToListAsync();
        }
        public async Task  AddBudgetAsync(CreateBudgetDTO dto)
        {
            DateTime startdate = dto.StartingAt.GetValueOrDefault();
            Budget newbudget = new()
            {
                Name = $"Budget {startdate.ToString("MMMM yyyy")}",
                StartingAt = startdate,
                EndingAt = dto.EndingAt.GetValueOrDefault()
            };
            _dbcontext.Budgets.Add(newbudget);
            _dbcontext.SaveChangesAsync();
        }
        public async Task<GetBudgetByIdDTO?> GetBudgetByIdAsync(int id)
        {
            return await _dbcontext.Budgets
                .Where(x => x.Id == id)
                .Select(x => new GetBudgetByIdDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartingAt = x.StartingAt,
                    EndingAt= x.EndingAt
                })
                .FirstOrDefaultAsync();
        }

        
    }
}