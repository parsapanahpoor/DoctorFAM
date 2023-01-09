using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

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

        #endregion

        #region User Panel

        #endregion
    }
}
