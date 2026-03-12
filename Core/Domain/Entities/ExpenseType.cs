namespace Domain.Entities
{
    public class ExpenseType
    {
        public int Id { get; set; }
        public string ExpenseTypeName { get; set; }

        // ✅ This Navigation Property must exist for the Repository query to work
    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}