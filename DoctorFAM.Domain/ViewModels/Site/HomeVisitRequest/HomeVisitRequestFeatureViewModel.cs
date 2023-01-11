using DoctorFAM.Domain.Entities.SiteSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Site.HomeVisitRequest
{
    public class HomeVisitRequestFeatureViewModel
    {
        #region propreties

        [Display(Name = "کد درخواست")]
        public ulong RequestId { get; set; }

        [Display(Name = "پزشک خانم")]
        public bool FemalePhysician { get; set; }

        [Display(Name = "ویزیت اورژانسی")]
        public bool EmergencyVisit { get; set; }

        public List<TariffForHealthHouseServices>? ListOfTariffs { get; set; }

        public List<TariffForHealthHouseServices>? ListOfUserSelectedTAriff { get; set; }

        #endregion
    }
}
