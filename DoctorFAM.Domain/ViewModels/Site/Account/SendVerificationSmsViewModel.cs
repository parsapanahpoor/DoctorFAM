using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Account
{
    public class SendVerificationSmsViewModel
    {
        #region properties

        public string Receptor { get; set; }

        public string Token { get; set; }

        #endregion
    }
}
