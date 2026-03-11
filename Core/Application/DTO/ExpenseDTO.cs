using System.ComponentModel.DataAnnotations;
namespace Application.DTO
{
    public class CreateExpenseDTO
    {
     [Required(ErrorMessage = "Please select an Expense type")]
      [Range(1, int.MaxValue, ErrorMessage = "Please select an Expense type")]
       public int ExpenseTypeId { get; set; }   // ✅ correct property

            [Required(ErrorMessage = "Please select an Expense type")]
      [Range(1, int.MaxValue, ErrorMessage = "Please select an Expense type")]
       public DateTime? Date { get; set; } = DateTime.Today;  // ✅ correct property



        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
       public decimal Amount { get; set; }

    [Required(ErrorMessage = "Please select an account")]
      [Range(1, int.MaxValue, ErrorMessage = "Please select a valid account")]
         public int AccountId { get; set; }   // link to Account

        [Required(ErrorMessage = "Paid Too is required")]
        [StringLength(100)]
        public string PaidTo { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(100)]
        public string Description { get; set; }
    }
}