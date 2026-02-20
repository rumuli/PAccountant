namespace Domain.Entities
{
    public class ExpensePlanning
    {
        public int Id { get; set; }
        public string BudgetName { get; set; }
        public string ExpenseTypeId {get;set;}
        public double Amount{get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public int UserAdded{get;set;}
        public DateTime UpdatedAt{get;set;}

    }
}