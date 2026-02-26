using Domain.Entities;
using Application.DTO.ExpensePlanning;
namespace Application.Services.ExpensePlanningServices{
    public interface IExpensePlanningService{
        Task<List<ExpensePlanning>> GetExpensePlanningsAsync();
        Task AddExpensePlanningAsync(CreateExpensePlanningDTO dto);
    }
}