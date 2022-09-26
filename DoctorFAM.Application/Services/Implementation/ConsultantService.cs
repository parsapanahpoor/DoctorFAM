using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class ConsultantService : IConsultantService
    {
        #region Ctor

        private readonly IConsultantRepository _consultantRepository;

        public ConsultantService(IConsultantRepository consultantRepository)
        {
            _consultantRepository = consultantRepository;
        }

        #endregion

        #region Consultant Panel Side



        #endregion
    }
}
