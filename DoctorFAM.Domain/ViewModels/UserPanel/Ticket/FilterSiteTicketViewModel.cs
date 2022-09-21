using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.UserPanel.Ticket
{
    public class FilterSiteTicketViewModel : BasePaging<Entities.Contact.Ticket>
    {
        public FilterSiteTicketViewModel()
        {
            UserTicketFilterStatus = UserTicketFilterStatus.All;
            UserTicketFilterOnWorkingStatus = UserTicketFilterOnWorkingStatus.All;
        }

        public UserTicketFilterStatus UserTicketFilterStatus { get; set; }

        public UserTicketFilterOnWorkingStatus UserTicketFilterOnWorkingStatus { get; set; }

        public string? TicketTitle { get; set; }

    }
    public enum UserTicketFilterStatus
    {
        [Display(Name = "All")] All,
        [Display(Name = "Answered")] Answered,
        [Display(Name = "On Working")] Pending,
        [Display(Name = "Closed")] Closed
    }

    public enum UserTicketFilterOnWorkingStatus
    {
        [Display(Name = "All")] All,
        [Display(Name = "On Working")] OnWorking,
        [Display(Name = "NotWorking")] NotWorking
    }
}
