using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoctorFAM.Application.Services.Implementation
{
    public class MedicalExaminationService : IMedicalExaminationService
    {
        #region Ctor 

        private readonly IMedicalExaminationRepository _medicalExamination;

        public MedicalExaminationService(IMedicalExaminationRepository medicalExamination)
        {
            _medicalExamination = medicalExamination;
        }

        #endregion

        #region Admin Side 

        //Create Medical Examination From Admin 
        public async Task<bool> CreateMedicalExaminationFromAdmin(CreateMEdicalExaminationAdminSideViewModel model)
        {
            #region Fill Entity

            Domain.Entities.PriodicExamination.MedicalExamination entity = new Domain.Entities.PriodicExamination.MedicalExamination()
            {
                MedicalExaminationName = model.MEdicalExaminationName.SanitizeText(),
                PriodMonth = model.PriodMonth
            };

            #endregion

            #region Add To The Data Base 

            await _medicalExamination.CreateMedicalExamination(entity);

            #endregion

            return true;
        }

        //Filter Medical Examination 
        public async Task<FilterMedicalExaminationAdminSideViewModel> FilterMedicalExamination(FilterMedicalExaminationAdminSideViewModel filter)
        {
            return await _medicalExamination.FilterMedicalExamination(filter);
        }

        //Get Medical Examination By Id 
        public async Task<MedicalExamination?> GetMedicalExaminationById(ulong medicalExaminationId)
        {
            return await _medicalExamination.GetMedicalExaminationById(medicalExaminationId);
        }

        //Fill Edit Medical Examination Admin Side View Model 
        public async Task<EditMedicalExaminationAdminSideViewModel?> FillEditMedicalExaminationAdminSideViewModel(ulong medicalExaminationId)
        {
            #region Get Medical Examination  

            var medical = await GetMedicalExaminationById(medicalExaminationId);
            if (medical == null) return null;

            #endregion

            #region Fill View Model 

            EditMedicalExaminationAdminSideViewModel returnModel = new EditMedicalExaminationAdminSideViewModel()
            {
                ExaminationId = medical.Id,
                MedicalExaminationName = medical.MedicalExaminationName,
                PriodMonth = medical.PriodMonth
            };

            #endregion

            return returnModel; 
        }

        //Edit Medical Examination Admin Side
        public async Task<bool> EditMedicalExaminationAdminSide(EditMedicalExaminationAdminSideViewModel model)
        {
            #region Get Medical Examination  

            var medical = await GetMedicalExaminationById(model.ExaminationId);
            if (medical == null) return false;

            #endregion

            #region Update Medical Examination Fields

            medical.MedicalExaminationName = model.MedicalExaminationName;
            medical.PriodMonth = model.PriodMonth;

            #endregion

            //Update Medical Examination Method 
            await _medicalExamination.EditMedicalExaminationAdminSide(medical) ;
        
            return true;
        }

        //Delete Medical Examination Admin Side 
        public async Task<bool> DeleteMedicalExaminationAdminSide(ulong medicalExamination)
        {
            #region Get Medical Examination  

            var medical = await GetMedicalExaminationById(medicalExamination);
            if (medical == null) return false;

            #endregion

            #region Delete Medical Examination Fields

            medical.IsDelete = true;

            #endregion

            //Update Medical Examination Method 
            await _medicalExamination.EditMedicalExaminationAdminSide(medical);

            return true;
        }

        #endregion

        #region User Panel

        #endregion
    }
}
