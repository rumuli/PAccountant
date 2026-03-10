using Domain.ValueObjects;

namespace Domain.Entities{

    public class Budget
    {
        public int Id { get; set; }
        public DateTime StartingAt{get;set;}
        public DateTime EndingAt {get;set;}
        public string Name {get;set;}
        // Status is converted to string in database using Fluent API in ApplicationDbContext (on model creating)
        public BudgetStatus Status{get;set;}
        public decimal PlannedIncome {get;set;}
        public decimal PlannedExpense {get;set;} 
    }
}