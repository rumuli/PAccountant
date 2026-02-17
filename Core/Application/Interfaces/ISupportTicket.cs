using Domain.Entities;

namespace Application.Interfaces
{
    public interface ISupportTicketService
    {
        public List<SupportTicket> GetAllSupportTickets();
         public SupportTicket GetSupportTicketById(int id);
    }
}