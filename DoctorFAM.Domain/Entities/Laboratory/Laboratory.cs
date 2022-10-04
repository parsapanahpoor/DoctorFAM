using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Laboratory
{
    public class Laboratory : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        #endregion

        #region relations

        public User User { get; set; }

        public LaboratoryInfo LaboratoryInfo { get; set; }

        #endregion
    }
}
