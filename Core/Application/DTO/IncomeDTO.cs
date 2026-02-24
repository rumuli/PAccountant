using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateIncomeDTO
    {
        [Required(ErrorMessage = "Please select an income type")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select an income type")]
        public int IncomeTypeId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; set; } = DateTime.Today; // Defaults to Today's date

        [Required(ErrorMessage = "Amount is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal AmountPaid { get; set; }

        [Required(ErrorMessage = "Source is required")]
        [StringLength(100)]
        public string Source { get; set; }

        [Required(ErrorMessage = "Please select a payment method")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a payment method")]
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "Deposited account is required")]
        public string DepositedAccount { get; set; }
    }

   public class UpdateIncomeDTO
{
    [Range(1, int.MaxValue, ErrorMessage = "Please select an income type.")]
    public int IncomeTypeId { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
    public decimal AmountPaid { get; set; }

    [Required(ErrorMessage = "Source is required.")]
    public string Source { get; set; } = string.Empty;

    [Range(1, int.MaxValue, ErrorMessage = "Please select a payment method.")]
    public int PaymentMethodId { get; set; }

    [Required(ErrorMessage = "Deposited account is required.")]
    public string DepositedAccount { get; set; } = string.Empty;
}
}