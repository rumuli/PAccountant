using Domain.Entities;

namespace Application.Services.Leads
{
    public interface ILeadService
    {
        Lead GetLeadById(int id);
        
        List<Lead> GetAllLeads();
    }
}