using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateIncomeDTO
    {
        [Required(ErrorMessage = "Please select an income type")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid income type")]
        public int IncomeTypeId { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; } = DateTime.Today; // Defaults to today's date

        [Required(ErrorMessage = "Amount is required")]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335", ErrorMessage = "Amount must be greater than 0")]
        public decimal AmountPaid { get; set; }

        [Required(ErrorMessage = "Source is required")]
        [StringLength(100)]
        public string Source { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a payment method")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid payment method")]
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "Please select an account")]
      [Range(1, int.MaxValue, ErrorMessage = "Please select a valid account")]
         public int AccountId { get; set; }   // link to Account

    }
}

