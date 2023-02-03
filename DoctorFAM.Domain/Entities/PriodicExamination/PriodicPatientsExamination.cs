using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.PriodicExamination
{
    public class PriodicPatientsExamination : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong MedicalExaminationId { get; set; }

        public DateTime LastPatientMedicalExamination { get; set; }

        public DateTime NextExaminationDate { get; set; }

        public ulong? DoctorUserId { get; set; }

        [MaxLength(500)]
        public string? LabelName { get; set; }

        #endregion

        #region relation 

        public MedicalExamination MedicalExamination { get; set; }

        #endregion
    }
}
