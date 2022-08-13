using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Notification
{
    public class SendSupporterNotificationViewModel 
    {
        #region properties

        public string Username { get; set; }

        public string CreateNotificationDate { get; set; }

        public string NotificationText { get; set; }

        public ulong RequestId { get; set; }

        public string? UserImage { get; set; }

        #endregion
    }
}
