using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Doctor.Follow
{
    public class IsUserFollowedViewModel
    {
        #region properties

        public ulong TargetUserId { get; set; }

        public bool IsUserFollowed{ get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public string? AreaName { get; set; }

        #endregion
    }
}
