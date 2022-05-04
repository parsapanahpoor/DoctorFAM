using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.InsuranceType
{
    public enum InsuranceType
    {
        [Display(Name = "آزاد")]
        Free,
        [Display(Name = "بیمه سلامت")]
        Salamat,
        [Display(Name = "تامین اجتماعی")]
        Tamin,
        [Display(Name = "مشاغل آزاد")]
        FreeJobs,
        [Display(Name = "سلامت ایرانیان")]
        Iranian
    }
}
