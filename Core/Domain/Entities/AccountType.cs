namespace Domain.Entities
{
    public class AccountType
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Status {get;set;}
        public string CreatedBy {get;set;}
        public DateTime CreatedAt {get;set;}=DateTime.Now;
        public string UpdateBy{get;set;}
        
    }
}