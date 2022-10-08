using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Gender;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Doctors
{
    public class DoctorsInfo : BaseEntity
    {
        #region properties

        public ulong DoctorId { get; set; }

        public string NationalCode { get; set; }

        public string MedicalSystemCode { get; set; }

        public string Education { get; set; }

        public string? Specialty { get; set; }

        public string MediacalFile { get; set; }

        public Gender Gender { get; set; }

        #endregion

        #region Relations

        public Doctor Doctor { get; set; }

        #endregion
    }

    public enum OrganizationInfoState
    {
        [Display(Name = "Accepted")]
        Accepted,
        [Display(Name = "WaitingForConfirm")]
        WatingForConfirm,
        [Display(Name = "Rejected")]
        Rejected,
        [Display(Name = "Register Now")]
        JustRegister
    }
}
