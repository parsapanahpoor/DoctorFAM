using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.FamilyDoctor;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.FamilyDoctor
{
    public class UserSelectedFamilyDoctor : BaseEntity
    {
        #region properties

        public ulong DoctorId { get; set; }

        public ulong PatientId{ get; set; }

        public string? RejectDescription { get; set; }

        public FamilyDoctorRequestState FamilyDoctorRequestState { get; set; }

        #endregion

        #region relations

        public User Doctor { get; set; }

        public User Patient { get; set; }

        #endregion
    }
}
