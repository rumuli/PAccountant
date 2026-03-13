using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using Domain.Entities;
using Domain.ValueObjects;
namespace Application.DTO

{
    public class CreateDebtDTO
    {
        
       [Required(ErrorMessage = "Please select an Debt type")]
      [Range(1, int.MaxValue, ErrorMessage = "Please select an Expense type")]
       public int DebtTypeId { get; set; }   // ✅ correct property

         [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal PrincipalAmount { get; set; }
        [Required(ErrorMessage = "Interest rate is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Interest rate must be greater than 0")]
        public decimal InterestRate { get; set; }

         [Required(ErrorMessage = "Creditor is required")]
        [StringLength(100)]
        public string Creditor { get; set; }

       [Required(ErrorMessage = "Date is required")]
        public DateTime? DueDate { get; set; } = DateTime.Today; // Defaults to Today's date

        [Required(ErrorMessage = "Date is required")]
        public DateTime? DateIncurred { get; set; } = DateTime.Today; // Defaults to Today's date

        
    }
    public class DebtRepaymentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Payment amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Payment amount must be greater than 0")]
        public decimal AmountPaid { get; set; }
        public decimal RemainingAmount { get; set; }
        public DebtStatus Status { get; set; }
    }
}