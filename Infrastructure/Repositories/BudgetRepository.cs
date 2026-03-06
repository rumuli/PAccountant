using System.Security.Cryptography.X509Certificates;
using Application.DTO.Budget;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
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
            DateTime enddate = dto.EndingAt.GetValueOrDefault();
            bool exist = await _dbcontext.Budgets.AnyAsync(b => b.StartingAt.Month == startdate.Month && b.StartingAt.Year == startdate.Year);  
            if (exist)
            {
                throw new Exception($"Budget for {startdate.ToString("MMMM yyyy")} already exists.");
            }
            if(enddate < startdate.AddMonths(1))
            {
                throw new Exception("Interval between starting and ending date is less than month. The budget period must be at least one month long.");
            }
            var newbudget = new Budget
            {
                Name = $"Budget {startdate.ToString("MMMM yyyy")}",
                StartingAt = startdate,
                PlannedIncome= 0,
                PlannedExpense=0,
                EndingAt = enddate
                // Status = dto.BudgetStatus
            };
            _dbcontext.Budgets.Add(newbudget);
            await _dbcontext.SaveChangesAsync();
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
        public async Task<List<CountStatusBudgetDTO>> CountBudgetByStatusAsync()
        {
            return await _dbcontext.Budgets
            .GroupBy(t=> t.Status)
            .Select(g => new CountStatusBudgetDTO
            {
                Status=g.Key,
                Counts = g.Count()
            })
            .ToListAsync();
        }
        
    }
}