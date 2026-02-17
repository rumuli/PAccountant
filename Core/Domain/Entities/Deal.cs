namespace Domain.Entities
{
    public class Deal
    {
        public int Id { get; set; }
        public string DealName { get; set; }
        public decimal CustomerId { get; set; }
        public decimal Value { get; set; }
        public string Stage { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
         public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedById { get; set; }
        
        public int? UpdatedById { get; set; }
        
        
        
    }
}