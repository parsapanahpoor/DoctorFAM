#region Using

using DoctorFAM.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using DoctorFAM.Domain.Entities.Interest;

namespace DoctorFAM.Domain.ViewModels.Admin.Interest;

#endregion

public class EditInterestViewModel
{
    #region properties

    public ulong Id { get; set; }

    public List<DoctorsInterestInfo> CurrentInfos { get; set; }

    public List<EditeInterestInfoViewModel> InterestInfo { get; set; }

    [DisplayName("نمایش در پنل پزشک")]
    public bool DoctorPanelSide { get; set; }

    [DisplayName("نمایش در پنل مشاور")]
    public bool ConsultantPanelSide { get; set; }

    #endregion
}

public class EditeInterestInfoViewModel : BaseInfoViewModel
{
    [Display(Name = "عنوان علاقه مندی")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
    public string Title { get; set; }
}

public enum EditInterestResult
{
    Success,
    Fail,
}
