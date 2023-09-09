#region Using

using DoctorFAM.Domain.Entities.PriodicExamination;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token;

#endregion

public class ImportingTokenInformationTouristSideViewModele
{
    #region properties

    [Display(Name = "تاریخ شروع")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The information entered is not valid.")]
    public string StartDate { get; set; }

    [Display(Name = "تاریخ پایان")]
    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^\d{4}\/(0?[1-9]|1[012])\/(0?[1-9]|[12][0-9]|3[01])$", ErrorMessage = "The information entered is not valid.")]
    public string EndDate { get; set; }

    public string? TokenLabel { get; set; }

    #endregion
}
