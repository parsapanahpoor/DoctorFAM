using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums
{
    public enum TicketStatus
    {
        [Display(Name = "پاسخ داده شده")] Answered = 1,
        [Display(Name = "درانتظار پاسخ")] Pending = 2,
        [Display(Name = "بسته شده")] Closed = 3
    }
}
