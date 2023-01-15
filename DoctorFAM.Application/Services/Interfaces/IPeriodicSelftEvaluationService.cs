using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IPeriodicSelftEvaluationService
    {
        #region Admin Side 

        //Create Diabet Risk Factor Questions
        Task<bool> CreateDiabetRiskFactorQuestions(string title);

        //Get Diabet Risk Factor Question By Id
        Task<DiabetRiskFactorQuestions?> GetDiabetRiskFactorQuestionById(ulong id);

        //Update Diabet Risk Factor Question 
        Task<bool> UpdateDiabetRiskFactorQuestion(DiabetRiskFactorQuestions entity);

        //Delete Diabet Risk Factor Questions
        Task<bool> DeleteDiabetRiskFactorQuestions(ulong id);

        //List Of Diabet Risk Factor Questions 
        Task<List<DiabetRiskFactorQuestions>?> ListOfDiabetRiskFactorQuestions();

        #endregion
    }
}
