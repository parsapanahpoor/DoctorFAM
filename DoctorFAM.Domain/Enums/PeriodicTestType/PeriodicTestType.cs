using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.PeriodicTestType
{
    public enum PeriodicTestType
    {
        [Display(Name ="عمومی")]
        General,

        [Display(Name = "دیابت")]
        Diabet,

        [Display(Name = "فشار خون")]
        BloodPressure,
    }
}
