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

        //Add Ticket Method
        Task AddTicket(Ticket ticket);

        //Add Ticekt Message
        Task AddTicketMessage(TicketMessage ticketMessage);

        #endregion
    }
}
