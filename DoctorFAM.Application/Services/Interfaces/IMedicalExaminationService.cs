using DoctorFAM.Domain.Entities.PriodicExamination;
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

        //Get Medical Examination By Id 
        Task<MedicalExamination?> GetMedicalExaminationById(ulong medicalExaminationId);

        //Fill Edit Medical Examination Admin Side View Model 
        Task<EditMedicalExaminationAdminSideViewModel?> FillEditMedicalExaminationAdminSideViewModel(ulong medicalExaminationId);

        //Edit Medical Examination Admin Side
        Task<bool> EditMedicalExaminationAdminSide(EditMedicalExaminationAdminSideViewModel model);

        //Delete Medical Examination Admin Side 
        Task<bool> DeleteMedicalExaminationAdminSide(ulong medicalExamination);

        #endregion

        #region User Panel Side



        #endregion
    }
}
