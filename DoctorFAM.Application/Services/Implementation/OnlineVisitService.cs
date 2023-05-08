using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.Repository;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Contact;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Request = DoctorFAM.DataLayer.Entities.Request;

namespace DoctorFAM.Application.Services.Implementation
{
    public class OnlineVisitService : IOnlineVisitService
    {
        #region Ctor

        private readonly IOnlineVisitRepository _onlineVisitRepository;
        private readonly IUserService _userService;
        private readonly IRequestService _requestService;
        private readonly IPatientService _patientService;
        private readonly ILocationService _locationService;
        private readonly IWalletRepository _walletRepository;
        private readonly IHomePharmacyServicec _homePharmacyService;
        private readonly IOrganizationService _organizationService;

        public OnlineVisitService(IOnlineVisitRepository onlineVisitRepository, IUserService userService, IRequestService requestService
                                    , IPatientService patientService, ILocationService locationService, IWalletRepository walletRepository
                                            , IHomePharmacyServicec homePharmacyService, IOrganizationService organizationService)
        {
            _onlineVisitRepository = onlineVisitRepository;
            _userService = userService;
            _requestService = requestService;
            _patientService = patientService;
            _locationService = locationService;
            _walletRepository = walletRepository;
            _homePharmacyService = homePharmacyService;
            _organizationService = organizationService;
        }

        #endregion

        #region Old Version

        #region Site Side 

        //Create Online Visit Request
        public async Task<ulong?> CreateOnlineVisitRequest(ulong userId)
        {
            #region User Validation

            if (await _userService.GetUserById(userId) == null)
            {
                return null;
            }

            #endregion

            #region Fill Entitie

            Random key = new Random();

            Request request = new Request()
            {
                RequestType = Domain.Enums.RequestType.RequestType.OnlineVisit,
                RequestState = Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UserId = userId,
                BusinessKey = (ulong)key.Next(0, 1000000000)
            };

            #endregion

            #region Add Request Method

            await _requestService.AddRequest(request);

            #endregion

            return request.Id;
        }

        //Validation For Create Patient 
        public async Task<CreatePatientResult> ValidateCreatePatient(PatientDetailForOnlineVisitViewModel model)
        {
            var result = await _requestService.IsExistRequestByRequestId(model.RequestId);

            if (result == false) return CreatePatientResult.RequestIdNotFound;

            return CreatePatientResult.Success;
        }

        //Create Patient Detail For Online Visit Request
        public async Task<ulong> CreatePatientDetail(PatientDetailForOnlineVisitViewModel patient)
        {
            #region Validate Model State 

            //If Country Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(patient.CountryId)) return 0;

            //If State Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(patient.StateId)) return 0;

            //If City Not Found
            if (!await _locationService.IsExistAnyLocationByLocationid(patient.CountryId)) return 0;


            #endregion

            #region Get Request 

            var requestState = await _requestService.GetRequestById(patient.RequestId);

            if (requestState == null || requestState.RequestState != RequestState.WaitingForCompleteInformationFromUser)
            {
                return 0;
            }

            #endregion

            #region Get User By User Id

            var user = await _userService.GetUserById(patient.UserId);
            if (user == null) return 0;

            #endregion

            #region Fill Entity Patient

            Patient model = new Patient
            {
                RequestId = patient.RequestId,
                Age = patient.Age,
                Gender = patient.Gender,
                InsuranceId = patient.InsuranceId,
                NationalId = patient.NationalId,
                PatientName = patient.PatientName.SanitizeText(),
                PatientLastName = patient.PatientLastName.SanitizeText(),
                RequestDescription = " درخواست برای ویزیت آنلاین ",
                UserId = patient.UserId
            };

            #endregion

            #region Add Patient

            await _patientService.AddPatient(model);

            #endregion

            #region Fill Paitient Request Detail

            PaitientRequestDetail request = new PaitientRequestDetail()
            {
                RequestId = patient.RequestId,
                PatientId = model.Id,
                CountryId = patient.CountryId,
                StateId = patient.StateId,
                CityId = patient.CityId,
                Mobile = user.Mobile,
                Phone = user.Mobile,
                Vilage = null,
                Distance = 0,
                FullAddress = " Online Visit "
            };

            #endregion

            #region Add Method

            await _requestService.AddPatientRequestDetail(request);

            #endregion

            return model.Id;
        }

        //Add Online Vist Request 
        public async Task<bool> AddOnlineVisitRequest(OnlineVisitRquestDetailViewModel onlineVisitRquest, ulong userId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(onlineVisitRquest.RequestId);
            if (request == null || request.UserId != userId || request.RequestState != Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser)
            {
                return false;
            }

            #endregion

            #region Get Patient By Id

            var patient = await _patientService.GetPatientById(onlineVisitRquest.PatientId);
            if (patient == null || patient.RequestId != request.Id)
            {
                return false;
            }

            #endregion

            #region Add Online Visit Request 

            #region Fill Online Visit Detail  Model 

            var model = new OnlineVisitRequestDetail()
            {
                OnlineVisitRequestDescription = onlineVisitRquest.OnlineVisitRequestDescription,
                OnlineVisitRequestType = onlineVisitRquest.OnlineVisitRequestType,
                RequestId = onlineVisitRquest.RequestId,
            };

            #endregion

            #region Add File

            if (onlineVisitRquest.OnlineVisitRequestFile != null)
            {
                if (Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName).ToLower() == ".jpg"
                        && Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName).ToLower() == ".png"
                        && Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName).ToLower() == ".jpeg")
                {
                    var res = onlineVisitRquest.OnlineVisitRequestFile.IsImage();
                    if (!res)
                    {
                        return false;
                    }
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName);

                if (!Directory.Exists(PathTools.OnlineVisitRequestFilePathServer))
                    Directory.CreateDirectory(PathTools.OnlineVisitRequestFilePathServer);

                string OriginPath = PathTools.OnlineVisitRequestFilePathServer + imageName;

                using (var stream = new FileStream(OriginPath, FileMode.Create))
                {
                    if (!Directory.Exists(OriginPath)) onlineVisitRquest.OnlineVisitRequestFile.CopyTo(stream);
                }

                model.OnlineVisitRequestFile = imageName;
            }

            #endregion

            await _onlineVisitRepository.AddOnlineRequestDetail(model);

            #endregion

            #region Update request

            request.RequestState = Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        public async Task<bool> ChargeUserWallet(ulong userId, int price, ulong requestId)
        {
            if (!await _userService.IsExistUserById(userId))
            {
                return false;
            }

            var wallet = new Wallet
            {
                UserId = userId,
                TransactionType = TransactionType.Deposit,
                GatewayType = GatewayType.Zarinpal,
                PaymentType = PaymentType.ChargeWallet,
                Price = price,
                Description = "شارژ حساب کاربری برای پرداخت هزینه ی ویزیت آنلاین",
                IsFinally = true,
                RequestId = requestId
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        public async Task<bool> PayOnlineVisitTariff(ulong userId, int price, ulong requestId)
        {
            if (!await _userService.IsExistUserById(userId))
            {
                return false;
            }

            var wallet = new Wallet
            {
                UserId = userId,
                TransactionType = TransactionType.Withdraw,
                GatewayType = GatewayType.Zarinpal,
                PaymentType = PaymentType.OnlineVisit,
                Price = price,
                Description = "پرداخت مبلغ ویزیت آنلاین",
                IsFinally = true,
                RequestId = requestId
            };

            await _walletRepository.CreateWalletAsync(wallet);
            return true;
        }

        //Get List Of Online Visit For Send Notification For Online Visit Notification 
        public async Task<List<string?>> GetListOfDoctorsForArrivalsOnlineVisitRequests()
        {
            #region Get Activated Doctors By Online Visit Interests 

            var returnValue = await _onlineVisitRepository.GetActivatedAndDoctorsInterestOnlineVisit();

            #endregion

            return returnValue;
        }

        #endregion

        #region Doctor Side

        //Filter Online Visit Requests 
        public async Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter)
        {
            return await _onlineVisitRepository.FilterOnlineVisitRequests(filter);
        }

        //Show Online Visit Request Detail Doctor Panel Side View Model 
        public async Task<OnlineVisitRequestDetailViewModel?> FillOnlineVisitRequestDetailDoctorPanelViewModel(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.OnlineVisit) return null;
            if (!request.PatientId.HasValue) return null;
            if (request.RequestState != RequestState.Paid) return null;

            #endregion

            #region Fill Model 

            OnlineVisitRequestDetailViewModel model = new OnlineVisitRequestDetailViewModel()
            {
                Patient = await _patientService.GetPatientById(request.PatientId.Value),
                User = await _userService.GetUserById(request.UserId),
                PatientRequestDetail = await _homePharmacyService.GetRequestPatientDetailByRequestId(request.Id),
                Request = request,
                OnlineVisitRequestDetail = await _onlineVisitRepository.GetOnlineVisitRequestDetail(request.Id)
            };

            #endregion

            return model;
        }

        //Confirm Online Visit Request From Doctor 
        public async Task<bool> ConfirmOnlineVisitRequestFromDoctor(ulong requestId, ulong userId)
        {
            #region Get Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return false;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.OnlineVisit) return false;
            if (!request.PatientId.HasValue) return false;
            if (request.OperationId.HasValue) return false;
            if (request.RequestState != RequestState.Paid) return false;

            #endregion

            #region Get Request By Doctor 

            request.OperationId = organization.OwnerId;
            request.RequestState = RequestState.SelectedFromDoctor;

            await _requestService.UpdateRequest(request);

            #endregion

            return true;
        }

        //Filter Your Online Visit Request 
        public async Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter)
        {
            return await _onlineVisitRepository.FilterYourOnlineVisitRequest(filter);
        }

        #endregion

        #region User Panel Side 

        //Filter User Onlien Visit Requests 
        public async Task<FilterOnlineVisitRequestUserPanelViewModel> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter)
        {
            return await _onlineVisitRepository.FilterOnlineVisitRequestUserPanel(filter);
        }

        #endregion

        #region Admin And Supporter Side 

        //Filter Online Visit Requests Admin Side 
        public async Task<FilterOnlineVisitAdminSideViewModel> FilterOnlineVisitRequestsAdminSide(FilterOnlineVisitAdminSideViewModel filter)
        {
            return await _onlineVisitRepository.FilterOnlineVisitRequestsAdminSide(filter);
        }

        //Show Online Visit Request Detail Admin Panel Side View Model 
        public async Task<OnlineVisitRequestDetailAdminSideViewModel?> FillOnlineVisitRequestDetailAdminPanelViewModel(ulong requestId)
        {
            #region Get Request By Request Id

            var request = await _requestService.GetRequestById(requestId);

            if (request == null) return null;
            if (request.RequestType != Domain.Enums.RequestType.RequestType.OnlineVisit) return null;
            if (!request.PatientId.HasValue) return null;

            #endregion

            #region Fill Model 

            OnlineVisitRequestDetailAdminSideViewModel model = new OnlineVisitRequestDetailAdminSideViewModel()
            {
                Patient = await _patientService.GetPatientById(request.PatientId.Value),
                User = await _userService.GetUserById(request.UserId),
                PatientRequestDetail = await _homePharmacyService.GetRequestPatientDetailByRequestId(request.Id),
                Request = request,
                OnlineVisitRequestDetail = await _onlineVisitRepository.GetOnlineVisitRequestDetail(request.Id)
            };

            #endregion

            return model;
        }

        #endregion

        #endregion

        #region Doctor Panel 

        //Select List For Show List Of Avalable Shifts 
        public async Task<List<SelectListViewModel>> SelectListForShowListOfAvailableShifts()
        {
            return await _onlineVisitRepository.SelectListForShowListOfAvailableShifts();
        }

        //Create Doctor Selected Online Visit Shift Date From Doctor Panel
        public async Task<CreateDoctorSelectedOnlineVisitShiftDateViewModelResult> CreateDoctorSelectedOnlineVisitShiftDateFromDoctorPanel(CreateDoctorSelectedOnlineVisitShiftDateViewModel model, ulong memberUserId)
        {
            //Today Date Time
            DateTime todayDateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            //Incoming Date Time To Miladi
            DateTime incomingDate = model.SelectedDateTime.ToMiladiDateTime();

            #region Check Validation 

            if (DateTime.Compare(incomingDate, todayDateTime) < 0)
            {
                return CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.LaterSelectedDate;
            }

            if (model.OnlineVisitWorkShiftDetailId is null)
            {
                return CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.Faild;
            }

            #endregion

            #region Get Owner Organization Member

            ulong organizationOwner = await _organizationService.GetOranizationOwnerIdByMemberUserId(memberUserId);
            if (organizationOwner == 0) return CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.Faild;

            if (await _onlineVisitRepository.IsExistAnyWorkShiftDateForCurrentDoctor(organizationOwner, Convert.ToInt32($"{incomingDate.Year}{incomingDate.Month}{incomingDate.Day}")))
            {
                return CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.DuplicateRecord;
            }

            #endregion

            #region Add Online Visit Doctors Reservation Date

            OnlineVisitDoctorsReservationDate doctorReservationDateSelected = new OnlineVisitDoctorsReservationDate()
            {
                DoctorUserId = organizationOwner,
                OnlineVisitShiftDate = model.SelectedDateTime.ToMiladiDateTime(),
                BusinessKey = Convert.ToInt32($"{incomingDate.Year}{incomingDate.Month}{incomingDate.Day}")
            };

            //Add To The Data Base 
            await _onlineVisitRepository.AddOnlineVisitDoctorsReservationDateToTheDataBase(doctorReservationDateSelected);

            #endregion

            #region Add Online Visit Doctor Selected Work Shift Add Online Visit Doctors And Patients Reservation Detail

            foreach (var item in model.OnlineVisitWorkShiftDetailId)
            {
                #region Add Online Visit Doctor Selected Work Shift

                OnlineVisitDoctorSelectedWorkShift doctorSelectedWorkShift = new OnlineVisitDoctorSelectedWorkShift()
                {
                    OnlineVisitDoctorsReservationDateId = doctorReservationDateSelected.Id,
                    OnlineVisitWorkShiftId = item
                };

                //Add doctorSelectedWorkShift
                await _onlineVisitRepository.AddOnlineVisitDoctorSelectedWorkShiftWithoutSaveChanges(doctorSelectedWorkShift);

                #endregion

                #region Add Online Visit Doctors And Patients Reservation Detail

                foreach (var reservationTimeDetailId in await _onlineVisitRepository.GetListOfWorkShiftsTimeDetailIdByWorkShiftId(item))
                {
                    OnlineVisitDoctorsAndPatientsReservationDetail reservationDetail = new OnlineVisitDoctorsAndPatientsReservationDetail()
                    {
                        OnlineVisitDoctorsReservationDateId = doctorReservationDateSelected.Id,
                        PatientUserId = null,
                        OnlineVisitWorkShiftDetail = reservationTimeDetailId,
                        OnlineVisitWorkShiftId = item
                    };

                    //Add To The Data Base 
                    await _onlineVisitRepository.AddOnlineVisitDoctorsAndPatientsReservationDetailToTheDataBaseWithoutSaveChanges(reservationDetail);
                }

                #endregion

                //Save Changes 
                await _onlineVisitRepository.SaveChanges();
            }

            #endregion

            return CreateDoctorSelectedOnlineVisitShiftDateViewModelResult.Success;
        }

        //List Of Work Shift Dates From Doctor Panel 
        public async Task<List<ListOfWorkShiftDatesFromDoctorPanelViewModel>?> FillListOfWorkShiftDatesFromDoctorPanelViewModel(ulong memberUserId)
        {
            #region Current Date Time

            var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

            #endregion

            #region Get Owner Organization Member

            ulong organizationOwner = await _organizationService.GetOranizationOwnerIdByMemberUserId(memberUserId);
            if (organizationOwner == 0) return null;

            #endregion      

            return await _onlineVisitRepository.GetValidatesWorkShiftDatesByDoctorUserIdForShowInDoctorPanel(organizationOwner);
        }

        //Fill Work Shift Date Detail Doctor Panel 
        public async Task<List<WorkShiftDateDetailDoctorPanelViewModel>?> FillWorkShiftDateDetailDoctorPanel(ulong OnlineVisitDoctorsReservationDateId, ulong memberUserId)
        {
            #region Get Owner Organization Member

            ulong organizationOwner = await _organizationService.GetOranizationOwnerIdByMemberUserId(memberUserId);
            if (organizationOwner == 0) return null;

            #endregion

            #region Validation For Owner Organization 

            if (!await _onlineVisitRepository.IsExistAnyOnlineVisitDoctorsReservationDateByDoctorUserId(OnlineVisitDoctorsReservationDateId, organizationOwner))
            {
                return null;
            }

            #endregion

            return await _onlineVisitRepository.FillWorkShiftDateDetailDoctorPanel(OnlineVisitDoctorsReservationDateId);
        }

        //Get Work Shift Date By OnlineVisitDoctorsReservationDateId
        public async Task<DateTime> GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(ulong OnlineVisitDoctorsReservationDateId)
        {
            return await _onlineVisitRepository.GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(OnlineVisitDoctorsReservationDateId);
        }

        //Fill OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel
        public async Task<List<OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId, ulong memberId)
        {
            #region Get Owner Organization Member

            ulong organizationOwner = await _organizationService.GetOranizationOwnerIdByMemberUserId(memberId);
            if (organizationOwner == 0) return null;

            #endregion

            #region Validation For Owner Organization 

            if (!await _onlineVisitRepository.IsExistAnyOnlineVisitDoctorsReservationDateByDoctorUserId(doctorReservationDateId, organizationOwner))
            {
                return null;
            }

            #endregion

            return await _onlineVisitRepository.FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(doctorReservationDateId, shiftId);
        }

        #endregion

        #region Admin Side 

        //Fill List Of Work Shifts Dates Admin Side View Model
        public async Task<List<ListOfWorkShiftsDatesAdminSideViewModel>> FillListOfWorkShiftsDatesAdminSideViewModel()
        {
            return await _onlineVisitRepository.FillListOfWorkShiftsDatesAdminSideViewModel();
        }

        //Fill ListOfWorkShiftDayDetailViewModel 
        public async Task<List<ListOfWorkShiftDayDetailViewModel>?> FillListOfWorkShiftDayDetailViewModel(int businessKey)
        {
            #region Get Doctors Reservation Dates Id By business Key 

            var doctorsReservationsDate = await _onlineVisitRepository.GetDoctorWorkShiftReservationIdByBusinessKetThatRenderFromDate(businessKey);
            if (doctorsReservationsDate == null) return null;

            #endregion

            #region Get Doctors Selected Work Shift Dates 

            //Create Instance
            List<OnlineVisitWorkShift> onlineVisitWorkShifts = new List<OnlineVisitWorkShift>();

            foreach (var item in doctorsReservationsDate)
            {
                List<OnlineVisitWorkShift> onlineVisitWork = await _onlineVisitRepository.GetDoctorWorkShiftSelecetedReservationDateByDoctorWorkShiftReservationId(item);
                if (onlineVisitWork == null) return null;

                onlineVisitWorkShifts.AddRange(onlineVisitWork);
            }

            #endregion

            var returbModel = onlineVisitWorkShifts.GroupBy(p => p.StartShiftTime)
                            .Select(p => new ListOfWorkShiftDayDetailViewModel()
                            {
                                EndTime = p.FirstOrDefault().EndShiftTime,
                                StartTime = p.FirstOrDefault().StartShiftTime,
                                WorkShiftId = p.FirstOrDefault().Id,
                                DateBusinessKey = businessKey
                            }).ToList();

            return returbModel;
        }

        //Fill ListOfDoctorsInSelectedShiftAdminSideViewModel
        public Task<List<ListOfDoctorsInSelectedShiftAdminSideViewModel>> FillListOfDoctorsInSelectedShiftAdminSideViewModel(ulong workShiftId, int dateBusinessKey)
        {
            return _onlineVisitRepository.FillListOfDoctorsInSelectedShiftAdminSideViewModel( workShiftId,  dateBusinessKey);
        }

        #endregion
    }
}
