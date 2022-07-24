using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Employees
{
    public class AddEmployeeViewModel
    {
        #region properties

        [MaxLength(200)]
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string Password { get; set; }

        [MaxLength(200)]
        [DisplayName("Mobile")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string Mobile { get; set; }

        [DisplayName("Avatar")]
        public string? Avatar { get; set; }

        #endregion
    }
}
public enum AddNewUserResult
{
    DuplicateMobileNumber,
    Success,
}
