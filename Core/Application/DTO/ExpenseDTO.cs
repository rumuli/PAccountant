namespace Application.DTO
{
    public class CreateExpenseDTO
    {
        
       public int ExpenseTypeId { get; set; }
       public decimal Amount { get; set; }
        public string Account { get; set; }
        public string PaidTo { get; set; }
        public string Description { get; set; }
    }
}