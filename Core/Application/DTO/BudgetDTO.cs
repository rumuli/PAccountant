using Domain.ValueObjects;

namespace Application.DTO.Budget{
    public class GetBudgetDTO
    {
        public int Id { get; set; }
        public DateTime StartingAt{get;set;}
        public DateTime EndingAt {get;set;}
        public string Name {get;set;}
        public BudgetStatus Status{get;set;}
        public decimal PlannedExpense { get; set; }

    }
    public class CreateBudgetDTO{
        public decimal PlannedExpense;

        public DateTime? StartingAt{get;set;}
        public DateTime? EndingAt{get;set;}
        // public string Name {get;set;}
    }
    public class UpdateBudgetDTO{
        public DateTime StartingAt{get;set;}
        public DateTime EndingAt{get;set;}
        // public string Name {get;set;}
    }
    public class DeleteBudgetDTO{
        public int Id {get;set;}
    }
    public class GetBudgetByIdDTO
    {
        public int Id { get; set; }
        public DateTime? StartingAt{get;set;}
        public DateTime? EndingAt {get;set;}
        public string Name {get;set;}
        public decimal PlannedExpense { get; set; }
    }
    public class CountStatusBudgetDTO
    {
        public BudgetStatus Status {get;set;}
        public int Counts {get;set;}

    }
}