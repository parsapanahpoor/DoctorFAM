using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class TicketService : ITicketService
    {
        #region Ctor

        private readonly ITicketRepository _ticketRepository;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;

        public TicketService(ITicketRepository ticketRepository, IUserService userService , IOrganizationService organizationService)
        {
            _ticketRepository = ticketRepository;
            _userService = userService;
            _organizationService = organizationService;
        }

        #endregion

        #region General Methods

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

        //Get Ticket By Online Visit Request Id
        public async Task<Ticket?> GetTicketByOnlineVisitRequestId(ulong requestId)
        {
            return await _ticketRepository.GetTicketByOnlineVisitRequestId(requestId);
        }

        //Read Tikcet By Doctor
        public async Task ReadTicketByDoctor(Ticket ticket)
        {
            ticket.IsReadByOwner = true;

            await _ticketRepository.UpdateRequest(ticket);
        }

        //Get Ticket By Ticket Id
        public async Task<Ticket?> GetTicketById(ulong ticketId)
        {
            return await _ticketRepository.GetTicketById(ticketId);
        }

        //Get Ticket Message
        public async Task<List<TicketMessage>?> GetTikcetMessagesByTicketId(ulong ticketId)
        {
            return await _ticketRepository.GetTikcetMessagesByTicketId(ticketId);
        }

        #endregion

        #region Doctor Side 

        //Create Answer Tikcet From Doctor Panel 
        public async Task<bool> CreateAnswerTikcetFromDoctorPanel(AnswerTikcetDoctorViewModel answer, ulong userId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Get Ticket By Id 

            var ticket = await GetTicketById(answer.TicketId);

            if (ticket == null) return false;

            #endregion

            #region Fill Ticket Message 

            var message = new TicketMessage
            {
                Message = answer.Message,
                SenderId = organization.OwnerId,
                TicketId = ticket.Id
            };

            #endregion

            #region Add Ticket Message Method

            await _ticketRepository.AddTicketMessage(message);

            #endregion

            #region Change Ticket State

            ticket.TicketStatus = TicketStatus.Answered;
            ticket.OnWorking = true;

            await _ticketRepository.UpdateRequest(ticket); 

            #endregion

            #region Read Ticket

            ticket.IsReadByOwner = true;
            ticket.IsReadByAdmin = false;
            ticket.IsReadByTargetUser = false; 

            await _ticketRepository.UpdateRequest(ticket);

            #endregion

            #region Save Changes

            await _ticketRepository.SaveChanges();

            #endregion

            return true;
        }


        #endregion
    }
}
