using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IFamilyDoctorService
    {
        #region User Panel 

        //Is Exist Any Family Doctor For Patient
        Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId);

        //Get User Selected Family Doctor 
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId);

        //Choosing A Doctor Family
        Task<bool> ChoosingFamilyDoctor(ulong doctorUserId, ulong patientId);

        //Show User Family Doctor Info In User Panel
        Task<ShowUserFamilyDoctorInfo?> FillShowUserFamilyDoctorInfoViewModel(ulong userId);

        //Filter Family Doctor Reservation Date
        Task<FilterDoctorFamilyReservationDateViewModel?> FilterDoctorFamilyReservationDate(FilterDoctorFamilyReservationDateViewModel filter);

        //Filter Family Doctor Reservation Date Time
        Task<FilterFamilyDoctorReservationDateTimeUserPanelViewModel?> FilterFamilyDoctorReservationDateTimeUserPanel(FilterFamilyDoctorReservationDateTimeUserPanelViewModel filter);

        //Cancel User Selected Family Doctor From User Panel 
        Task<bool> CancelUserSelectedFamilyDoctorFromUserPanel(ulong patientId);

        #endregion

        #region Doctor Panel 

        //List Of Current Doctor Population Covered Users
        Task<ListOfDoctorPopulationCoveredViewModel> FilterCurrentDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter);

        //Get Persone Information Detail In Doctor Population Covered
        Task<ShowPopulationCoveredDetailViewModel?> GetPersoneInformationDetailInDoctorPopulationCovered(ulong requestId, ulong doctorId);

        //Get User Selected Family Doctor By Patient Id And Doctor Id With Accepted And Waiting State
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(ulong userId, ulong doctorId);

        //Get User Selected Family Doctor By Request Id
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestId(ulong requestId);

        //Change User Selected Family Doctor Request From Doctor
        Task<bool> ChangeUserSeletedFamilyDoctorRequestFromDoctor(UserSelectedFamilyDoctor userSelectedRequest, ulong doctorId);

        //List Of Doctor Population Covered Users
        Task<ListOfDoctorPopulationCoveredViewModel> FilterDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter);

        #endregion

        #region Admin And Supporter Side 

        //Get List Of Doctor Population Covered By Doctor Id
        Task<List<UserSelectedFamilyDoctor>?> GetListOfDoctorPopulationCoveredByDoctorId(ulong doctorId);

        //List Of Family Doctor Request Admin Side 
        Task<FilterFamilyDoctorViewModel> FilterFamilyDoctorRequestAdminAndSupporterSide(FilterFamilyDoctorViewModel filter);

        //Get User Selected Family Doctor By Request Id With Doctor And Patient Information
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestIdWithDoctorAndPatientInformation(ulong requestId);

        #endregion
    }
}
