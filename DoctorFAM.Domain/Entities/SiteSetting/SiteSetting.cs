using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Domain.Entities.SiteSetting
{
    public class SiteSetting : BaseEntity
    {
        [Display(Name = "متن کپی رایت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string CopyRightText { get; set; }

        [Display(Name = "تعرفه ی ویزیت در منزل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int HomeVisitTariff { get; set; }

        public int DeathCertificateTariff { get; set; }

        public int HomeLaboratoryTariff { get; set; }

        public int HomeNurseTariff { get; set; }

        public int HomePatientTransportTariff { get; set; }

        public int HomePharmacyTariff { get; set; }

        public int ReservationTarrif { get; set; }

        [Display(Name = "تایم  ارسال اس ام اس ")]
        public int SendSMSTimer { get; set; }
    }
}
