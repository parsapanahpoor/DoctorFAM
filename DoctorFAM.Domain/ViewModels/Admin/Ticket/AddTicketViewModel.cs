using DoctorFAM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Ticket
{
    public class AddTicketViewModel
    {
        #region Properties

        [Display(Name = "Sender")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong? userId { get; set; }

        public string? userName { get; set; }

        [Display(Name = "Title")]
        [MaxLength(200, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string Title { get; set; }

        [Display(Name = "Ticket State")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public TicketStatus TicketStatus { get; set; }

        public bool IsReadByAdmin { get; set; }

        public bool IsReadByOwner { get; set; }

        public bool OnWorking { get; set; }

        [Display(Name = "Message")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string Message { get; set; }

        #endregion
    }

}
