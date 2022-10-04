using BusinessPortal.Application.Services.Implementation;
using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums;
using DoctorFAM.Domain.Enums.Ticket;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Ticket;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.UserPanel.Ticket;
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

        //Answer Ticket By User 
        public async Task<bool> AnswerTicketByUser(AnswerTicketViewModel answer, ulong userId)
        {
            #region Get Ticket

            var ticket = await _ticketRepository.GetTicketById(answer.TicketId);
            if (ticket == null || ticket.OwnerId != userId || ticket.TicketStatus != TicketStatus.Answered) return false;

            #endregion

            #region Fill Ticket Message Entity

            var message = new TicketMessage
            {
                Message = answer.Message.SanitizeText(),
                SenderId = userId,
                TicketId = ticket.Id,
                CreateDate = DateTime.Now
            };

            #endregion

            #region Add Ticket Message Method

            await _ticketRepository.UpdateTicketMessage(message);

            #endregion

            #region Read Ticket & Update Ticket

            ticket.IsReadByOwner = true;
            ticket.IsReadByAdmin = false;
            ticket.TicketStatus = TicketStatus.Pending;

            await _ticketRepository.UpdateRequest(ticket);

            #endregion

            return true;
        }

        //Get User Ticket For Show Ticket Detail 
        public async Task<UserPanelTicketDetailViewModel?> GetUserPanelTicketDetailViewModel(ulong ticketId, ulong userId)
        {
            #region Get Ticket

            var ticket = await _ticketRepository.GetTicketById(ticketId);
            if (ticket == null || ticket.OwnerId != userId) return null;

            #endregion

            #region Get Ticket Messages

            var messages = await _ticketRepository.GetTikcetMessagesByTicketId(ticketId);

            #endregion

            #region Read Ticket

            if (!ticket.IsReadByOwner)
            {
                ticket.IsReadByOwner = true;

                await _ticketRepository.UpdateRequest(ticket);
            }

            #endregion

            #region Fill View Model

            var result = new UserPanelTicketDetailViewModel
            {
                CreateDate = ticket.CreateDate.ToShamsi(),
                Status = ticket.TicketStatus.GetEnumName(),
                MessagesCount = messages.Count(),
                TicketTitle = ticket.Title,
                TicketMessages = messages,
                OwnerId = ticket.OwnerId,
                TicketStatus = ticket.TicketStatus
            };

            #endregion

            return result;
        }

        //Create Ticket For Each Panels
        public async Task<ulong> CreateTicket(CreateTicketViewModel create, ulong userId, TicketSenderType ticketSenderType)
        {
            #region Get user By Id

            var user = await _userService.GetUserById(userId);
            if (user == null) return 0;

            #endregion

            #region Fill Ticket Entity

            var ticket = new Ticket
            {
                Title = create.Title.SanitizeText(),
                IsReadByAdmin = false,
                IsReadByOwner = true,
                OnWorking = false,
                TicketStatus = TicketStatus.Pending,
                OwnerId = userId,
                TargetUserId = userId,
                CreateDate = DateTime.Now,
                TicketForAdminAndSupporters = true,
                TicketSenderType = ticketSenderType
            };

            #endregion

            #region Add Ticket Method

            await _ticketRepository.AddTicket(ticket);

            #endregion

            #region Fill Ticket Message Entity

            var message = new TicketMessage
            {
                Message = create.Message.SanitizeText(),
                SenderId = userId,
                TicketId = ticket.Id,
                CreateDate = DateTime.Now
            };

            #endregion

            #region Add Ticket Message Method 

            await _ticketRepository.AddTicketMessage(message);

            #endregion

            return ticket.Id;
        }

        //Filter Tickets In Each Panels Side
        public async Task<FilterSiteTicketViewModel> FilterSiteTicket(FilterSiteTicketViewModel filter, ulong userId)
        {
            return await _ticketRepository.FilterSiteTicket(filter, userId);
        }

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
                OnWorking = false,
                TicketStatus = TicketStatus.Pending,
                OwnerId = request.OperationId.Value,
                TargetUserId = request.UserId,
                CreateDate = DateTime.Now,
                RequestId = request.Id,
                OnlineVisitRequest = true,
                TicketSenderType = TicketSenderType.FromDoctor
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

        #region Admin Side 

        //Filter Admin side Ticketes
        public async Task<AdminFilterTicketViewModel> FilterAdminTicketViewModel(AdminFilterTicketViewModel filter)
        {
            return await _ticketRepository.FilterAdminTicketViewModel(filter);
        }

        //Add Ticket From Admin Panel 
        public async Task<bool> AddTicketFromAdminPanel(AddTicketViewModel addTicket, ulong adminId)
        {
            #region Check Is Exist User

            if (await _userService.GetUserById(addTicket.userId.Value) == null)
            {
                return false;
            }

            #endregion

            #region Fill Ticket Entity

            var ticket = new Ticket
            {
                Title = addTicket.Title.SanitizeText(),
                IsReadByAdmin = true,
                IsReadByOwner = false,
                OnWorking = false,
                TicketStatus = TicketStatus.Answered,
                OwnerId = addTicket.userId.Value,
                CreateDate = DateTime.Now,
                TargetUserId = addTicket.userId.Value,
                TicketSenderType = TicketSenderType.FromAdmin
            };

            #endregion

            #region Add Ticket Method

            await _ticketRepository.AddTicket(ticket);

            #endregion

            #region Fill Message Entity

            var message = new TicketMessage
            {
                Message = addTicket.Message.SanitizeText(),
                SenderId = adminId,
                TicketId = ticket.Id,
                CreateDate = DateTime.Now
            };

            #endregion

            #region Add Message Method

            await _ticketRepository.AddTicketMessage(message);

            #endregion

            return true;
        }

        //Read Ticket By Admin 
        public async Task ReadTicketByAdmin(Ticket ticket)
        {
            ticket.IsReadByAdmin = true;

            await _ticketRepository.ReadTicketByAdmin(ticket);
        }

        //Get Ticket Messages For Admin 
        public async Task<List<TicketMessage>> GetTicketMessages(ulong ticketId)
        {
            #region Get Ticket By Id 

            var ticket = await GetTicketById(ticketId);
            if (ticket == null) return null;

            #endregion

            #region Get Ticket Messages By Ticket Id

            var messages = await _ticketRepository.GetTikcetMessagesByTicketId(ticketId);

            #endregion

            return messages;
        }

        //Create Answer Ticket From Admin 
        public async Task<bool> CreateAnswerTicketAdmin(AnswerTicketAdminViewModel answer, ulong userId)
        {
            #region Ticket Validation

            var ticket = await GetTicketById(answer.TicketId);
            if (ticket == null) return false;

            #endregion

            #region Create Message Answer

            #region Fill Entity 

            var message = new TicketMessage
            {
                Message = answer.Message,
                SenderId = userId,
                TicketId = ticket.Id,
                CreateDate = DateTime.Now,
            };

            #endregion

            #region Add Ticket Message Method

            await _ticketRepository.AddTicketMessage(message);

            #endregion

            #endregion

            #region Change Ticket State

            ticket.TicketStatus = TicketStatus.Answered;

            await _ticketRepository.UpdateRequest(ticket);

            #endregion

            #region Read Ticket

            ticket.IsReadByOwner = false;
            ticket.IsReadByAdmin = true;

            await _ticketRepository.UpdateRequest(ticket);

            #endregion

            return true;
        }

        //Change On Working Ticket Status
        public async Task<bool> ChangeOnWorkingTicketStatus(ulong ticketId)
        {
            #region Get Ticket By Ticket Id 

            var ticket = await GetTicketById(ticketId);
            if (ticket == null) return false;

            #endregion

            #region Chanmge Ticket On Working Status

            ticket.OnWorking = !ticket.OnWorking;

            await _ticketRepository.UpdateRequest(ticket);

            #endregion

            return true;
        }

        //Delete Ticket Message 
        public async Task<bool> DeleteTicketMessage(ulong messageId)
        {
            #region Get Message Ticket By Id

            var message = await _ticketRepository.GetMessageById(messageId);
            if (message == null) return false;

            #endregion

            #region Delete Ticket Message 

            message.IsDelete = true;

            await _ticketRepository.UpdateTicketMessage(message);

            #endregion

            return true;
        }

        #endregion

        #region Supporter Panel 

        //Add Ticket From Admin Panel 
        public async Task<bool> AddTicketFromSupporterPanel(AddTicketViewModel addTicket, ulong adminId)
        {
            #region Check Is Exist User

            if (await _userService.GetUserById(addTicket.userId.Value) == null)
            {
                return false;
            }

            #endregion

            #region Fill Ticket Entity

            var ticket = new Ticket
            {
                Title = addTicket.Title.SanitizeText(),
                IsReadByAdmin = true,
                IsReadByOwner = false,
                OnWorking = false,
                TicketStatus = TicketStatus.Answered,
                OwnerId = addTicket.userId.Value,
                CreateDate = DateTime.Now,
                TargetUserId = addTicket.userId.Value,
                TicketSenderType = TicketSenderType.FromSupporter
            };

            #endregion

            #region Add Ticket Method

            await _ticketRepository.AddTicket(ticket);

            #endregion

            #region Fill Message Entity

            var message = new TicketMessage
            {
                Message = addTicket.Message.SanitizeText(),
                SenderId = adminId,
                TicketId = ticket.Id,
                CreateDate = DateTime.Now
            };

            #endregion

            #region Add Message Method

            await _ticketRepository.AddTicketMessage(message);

            #endregion

            return true;
        }

        #endregion

        #region Consultant Panel Side 

        //Create Tikcet For First Time After Accept Consultant Request From Consultant 
        public async Task<bool> AddTicketForFirstTimeInConsultantInConsultantPanel(UserSelectedConsultant userSelectedConsultant)
        {
            #region Create Ticket

            var ticket = new Ticket
            {
                Title = "Consultant Request",
                IsReadByAdmin = false,
                IsReadByOwner = true,
                IsReadByTargetUser = false,
                OnWorking = false,
                TicketStatus = TicketStatus.Pending,
                OwnerId = userSelectedConsultant.ConsultantId,
                TargetUserId = userSelectedConsultant.PatientId,
                CreateDate = DateTime.Now,
                ConsultantRequest = true,
                TicketSenderType=TicketSenderType.FromConsultant,
                RequesConsultanttId = userSelectedConsultant.Id
            };

            await _ticketRepository.AddTicket(ticket);

            #endregion

            return true;
        }

        //Get Ticket By Consultant Request Id
        public async Task<Ticket?> GetTicketByConsultantRequestId(ulong requestId)
        {
            return await _ticketRepository.GetTicketByConsultantRequestId(requestId);
        }

        //Create Answer Tikcet From Consultant 
        public async Task<bool> CreateAnswerTikcetFromConsultantPanel(AnswerTikcetDoctorViewModel answer, ulong userId)
        {
            #region Get Consultant Organization

            var organization = await _organizationService.GetConsultantOrganizationByUserId(userId);
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
    }
}
