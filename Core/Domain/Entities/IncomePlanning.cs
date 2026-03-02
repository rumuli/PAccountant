namespace Domain.Entities
{
    public class IncomePlanning
    {
<<<<<<< HEAD
        public int Id { get; set; }
        public int BudgetId {get;set;}
        public Budget Budget { get; set;} = new Budget();
        public int IncomeTypeId {get;set;}
        public IncomeType IncomeType {get;set;} = new IncomeType();
=======
        public int Id {get;set; }
        public string BudgetName { get; set;}
        public string IncomeTypeId {get;set;}
>>>>>>> PersonalAccount
        public double Amount{get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public int UserAdded{get;set;}
        public DateTime UpdatedAt{get;set;}
    }
}