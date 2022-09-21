using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Ticket
{
    public class UserPanelTicketDetailViewModel
    {
        public string TicketTitle { get; set; }

        public string CreateDate { get; set; }

        public string Status { get; set; }

        public int MessagesCount { get; set; }

        public ulong OwnerId { get; set; }

        public List<TicketMessage> TicketMessages { get; set; }

        public TicketStatus TicketStatus { get; set; }
    }
}
