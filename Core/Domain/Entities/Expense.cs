namespace Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }
        public string ExpenseTypeId { get; set; }
       public decimal Amount { get; set; }
        public string Account { get; set; }
        public string PaidTo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    
    }
}
