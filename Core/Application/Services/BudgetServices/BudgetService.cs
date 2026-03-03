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
   public async Task AddBudgetAsync(CreateBudgetDTO dto)
      {
        await _budget.AddBudgetAsync(dto);
      }
   public async Task<GetBudgetByIdDTO?> GetBudgetByIdAsync(int id)
   {
      return await _budget.GetBudgetByIdAsync(id);
   }
   
   } 
}