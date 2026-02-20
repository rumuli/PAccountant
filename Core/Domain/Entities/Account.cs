namespace Domain.Entities
{
    public class Account
    {
        public int Id {get;set;}
        public string AccountTypeId {get;set;}
        public string AccountNumber {get;set;}
        public string Provider {get;set;}
        public string CreatedBy {get;set;}
        public string CreatedAt {get;set;}
        public string UpdateBy{get;set;}

    }
}