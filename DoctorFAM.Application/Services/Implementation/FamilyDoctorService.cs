using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.NavBar;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;

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
        private readonly IReservationService _reservationService;

        public FamilyDoctorService(IFamilyDoctorRepository familyDoctor, IDoctorsService doctorServicec, IOrganizationService organizationService
                                    , IUserService userService, IPopulationCoveredService populationCovered, IReservationService reservationService)
        {
            _familyDoctor = familyDoctor;
            _doctorService = doctorServicec;
            _organizationService = organizationService;
            _userService = userService;
            _populationCovered = populationCovered;
            _reservationService = reservationService;
        }

        #endregion

        #region User Panel 

        //Cancel User Selected Family Doctor From User Panel 
        public async Task<bool> CancelUserSelectedFamilyDoctorFromUserPanel(ulong patientId)
        {
            #region Get User Selected Family Doctor By patientId

            var userSelectedFAmilyDoctor = await _familyDoctor.GetUserSelectedFamilyDoctorByUserId(patientId);
            if (userSelectedFAmilyDoctor == null) return false;

            #endregion

            #region Delete Recorde

            userSelectedFAmilyDoctor.IsDelete = true;

            await _familyDoctor.UpdateUserSelectedFamilyDoctor(userSelectedFAmilyDoctor);

            #endregion

            return true;
        }

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
        public async Task<bool> ChoosingFamilyDoctor(ulong doctorUserId, ulong patientId)
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

        //Filter Family Doctor Reservation Date
        public async Task<FilterDoctorFamilyReservationDateViewModel?> FilterDoctorFamilyReservationDate(FilterDoctorFamilyReservationDateViewModel filter)
        {
            #region Check Validation For User Selected Family Doctor 

            var userSelectedFamilyDoctor = await GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(filter.PatientId, filter.UserId);
            if (userSelectedFamilyDoctor == null)
            {
                return null;
            }

            #endregion

            #region return Model

            return await _reservationService.FilterFamilyDoctorReservationDateFromUserPanel(filter);

            #endregion
        }

        //Filter Family Doctor Reservation Date Time
        public async Task<FilterFamilyDoctorReservationDateTimeUserPanelViewModel?> FilterFamilyDoctorReservationDateTimeUserPanel(FilterFamilyDoctorReservationDateTimeUserPanelViewModel filter)
        {
            #region Check Validation For User Selected Family Doctor 

            var userSelectedFamilyDoctor = await GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(filter.PatientId, filter.UserId);
            if (userSelectedFamilyDoctor == null)
            {
                return null;
            }

            #endregion

            #region return Model

            return await _reservationService.FilterFamilyDoctorReservationDateTimeUserPanel(filter);

            #endregion
        }

        #endregion

        #region Doctor Panel 

        //Select All Population Covered UserIds For Send SMS To Them 
        public async Task<List<ulong>?> SelectAllPopulationCoveredUserIdsForSendSMSToThem(ulong doctorUserId)
        {
            var usersId = await _familyDoctor.ListOfCurrentDoctorPopulationCoveredUsersWithoutBasePaging(doctorUserId);
            if (usersId == null) return null;

            return usersId;
        }

        //List Of Current Doctor Population Covered Users Without Base Paging
        public async Task<List<ChooseUsersForSendSMSViewModel>?> ListOfCurrentDoctorPopulationCoveredUsersWithoutBasePaging(ulong doctorUserId)
        {
            #region Get List Of Users Id 

            var usersId = await _familyDoctor.ListOfCurrentDoctorPopulationCoveredUsersWithoutBasePaging(doctorUserId);
            if (usersId == null) return null;

            #endregion

            #region Fill View Model 

            List<ChooseUsersForSendSMSViewModel> returnModel = new List<ChooseUsersForSendSMSViewModel>();

            //Create Instance
            ChooseUsersForSendSMSViewModel user = new ChooseUsersForSendSMSViewModel();

            foreach (var userId in usersId)
            {
                var userFromDataBase = await _familyDoctor.ChooseUsersForSendSMSViewModel(userId);
                if (userFromDataBase != null)
                {
                    user = userFromDataBase;

                    returnModel.Add(userFromDataBase);
                }
            }

            #endregion

            return returnModel;
        }

        //Show Lastest Family Doctor Request In Doctor Panel Nav Bar 
        public async Task<LastestFamilyDoctorRequestForShowInNavBarViewModel?> ShowLastestFamilyDoctorRequestInDoctorPanelNavBar(ulong userId)
        {
            //Create Instace From Return Value
            LastestFamilyDoctorRequestForShowInNavBarViewModel model = new();

            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted)
            {
                model.HasAccessForShow = false;

                return model;
            }

            #endregion

            #region Check That Doctor Is Family Doctor 

            //Get Doctor By Organization Owner Id
            var doctor = await _doctorService.GetDoctorByUserId(organization.OwnerId);
            if (doctor is null)
            {
                model.HasAccessForShow = false;

                return model;
            }

            //Get Doctor Selected Interests 
            var interests = await _doctorService.GetDoctorSelectedInterests(doctor.Id);
            if (doctor is null || !interests.Any(p => p.InterestId == 3))
            {
                model.HasAccessForShow = false;

                return model;
            }
            else
            {
                model.HasAccessForShow = true;
            }

            #endregion

            #region Fill Model 

            //Lastest User Request For Family Doctor
            var requests = await _familyDoctor.GetLastestFamilyDoctorRequestForCurrentDoctor(organization.OwnerId);
            if (requests is null)
            {
                model.RequestCount = 0;

                return model;
            }

            //Model Count 
            model.RequestCount = requests.Count;

            //Make Instance  
            List<LastestFamilyDoctorRequestForShowInNavBarDetailViewModel> detail = new List<LastestFamilyDoctorRequestForShowInNavBarDetailViewModel>();

            //List OF Users 
            foreach (var item in requests)
            {
                //Get User By Patient Id
                var user = await _userService.GetUserById(item.PatientId);

                if (user is not null)
                {
                    detail.Add(new LastestFamilyDoctorRequestForShowInNavBarDetailViewModel()
                    {
                        DateTimes = item.CreateDate,
                        Users = user,
                    });
                }
            }

            model.Detail = detail;

            #endregion

            return model;
        }

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

            return await _familyDoctor.GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(userId, organization.OwnerId);
        }

        //Change User Selected Family Doctor Request From Doctor
        public async Task<bool> ChangeUserSeletedFamilyDoctorRequestFromDoctor(UserSelectedFamilyDoctor userSelectedRequest, ulong doctorId)
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
            request.IsUserInDoctorPopulationCoveredOutOfDoctorFAM = userSelectedRequest.IsUserInDoctorPopulationCoveredOutOfDoctorFAM;

            await _familyDoctor.UpdateUserSelectedFamilyDoctor(request);

            #endregion

            return true;
        }

        //List Of Doctor Population Covered Users
        public async Task<ListOfDoctorPopulationCoveredViewModel> FilterDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter)
        {
            return await _familyDoctor.FilterDoctorPopulationCovered(filter);
        }

        //List Of Current Doctor Population Covered Users
        public async Task<ListOfDoctorPopulationCoveredViewModel> FilterCurrentDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter)
        {
            return await _familyDoctor.FilterCurrentDoctorPopulationCovered(filter);
        }

        #endregion

        #region Admin And Supporter Side 

        //Get List Of Doctor Population Covered By Doctor Id
        public async Task<List<UserSelectedFamilyDoctor>?> GetListOfDoctorPopulationCoveredByDoctorId(ulong doctorId)
        {
            return await _familyDoctor.GetListOfDoctorPopulationCoveredByDoctorId(doctorId);
        }

        //List Of Family Doctor Request Admin Side 
        public async Task<FilterFamilyDoctorViewModel> FilterFamilyDoctorRequestAdminAndSupporterSide(FilterFamilyDoctorViewModel filter)
        {
            return await _familyDoctor.FilterFamilyDoctorRequestAdminAndSupporterSide(filter);
        }

        //Get User Selected Family Doctor By Request Id With Doctor And Patient Information
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestIdWithDoctorAndPatientInformation(ulong requestId)
        {
            return await _familyDoctor.GetUserSelectedFamilyDoctorByRequestIdWithDoctorAndPatientInformation(requestId);
        }

        #endregion
    }
}
