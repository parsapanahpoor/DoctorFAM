using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IPeriodicSelftEvaluationRepository
    {
        #region Admin Side 

        //Create Data To The Data Base 
        Task CreateDiabetRiskFactorQuestion(DiabetRiskFactorQuestions entity);

        //Get Diabet Risk Factor Question By Id
        Task<DiabetRiskFactorQuestions?> GetDiabetRiskFactorQuestionById(ulong id);

        //Update Diabet Risk Factor Question 
        Task UpdateDiabetRiskFactorQuestion(DiabetRiskFactorQuestions entity);

        //List Of Diabet Risk Factor Questions 
        Task<List<DiabetRiskFactorQuestions>?> ListOfDiabetRiskFactorQuestions();

        #endregion
    }
}
