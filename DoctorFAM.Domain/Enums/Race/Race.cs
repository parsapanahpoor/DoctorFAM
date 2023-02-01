using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Enums.Race
{
    public enum Race
    {
        [Display(Name = " سفید پوست و سایر")]
        White,
        [Display(Name = "سیاه پوست")]
        AfricanAmericans
    }
}
