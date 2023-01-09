using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class MedicalExaminationRepository : IMedicalExaminationRepository
    {
        #region Ctor 

        private readonly DoctorFAMDbContext _context;

        public MedicalExaminationRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin Side 



        #endregion

        #region User Panel Side 



        #endregion

        #region Doctor Side 



        #endregion
    }
}
