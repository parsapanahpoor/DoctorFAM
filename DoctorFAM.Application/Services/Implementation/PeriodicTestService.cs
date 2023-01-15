using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class PeriodicTestService : IPeriodicTestService
    {
        #region Ctor

        private readonly IPeriodicTestRepository _periodicTestRepository;

        public PeriodicTestService(IPeriodicTestRepository periodicTestRepository)
        {
            _periodicTestRepository = periodicTestRepository;
        }

        #endregion

        #region Site Side 



        #endregion
    }
}
