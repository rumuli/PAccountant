using Domain.Entities;

namespace Application.Interfaces
{
    public interface IDealService
    {
        public List<Deal> GetAllDeals();
        public Deal GetDealById(int id);
    }
}