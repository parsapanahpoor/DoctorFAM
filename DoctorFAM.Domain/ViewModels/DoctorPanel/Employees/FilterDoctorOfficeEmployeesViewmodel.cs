using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Employees
{
    public class FilterDoctorOfficeEmployeesViewmodel : BasePaging<OrganizationMember>
    {
        #region properties

        public ulong userId { get; set; }

        [Display(Name = "Username")]
        public string? Username { get; set; }

        [Display(Name = "Mobile")]
        public string? Mobile { get; set; }

        #endregion
    }
}
