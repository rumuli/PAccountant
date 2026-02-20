namespace Domain.Entities{

    public class Budget
    {
        public int Id { get; set; }
        public DateTime StartingAt{get;set;}
        public DateTime EndingAt {get;set;}
        public string Name {get;set;}
    }
}