using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class FamilyDoctorService : IFamilyDoctorService
    {
        #region Ctor

        private readonly IFamilyDoctorRepository _familyDoctor;
        private readonly IDoctorsService _doctorService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserService _userService;
        private readonly IPopulationCoveredService _populationCovered;

        public FamilyDoctorService(IFamilyDoctorRepository familyDoctor , IDoctorsService doctorServicec, IOrganizationService organizationService
                                    , IUserService userService, IPopulationCoveredService populationCovered)
        {
            _familyDoctor = familyDoctor;
            _doctorService = doctorServicec;
            _organizationService = organizationService;
            _userService = userService;
            _populationCovered = populationCovered;
        }

        #endregion

        #region User Panel 

        //Is Exist Any Family Doctor For Patient
        public async Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId)
        {
            return await _familyDoctor.IsExistAnyFamilyDoctorForPatient(userId);
        }

        //Get User Selected Family Doctor 
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId)
        {
            return await _familyDoctor.GetUserSelectedFamilyDoctorByUserId(userId);
        }

        //Choosing A Doctor Family
        public async Task<bool> ChoosingFamilyDoctor(ulong doctorUserId , ulong patientId)
        {
            #region Get Doctor By Doctor Id

            var doctor = await _doctorService.GetDoctorByUserId(doctorUserId);
            if (doctor == null) return false;

            #endregion

            #region Get Users

            var doctorUser = await _userService.GetUserById(doctor.UserId);
            if (doctorUser == null) return false;

            var patient = await _userService.GetUserById(patientId);
            if (patient == null) return false; 

            #endregion

            #region Check Validation 

            #region Organization Validation 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctor.UserId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Validation Doctor Interest

            var getDoctorInterest = await _doctorService.GetDoctorSelectedInterests(doctor.Id);
            if (!getDoctorInterest.Any(p => !p.IsDelete && p.InterestId == 3)) return false;

            #endregion

            #region Get Get User Selected Family Doctor By User Id

            var userSelectedFamilyDoctor = await GetUserSelectedFamilyDoctorByUserId(patientId);
            if (userSelectedFamilyDoctor != null
                                && (userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm
                                                    || userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted))
            {
                return false;
            }

            if (userSelectedFamilyDoctor != null && userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline)
            {
                await _familyDoctor.RemoveFamilyDoctorForThisPatient(userSelectedFamilyDoctor);
            }

            #endregion

            #endregion

            #region Add Family Doctor For Patient Method 

            UserSelectedFamilyDoctor model = new UserSelectedFamilyDoctor()
            {
                CreateDate = DateTime.Now,
                DoctorId = doctor.UserId,
                PatientId = patientId,
                FamilyDoctorRequestState = Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm,
                IsDelete = false,
                RejectDescription = null
            };

            await _familyDoctor.AddFamilyDoctorForThisPatient(model);

            #endregion

            return true;
        }

        //Show User Family Doctor Info In User Panel
        public async Task<ShowUserFamilyDoctorInfo?> FillShowUserFamilyDoctorInfoViewModel(ulong userId)
        {
            #region Get User Seleted Family Doctor 

            var request = await GetUserSelectedFamilyDoctorByUserId(userId);
            if (request == null) return null;

            #endregion

            #region Get Doctor By Id 

            var doctor = await _userService.GetUserById(request.DoctorId);
            if (doctor == null) return null;
            
            #endregion

            #region Get Doctor Personal Information 

            var doctorInfo = await _doctorService.GetDoctorsInformationByUserId(request.DoctorId);
            if (doctorInfo == null) return null;

            #endregion

            #region Fill Model

            ShowUserFamilyDoctorInfo model = new ShowUserFamilyDoctorInfo()
            {
                DoctorsInfo = doctorInfo,
                User = doctor
            };

            #endregion

            return model;
        }

        #endregion

        #region Doctor Panel 

        //Get User Selected Family Doctor By Request Id
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestId(ulong requestId)
        {
            return await _familyDoctor.GetUserSelectedFamilyDoctorByRequestId(requestId);
        }

        //Get Persone Information Detail In Doctor Population Covered
        public async Task<ShowPopulationCoveredDetailViewModel?> GetPersoneInformationDetailInDoctorPopulationCovered(ulong patientId, ulong doctorId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorId);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Get User Selected Family Doctor Request

            var userSelected = await GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(patientId, organization.OwnerId);
            if (userSelected == null) return null;
            if (userSelected.DoctorId != organization.OwnerId) return null;

            #endregion

            #region Get Patient By User Id

            var patient = await _userService.GetUserById(userSelected.PatientId);
            if (patient == null) return null;

            #endregion

            #region Doctor Id

            var doctor = await _userService.GetUserById(organization.OwnerId);
            if (doctor == null) return null;

            #endregion

            #region Fill View Model

            ShowPopulationCoveredDetailViewModel model = new ShowPopulationCoveredDetailViewModel()
            {
                Patient = patient,
                PopulationCovered = await _populationCovered.GetUserPopulation(patient.Id),
                UserSelectedFamilyDoctorRequest = userSelected
            };

            #endregion

            return model;
        }

        //Get User Selected Family Doctor By Patient Id And Doctor Id With Accepted And Waiting State
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(ulong userId, ulong doctorId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorId);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            return await _familyDoctor.GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(userId , organization.OwnerId);
        }

        //Change User Selected Family Doctor Request From Doctor
        public async Task<bool> ChangeUserSeletedFamilyDoctorRequestFromDoctor(UserSelectedFamilyDoctor userSelectedRequest , ulong doctorId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Get User Selected Family Doctor Request 

            var request = await GetUserSelectedFamilyDoctorByRequestId(userSelectedRequest.Id);
            if (request == null) return false;
            if (request.DoctorId != organization.OwnerId) return false;
            if (request.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline) return false;

            #endregion

            #region Update State 

            request.FamilyDoctorRequestState = userSelectedRequest.FamilyDoctorRequestState;
            request.RejectDescription = userSelectedRequest.RejectDescription;

            await _familyDoctor.UpdateUserSelectedFamilyDoctor(request);

            #endregion

            return true;
        }

        //List Of Doctor Population Covered Users
        public async Task<ListOfDoctorPopulationCoveredViewModel> FilterDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter)
        {
            return await _familyDoctor.FilterDoctorPopulationCovered(filter);
        }

        #endregion
    }
}
