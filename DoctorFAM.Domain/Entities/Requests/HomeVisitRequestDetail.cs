using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Requests
{
    public class HomeVisitRequestDetail : BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        public bool FemalePhysician { get; set; }

        public bool EmergencyVisit { get; set; }

        [Display(Name = "تزریق عضلانی")]
        public bool IntramuscularInjection { get; set; }

        [Display(Name = "تزریق جلدی یا زیر جلدی")]
        public bool DermalOrSubcutaneousInjection { get; set; }

        [Display(Name = "تزریق ریدی")]
        public bool ReedyInjection { get; set; }

        [Display(Name = "سرم تراپی")]
        public bool SerumTherapy { get; set; }

        [Display(Name = "اندازه گیری فشار خون")]
        public bool BloodPressureMeasurement { get; set; }

        [Display(Name = "گلوکومتری")]
        public bool Glucometry { get; set; }

        [Display(Name = "پالس اکسیمتری")]
        public bool PulseOximetry { get; set; }

        [Display(Name = "پانسمان کوچک")]
        public bool SmallDressing { get; set; }

        [Display(Name = "پانسمان بزرگ")]
        public bool GreatDressing { get; set; }

        [Display(Name = "لوله گذاری معده")]
        public bool GastricIntubation { get; set; }

        [Display(Name = "سونگذاری مثانه")]
        public bool UrinaryBladder { get; set; }

        [Display(Name = "اکسیژن تراپی")]
        public bool OxygenTherapy { get; set; }

        [Display(Name = "نوار قلب")]
        public bool ECG { get; set; }

        #endregion

        #region relations 

        public Request Request{ get; set; }

        #endregion
    }
}
