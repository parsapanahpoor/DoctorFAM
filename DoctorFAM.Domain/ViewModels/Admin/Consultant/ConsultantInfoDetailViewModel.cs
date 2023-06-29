using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.WorkAddress;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.Consultant
{
    public class ConsultantInfoDetailViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public ulong UserId { get; set; }

        public ulong ConsultantId { get; set; }

        [Display(Name = "NationalId")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The entered national code is not valid")]
        public string NationalCode { get; set; }

        [Display(Name = "education")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string? Education { get; set; }

        [Display(Name = "Work Address")]
        public List<WorkAddress>? WorkAddresses { get; set; }

        [Display(Name = "The reason for the rejection of the information ")]
        public string? RejectDescription { get; set; }

        public OrganizationInfoState ConsultantInfosType { get; set; }

        public int? InPersonReservationTariffForDoctorPopulationCovered { get; set; }

        public int? OnlineReservationTariffForDoctorPopulationCovered { get; set; }

        public int? InPersonReservationTariffForAnonymousPersons { get; set; }

        public int? OnlineReservationTariffForAnonymousPersons { get; set; }

        public List<DoctorsInterestInfo>? DoctorsInterests { get; set; }

        #endregion
    }

    public enum EditConsultantInfoResult
    {
        success,
        faild,
        NationalId,
        InpersonReservationPopluationCoveredLessThanSiteShare,
        OnlineReservationPopluationCoveredLessThanSiteShare,
        InpersonReservationAnonymousePersoneLessThanSiteShare,
        OnlineReservationAnonymousePersoneLessThanSiteShare
    }
}
