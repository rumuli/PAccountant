using Domain.Entities;
using Application.Interfaces;
using Application.Services.Campaigns;
using Infrastructure.Data;
using Infrastructure.DependencyInjection;
using Application.DTO;

namespace Infrastructure.Repositories
{
    public class CampaignRepository : ICampaign
    {
        private readonly ApplicationDbContext _dbContext;
        public CampaignRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Campaign> GetAllCampaigns()
        {
            List<Campaign> _campaigns = _dbContext.Campaigns.ToList();
            return _campaigns;
        }
        public Campaign GetCampaignById(int id)
        {
            return _dbContext.Campaigns.FirstOrDefault(c => c.Id == id);

        }
        //create and update method
        public void CreateCampaign(CreateCampaignDTO campaignDTO)
        {
            Campaign campaign = new()
            {
                Title = campaignDTO.Title,
                Description = campaignDTO.Description,
                StartDate = campaignDTO.StartDate,
                EndDate = campaignDTO.EndDate,
                Budget = campaignDTO.Budget,
                IsActive = true,
                CreatedAt = DateTime.Now,
                CreatedById = 7
            };
            _dbContext.Campaigns.Add(campaign);
            _dbContext.SaveChanges();
        }
         public void UpdateCampaign(int id, UpdateCampaignDTO campaignDTO)  
        {
            Campaign campaign = _dbContext.Campaigns.Find(id);
            if (campaign == null) return;
            campaign.Title = campaignDTO.Title;
            campaign.Description = campaignDTO.Description;
            campaign.Budget = campaignDTO.Budget;
            _dbContext.SaveChanges();
        }
    }
    }
