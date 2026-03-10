using Application.DTO.Budget;
using Domain.Entities;
namespace Application.Interfaces{
    public interface IBudget{
        Task <List<GetBudgetDTO>> GetBudgetsAsync();
        Task AddBudgetAsync(CreateBudgetDTO dto);
        Task<GetBudgetByIdDTO?> GetBudgetByIdAsync(int id);
    }
}