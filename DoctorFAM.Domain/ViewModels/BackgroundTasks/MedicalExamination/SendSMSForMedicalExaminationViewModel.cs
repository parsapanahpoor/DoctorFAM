using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.BackgroundTasks.MedicalExamination
{
    public class SendSMSForMedicalExaminationViewModel
    {
        #region properties

        public ulong? MedicalExaminationId { get; set; }

        public string? MedicalExaminationName { get; set; }

        public string? Mobile { get; set; }

        #endregion
    }
}
