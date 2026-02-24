using Domain.Entities;
using Application.DTO;
using Application.Services.PaymentMethods;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PaymentMethodRepository : IPaymentMethod
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentMethodRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<List<PaymentMethod>> GetAllPaymentMethodsAsync()
        {
            return await _dbContext.PaymentMethods.ToListAsync();
        }

        public async Task<PaymentMethod?> GetPaymentMethodByIdAsync(int id)
        {
            return await _dbContext.PaymentMethods.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task CreatePaymentMethodAsync(CreatePaymentMethodDTO paymentMethodDTO)
        {
            var paymentMethod = new PaymentMethod
            {
                PaymentMethodName = paymentMethodDTO.PaymentMethodName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
                
            };

            _dbContext.PaymentMethods.Add(paymentMethod);
            await _dbContext.SaveChangesAsync();
        }
    }
}

