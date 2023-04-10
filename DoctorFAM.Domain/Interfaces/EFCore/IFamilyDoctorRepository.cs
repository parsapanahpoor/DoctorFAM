using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IFamilyDoctorRepository
    {
        #region User Panel 

        //Is Exist Any Family Doctor For Patient
        Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId);

        //Get User Selected Family Doctor 
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId);

        //Add Family Doctor For This Patient 
        Task AddFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor);

        //Remove Family Doctor For This Patient 
        Task RemoveFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor);

        //Update User Selected Family Doctor 
        Task UpdateUserSelectedFamilyDoctor(UserSelectedFamilyDoctor userSelectedFamilyDoctor);

        #endregion

        #region Doctor Panel 

        //Get User Selected Family Doctor By Patient Id And Doctor Id With Accepted And Waiting State
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(ulong userId, ulong doctorId);

        //Get User Selected Family Doctor By Request Id
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestId(ulong requestId);

        //List Of Doctor Population Covered Users
        Task<ListOfDoctorPopulationCoveredViewModel> FilterDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter);

        //List Of Current Doctor Population Covered Users
        Task<ListOfDoctorPopulationCoveredViewModel> FilterCurrentDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter);

        //Get Lastest Family Doctor Request For Current Doctor 
        Task<List<UserSelectedFamilyDoctor>> GetLastestFamilyDoctorRequestForCurrentDoctor(ulong doctorId);

        #endregion

        #region Admin And Supporter Side 

        //Count Of Awaiting Family Doctor Requests
        Task<int> CountOfAwaitingFamilyDoctorRequests();

        //Count Of Accepted Family Doctor Requests
        Task<int> CountOfAcceptedFamilyDoctorRequests();

        //Get List Of Doctor Population Covered By Doctor Id
        Task<List<UserSelectedFamilyDoctor>?> GetListOfDoctorPopulationCoveredByDoctorId(ulong doctorId);

        //List Of Family Doctor Request Admin Side 
        Task<FilterFamilyDoctorViewModel> FilterFamilyDoctorRequestAdminAndSupporterSide(FilterFamilyDoctorViewModel filter);

        //Get User Selected Family Doctor By Request Id With Doctor And Patient Information
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestIdWithDoctorAndPatientInformation(ulong requestId);

        #endregion

        #region Site Side 

        //Get User Selected Family Doctor By User And Doctor Id 
        Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserAndDoctorId(ulong userId, ulong doctorUserId);

        #endregion
    }
}
