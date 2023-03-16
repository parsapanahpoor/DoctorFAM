using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.A1C
{
    public class LogForUsersA1C : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public decimal A1C { get; set; }

        #endregion
    }
}
