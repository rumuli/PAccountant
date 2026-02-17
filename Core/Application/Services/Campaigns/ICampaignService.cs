     
using Domain.Entities;
using Application.Services.Campaigns;
using Application.Interfaces;
using Application.DTO;

namespace Application.Services.Campaigns
{
    public interface ICampaignService
    {
        Campaign GetCampaignById(int id);
         List<Campaign> GetAllCampaigns();
          void CreateCampaign(CreateCampaignDTO campaignDTO); 
        void UpdateCampaign(int id, UpdateCampaignDTO campaignDTO);
    }
}
