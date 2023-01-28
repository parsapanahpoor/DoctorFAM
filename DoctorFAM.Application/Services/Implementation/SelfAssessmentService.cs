using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class SelfAssessmentService : ISelfAssessmentService
    {
        #region Ctor

        private readonly ISelfAssessmentRepository _selfAssessmentRepository;

        public SelfAssessmentService(ISelfAssessmentRepository selfAssessmentRepository)
        {
            _selfAssessmentRepository = selfAssessmentRepository;
        }

        #endregion

        #region Diabet Self Assessment 

        #region Site Side 



        #endregion

        #region User Panel 



        #endregion

        #endregion
    }
}
