using Application.Interfaces;

using Infrastructure.Data;
using Application.Services.Leads;
using Domain.Entities;
using Infrastructure.DependencyInjection;

namespace Infrastructure.Repositories
{
    public class LeadRepository : ILead
    {
        private readonly ApplicationDbContext _dbContext;
        public LeadRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }
        public List<Lead> GetAllLeads()
        {
            List<Lead> _leads = _dbContext.Leads.ToList();

            return _leads;
        }

        public Lead GetLeadById(int id)
        {
            return _dbContext.Leads.FirstOrDefault(l => l.Id == id);
        }

    }
}