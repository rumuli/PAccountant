using Domain.ValueObjects;
namespace Domain.Entities
{
    public class Property
    {
        public int Id {get;set;}
        public PropertyCategory PropertyCategory {get; set;} = new PropertyCategory();
        public Person Person {get;set;} = new Person();
        public string Name {get;set;}
        public string Value {get;set;}
        public string Location {get;set;}
        public string AssignedTo{get;set;}
        public double PurchasePrice{get;set;}
        public string Identification{get;set;}
        public DateTime PurchaseDate{get;set;}
        public string CreatedBy {get;set;}
        public PropertyStatus Status {get;set;}
        public DateTime CreatedAt {get;set;}=DateTime.Now;
        public string UpdateBy{get;set;}

    }
}