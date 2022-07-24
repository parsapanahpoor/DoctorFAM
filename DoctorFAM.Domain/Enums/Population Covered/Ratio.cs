using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Population_Covered
{
    public enum Ratio
    {
        [Display(Name = "Partner")]
        Partner,
        [Display(Name = "Child")]
        Child,
        [Display(Name ="Mother")]
        Mother, 
        [Display(Name ="Father")]
        Father ,        
        [Display(Name = "Sister")]
        Sister,
        [Display(Name = "Brother")]
        Brother
    }
}
