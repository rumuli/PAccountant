using Domain.Entities;
using Application.Interfaces;


namespace Application.Services.SupportTickets
{
    public interface ISupportTicketService
    {
         SupportTicket GetSupportTicketById(int id);
          
          List<SupportTicket> GetAllSupportTickets();
}
}