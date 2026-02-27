namespace Application.DTO
{
    public class PropertyCreateDTO
    {
        public int CategoryId {get;set;}
        public string Name {get;set;}
        public string Value {get;set;}
        public string Location {get;set;}
        public string AssignedTo{get;set;}
        public double PurchasePrice{get;set;}
        public string Identification{get;set;}
        public DateTime PurchaseDate{get;set;}
        public string CreatedBy {get;set;}
        public string CreatedAt {get;set;}
    }
    public class PropertyUpdateDTO
    {
         public string Name {get;set;}
        public string Value {get;set;}
        public string Location {get;set;}
        public string AssignedTo{get;set;}
        public double PurchasePrice{get;set;}
        public string Identification{get;set;}
        public DateTime PurchaseDate{get;set;}
        public string UpdateBy{get;set;}
    }
}