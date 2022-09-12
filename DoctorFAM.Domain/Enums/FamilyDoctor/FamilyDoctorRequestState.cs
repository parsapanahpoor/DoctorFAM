using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.FamilyDoctor
{
    public enum FamilyDoctorRequestState 
    {
        [Display(Name ="Accepted")]
        Accepted,

        [Display(Name = "Decline")]
        Decline,

        [Display(Name = "WaitingForConfirm")]
        WaitingForConfirm,
    }
}
