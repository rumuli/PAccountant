namespace Application.DTO.IncomePlanning{
    public class CreateIncomePlanningDTO{

        public int BudgetId {get;set;}
        public int IncomeTypeId {get;set;}
        public decimal Amount{get;set;}
        public string Description {get;set;}

    }
    public class SummaryIncomePlanningDTO{
        public int BudgetId {get;set;}
        public int IncomeTypeId {get;set;}
        public decimal Amount{get;set;}
    }
}