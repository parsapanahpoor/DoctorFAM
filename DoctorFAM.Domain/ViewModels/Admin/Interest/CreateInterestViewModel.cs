#region Using

using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.Interest;

#endregion

public class CreateInterestViewModel
{
    public List<CreateInterestInfoViewModel> InterestInfo { get; set; }

    [DisplayName("نمایش در پنل پزشک")]
    public bool DoctorPanel { get; set; }

    [DisplayName("نمایش در پنل مشاور")]
    public bool ConsultantPanel { get; set; }
}

public class CreateInterestInfoViewModel : BaseInfoViewModel
{
    [Display(Name = "عنوان علاقه مندی")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
    public string Title { get; set; }
}

public enum CreateInterestResult
{
    Success,
    Fail,
}
