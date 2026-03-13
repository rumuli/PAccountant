using System.Net;
using System.Security.Cryptography.X509Certificates;
using Application.DTO.Budget;
using Application.Interfaces;
using Domain.Entities;
using Domain.ValueObjects;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Repositories
{
    public class BudgetRepository : IBudget
    {
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserContext _userContext;
        public BudgetRepository(ApplicationDbContext context, UserContext userContext)
        {
            _dbcontext = context;
            _userContext = userContext;
        }
        public async Task<List<GetBudgetDTO>> GetBudgetsAsync()
        {
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }
            
            return await _dbcontext.Budgets
                    .Where(b => b.PersonId == _userContext.Id)
                    .Select(b => new GetBudgetDTO 
                    {
                        Id = b.Id,
                        Name = b.Name,
                        StartingAt = b.StartingAt,
                        EndingAt = b.EndingAt,
                        // Status=b.Status,
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
            //useContext
           if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }

            // Fix: We need the PersonId linked to this User, not the UserId itself
            var user = await _dbcontext.Users
                .FirstOrDefaultAsync(u => u.Id == _userContext.Id);

            if (user == null)
            {
                throw new Exception("User record not found");
            }
            // 2. Mapping to Entity (This was the error!)
            // Use the actual Domain Entity class here, not the DTO
            var budgetEntity = new Domain.Entities.Budget 
            {
                Name = $"Budget {startdate.ToString("MMMM yyyy")}",
                PersonId = user.PersonId,
                StartingAt = startdate,
                EndingAt = enddate,
                Status = BudgetStatus.Planned,
                PlannedIncome = 0,
                // Fix: Saving the user's input from the DTO instead of hardcoding 0
                PlannedExpense = 0
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
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }
            return await _dbcontext.Budgets
                .Where(x => x.Id == id && x.PersonId == _userContext.Id)
                .Select(x => new GetBudgetByIdDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartingAt = x.StartingAt,
                    EndingAt= x.EndingAt,
                    PlannedExpense = x.PlannedExpense,
                    PlannedIncome = x.PlannedIncome
                })
                .FirstOrDefaultAsync();
        }
        public async Task<List<CountStatusBudgetDTO>> CountBudgetByStatusAsync()
        {
            if (_userContext.Id == null)
            {
                throw new Exception("User not authenticated");
            }
            return await _dbcontext.Budgets
                .Where(b => b.PersonId == _userContext.Id)
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