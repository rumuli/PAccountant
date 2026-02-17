using Domain.Entities;
using Application.Interfaces;
using Application.Services.Campaigns;
using Application.DTO;



namespace Application.Services.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaign _campaign;
        public CampaignService(ICampaign campaign)
        {
            _campaign = campaign;
        }
        public Campaign GetCampaignById(int id)
        {
            return _campaign.GetCampaignById(id);
        }
        public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> campaigns = _campaign.GetAllCampaigns();
            return campaigns;

    }
    public void CreateCampaign(CreateCampaignDTO campaignDTO)
    {
        _campaign.CreateCampaign(campaignDTO);

    
    }

    public void UpdateCampaign(int id, UpdateCampaignDTO campaignDTO)
    {
        _campaign.UpdateCampaign(id, campaignDTO);
    }
}

    public interface ICampaign
    {
        void CreateCampaign(CreateCampaignDTO campaignDTO);
        List<Campaign> GetAllCampaigns();
        Campaign GetCampaignById(int id);
        void UpdateCampaign(int id, UpdateCampaignDTO campaignDTO);
    }
}

    

