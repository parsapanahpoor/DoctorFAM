using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.DrugAlert
{
    public enum DrugAlertDurationType
    {
        [Display(Name ="روزانه")]
        Daily,

        [Display(Name = "هفتگی")]
        Weekly,

        [Display(Name = "ماهانه")]
        Monthly,

        [Display(Name = "سالانه")]
        Yearly
    }
}
