using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.PriodicExamination
{
    public class MedicalExamination : BaseEntity
    {
        #region properties

        [MaxLength(300)]
        public string MedicalExaminationName { get; set; }

        public int PriodMonth { get; set; }

        #endregion

        #region Relations



        #endregion
    }
}
