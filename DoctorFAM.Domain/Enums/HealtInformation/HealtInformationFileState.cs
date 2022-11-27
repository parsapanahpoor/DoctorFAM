using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.HealtInformation
{
    public enum HealtInformationFileState
    {
        [Display(Name ="تایید شده")]
        Accepted,
        [Display(Name = "درانتظار تایید")]
        WaitingForConfirm,
        [Display(Name = "تایید نشده")]
        Rejected
    }
}
