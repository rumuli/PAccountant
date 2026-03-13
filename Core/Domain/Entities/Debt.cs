using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Debt
    {
        public int Id { get; set; }

        // ✅ Foreign key for DebtType
        public int DebtTypeId { get; set; }
        public DebtType DebtType { get; set; } = default!;

        public decimal PrincipalAmount { get; set; }
        public decimal InterestRate { get; set; } 
        public decimal TotalAmount {get;set;}
        public decimal AmountPaid { get; set; }
        public decimal RemainingAmount { get; set; }
        public DebtStatus Status { get; set; }
        public string Creditor { get; set; }

        public DateTime DueDate { get; set; }
        public DateTime DateIncurred { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
