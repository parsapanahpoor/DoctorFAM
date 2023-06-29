#region Usings

using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantRequest;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using DoctorFAM.Domain.ViewModels.Consultant.NavBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces;

#endregion

public interface IConsultantRepository
{
    #region Consultant Panel

    //Fill Consultant NavBar Info 
    Task<ConsultantPanelNavNarViewModel?> FillConsultantPanelNavNarViewModel(ulong userId);

    //Get User Selected Consultant By Patient And Consultant Id
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByPatientAndConsultantId(ulong patientId, ulong consultantId);

    //Get User Selected Consultant By Request Id
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByRequestId(ulong requestId);

    //List Of Your Consultant Population Covered Users
    Task<ListOfConsultantPopulationCoveredViewModel> FilterYourListOfConsultantPopulationCoveredViewModel(ListOfConsultantPopulationCoveredViewModel filter);

    //List Of Consultant Population Covered Users
    Task<ListOfConsultantPopulationCoveredViewModel> FilterListOfConsultantPopulationCoveredViewModel(ListOfConsultantPopulationCoveredViewModel filter);

    //Fill Consultant Side Bar Panel
    Task<ConsultantSideBarViewModel> GetConsultantSideBarInfo(ulong userId);

    //Is Exist Any Consultant By This User Id 
    Task<bool> IsExistAnyConsultantByUserId(ulong userId);

    //Add Consultant To Data Base
    Task<ulong> AddConsultant(Consultant consultant);

    //Get Consultant By User Id
    Task<Consultant?> GetConsultantByUserId(ulong userId);

    Task<List<DoctorsInterestInfo>> GetConsultantSelectedInterests(ulong doctorId);

    //Get Consultant Information By User Id
    Task<ConsultantInfo?> GetConsultantInformationByUserId(ulong userId);

    Task<bool> IsExistInterestForConsultant(ulong interestId, ulong doctorId);

    Task AddDoctorSelectedInterest(DoctorsSelectedInterests doctorsSelectedInterests);

    Task<DoctorsSelectedInterests?> GetConsultantSelectedInterestByConsultantIdAndInetestId(ulong interestId, ulong doctorId);

    Task DeleteConsultantSelectedInterest(DoctorsSelectedInterests item);

    Task<bool> IsExistInterestById(ulong interestId);

    //Check Is Exist Consultant Info By User ID
    Task<bool> IsExistAnyConsultantInfoByUserId(ulong userId);

    //Update Consultant Info 
    Task UpdateConsultantInfo(ConsultantInfo consultantInfo);

    //Add Consultant Info
    Task AddConsultantInfo(ConsultantInfo consultantInfo);

    //Filter Consultant Info Admin Side
    Task<ListOfConsultantInfoViewModel> FilterConsultantInfoAdminSide(ListOfConsultantInfoViewModel filter);

    //Get User Selected Consultant By Patient Id And Consultant Id With Accepted And Waiting State
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByPatientIdAndConsultantWithAcceptedAndWaitingState(ulong userId, ulong consultantId);

    Task<List<DoctorsInterestInfo>> GetConsultantInterestsInfo();

    //Get Consultant Reservation Tariff By User Id 
    Task<DoctorsReservationTariffs?> GetConsultantReservationConsultantByDentistUserId(ulong consultantUserId);

    //Get Consultant Reservation Tariff By User Id 
    Task<DoctorsReservationTariffs?> GetConsultantReservationTariffByConsultantUserId(ulong consultantUserId);

    //Add Consultant Reservation Tariff To The Data Base 
    Task AddConsultantReservationTariffToTheDataBase(DoctorsReservationTariffs reservationTariffs);

    //Update Consultant Reservation Tariffs
    Task UpdateConsultantReservationTariffs(DoctorsReservationTariffs reservationTariffs);

    //Get Consultant By Id
    Task<Consultant?> GetConsultantById(ulong doctorId);

    //Get Consultant Diabet Consultant Resumes By Consultant User Id 
    Task<List<DiabetConsultantsResume>?> GetConsultantDiabetConsultantResumesByConsultantUserId(ulong doctorUserId);

    #endregion

    #region Admin Side 

    //Filter Consultant Requests Admin Side 
    Task<FilterConsultantAdminSideViewModel> FilterConsultantAdminSideViewModel(FilterConsultantAdminSideViewModel filter);

    //Get Consultant Info By Nurse Id
    Task<ConsultantInfo?> GetConsultantInfoByConsultantId(ulong consultantId);

    //Get Consultant Info By Nurse Info Id
    Task<ConsultantInfo?> GetConsultantInfoById(ulong consultantInfoId);

    #endregion

    #region User Panel 

    //Get User Selected Consultant 
    Task<UserSelectedConsultant?> GetUserSelectedConsultantByUserId(ulong userId);

    //Get List Of Consultant
    Task<List<Consultant>?> FilterConsultantUserPanelSide(FilterConsultantUserPanelSideViewModel filter);

    //Remove Consultant For This Patient 
    Task RemoveConsultantForThisPatient(UserSelectedConsultant consultant);

    //Add Consultant For This Patient 
    Task AddConsultantForThisPatient(UserSelectedConsultant consultant);

    //Update User Selected Consultant 
    Task UpdateUserSelectedConsultant(UserSelectedConsultant userSelectedConsultant);

    #endregion
}
