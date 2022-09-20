using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.OnlineVisitRequest;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit
{
    public class FilterOnlineVisitViewModel : BasePaging<Request>
    {
        #region properties

        public ulong? UserId { get; set; }

        public ulong? CountryId { get; set; }

        public ulong? CityId { get; set; }

        public ulong? StateId { get; set; }

        public string? Username { get; set; }

        public string? UserMobile { get; set; }

        public FilterRequestAdminSideOrder FilterRequestAdminSideOrder { get; set; }

        public OnlineVisitRequestTypeForFilter OnlineVisitRequestTypeForFilter { get; set; }

        #endregion
    }

    public enum OnlineVisitRequestTypeForFilter
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "EmergencyConsultation")]
        EmergencyConsultation,
        [Display(Name = "DiseaseCounseling")]
        DiseaseCounseling,
        [Display(Name = "DrugCounseling")]
        DrugCounseling,
        [Display(Name = "ParaclinicalCounseling")]
        ParaclinicalCounseling,
        [Display(Name = "PsychologicalCounseling")]
        PsychologicalCounseling,
    }
}
