using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.CooperationRequest
{
    public class CooperationRequest : BaseEntity
    {
        #region properties

        public string Mobile { get; set; }

        public string UserName { get; set; }

        public string RoleTitle { get; set; }

        public bool FollowedUp { get; set; }

        #endregion

        #region Relations

        #endregion
    }
}
