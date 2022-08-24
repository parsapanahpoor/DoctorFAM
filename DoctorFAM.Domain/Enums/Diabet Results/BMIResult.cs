using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Diabet_Results
{
    public enum BMIResult
    {
        [Display(Name = "Underweight")]
        Underweight,
        [Display(Name = "Appropriate")]
        Appropriate,
        [Display(Name = "Overweight")]
        Overweight,
        [Display(Name = "fat")]
        fat,
        [Display(Name = "ExcessiveObesity")]
        ExcessiveObesity
    }
}
