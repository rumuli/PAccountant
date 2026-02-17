
using Application.Interfaces;
using Infrastructure.Data;
using Domain.Entities;
using Application.Services.Deals;
using Infrastructure.DependencyInjection;

namespace Infrastructure.Repositories
{
    public class DealRepository : IDeal
    {
        private readonly ApplicationDbContext _dbContext;
        public DealRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public List<Deal> GetAllDeals()
        {
            List<Deal> _deals = _dbContext.Deals.ToList();

            return _deals;
        }
        public Deal GetDealById(int id)
        {
            return _dbContext.Deals.FirstOrDefault(d => d.Id == id);
        }

        
    }
}