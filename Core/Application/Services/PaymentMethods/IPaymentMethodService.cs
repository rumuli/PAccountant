using Domain.Entities;
using Application.DTO;

namespace Application.Services.PaymentMethods
{
    public interface IPaymentMethodService
    {
         Task <List<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id);
        Task<int> CreatePaymentMethodAsync(CreatePaymentMethodDTO paymentTypeDTO);
    }
}