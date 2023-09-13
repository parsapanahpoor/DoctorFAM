using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS
{
    public class ChooseUsersForSendSMSViewModel
    {
        #region properties

        public ulong? UserId{ get; set; }

        public string Username { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Mobile { get; set; }

        public string? UserAvatar { get; set; }

        #endregion
    }
}
