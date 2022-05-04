using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.InsuranceType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Patient
{
    public class Patient :BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public string PatientName { get; set; }

        public string PatientLastName { get; set; }

        public string NationalId { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public InsuranceType InsuranceType { get; set; }

        public string RequestDescription { get; set; }

        public ulong? RequestId { get; set; }

        #endregion

        #region Relation 

        [ForeignKey("RequestId")]
        public Request Request { get; set; }

        public User User { get; set; }

        public ICollection<PaitientRequestDetail> PaitientRequestDetails { get; set; }

        #endregion
    }
}
