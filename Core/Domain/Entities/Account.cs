namespace Domain.Entities
{
    public class Account
    {
        public int Id {get;set;}
        public int AccountTypeId {get;set;}
        public string AccountNumber {get;set;}
        public string Provider {get;set;}
        public double Balance {get;set;}
        public AccountType AccountType {get; set;} = new AccountType();
        public string  Status{get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy {get;set;}
        public string UpdateBy{get;set;}

    }
}