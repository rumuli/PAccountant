namespace Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }

        // Foreign key for IncomeType
        public int IncomeTypeId { get; set; }
        public IncomeType IncomeType { get; set; } = default!;

        public DateTime Date { get; set; }
        public decimal AmountPaid { get; set; }
        public string Source { get; set; } = string.Empty;

        // Foreign key for PaymentMethod
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; } = default!;

        // Link to Account
        public int AccountId { get; set; }
        public Account Account { get; set; } = default!;

        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}

