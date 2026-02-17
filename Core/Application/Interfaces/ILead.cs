using Domain.Entities;

namespace Application.Interfaces
{
    public interface ILeadService
    {
        public List<Lead> GetAllLeads();
        public Lead GetLeadById(int id);
    }
}