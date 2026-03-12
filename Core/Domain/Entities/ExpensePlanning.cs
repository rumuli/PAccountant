using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;

namespace Domain.Entities
{
public class ExpensePlanning
{
        public int Id { get; set; }
        public int BudgetId{get;set;}
        public Budget Budget { get; set; } = new Budget();
        public int ExpenseTypeId {get;set;}
        public ExpenseType ExpenseType {get;set;}=new ExpenseType();
        public decimal Amount{get;set;}
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
        
        public int UserAdded{get;set;}
}
}