using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Enums.Ticket;
using DoctorFAM.Domain.ViewModels.Admin.Ticket;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.UserPanel.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ITicketService
    {
        #region Geneal Methods 

        //Answer Ticket By User 
        Task<bool> AnswerTicketByUser(AnswerTicketViewModel answer, ulong userId);

        //Get User Ticket For Show Ticket Detail 
        Task<UserPanelTicketDetailViewModel?> GetUserPanelTicketDetailViewModel(ulong ticketId, ulong userId);

        //Create Ticket For Each Panels
        Task<ulong> CreateTicket(CreateTicketViewModel create, ulong userId , TicketSenderType ticketSenderType);

        //Filter Tickets In Each Panels Side
        Task<FilterSiteTicketViewModel> FilterSiteTicket(FilterSiteTicketViewModel filter, ulong userId);

        //Change Ticket Status
        Task<string> ChangeTicketStatus(int state, ulong ticketId);

        //Delete Ticket Message
        Task<bool> DeleteTicketMessage(ulong messageId, ulong UserId);

        //Create Tikcet For First Time After Accept Online Visit Request From Doctor 
        Task<bool> AddTicketForFirstTimeInOnlineVisitInDoctorPanel(Request request);

        //Get Ticket By Online Visit Request Id
        Task<Ticket?> GetTicketByOnlineVisitRequestId(ulong requestId);

        //Read Tikcet By Doctor
        Task ReadTicketByDoctor(Ticket ticket);

        //Get Ticket By Ticket Id
        Task<Ticket?> GetTicketById(ulong ticketId);

        //Get Ticket Message
        Task<List<TicketMessage>?> GetTikcetMessagesByTicketId(ulong ticketId);

        //Create Answer Tikcet From Doctor Panel 
        Task<bool> CreateAnswerTikcetFromDoctorPanel(AnswerTikcetDoctorViewModel answer, ulong userId);

        #endregion

        #region User Panel Side 

        //Read Tikcet By User 
        Task ReadTicketByUser(Ticket ticket);

        //Create Answer Tikcet From User Panel 
        Task<bool> CreateAnswerTikcetFromUserPanel(AnswerTikcetUserPanelViewModel answer, ulong userId);

        #endregion

        #region Admin Side And Supporter Side 

        //Read Ticket By Admin 
        Task ReadTicketByAdmin(Ticket ticket);

        //Filter Admin side Ticketes
        Task<AdminFilterTicketViewModel> FilterAdminTicketViewModel(AdminFilterTicketViewModel filter);

        //Add Ticket From Admin Panel 
        Task<bool> AddTicketFromAdminPanel(AddTicketViewModel addTicket, ulong adminId);

        //Get Ticket Messages For Admin 
        Task<List<TicketMessage>> GetTicketMessages(ulong ticketId);

        //Create Answer Ticket From Admin 
        Task<bool> CreateAnswerTicketAdmin(AnswerTicketAdminViewModel answer, ulong userId);

        //Change On Working Ticket Status
        Task<bool> ChangeOnWorkingTicketStatus(ulong ticketId);

        //Delete Ticket Message 
        Task<bool> DeleteTicketMessage(ulong messageId);

        #endregion
    }
}
