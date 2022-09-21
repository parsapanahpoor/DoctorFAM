using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Tikcet;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
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
    }
}
