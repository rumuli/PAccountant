namespace Domain.Entities
{
    public class Debt
    {
        public int Id { get; set; }
        public string DebtType { get; set; }
        public decimal Amount { get; set; }
        public string Creditor { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateIncurred { get; set; }
        public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}