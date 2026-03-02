namespace Domain.Entities
{
    public class AccountType
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Status {get;set;}
        public string CreatedBy {get;set;}
<<<<<<< HEAD
        public string CreatedAt {get;set;}
        public string UpdateBy{get;set;}
=======
        public DateTime CreatedAt {get;set;}=DateTime.Now;
        public string UpdateBy{get;set;}
        
>>>>>>> PersonalAccount
    }
}