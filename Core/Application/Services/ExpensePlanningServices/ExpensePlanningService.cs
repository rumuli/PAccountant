using Application.DTO.ExpensePlanning;
using Domain.Entities;
using Application.Services.ExpensePlanningServices;
using Application.Interfaces;

namespace Application.Services.ExpensePlanningServices{
    public class ExpensePlanningService : IExpensePlanningService{
        private readonly IExpensePlanning _expensePlanning;
        public ExpensePlanningService(IExpensePlanning expensePlanning){
            _expensePlanning = expensePlanning;
        }
        public async Task<List<ExpensePlanning>> GetExpensePlanningsAsync(){
            return await _expensePlanning.GetExpensePlanningsAsync();
            
        }
        public async Task AddExpensePlanningAsync(CreateExpensePlanningDTO dto){
            await _expensePlanning.AddExpensePlanningAsync(dto);
        }
        public async Task <List<ExpensePlanning>> GetSummaryExpensePlanningAsync(int BudgetId)
        {
            return await _expensePlanning.GetSummaryExpensePlanningAsync(BudgetId);
        }
    }
}