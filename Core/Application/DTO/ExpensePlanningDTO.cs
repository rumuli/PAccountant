namespace Application.DTO.ExpensePlanning{
    public class CreateExpensePlanningDTO{

        public int BudgetId {get;set;}
        public int ExpenseTypeId {get;set;}
        public double Amount{get;set;}
        public string Description {get;set;}
        // public DateTime CreatedAt {get;set;}
        // public int UserAdded{get;set;}
        // public DateTime UpdatedAt{get;set;}

    }
}