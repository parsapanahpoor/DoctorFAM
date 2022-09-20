using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Enums;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class TicketService : ITicketService
    {
        #region Ctor

        private readonly ITicketRepository _ticketRepository;
        private readonly IUserService _userService;

        public TicketService(ITicketRepository ticketRepository, IUserService userService)
        {
            _ticketRepository = ticketRepository;
            _userService = userService;
        }

        #endregion

        #region Doctor Panel 

        //Create Tikcet For First Time After Accept Online Visit Request From Doctor 
        public async Task<bool> AddTicketForFirstTimeInOnlineVisitInDoctorPanel(Request request)
        {
            #region Create Ticket

            var ticket = new Ticket
            {
                Title = "Online Visit Request",
                IsReadByAdmin = false,
                IsReadByOwner = true,
                IsReadByTargetUser = false,
                OnWorking = true,
                TicketStatus = TicketStatus.Pending,
                OwnerId = request.OperationId.Value,
                TargetUserId = request.UserId,
                CreateDate = DateTime.Now,
                RequestId = request.Id
            };

            await _ticketRepository.AddTicket(ticket);

            #endregion

            return true;
        }


        #endregion
    }
}
