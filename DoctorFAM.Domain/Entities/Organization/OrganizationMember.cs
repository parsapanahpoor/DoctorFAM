using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Organization
{
    public class OrganizationMember : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong OrganizationId { get; set; }

        #endregion

        #region relations

        public User User { get; set; }

        public Organization Organization { get; set; }

        #endregion
    }
}
