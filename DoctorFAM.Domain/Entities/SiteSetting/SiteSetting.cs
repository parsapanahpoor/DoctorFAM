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

        public int OnlineVisitTariff { get; set; }

        public int DeathCertificateTariff { get; set; }

        public int HomeLaboratoryTariff { get; set; }

        public int HomeNurseTariff { get; set; }

        public int HomePatientTransportTariff { get; set; }

        public int HomePharmacyTariff { get; set; }

        public int ReservationTarrif { get; set; }

        [Display(Name = "تایم  ارسال اس ام اس ")]
        public int SendSMSTimer { get; set; }

        public string SiteDomain { get; set; }

        [Display(Name = "تعرفه به ازای فاصله از شهر")]
        public int DistanceFromCityTarriff { get; set; }

        [Display(Name = "تعداد پیامک رایگان برای ارسال از پزشک به بیماران")]
        public int CountOFFreeSMSForDoctors { get; set; }

        [Display(Name = "سهم وب سایت از نوبت دهی حضوری بیماران تحت پوشش پزشک خانواده")]
        public int InPersonReservationTariffForDoctorPopulationCoveredSiteShare { get; set; }

        [Display(Name = "سهم وب سایت از نوبت دهی آنلاین بیماران تحت پوشش پزشک خانواده")]
        public int OnlineReservationTariffForDoctorPopulationCoveredSiteShare { get; set; }

        [Display(Name = "سهم وب سایت از نوبت دهی حضوری بیماران ناشناس")]
        public int InPersonReservationTariffForAnonymousPersonsSiteShare { get; set; }

        [Display(Name = "سهم وب سایت از نوبت دهی آنلاین بیماران ناشناس")]
        public int OnlineReservationTariffForAnonymousPersonsSiteShare { get; set; }

        [Display(Name = "موجودی صندوق سایت")]
        public int SiteCashDesk { get; set; }

        [Display(Name = "سهم وب سایت از ویزیت در منزل")]
        public int HomeVisitSiteShare { get; set; }

        [Display(Name = "مبلغ غیرقابل برداشت")]
        public int WalletLockPrice { get; set; }
    }
}
