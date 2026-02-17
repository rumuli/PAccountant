using Application.Interfaces;
using Infrastructure.Data;
using Domain.Entities;
using Application.Services.SupportTickets; 
using Infrastructure.DependencyInjection;  

namespace Infrastructure.Repositories
{
    public class SupportTicketRepository : ISupportTicket
    {
        private readonly ApplicationDbContext _dbContext;
        public SupportTicketRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<SupportTicket> GetAllSupportTickets()
        {
            List<SupportTicket> _tickets = _dbContext.SupportTickets.ToList();

            return _tickets;
        }

        public SupportTicket GetSupportTicketById(int id)
        {
            return _dbContext.SupportTickets.FirstOrDefault(t => t.Id == id);
        }

       
    }
}