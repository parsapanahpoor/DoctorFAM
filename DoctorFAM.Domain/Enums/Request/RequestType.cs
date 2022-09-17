using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.RequestType
{
    public enum RequestType
    {
        [Display(Name = "ویزیت در منزل")]
        HomeVisit,
        [Display(Name = "پرستاری در منزل")]
        HomeNurse,
        [Display(Name = "داروخانه در منزل")]
        HomeDrog,
        [Display(Name = "آزمایشگاه در منزل")]
        HomeLab,
        [Display(Name = "انتقال بیمار و متوفی")]
        PatientTransfer,
        [Display(Name = "گواهی فوت")]
        DeathCertificate,
        [Display(Name = "ویزیت آنلاین")]
        OnlineVisit
    }
}
