using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.MedicalExamination
{
    public class FilterMedicalExaminationAdminSideViewModel : BasePaging<Domain.Entities.PriodicExamination.MedicalExamination>
    {
        public string? MEdicalExaminationName { get; set; }
    }
}
