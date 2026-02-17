namespace Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public int CustomerId { get; set; }
        public int UserId{ get; set; }
        public bool IsActive { get; set; }
         public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int? CreatedById { get; set; }
        
        public int? UpdatedById { get; set; }
     
    }
   
}