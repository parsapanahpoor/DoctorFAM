using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Contact
{
    public class TicketMessage : BaseEntity
    {
        #region Properties

        public ulong TicketId { get; set; }

        public ulong SenderId { get; set; }

        [Display(Name = "متن پیام")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string? Message { get; set; }

        public string? MessageFile { get; set; }

        #endregion

        #region Relations

        public Ticket Ticket { get; set; }

        public User Sender { get; set; }

        #endregion
    }
}
