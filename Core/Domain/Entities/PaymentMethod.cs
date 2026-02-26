namespace Domain.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string PaymentMethodName { get; set; }
        public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        
    }
}