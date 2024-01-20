using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.MedicalExamination;
using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IMedicalExaminationRepository
    {
        #region Admin side 

        //Create Medical Examination 
        Task CreateMedicalExamination(MedicalExamination model);

        //Filter Medical Examination 
        Task<FilterMedicalExaminationAdminSideViewModel> FilterMedicalExamination(FilterMedicalExaminationAdminSideViewModel filter);

        //Get Medical Examination By Id 
        Task<MedicalExamination?> GetMedicalExaminationById(ulong medicalExaminationId);

        //Edit Medical Examination Admin Side 
        Task EditMedicalExaminationAdminSide(MedicalExamination model);

        #endregion

        #region Site Side 

        //Get List Of Medical Examinations
        Task<List<MedicalExamination>?> GetListOfMedicalExaminations();

        //Get List Of Medical Examinations With Select List 
        Task<List<SelectListViewModel>> GetListOfMedicalExaminationsWithSelectList();

        //Add Priodic Examination From Site 
        Task AddPriodicExaminationFromSite(PriodicPatientsExamination model);

        //Get User Priodic Examination By User Id
        Task<List<PriodicPatientsExamination>?> GetUserPriodicExaminationByUserId(ulong userId);

        //Get Priodic Examination By Priodic Examination Id
        Task<PriodicPatientsExamination?> GetPriodicExaminationByPriodicExaminationId(ulong priodicExaminationId);

        //Update Priodic Examination
        Task UpdatePriodicExamination(PriodicPatientsExamination priodic);

        //Check That Current User Has Any Priodic Examination In This Week
        Task<List<PriodicPatientsExamination>?> CheckThatCurrentUserHasAnyPriodicExaminationInThisWeek(ulong userId);

        //Check That Current User Has Any Priodic Examination After Today
        Task<List<PriodicPatientsExamination>?> CheckThatCurrentUserHasAnyPriodicExaminationAfterToday(ulong userId);

        #endregion

        #region Background Task

        //Get List Of User Medical Examination For Send SMS One Day Before
        Task<List<SendSMSForMedicalExaminationViewModel>> GetListOfUserMedicalExaminationForSendSMSOneDayBefore();

        //Get User Selected Medical Examination By Id
        Task<PriodicPatientsExamination?> GetUserMedicalExaminationById(ulong id);

        //Update User Medical Examination Without Save Changes
        void UpdateUserMedicalExaminationWithoutSaveChanges(PriodicPatientsExamination model);

        //Save Chamges 
        Task Savechanges();

        #endregion
    }
}

