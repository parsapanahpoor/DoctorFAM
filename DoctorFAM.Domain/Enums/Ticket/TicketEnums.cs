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
        [Display(Name = "Answered")] Answered = 1,
        [Display(Name = "Pending")] Pending = 2,
        [Display(Name = "Closed")] Closed = 3
    }
}
