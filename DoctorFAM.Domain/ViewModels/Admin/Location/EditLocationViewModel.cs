
using DoctorFAM.Domain.Entities.States;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Location
{
    public class EditLocationViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [DisplayName("Unique Name")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string UniqueName { get; set; }

        public List<LocationInfo> CurrentInfos { get; set; }

        public List<EditeLocationInfoViewModel> LocationInfo { get; set; }

        [DisplayName("Home Visit")]
        public bool HomeVisit { get; set; }

        [DisplayName("Home Nurse")]
        public bool HomeNurse { get; set; }

        [DisplayName("Pharmacy At Home")]
        public bool HomePharmacy { get; set; }

        [DisplayName("Laboratory At Home")]
        public bool HomeLaboratory { get; set; }

        [DisplayName("Death Certificate")]
        public bool DeathCertificate { get; set; }

        [DisplayName("Patient Transport")]
        public bool HomePatientTransport { get; set; }

        public ulong? ParentId { get; set; }

        #endregion
    }

    public class EditeLocationInfoViewModel : BaseInfoViewModel
    {
        [Display(Name = "Location title")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string Title { get; set; }
    }

    public enum EditLocationResult
    {
        Success,
        Fail,
        UniqNameIsExist
    }
}
