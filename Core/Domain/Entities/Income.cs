namespace Domain.Entities
{
    public class Income
    {
        public int Id { get; set; }
        public string IncomeTypeId  { get; set; }
        public DateTime Date { get; set; }
        public decimal AmountPaid { get; set; }
        public string Source { get; set; }
        public string PaymentMethodId { get; set; }
        public string DepositedAccount { get; set; }
        public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }

        
    }

   
    }

