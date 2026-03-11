using Application.DTO.IncomePlanning;
using Domain.Entities;
namespace Application.Interfaces{
    public interface IIncomePlanning{
        Task<List<IncomePlanning>> GetIncomePlanningsAsync();
        Task AddIncomePlanning(CreateIncomePlanningDTO dto);
        Task <List<IncomePlanning>> GetSummaryIncomePlanningAsync(int BudgetId);
    }
}