namespace Application.DTO
{
    public class AccountCreateDTO
    {
        public int AccountTypeId {get;set;}
        public string AccountNumber {get;set;}
        public string Provider {get;set;}
        public double Balance {get;set;}
        public string  Status{get;set;}
        public string CreatedBy {get;set;}
        public DateTime CreatedAt { get; set; } 
        
    }
    public class AccountUpdateDTO
    {
        public string AccountNumber {get;set;}
        public string Provider {get;set;}
        public double Balance {get;set;}
        public string  Status{get;set;}
         public string UpdateBy{get;set;}
    }
}