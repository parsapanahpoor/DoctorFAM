using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.InsuranceType
{
    public enum InsuranceType
    {
        [Display(Name = "Free")]
        Free,
        [Display(Name = "Health Insurance")]
        Salamat,
        [Display(Name = "Social Security")]
        Tamin,
        [Display(Name = "Self-employed")]
        FreeJobs,
        [Display(Name = "Iranian health")]
        Iranian
    }
}
