using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Account
{
    public class UserRole :BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong RoleId { get; set; }

        #endregion

        #region relation

        public User User { get; set; }

        public Role Role { get; set; }

        #endregion
    }
}
