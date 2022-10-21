using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem
{
    public class UserInsertedFromParsaSystem : BaseEntity
    {
        #region properties

        public ulong DoctorUserId { get; set; }

        public bool SMSSent { get; set; }

        public DateTime SMSSentDate { get; set; }

        public bool ShowInDashboard { get; set; }

        [MaxLength(20)]
        public string? PatientMobile { get; set; }

        public string? PatientFirstName { get; set; }

        public string? PatientLastName { get; set; }

        public string? PatientNationalId { get; set; }

        public bool IsRegisteredUser { get; set; }

        public bool HasAnyFamilyDoctor { get; set; }

        #endregion

        #region relation

        [ForeignKey("DoctorUserId")]
        public User User { get; set; }

        #endregion
    }
}
