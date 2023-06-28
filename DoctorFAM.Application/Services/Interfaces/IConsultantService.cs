#region Usings

using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo.Interest;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantRequest;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using DoctorFAM.Domain.ViewModels.Consultant.NavBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.UserPanel.Consultant;
using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Application.Services.Interfaces;

#endregion

public interface IConsultantService
{
    #region Consultant Panel Side 

    //Fill Consultant NavBar Info 
    Task<ConsultantPanelNavNarViewModel?> FillConsultantPanelNavNarViewModel(ulong userId);

    //Get User Selected Consultant By Patient And Consultant Id
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByPatientAndConsultantId(ulong patientId, ulong consultantId);

    //List Of Your Consultant Population Covered Users
    Task<ListOfConsultantPopulationCoveredViewModel> FilterYourListOfConsultantPopulationCoveredViewModel(ListOfConsultantPopulationCoveredViewModel filter);

    //Change User Selected Consultant Request From Consultant
    Task<bool> ChangeUserSeletedConsultantRequestFromConsultant(UserSelectedConsultant userSelectedRequest, ulong doctorId);

    //Get User Selected Consultant By Request Id
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByRequestId(ulong requestId);

    //Get Persone Information Detail In Consultant Population Covered
    Task<Domain.ViewModels.Consultant.ConsultantRequest.ShowPopulationCoveredDetailViewModel?> GetPersoneInformationDetailInConsultantPopulationCovered(ulong patientId, ulong consultantId);

    //List Of Consultant Population Covered Users
    Task<ListOfConsultantPopulationCoveredViewModel> FilterListOfConsultantPopulationCoveredViewModel(ListOfConsultantPopulationCoveredViewModel filter);

    //Fill Consultant Side Bar Panel
    Task<ConsultantSideBarViewModel> GetConsultantSideBarInfo(ulong userId);

    //Is Exist Any Consultant By This User Id 
    Task<bool> IsExistAnyConsultantByUserId(ulong userId);

    //Add Consultant For First Time Loging To Consultant Panel 
    Task AddConsultantForFirstTime(ulong userId);

    //Get Consultant By User Id
    Task<Consultant?> GetConsultantByUserId(ulong userId);

    //Fill Consultant Info View Model
    Task<ManageConsultantInfoViewModel?> FillManageConsultantInfoViewModel(ulong userId);

    //Check Is Exist Consultant Info By User ID
    Task<bool> IsExistAnyConsultantInfoByUserId(ulong userId);

    //Add Or Edit Consultant Info From Consultant Panel
    Task<AddOrEditConsultantInfoResult> AddOrEditConsultantInfoNursePanel(ManageConsultantInfoViewModel model);

    //Filter Consultant Info Admin Side
    Task<ListOfConsultantInfoViewModel> FilterConsultantInfoAdminSide(ListOfConsultantInfoViewModel filter);

    //Get User Selected Consultant By Patient Id And Consultant Id With Accepted And Waiting State
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByPatientIdAndConsultantIdWithAcceptedAndWaitingState(ulong userId, ulong consultant);

    Task<ConsultantInterestsViewModel> FillConsultantInterestViewModelFromConsultantPanel(ulong userId);

    //Add  Consultant Selected Interest
    Task<DoctorSelectedInterestResult> AddConsultantSelectedInterest(ulong interestId, ulong userId);

    //Delete Consultant Selected Interest Consultant Panel
    Task<DoctorSelectedInterestResult> DeleteConsultantSelectedInterestConsultantPanel(ulong interestId, ulong userId);

    //Fill Diabet Consultatn Resume View Model
    Task<UploadDiabetConsultatntDoctorSideViewModel?> FillDiabetConsultatnResumeViewModel(ulong userId);

    //Get Consultatn Diabet Consultant Resumes By Consultatn User Id 
    Task<List<DiabetConsultantsResume>?> GetConsultatnDiabetConsultantResumesByConsultatnUserId(ulong doctorUserId);

    //Upload Consultatn Diabet Consultant Resume File 
    Task<bool> UploadConsultatnDiabetConsultantResumeFile(ulong userId, string? description, IFormFile? resumePicture);

    //Delete Diabet Consultant Resume By Resume Id
    Task<bool> DeleteDiabetConsultantResumeByResumeId(ulong resumeId, ulong userId);

    //Fill Blood Pressure Consultatn Resume View Model
    Task<UploadBloodPressureConsultatntDoctorSideViewModel?> FillBloodPressureConsultatnResumeViewModel(ulong userId);

    //Get Consultant Blood Pressure Consultant Resumes By Doctor User Id 
    Task<List<BloodPressureConsultantResume>?> GetConsultantBloodPressureConsultantResumesByDoctorUserId(ulong doctorUserId);

    //Upload Consultant Blood Pressure Consultant Resume File 
    Task<bool> UploadConsultantBloodPressureConsultantResumeFile(ulong userId, string? description, IFormFile? resumePicture);

    //Delete Blood Pressure Consultant Resume By Resume Id
    Task<bool> DeleteBloodPressureConsultantResumeByResumeId(ulong resumeId, ulong userId);

    #endregion

    #region Admin  Side 

    //Show Consultant Request Detail Admin Side View Model 
    Task<ConsultantRequestDetailAdminSideViewModel?> FillConsultantRequestDetailAdminSideViewModel(ulong requestId);

    //Filter Consultant Requests Admin Side 
    Task<FilterConsultantAdminSideViewModel> FilterConsultantAdminSideViewModel(FilterConsultantAdminSideViewModel filter);

    //Get Consultant Info By Nurse Id
    Task<ConsultantInfo?> GetConsultantInfoByConsultantId(ulong consultantId);

    //Get Consultant By Consultant Id
    Task<Consultant?> GetConsultantById(ulong consultantId);

    //Fill Consultant Info Detail ViewModel
    Task<ConsultantInfoDetailViewModel?> FillConsultantInfoDetailViewModel(ulong ConsultantId);

    //Edit Consultant Info From Admin Panel
    Task<EditConsultantInfoResult> EditConsultantInfoAdminSide(ConsultantInfoDetailViewModel model);

    #endregion

    #region User Panel Side

    //Get User Selected Consultant 
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByUserId(ulong userId);

    //Get List Of Consultant
    Task<List<Consultant>?> FilterConsultantUserPanelSide(FilterConsultantUserPanelSideViewModel filter);

    //Fill Consultant Information Detail View Model
    Task<ShowConsultantInformationDetailViewModel?> FillShowConsultantInformationDetailViewModel(ulong consultantId);

    //Choosing A Consultant
    Task<bool> ChoosingConsultantFromUser(ulong consultantUserId, ulong patientId);

    //Show User Consultant Info In User Panel
    Task<ShowUserConsultantInfo?> FillShowUserConsultantInfo(ulong userId);

    //Cancel User Selected Consultant From User Panel 
    Task<bool> CancelUserSelectedConsultantFromUserPanel(ulong patientId);

    #endregion
}
