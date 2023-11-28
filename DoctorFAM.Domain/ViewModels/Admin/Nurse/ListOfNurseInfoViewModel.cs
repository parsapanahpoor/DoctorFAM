using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.Admin.Doctor
{
    public class ListOfNurseInfoViewModel : BasePaging<Organization>
    {
        #region Ctor

        public ListOfNurseInfoViewModel()
        {
            NurseState = NurseState.All;
        }

        #endregion

        #region properties

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? NationalCode { get; set; }

        public NurseState NurseState { get; set; }

        #endregion
    }

    public enum NurseState
    {
        [Display(Name = "Accepted")]
        Accepted,
        [Display(Name = "WaitingForConfirm")]
        WaitingForConfirm,
        [Display(Name = "Rejected")]
        Rejected,
        [Display(Name = "All")]
        All
    }
}
