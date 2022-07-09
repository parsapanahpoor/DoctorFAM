using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Gender
{
    public enum Gender
    {
        [Display(Name = "male")]
        Male,
        [Display(Name = "female")]
        Female
    }
}
