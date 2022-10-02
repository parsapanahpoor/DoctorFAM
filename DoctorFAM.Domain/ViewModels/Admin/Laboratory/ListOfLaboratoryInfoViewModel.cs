using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Laboratory
{
    public class ListOfLaboratoryInfoViewModel : BasePaging<Organization>
    {
        #region Ctor

        public ListOfLaboratoryInfoViewModel()
        {
            LaboratoryState = LaboratoryState.All;
        }

        #endregion

        #region properties

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? NationalCode { get; set; }

        public LaboratoryState LaboratoryState { get; set; }

        #endregion
    }

    public enum LaboratoryState
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
