using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo
{
    public class ListOfDoctorsInfoViewModel : BasePaging<Organization>
    {
        #region Ctor

        public ListOfDoctorsInfoViewModel()
        {
            DoctorsState = DoctorsState.All;
        }

        #endregion

        #region properties

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? NationalCode { get; set; }

        public int? MedicalSystemCode { get; set; }

        public int? CountOfAcceptedDoctors { get; set; }

        public int? CountOfNewRegisterDoctors { get; set; }

        public int? CountOfDeclineDoctors { get; set; }

        public int? CountOfWaitingDoctors { get; set; }

        public int? CountOfDeletedDoctors { get; set; }

        public DoctorsState DoctorsState { get; set; }

        #endregion
    }

    public enum DoctorsState
    {
        [Display(Name = "Accepted")]
        Accepted,
        [Display(Name = "WaitingForConfirm")]
        WaitingForConfirm,
        [Display(Name = "Rejected")]
        Rejected,
        [Display(Name = "ثبت نامی جدید")]
        NewRegister,
        [Display(Name = "All")]
        All
    }
}
