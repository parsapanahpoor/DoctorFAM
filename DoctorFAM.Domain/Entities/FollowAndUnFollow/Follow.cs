using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.FollowAndUnFollow
{
    public class Follow : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong TargetUserId { get; set; }

        #endregion

        #region relation 



        #endregion
    }
}
