using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.CooperationRequest
{
    public class SendCooperationRequestViewModel
    {
        #region properties

        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "موبایل وارد شده معتبر نمی باشد")]
        public string Mobile { get; set; }

        public string Username { get; set; }

        public string RoleName { get; set; }

        #endregion
    }
}
