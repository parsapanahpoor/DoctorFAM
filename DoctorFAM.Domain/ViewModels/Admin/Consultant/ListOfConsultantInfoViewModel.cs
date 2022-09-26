using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Consultant
{
    public class ListOfConsultantInfoViewModel : BasePaging<Organization>
    {
        #region Ctor

        public ListOfConsultantInfoViewModel()
        {
            ConsultantState = ConsultantState.All;
        }

        #endregion

        #region properties

        public string? FullName { get; set; }

        public string? Email { get; set; }

        public string? Mobile { get; set; }

        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public string? NationalCode { get; set; }

        public ConsultantState ConsultantState { get; set; }

        #endregion
    }

    public enum ConsultantState
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
