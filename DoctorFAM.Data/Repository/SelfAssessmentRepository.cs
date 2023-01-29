using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.SelfAssessment;
using DoctorFAM.Domain.Interfaces.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class SelfAssessmentRepository : ISelfAssessmentRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public SelfAssessmentRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Blood Pressure Self Assessment 

        #region Site Side 

        //Add Blood Pressure Self Assessment To The Data Base 
        public async Task AddBloodPressureSelfAssessmentToTheDataBase(BloodPressureSelfAssessment model)
        {
            await _context.BloodPressureSelfAssessments.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        #endregion

        #endregion

        #region Diabet Self Assessment 

        #region Site Side 

        //Add Diabet Self Assessment To The Data Base 
        public async Task AddDiabetSelfAssessmentToTheDataBase(DiabetSelfAssessment model)
        {
            await _context.DiabetSelfAssessments.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region User Panel 



        #endregion

        #endregion
    }
}
