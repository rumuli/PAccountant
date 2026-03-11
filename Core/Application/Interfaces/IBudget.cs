using Application.DTO.Budget;
using Domain.Entities;
namespace Application.Interfaces{
    public interface IBudget{
        Task <List<GetBudgetDTO>> GetBudgetsAsync();
        Task <GetBudgetDTO> AddBudgetAsync(CreateBudgetDTO dto);
        Task<GetBudgetByIdDTO?> GetBudgetByIdAsync(int id);
    }
}