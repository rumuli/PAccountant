namespace Domain.Entities
{
    public class ExpensePlanning
    {
        public int Id { get; set; }
        public int BudgetId{get;set;}
        public Budget Budget { get; set; } = new Budget();
        public int ExpenseTypeId {get;set;}
        public ExpenseType ExpenseType {get;set;}=new ExpenseType();
        public double Amount{get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public int UserAdded{get;set;}
        public DateTime UpdatedAt{get;set;}

    }
}