using System.ComponentModel.DataAnnotations;
namespace Application.DTO

{
    public class CreateDebtDTO
    {
        
       [Required(ErrorMessage = "Please select an Debt type")]
      [Range(1, int.MaxValue, ErrorMessage = "Please select an Expense type")]
       public int DebtTypeId { get; set; }   // ✅ correct property

         [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

         [Required(ErrorMessage = "Creditor is required")]
        [StringLength(100)]
        public string Creditor { get; set; }

       [Required(ErrorMessage = "Date is required")]
        public DateTime? DueDate { get; set; } = DateTime.Today; // Defaults to Today's date

        [Required(ErrorMessage = "Date is required")]
        public DateTime? DateIncurred { get; set; } = DateTime.Today; // Defaults to Today's date

        
    }
}