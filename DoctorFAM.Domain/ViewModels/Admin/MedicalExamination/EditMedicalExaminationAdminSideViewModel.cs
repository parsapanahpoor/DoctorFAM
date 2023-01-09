using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.MedicalExamination
{
    public class EditMedicalExaminationAdminSideViewModel
    {
        #region properties

        public ulong ExaminationId { get; set; }

        public string MedicalExaminationName { get; set; }

        public int PriodMonth { get; set; }

        #endregion
    }
}
