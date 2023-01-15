using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class PeriodicSelftEvaluationService : IPeriodicSelftEvaluationService
    {
        #region Ctor

        private readonly IPeriodicSelftEvaluationRepository _periodicSelftEvaluationRepository;

        public PeriodicSelftEvaluationService(IPeriodicSelftEvaluationRepository periodicSelftEvaluationRepository)
        {
            _periodicSelftEvaluationRepository = periodicSelftEvaluationRepository;
        }

        #endregion

        #region Admin Side 



        #endregion
    }
}
