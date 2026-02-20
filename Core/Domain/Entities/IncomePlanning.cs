namespace Application.Domain.Entities
{
    public class IncomePlanning
    {
        public string BudgetName { get; set;}
        public string IncomeTypeId {get;set;}
        public double Amount{get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public int UserAdded{get;set;}
        public DateTime UpdatedAt{get;set;}
    }
}