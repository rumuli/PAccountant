using Application.DTO.Budget;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
namespace Application.Services.BudgetServices{

   public class BudgetService : IBudgetService{
   
   private readonly IBudget _budget;
   public BudgetService (IBudget budget)
      {
         _budget = budget;
      }
   public async Task< List<GetBudgetDTO>> GetBudgetsAsync()
      {
         return await _budget.GetBudgetsAsync();
      }
   public async Task <GetBudgetDTO> AddBudgetAsync(CreateBudgetDTO dto)
      {
         var newBudget = await _budget.AddBudgetAsync(dto);

            // 2. Map the data to a DTO that actually HAS an Id (GetBudgetDTO)
            return new GetBudgetDTO
            {
               Id = newBudget.Id, // Works! newBudget is the Entity from the DB
               StartingAt = newBudget.StartingAt,
               EndingAt = newBudget.EndingAt,
               Name = newBudget.Name,
               Status = newBudget.Status
            };
      }
   public async Task<GetBudgetByIdDTO?> GetBudgetByIdAsync(int id)
   {
      return await _budget.GetBudgetByIdAsync(id);
   }
   
   } 
}