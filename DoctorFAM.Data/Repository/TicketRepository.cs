using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Ticket;
using DoctorFAM.Domain.ViewModels.UserPanel.Ticket;
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

        //Get Ticket By Consultant Request Id
        public async Task<Ticket?> GetTicketByConsultantRequestId(ulong requestId)
        {
            return await _context.Tickets.Include(p => p.Owner)
                            .Include(p => p.TargetUser)
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.RequesConsultanttId == requestId);
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

        //Filter Tickets In Each Panels Side
        public async Task<FilterSiteTicketViewModel> FilterSiteTicket(FilterSiteTicketViewModel filter, ulong userId)
        {
            var query = _context.Tickets
                .Include(s => s.Owner)
                .Where(s => s.OwnerId == userId && !s.IsDelete && s.OnlineVisitRequest == false && !s.ConsultantRequest && !s.RequesConsultanttId.HasValue)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.UserTicketFilterStatus)
            {
                case UserTicketFilterStatus.All:
                    break;
                case UserTicketFilterStatus.Answered:
                    query = query.Where(s => s.IsReadByOwner);
                    break;
                case UserTicketFilterStatus.Closed:
                    query = query.Where(s => !s.IsReadByOwner);
                    break;
                case UserTicketFilterStatus.Pending:
                    query = query.Where(s => !s.IsReadByOwner);
                    break;
            }

            switch (filter.UserTicketFilterOnWorkingStatus)
            {
                case UserTicketFilterOnWorkingStatus.All:
                    break;
                case UserTicketFilterOnWorkingStatus.OnWorking:
                    query = query.Where(s => s.OnWorking);
                    break;
                case UserTicketFilterOnWorkingStatus.NotWorking:
                    query = query.Where(s => !s.OnWorking);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.TicketTitle))
            {
                query = query.Where(s => s.Title.Contains(filter.TicketTitle));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #region Doctor Panel 



        #endregion

        #region Site Side


        #endregion

        #region Admin Side 

        //Read Ticket By Admin
        public async Task ReadTicketByAdmin(Ticket ticket)
        {
            _context.Update(ticket);
            await _context.SaveChangesAsync();
        }

        //Filter Admin side Ticketes
        public async Task<AdminFilterTicketViewModel> FilterAdminTicketViewModel(AdminFilterTicketViewModel filter)
        {
            var query = _context.Tickets
                .Include(s => s.Owner)
                .Where(s => !s.IsDelete && !s.OnlineVisitRequest && !s.ConsultantRequest && !s.RequesConsultanttId.HasValue)
                .OrderByDescending(s => s.CreateDate )
                .AsQueryable();

            #region State

            switch (filter.AdminTicketFilterSeenByUserStatus)
            {
                case AdminTicketFilterSeenByUserStatus.All:
                    break;
                case AdminTicketFilterSeenByUserStatus.SeenByUser:
                    query = query.Where(s => s.IsReadByOwner);
                    break;
                case AdminTicketFilterSeenByUserStatus.NotSeenByUser:
                    query = query.Where(s => !s.IsReadByOwner);
                    break;
            }

            switch (filter.AdminTicketFilterSeenByAdminStatus)
            {
                case AdminTicketFilterSeenByAdminStatus.All:
                    break;
                case AdminTicketFilterSeenByAdminStatus.SeenByAdmin:
                    query = query.Where(s => s.IsReadByAdmin);
                    break;
                case AdminTicketFilterSeenByAdminStatus.NotSeenByAdmin:
                    query = query.Where(s => !s.IsReadByAdmin);
                    break;
            }

            switch (filter.AdminTicketFilterStatus)
            {
                case AdminTicketFilterStatus.All:
                    break;
                case AdminTicketFilterStatus.Answered:
                    query = query.Where(s => s.IsReadByOwner);
                    break;
                case AdminTicketFilterStatus.Closed:
                    query = query.Where(s => !s.IsReadByOwner);
                    break;
                case AdminTicketFilterStatus.Pending:
                    query = query.Where(s => !s.IsReadByOwner);
                    break;
            }

            switch (filter.AdminTicketFilterOnWorkingStatus)
            {
                case AdminTicketFilterOnWorkingStatus.All:
                    break;
                case AdminTicketFilterOnWorkingStatus.OnWorking:
                    query = query.Where(s => s.OnWorking);
                    break;
                case AdminTicketFilterOnWorkingStatus.NotWorking:
                    query = query.Where(s => !s.OnWorking);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.OwnerName))
            {
                query = query.Where(s => (s.Owner.Username).Contains(filter.OwnerName));
            }

            if (!string.IsNullOrEmpty(filter.TicketTitle))
            {
                query = query.Where(s => s.Title.Contains(filter.TicketTitle));
            }

            if (!string.IsNullOrEmpty(filter.UserEmail))
            {
                query = query.Where(s => s.Owner.Email.Contains(filter.UserEmail));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }


        #endregion
    }
}
