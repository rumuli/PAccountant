using Domain.Entities;
using Application.DTO;
using Application.Interfaces;

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

        public async Task<int> CreatePaymentMethodAsync(CreatePaymentMethodDTO paymentMethodDTO)
        {
            return await _paymentMethod.CreatePaymentMethodAsync(paymentMethodDTO);
        }
    }

   
}