using Domain.ValueObjects;
namespace Domain.Entities
{
    public class Account
    {
        public int Id {get;set;}
        public int AccountTypeId {get;set;}
        public Person Person {get;set;}
        public int PersonId {get;set;}
        public string AccountNumber {get;set;}
        public string Provider {get;set;}
        public decimal InitialBalance {get;set;}
        public decimal Balance {get;set;}
        public AccountType AccountType {get; set;} = new AccountType();
        public AccountStatus Status {get;set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string CreatedBy {get;set;}
        public string UpdateBy{get;set;}
       

    }
}