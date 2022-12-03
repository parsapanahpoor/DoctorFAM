
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.ResumeState
{
    public enum ResumeState
    {
        [Display(Name = "Accepted")]
        Accepted,
        [Display(Name = "Decline")]
        Decline,
        [Display(Name = "WaitingForConfirm")]
        WaitingForConfirm,
    }
}
