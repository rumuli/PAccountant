using Domain.Entities;
using Application.DTO;

namespace Application.Services.PaymentMethods
{
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IPaymentMethod _paymentMethod;

        public PaymentMethodService(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }

        public async Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id)
        {
            return await _paymentMethod.GetPaymentMethodByIdAsync(id);
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await _paymentMethod.GetAllPaymentMethodsAsync();
        }

        public async Task CreatePaymentMethodAsync(CreatePaymentMethodDTO paymentMethodDTO)
        {
            await _paymentMethod.CreatePaymentMethodAsync(paymentMethodDTO);
        }
    }

    public interface IPaymentMethod
    {
        Task CreatePaymentMethodAsync(CreatePaymentMethodDTO paymentMethodDTO);
        Task<List<PaymentMethod>> GetAllPaymentMethodsAsync();
        Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id);
    }
}