using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantRequest;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using DoctorFAM.Domain.ViewModels.UserPanel.Consultant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IConsultantService
    {
        #region Consultant Panel Side 

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

        #endregion

        #region Admin  Side 

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
}
