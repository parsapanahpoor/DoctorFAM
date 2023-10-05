using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.PeriodicSelfEvaluatuion;
using DoctorFAM.Domain.Interfaces.EFCore;

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

        //Create Diabet Risk Factor Questions
        public async Task<bool> CreateDiabetRiskFactorQuestions(string title)
        {
            #region Fill Entity

            DiabetRiskFactorQuestions entity = new DiabetRiskFactorQuestions()
            {
                Title = title.SanitizeText()
            };

            //Create Data To The Data Base 
            await _periodicSelftEvaluationRepository.CreateDiabetRiskFactorQuestion(entity);

            #endregion

            return true;
        }

        //Get Diabet Risk Factor Question By Id
        public async Task<DiabetRiskFactorQuestions?> GetDiabetRiskFactorQuestionById(ulong id)
        {
            return await _periodicSelftEvaluationRepository.GetDiabetRiskFactorQuestionById(id);
        }

        //Update Diabet Risk Factor Question 
        public async Task<bool> UpdateDiabetRiskFactorQuestion(DiabetRiskFactorQuestions entity)
        {
            await _periodicSelftEvaluationRepository.UpdateDiabetRiskFactorQuestion(entity);

            return true;
        }

        //Delete Diabet Risk Factor Questions
        public async Task<bool> DeleteDiabetRiskFactorQuestions(ulong id)
        {
            #region Gett Diabet Risk Factor Questions 

            var diabet = await GetDiabetRiskFactorQuestionById(id);
            if (diabet == null) return false;

            #endregion

            #region Update 

            diabet.IsDelete = true;

            //Update MEthod 
            await UpdateDiabetRiskFactorQuestion(diabet);

            #endregion

            return true;
        }

        //List Of Diabet Risk Factor Questions 
        public async Task<List<DiabetRiskFactorQuestions>?> ListOfDiabetRiskFactorQuestions()
        {
            return await _periodicSelftEvaluationRepository.ListOfDiabetRiskFactorQuestions();
        }

        #endregion
    }
}
