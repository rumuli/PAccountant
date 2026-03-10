using Application.DTO.ExpensePlanning;
using Domain.Entities;
namespace Application.Interfaces{
    public interface IExpensePlanning{
        Task <List<ExpensePlanning>> GetExpensePlanningsAsync();
        Task AddExpensePlanningAsync(CreateExpensePlanningDTO dto);
        Task <List<ExpensePlanning>> GetSummaryExpensePlanningAsync(int BudgetId);

    }
}