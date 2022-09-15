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

    public enum FamilyDoctorRequestStateAdminFilter
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Accepted")]
        Accepted,
        [Display(Name = "Decline")]
        Decline,
        [Display(Name = "WaitingForConfirm")]
        WaitingForConfirm,
    }

    public enum FamilyDoctorRequestDeleteState
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Deleted")]
        Deleted,
        [Display(Name = "NotDeleted")]
        NotDeleted
    }
}
