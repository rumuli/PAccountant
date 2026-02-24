using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IPaymentMethodService
    {
        Task<List<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id);
        Task CreatePaymentMethodAsync(CreatePaymentMethodDTO paymentTypeDTO);
    }
}

