using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Application.Services.Interfaces
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Interfaces.EFCore;

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



        #endregion

        #region User Panel

        #endregion
    }
}
