using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class PeriodicSelftEvaluationRepository : IPeriodicSelftEvaluationRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public PeriodicSelftEvaluationRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin Side 

        //Create Data To The Data Base 
        public async Task CreateDiabetRiskFactorQuestion(DiabetRiskFactorQuestions entity)
        {
            await _context.DiabetRiskFactorQuestions.AddAsync(entity) ;
            await _context.SaveChangesAsync() ;
        }

        //Get Diabet Risk Factor Question By Id
        public async Task<DiabetRiskFactorQuestions?> GetDiabetRiskFactorQuestionById(ulong id)
        {
            return await _context.DiabetRiskFactorQuestions.FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == id);
        }

        //Update Diabet Risk Factor Question 
        public async Task UpdateDiabetRiskFactorQuestion(DiabetRiskFactorQuestions entity)
        {
             _context.DiabetRiskFactorQuestions.Update(entity);
            await _context.SaveChangesAsync();
        }

        //List Of Diabet Risk Factor Questions 
        public async Task<List<DiabetRiskFactorQuestions>?> ListOfDiabetRiskFactorQuestions()
        {
            return await _context.DiabetRiskFactorQuestions.Where(p=> !p.IsDelete).ToListAsync();
        }

        #endregion
    }
}
