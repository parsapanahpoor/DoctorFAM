using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;

public class CreateDoctorSelectedOnlineVisitShiftDateViewModel
{
    #region properties

    [Display(Name = "تاریخ انتخابی")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "اطلاعات وارد شده صحیح نمی باشد.")]
    public string SelectedDateTime { get; set; }

    public List<ulong> OnlineVisitWorkShiftDetailId { get; set; }

    #endregion
}

public enum CreateDoctorSelectedOnlineVisitShiftDateViewModelResult
{
    LaterSelectedDate,
    DuplicateRecord,
    Success,
    Faild
}
