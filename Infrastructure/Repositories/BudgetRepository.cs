using System.Net;
using System.Security.Cryptography.X509Certificates;
using Application.DTO.Budget;
using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
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
                        EndingAt = b.EndingAt,
                        // Fix: Sending the actual database value to the UI
                        PlannedExpense = b.PlannedExpense 
                    })
                    .ToListAsync();
        }
        
        public async Task<GetBudgetDTO> AddBudgetAsync(CreateBudgetDTO dto)
        {
            DateTime startdate = dto.StartingAt.GetValueOrDefault();
            DateTime enddate = dto.EndingAt.GetValueOrDefault();

            // 1. Validation Logic
            bool exist = await _dbcontext.Budgets.AnyAsync(b => 
                b.StartingAt.Month == startdate.Month && 
                b.StartingAt.Year == startdate.Year);  
            
            if (exist)
            {
                throw new Exception($"Budget for {startdate.ToString("MMMM yyyy")} already exists.");
            }

            if(enddate < startdate.AddMonths(1))
            {
                throw new Exception("Interval between starting and ending date is less than month.");
            }

            // 2. Mapping to Entity (This was the error!)
            // Use the actual Domain Entity class here, not the DTO
            var budgetEntity = new Domain.Entities.Budget 
            {
                Name = $"Budget {startdate.ToString("MMMM yyyy")}",
                StartingAt = startdate,
                EndingAt = enddate,
                Status = BudgetStatus.Planned
                // Add PlannedIncome/Expense here if they exist on your Entity
            };

            // 3. Persistence
            _dbcontext.Budgets.Add(budgetEntity); // Now adding the Entity
            await _dbcontext.SaveChangesAsync();

            // 4. Return the DTO (Mapping back so the UI gets the new ID)
            return new GetBudgetDTO
            {
                Id = budgetEntity.Id,
                Name = budgetEntity.Name,
                StartingAt = budgetEntity.StartingAt,
                EndingAt = budgetEntity.EndingAt,
                Status = budgetEntity.Status
            };
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
                    EndingAt = x.EndingAt,
                    // Fix: Map the expense for the detail view
                    PlannedExpense = x.PlannedExpense
                })
                .FirstOrDefaultAsync();
        }

        public async Task<List<CountStatusBudgetDTO>> CountBudgetByStatusAsync()
        {
            return await _dbcontext.Budgets
                .GroupBy(b=>b.Status)
                .Select(g => new CountStatusBudgetDTO
                {
                    Status =g.Key,
                    Counts= g.Count()
                })
                .ToListAsync();
        }
    }
}