#region Using

using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Location;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.Interest;

#endregion

public class FilterInterestAdminSideViewModel : BasePaging<DoctorsInterestInfo>
{
    #region properties

    public string? Title { get; set; }

    public InterestStatus InterestStatus { get; set; }

    public Entities.Interest.DoctorsInterest ParentInterest { get; set; }

    #endregion
}

public enum InterestStatus
{
    [Display(Name = "همه")] All,
    [Display(Name = "قابل نمایش")] NotDeleted,
    [Display(Name = "غیرقابل نمایش")] Deleted,
}
