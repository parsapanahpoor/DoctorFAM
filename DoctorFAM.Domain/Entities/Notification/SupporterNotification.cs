using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Notification;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Notification
{
    public class SupporterNotification : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong ReciverId { get; set; }

        //This Is For Any Request Id Or etc ... 
        public ulong TargetId { get; set; }

        public bool IsSeen { get; set; }

        public SupporterNotificationText SupporterNotificationText { get; set; }

        #endregion

        #region realtions 

        public User User { get; set; }


        #endregion
    }
}
