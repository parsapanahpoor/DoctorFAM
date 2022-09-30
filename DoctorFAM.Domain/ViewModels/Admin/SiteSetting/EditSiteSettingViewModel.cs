using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.SiteSetting
{
    public class EditSiteSettingViewModel
    {
        [Display(Name = "Copyright text")]
        public string? CopyRightText { get; set; }

        [Display(Name = "Tariff for home visits in Rials")]
        public int? HomeVisitTariff { get; set; }

        [Display(Name = "Tariff for issuance of death certificate in Rials")]
        public int? DeathCertificateTariff { get; set; }

        [Display(Name = "Laboratory fee at home in Rials")]
        public int? HomeLaboratoryTariff { get; set; }

        [Display(Name = "The tariff of the nurse at home is in Rials")]
        public int? HomeNurseTariff { get; set; }

        [Display(Name = "Patient transfer fee in Rials")]
        public int? HomePatientTransportTariff { get; set; }

        [Display(Name = "Pharmacy tariff at home in Rials")]
        public int? HomePharmacyTariff { get; set; }

        [Display(Name = "Reservation tariff in Rials")]
        public int? ReservationTariff { get; set; }

        [Display(Name = "Send SMS Time")]
        public int? SendSMSTime { get; set; }

        [Display(Name = "Site Domain Address")]
        public string? SiteDomain { get; set; }

        [Display(Name = "Online Visit tariff in Rials")]
        public int? OnlineVisitTariff { get; set; }

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

    public enum EditSiteSettingResult
    {
        Success,
        Fail
    }
}
