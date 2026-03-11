namespace Application.DTO.ExpensePlanning{
    public class CreateExpensePlanningDTO{

        public int BudgetId {get;set;}
        public int ExpenseTypeId {get;set;}
        public decimal Amount{get;set;}
        public string Description {get;set;}

    }
}