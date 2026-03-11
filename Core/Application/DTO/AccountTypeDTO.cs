namespace Application.DTO
{
    public class AccountTypeCreateDTO
    {
        public string Name {get;set;}
        public string Status {get;set;}
        public string CreatedBy {get;set;}
        public DateTime CreatedAt {get;set;}
    }
    public class AccountTypeUpdateDTO
    {
        public string Name {get;set;}
        public string Status {get;set;}
        public DateTime CreatedAt {get;set;}
        public string UpdateBy{get;set;}
    }
}