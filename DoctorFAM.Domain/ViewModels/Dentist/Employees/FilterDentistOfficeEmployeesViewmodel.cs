#region Usings

using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

#endregion

namespace DoctorFAM.Domain.ViewModels.Dentist.Employees;

public class FilterDentistOfficeEmployeesViewmodel : BasePaging<OrganizationMember>
{
    #region properties

    public ulong userId { get; set; }

    [Display(Name = "Username")]
    public string? Username { get; set; }

    [Display(Name = "Mobile")]
    public string? Mobile { get; set; }

    #endregion
}
