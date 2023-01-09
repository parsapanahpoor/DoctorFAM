using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IMedicalExaminationRepository
    {
        #region Admin side 

        //Create Medical Examination 
        Task CreateMedicalExamination(MedicalExamination model);

        //Filter Medical Examination 
        Task<FilterMedicalExaminationAdminSideViewModel> FilterMedicalExamination(FilterMedicalExaminationAdminSideViewModel filter);

        //Get Medical Examination By Id 
        Task<MedicalExamination?> GetMedicalExaminationById(ulong medicalExaminationId);

        //Edit Medical Examination Admin Side 
        Task EditMedicalExaminationAdminSide(MedicalExamination model);

        #endregion
    }
}
