using Domain.Entities;
using Application.Interfaces;
using System.Reflection.Metadata.Ecma335;
using Application.Services.SupportTickets;

namespace Application.Services.SupportTickets

{
    public class SupportTicketService : ISupportTicketService
    {
        private readonly ISupportTicket _supportticket;
         public SupportTicketService(ISupportTicket supportticket)

        {
            _supportticket = supportticket;
        }

        public List<SupportTicket> GetAllSupportTickets()
        {
            List<SupportTicket> supporttickets = _supportticket.GetAllSupportTickets();
            return supporttickets;
        }

        public SupportTicket GetSupportTicketById(int id)
        {
            return _supportticket.GetSupportTicketById(id);
        }

    }

    public interface ISupportTicket
    {
        List<SupportTicket> GetAllSupportTickets();
        SupportTicket GetSupportTicketById(int id);
    }
}