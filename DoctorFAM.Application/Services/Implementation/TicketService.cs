using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
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

        //Change Ticket Status
        public async Task<string> ChangeTicketStatus(int state, ulong ticketId)
        {
            #region Get Ticket By Id 

            var ticket = await GetTicketById(ticketId);

            if (ticket == null) return string.Empty;

            #endregion

            #region Update Ticket Status

            ticket.TicketStatus = (TicketStatus)state;

            await _ticketRepository.UpdateRequest(ticket);

            #endregion

            return ticket.TicketStatus.GetEnumName();
        }

        //Delete Ticket Message
        public async Task<bool> DeleteTicketMessage(ulong messageId , ulong UserId)
        {
            #region Get Message By Id

            var message = await _ticketRepository.GetMessageById(messageId);

            if (message == null) return false;
            if (message.SenderId != UserId) return false;

            #endregion

            #region Delete Message

            message.IsDelete = true;

            await _ticketRepository.UpdateTicketMessage(message) ;

            #endregion

            return true;
        }

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
                RequestId = request.Id,
                OnlineVisitRequest = true,
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

            #region Add File

            if (answer.MessageFile != null)
            {
                if (Path.GetExtension(answer.MessageFile.FileName).ToLower() == ".jpg"
                        && Path.GetExtension(answer.MessageFile.FileName).ToLower() == ".png"
                        && Path.GetExtension(answer.MessageFile.FileName).ToLower() == ".jpeg")
                {
                    var res = answer.MessageFile.IsImage();
                    if (!res)
                    {
                        return false;
                    }
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(answer.MessageFile.FileName);

                if (!Directory.Exists(PathTools.TicketFilePathServer))
                    Directory.CreateDirectory(PathTools.TicketFilePathServer);

                string OriginPath = PathTools.TicketFilePathServer + imageName;

                using (var stream = new FileStream(OriginPath, FileMode.Create))
                {
                    if (!Directory.Exists(OriginPath)) answer.MessageFile.CopyTo(stream);
                }

                message.MessageFile = imageName;
            }

            #endregion


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

        #region User Panel Side 

        //Read Tikcet By User 
        public async Task ReadTicketByUser(Ticket ticket)
        {
            ticket.IsReadByTargetUser = true;

            await _ticketRepository.UpdateRequest(ticket);
        }

        //Create Answer Tikcet From User Panel 
        public async Task<bool> CreateAnswerTikcetFromUserPanel(AnswerTikcetUserPanelViewModel answer, ulong userId)
        {
            #region Get Ticket By Id 

            var ticket = await GetTicketById(answer.TicketId);

            if (ticket == null) return false;
            if (ticket.TicketStatus == TicketStatus.Closed) return false;

            #endregion

            #region Fill Ticket Message 

            var message = new TicketMessage
            {
                Message = answer.Message,
                SenderId = userId,
                TicketId = ticket.Id
            };

            #region Add File

            if (answer.MessageFile != null)
            {
                if (Path.GetExtension(answer.MessageFile.FileName).ToLower() == ".jpg"
                        && Path.GetExtension(answer.MessageFile.FileName).ToLower() == ".png"
                        && Path.GetExtension(answer.MessageFile.FileName).ToLower() == ".jpeg")
                {
                    var res = answer.MessageFile.IsImage();
                    if (!res)
                    {
                        return false;
                    }
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(answer.MessageFile.FileName);

                if (!Directory.Exists(PathTools.TicketFilePathServer))
                    Directory.CreateDirectory(PathTools.TicketFilePathServer);

                string OriginPath = PathTools.TicketFilePathServer + imageName;

                using (var stream = new FileStream(OriginPath, FileMode.Create))
                {
                    if (!Directory.Exists(OriginPath)) answer.MessageFile.CopyTo(stream);
                }

                message.MessageFile = imageName;
            }

            #endregion

            #endregion

            #region Add Ticket Message Method

            await _ticketRepository.AddTicketMessage(message);

            #endregion

            #region Change Ticket State

            ticket.TicketStatus = TicketStatus.Pending;
            ticket.OnWorking = true;

            await _ticketRepository.UpdateRequest(ticket);

            #endregion

            #region Read Ticket

            ticket.IsReadByOwner = false;
            ticket.IsReadByAdmin = false;
            ticket.IsReadByTargetUser = true;

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
