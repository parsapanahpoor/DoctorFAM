using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Organization
{
    public class Organization : BaseEntity
    {
        #region properties

        public ulong OwnerId { get; set; }

        public OrganizationType OrganizationType { get; set; }

        public OrganizationInfoState OrganizationInfoState { get; set; }

        public string? RejectDescription { get; set; }

        #endregion

        #region relations

        [ForeignKey("OwnerId")]
        public User User { get; set; }

        public ICollection<OrganizationMember> OrganizationMembers { get; set; }

        #endregion
    }
}
