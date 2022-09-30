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

        [Display(Name = "تزریق عضلانی")]
        public int IntramuscularInjection { get; set; }

        [Display(Name = "تزریق جلدی یا زیر جلدی")]
        public int DermalOrSubcutaneousInjection { get; set; }

        [Display(Name = "تزریق ریدی")]
        public int ReedyInjection { get; set; }

        [Display(Name = "سرم تراپی")]
        public int SerumTherapy { get; set; }

        [Display(Name = "اندازه گیری فشار خون")]
        public int BloodPressureMeasurement { get; set; }

        [Display(Name = "گلوکومتری")]
        public int Glucometry { get; set; }

        [Display(Name = "پالس اکسیمتری")]
        public int PulseOximetry { get; set; }

        [Display(Name = "پانسمان کوچک")]
        public int SmallDressing { get; set; }

        [Display(Name = "پانسمان بزرگ")]
        public int GreatDressing { get; set; }

        [Display(Name = "لوله گذاری معده")]
        public int GastricIntubation { get; set; }

        [Display(Name = "سونگذاری مثانه")]
        public int UrinaryBladder { get; set; }

        [Display(Name = "اکسیژن تراپی")]
        public int OxygenTherapy { get; set; }

        [Display(Name = "نوار قلب")]
        public int ECG { get; set; }

        [Display(Name = "تعرفه به ازای فاصله از شهر")]
        public int DistanceFromCityTarriff { get; set; }
    }
}
