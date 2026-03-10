using Application.DTO.Budget;
using Domain.Entities;
namespace Application.Services.BudgetServices{
    public interface IBudgetService{
        Task <List<GetBudgetDTO>> GetBudgetsAsync();
        Task <GetBudgetDTO>AddBudgetAsync(CreateBudgetDTO dto);
        Task<GetBudgetByIdDTO?> GetBudgetByIdAsync(int id);
    }
}