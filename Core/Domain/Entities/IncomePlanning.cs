namespace Domain.Entities
{
public class IncomePlanning
{
        public int Id { get; set; }
        public int BudgetId {get;set;}
        public Budget Budget { get; set;} = new Budget();
        public int IncomeTypeId {get;set;}
        public IncomeType IncomeType {get;set;} = new IncomeType();
        public decimal Amount{get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}

        public int UserAdded{get;set;}
}
}