using Application.DTO.Budget;
namespace Application.Services.BudgetServices{
    public interface IBudgetService{
        Task <List<GetBudgetDTO>> GetBudgetsAsync();
        Task AddBudgetAsync(CreateBudgetDTO dto);
        Task<GetBudgetByIdDTO?> GetBudgetByIdAsync(int id);
        Task<List<CountStatusBudgetDTO>>CountBudgetByStatusAsync();
    }
}