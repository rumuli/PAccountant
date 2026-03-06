using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IPaymentMethod
    {
        Task <List<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id);
        Task<int> CreatePaymentMethodAsync(CreatePaymentMethodDTO paymentTypeDTO);
    }
}