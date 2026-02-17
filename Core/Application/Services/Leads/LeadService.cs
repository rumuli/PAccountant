using Domain.Entities;
using Application.Services.Leads;
using Application.Interfaces;


namespace Application.Services.Leads
{
    public class LeadService : ILeadService
    {
        private readonly ILead _lead;

        public LeadService(ILead lead)
        {
            _lead = lead;
        }
        public List<Lead> GetAllLeads()
        {
            List<Lead> leads = _lead.GetAllLeads();
           
            return leads;
        }

       public Lead GetLeadById(int id)
        {
            return _lead.GetLeadById(id);
    }
    }

    public interface ILead
    {
        List<Lead> GetAllLeads();
        Lead GetLeadById(int id);
    }
}

