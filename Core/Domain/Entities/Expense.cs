namespace Domain.Entities
{
    public class Expense
    {
        public int Id { get; set; }

        //foreign key for ExpenseType
         public int ExpenseTypeId { get; set; }  

        public ExpenseType ExpenseType { get; set; } = default!;
       public decimal Amount { get; set; }
       public DateTime? Date{ get; set; }= DateTime.Now;
        // Link to Account
        public int AccountId { get; set; }
        public Account Account { get; set; } = default!;
        public string PaidTo { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    
    }
}
