﻿using System;
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

        [Display(Name = "موجودی حساب سایت")]
        public int? CashDesk { get; set; }

        [Display(Name = "سهم وب سایت از ویزیت در منزل")]
        public int HomeVisitSiteShare { get; set; }

        [Display(Name = "مبلغ غیرقابل برداشت از کیف پول")]
        public int WalletLockPrice { get; set; }

        [Display(Name = "تعرفه ی بلیط گردشگری به ازای هر 24 ساعت")]
        public int TouristTicketTariff { get; set; }
    }

    public enum EditSiteSettingResult
    {
        Success,
        Fail,
        InpersonReservationPopluationCoveredLessThanSiteShare,
        OnlineReservationPopluationCoveredLessThanSiteShare,
        InpersonReservationAnonymousePersoneLessThanSiteShare,
        OnlineReservationAnonymousePersoneLessThanSiteShare,
        HomeVisitSiteShareMoreThanHomeVisitTarriff
    }
}
