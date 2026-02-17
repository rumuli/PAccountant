using Domain.Entities;
using Application.Services.Deals;
using Application.Interfaces;

namespace Application.Services.Deals
{
    public class DealService : IDealService
    {
        private readonly IDeal _deal;

        public DealService(IDeal deal)

        {
            _deal = deal;
        }
        public List<Deal> GetAllDeals()
        {
            List<Deal> deals = _deal.GetAllDeals();
           
            return deals;
        }

       public Deal GetDealById(int id)
        {
            return _deal.GetDealById(id);
    }
    }

    public interface IDeal
    {
        List<Deal> GetAllDeals();
        Deal GetDealById(int id);
    }

   
}