namespace Application.DTO
{
    public class PropertyCategoryCreateDTO
    {
        public string Name{get;set;}
        public string Status {get;set;}
        public string CreatedBy {get;set;}
        public string CreatedAt {get;set;}
    }
    public class PropertyCategoryUpdateDTO
    {
       public string Name{get;set;}
       public string Status {get;set;}
       public string UpdateBy{get;set;}
    }
}