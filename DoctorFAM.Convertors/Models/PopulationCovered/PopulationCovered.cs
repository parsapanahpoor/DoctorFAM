using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.Enums.InsuranceType;
using DoctorFAM.Domain.Enums.Population_Covered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Convertors.Models.PopulationCovered
{
    public class PopulationCovered : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public string PatientName { get; set; }

        public string PatientLastName { get; set; }

        public string NationalId { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public InsuranceType InsuranceType { get; set; }

        public Ratio Ratio { get; set; }

        public DateTime BirthDay { get; set; }

        #endregion

        #region Relation 

        public User User { get; set; }

        #endregion
    }
}
