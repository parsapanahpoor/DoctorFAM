using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class TicketRepository : ITicketRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public TicketRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region General Methods 

        //Add Ticket Method
        public async Task AddTicket(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        //Add Ticekt Message
        public async Task AddTicketMessage(TicketMessage ticketMessage)
        {
            await _context.TicketMessages.AddAsync(ticketMessage);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
