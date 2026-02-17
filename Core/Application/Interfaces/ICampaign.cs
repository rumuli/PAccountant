using Domain.Entities;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ICampaignServices
    {
       
       public List<Campaign> GetAllCampaigns();
        Campaign GetCampaignById(int id);
         void CreateCampaign(CreateCampaignDTO campaignDTO);
        void UpdateCampaign(int id, UpdateCampaignDTO campaignDTO);
    }
}
