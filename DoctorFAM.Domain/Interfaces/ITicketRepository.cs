using DoctorFAM.Domain.Entities.Contact;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface ITicketRepository
    {
        #region General Methods 

        //Update Ticket Message 
        Task UpdateTicketMessage(TicketMessage ticketMessage);

        //Get Message By Message Id 
        Task<TicketMessage?> GetMessageById(ulong ticketMessageId);

        //Add Ticket Method
        Task AddTicket(Ticket ticket);

        //Add Ticekt Message
        Task AddTicketMessage(TicketMessage ticketMessage);

        //Get Ticket By Online Visit Request Id
        Task<Ticket?> GetTicketByOnlineVisitRequestId(ulong requestId);

        //Update Request 
        Task UpdateRequest(Ticket ticket);

        //Get Tikcet By Tikcet Id
        Task<Ticket?> GetTicketById(ulong ticketId);

        //Get Tikcet Messages By Ticket Id
        Task<List<TicketMessage>?> GetTikcetMessagesByTicketId(ulong ticketId);

        //Update Request Without Save Changes
        Task UpdateRequestWithoutSaveChanges(Ticket ticket);

        //Save Changes
        Task SaveChanges();

        #endregion
    }
}
