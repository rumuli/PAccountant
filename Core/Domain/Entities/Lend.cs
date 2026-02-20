namespace Domain.Entities
{
public class Lend
{
    public Guid Id { get; private set; }
    public string BorrowerName { get; set; } = string.Empty;
    public decimal Amount { get; private set; }
    public DateTime LendDate { get; private set; }
    public DateTime? DueDate { get; private set; }
     public bool IsActive { get; set; }
      public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }


}
}
   
