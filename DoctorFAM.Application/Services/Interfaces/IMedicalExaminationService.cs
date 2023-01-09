using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IMedicalExaminationService 
    {
        #region Admin Side 

        //Create Medical Examination From Admin 
        Task<bool> CreateMedicalExaminationFromAdmin(CreateMEdicalExaminationAdminSideViewModel model);


        //Filter Medical Examination 
        Task<FilterMedicalExaminationAdminSideViewModel> FilterMedicalExamination(FilterMedicalExaminationAdminSideViewModel filter);

        #endregion

        #region User Panel Side



        #endregion
    }
}
