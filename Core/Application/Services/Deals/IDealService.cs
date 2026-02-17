using Domain.Entities;

namespace Application.Services.Deals
{
    public interface IDealService
    {
        Deal GetDealById(int id);
        
        List<Deal> GetAllDeals();
    }
}