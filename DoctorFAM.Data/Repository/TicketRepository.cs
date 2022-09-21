using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        //Get Message By Message Id 
        public async Task<TicketMessage?> GetMessageById(ulong ticketMessageId)
        {
            return await _context.TicketMessages.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == ticketMessageId);
        }

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

        //Get Ticket By Online Visit Request Id
        public async Task<Ticket?> GetTicketByOnlineVisitRequestId(ulong requestId)
        {
            return await _context.Tickets.Include(p => p.Owner)
                            .Include(p => p.TargetUser)
                            .FirstOrDefaultAsync(p=> !p.IsDelete && p.RequestId == requestId);
        }

        //Update Request 
        public async Task UpdateRequest(Ticket ticket)
        {
            _context.Update(ticket);
            await _context.SaveChangesAsync();
        }

        //Update Ticket Message 
        public async Task UpdateTicketMessage(TicketMessage ticketMessage)
        {
            _context.TicketMessages.Update(ticketMessage);
            await _context.SaveChangesAsync();
        }

        //Get Tikcet By Id
        public async Task<Ticket?> GetTicketById(ulong ticketId)
        {
            return await _context.Tickets
                .Include(s => s.Owner)
                .Include(s => s.TargetUser)
                .FirstOrDefaultAsync(s => !s.IsDelete && s.Id == ticketId);
        }

        //Get Tikcet Messages By Ticket Id
        public async Task<List<TicketMessage>?> GetTikcetMessagesByTicketId(ulong ticketId)
        {
            return await _context.TicketMessages
                .Include(s => s.Ticket)
                .Include(s => s.Sender)
                .Where(s => s.TicketId == ticketId && !s.IsDelete)
                .OrderByDescending(s => s.CreateDate)
                .ToListAsync();
        }

        //Update Request Without Save Changes
        public async Task UpdateRequestWithoutSaveChanges(Ticket ticket)
        {
            _context.Update(ticket);
        }

        //Save Changes
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
            
        #endregion

        #region Doctor Panel 



        #endregion
    }
}
