using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.MedicalExamination
{
    public class CreateMEdicalExaminationAdminSideViewModel
    {
        #region properties

        [Required]
        public string MEdicalExaminationName { get; set; }

        public int PriodMonth { get; set; }

        #endregion
    }
}
