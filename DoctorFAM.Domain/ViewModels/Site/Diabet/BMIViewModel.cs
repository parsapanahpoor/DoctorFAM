using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Diabet
{
    /// <summary>
    /// para : SaveResult Has Two Result : 0 is meaning True And 1 is meaning false
    /// </summary>

    public class BMIViewModel
    {
        #region properties

        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public int Weight { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        public int Height { get; set; }

        public int SaveResult { get; set; }

        #endregion
    }
}
