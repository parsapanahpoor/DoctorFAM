using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class ReservationService : IReservationService
    {
        #region Ctor

        private readonly IReservationRepository _reservation;

        private readonly IOrganizationService _organizationService;

        private readonly IWorkAddressService _workAddress;

        private readonly IDoctorsRepository _doctorsRepository;

        private readonly IUserService _userService;

        private readonly ISiteSettingService _siteSettingService;

        private readonly IWalletService _walletService;

        public ReservationService(IReservationRepository reservation, IOrganizationService organizationService, IWorkAddressService workAddress, IDoctorsRepository doctorsRepository, IUserService userService, ISiteSettingService siteSettingService, IWalletService walletService)
        {
            _reservation = reservation;
            _organizationService = organizationService;
            _workAddress = workAddress;
            _doctorsRepository = doctorsRepository;
            _userService = userService;
            _siteSettingService = siteSettingService;
            _walletService = walletService;
        }

        #endregion

        #region Doctor Panel

        //Add Cancel Reservation Request 
        public async Task<bool> CreateCancelReservationRequestFromDoctorPanel(CancelReservationRequestViewModel model , ulong userId)
        {
            #region Get Organization 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Doctor Reservation Date By Id 

            var reservation = await _reservation.GetReservationDateById(model.ReservationDateId);
            if (reservation == null) return false;
            if (reservation.UserId != organization.OwnerId) return false;

            #endregion

            #region Validation On Reservation Date Time Add Add Cancelation Date

            #region Add Reservation Date Cancelation 

            #region Fill Reservation Date Cancelation View Model 

            ReservationDateCancelation date = new ReservationDateCancelation()
            {
                DoctorReservationDateId = reservation.Id,
            };

            #endregion

            #region Add Reservation Date Cancelation 

            await _reservation.AddReservationDateCancelation(date);

            #endregion

            #endregion

            #region Add Reservation Date Time Cancelation 

            foreach (var item in model.ReservationDateTimeId)
            {
                var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(item);
                if (reservationDateTime == null) return false;
                if (reservationDateTime.DoctorReservationDateId != reservation.Id) return false;
                if (reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Canceled) return false;

                #region Fill Entity

                ReservationDateTimeCancelation dateTime = new ReservationDateTimeCancelation()
                {
                    DoctorReservationDateTimeId = reservationDateTime.Id,
                    ReservationDateCancelationId = date.Id
                };

                #endregion

                await _reservation.AddReservationDateTimeCancelation(dateTime);
            }

            #endregion

            #endregion

            //Save changes
            await _reservation.Savechanges();

            return true;
        }

        //Get List Of Reservation Dete Time By Reservation Date Id For Select List  
        public async Task<List<SelectListViewModel>> GetReservationDateTimeByReservationDateIdSelectList(ulong reservationDateId, ulong userId)
        {
            #region Get Organization 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Doctor Reservation Date By Id 

            var reservation = await _reservation.GetReservationDateById(reservationDateId);
            if (reservation == null) return null;
            if (reservation.UserId != organization.OwnerId) return null; 

            #endregion

            return await _reservation.GetReservationDateTimeByReservationDateIdSelectList(reservationDateId , organization.OwnerId);
        }

        //Get Future Doctor Reservation For Cancel Reservation Request 
        public async Task<List<SelectListViewModel>> GetReservationsForAddCancelRequest(ulong userId)
        {
            #region Get Organization 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            var model = await _reservation.GetReservationsForAddCancelRequest(organization.OwnerId);

            return model.Select(p => new SelectListViewModel()
            {
                Id = p.Id,
                Title = p.ReservationDate.ToShamsi()
            }).ToList();
        }

        //Get Doctor Reservation Date By Date 
        public async Task<DoctorReservationDate?> GetDoctorReservationDateByDate(DateTime date, ulong userId)
        {
            return await _reservation.GetDoctorReservationDateByDate(date, userId);
        }

        public async Task<FilterAppointmentViewModel> FilterDoctorReservationDateSide(FilterAppointmentViewModel filter)
        {
            return await _reservation.FilterDoctorReservationDateSide(filter);
        }

        public async Task<FilterAppointmentViewModel> FiltrDoctorReservationDateHistory(FilterAppointmentViewModel filter)
        {
            return await _reservation.FiltrDoctorReservationDateHistory(filter);
        }

        //Add Reservation Date 
        public async Task<bool> AddReservationDate(AddReservationDateViewModel model, ulong userId)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Is Exist Any Reservastion Date 

            if (await _reservation.IsExistAnyDuplicateReservationDate(model.ReservationDate.ToMiladiDateTime(), organization.OwnerId))
            {
                return false;
            }

            #endregion

            #region Check Doctor Is Valid

            var doctor = await _doctorsRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return false;

            #endregion

            #region Fill Entity

            DoctorReservationDate reservation = new DoctorReservationDate()
            {
                UserId = organization.OwnerId,
                CreateDate = DateTime.Now,
                ReservationDate = model.ReservationDate.ToMiladiDateTime()
            };

            #endregion

            #region Add Reservation Date Method

            await _reservation.AddDoctorReservationDate(reservation);

            #endregion

            #region Get Doctor Office Address

            var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(organization.OwnerId);

            #endregion

            #region If Add Reservation Date State Is computerized

            //Check That Fields Are Not Empty
            if (model.AddReservationDateState == AddReservationDateState.computerized && model.StartTime.HasValue && model.EndTime.HasValue && model.PeriodNumber.HasValue)
            {
                //If Start Time Is Smaller Than End Time 
                if (model.StartTime.Value >= model.EndTime.Value) return false;

                int hours = model.StartTime.Value;
                int minute = 0;

                int startTime = model.StartTime.Value;
                int endTimeComingFromModel = model.EndTime.Value;
                int periodNumber = model.PeriodNumber.Value;

                //Diference Between Start Time And End Time 
                int diference = (endTimeComingFromModel - startTime) * 60;

                // The Number Of Intervals
                int intervalsCount = diference / periodNumber;

                for (int i = 0; i < intervalsCount; i++)
                {
                    //Sampling From Reservation Date Time 
                    DoctorReservationDateTime reservationTime = new DoctorReservationDateTime();

                    //Sampling From Time DateTime 
                    DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minute, 0);
                    DateTime endTime = time.AddMinutes(periodNumber);

                    //Fill Reservation Date Time 
                    reservationTime.StartTime = time.ToString($"{time.Hour.ToString("00")}:{time.Minute.ToString("00")}:00");
                    reservationTime.EndTime = endTime.ToString($"{endTime.Hour.ToString("00")}:{endTime.Minute.ToString("00")}:00");
                    reservationTime.DoctorReservationDateId = reservation.Id;
                    reservationTime.DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved;
                    if (doctorOffice != null) reservationTime.WorkAddressId = doctorOffice.Id;

                    await _reservation.AddReservationDateTime(reservationTime);

                    //Update Last Parameters For Proccess Next Reservation Date Time 
                    hours = endTime.Hour;
                    minute = endTime.Minute;
                }
            }

            #endregion

            return true;
        }

        public async Task<List<DoctorReservationDateTime>?> GetListOfReservationDateTimesByReservationDateId(ulong reservationDateId)
        {
            return await _reservation.GetListOfReservationDateTimesByReservationDateId(reservationDateId);
        }

        public async Task<FilterReservationDateTimeDoctorPAnel> FilterReservationDateTimeDoctorSide(FilterReservationDateTimeDoctorPAnel filter)
        {
            return await _reservation.FilterReservationDateTimeDoctorSide(filter);
        }

        public async Task<DoctorReservationDate?> GetReservationDateById(ulong reservationDateId)
        {
            return await _reservation.GetReservationDateById(reservationDateId);
        }

        public async Task<bool> DeleteReservationDate(ulong reservationDateId, ulong userId)
        {
            #region Get Organization by UserId

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Doctor By Owner Id

            var doctor = await _doctorsRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return false;

            #endregion

            #region Get Reservation Id

            var reservation = await _reservation.GetReservationDateById(reservationDateId);
            if (reservation == null) return false;

            #endregion

            #region Get Reservation Date Times 

            var list = await _reservation.GetListOfReservationDateTimesByReservationDateId(reservationDateId);
            if (list != null && list.Any()) return false;

            #endregion

            #region Delete Reservation Date 

            reservation.IsDelete = true;

            await _reservation.UpdateReservationDate(reservation);

            #endregion

            return true;
        }

        public async Task<AddReservationDateTimeViewModel?> FillAddReservationDateTime(ulong reservationDateId, ulong userId)
        {
            #region Get Organization By User Id 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Doctor By Owner Id

            var doctor = await _doctorsRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return null;

            #endregion

            #region Get Reservation By Id 

            var reservationDate = await _reservation.GetReservationDateById(reservationDateId);
            if (reservationDate == null) return null;
            if (reservationDate.UserId != organization.OwnerId) return null;

            #endregion

            #region Fill View Model

            AddReservationDateTimeViewModel model = new AddReservationDateTimeViewModel()
            {
                ReservationDateId = reservationDateId,
            };

            #endregion

            return model;
        }

        public async Task<bool> AddReservationDateTimeDoctorPanel(AddReservationDateTimeViewModel model, ulong userId)
        {
            #region Get Organization By User Id 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Doctor By Owner Id

            var doctor = await _doctorsRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return false;

            #endregion

            #region Get Reservation By Id 

            var reservationDate = await _reservation.GetReservationDateById(model.ReservationDateId);
            if (reservationDate == null) return false;
            if (reservationDate.UserId != organization.OwnerId) return false;

            #endregion

            #region Get Doctor Office Address

            var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(organization.OwnerId);

            #endregion

            #region Fill Entity

            DoctorReservationDateTime dateTime = new DoctorReservationDateTime
            {
                CreateDate = DateTime.Now,
                DoctorReservationDateId = model.ReservationDateId,
                DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
            };

            //Fill Work Address Id 
            if (doctorOffice != null)
            {
                dateTime.WorkAddressId = doctorOffice.Id;
            }

            await _reservation.AddReservationDateTime(dateTime);

            #endregion

            return true;
        }

        public async Task<bool> DeleteReservationDateTime(ulong reservationDateTimeId, ulong userId)
        {
            #region Get Organization By User Id 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return false;

            #endregion

            #region Get Doctor By Owner Id

            var doctor = await _doctorsRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return false;

            #endregion

            #region Get Reservation Date Time By Id

            var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationDateTimeId);
            if (reservationDateTime == null) return false;
            if (reservationDateTime.DoctorReservationDate.UserId != organization.OwnerId) return false;

            //If This Time Was Reserved Cannot Be Delete
            if (reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved) return false;
            if (reservationDateTime.PatientId != null) return false;

            #endregion

            #region Delete Reservation Date Time 

            reservationDateTime.IsDelete = true;

            await _reservation.UpdateReservationDateTime(reservationDateTime);

            #endregion

            return true;
        }

        public async Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeById(ulong reservationDateTimeId)
        {
            return await _reservation.GetDoctorReservationDateTimeById(reservationDateTimeId);
        }

        public async Task<ShowPatientDetailViewModel?> ShowPatientDetailViewModel(ulong reservationDateTimeId, ulong userId)
        {
            #region Get Organization By User Id 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null) return null;

            #endregion

            #region Get Doctor By Owner Id

            var doctor = await _doctorsRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return null;

            #endregion

            #region Get Reservation Date Time By Id

            var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationDateTimeId);
            if (reservationDateTime == null) return null;
            if (reservationDateTime.PatientId == null) return null;
            if (reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved
                && reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Canceled) return null;

            #endregion

            #region Get Reservation Date

            var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
            if (reservationDate == null) return null;
            if (reservationDate.UserId != organization.OwnerId) return null;

            #endregion

            #region Get Patient By User Id

            var patient = await _userService.GetUserById(reservationDateTime.PatientId.Value);
            if (patient == null) return null;

            #endregion

            #region Fill View Model

            ShowPatientDetailViewModel model = new ShowPatientDetailViewModel()
            {
                DoctorReservationDate = reservationDate,
                DoctorReservationDateTime = reservationDateTime,
                User = patient
            };

            #endregion

            return model;
        }

        #endregion

        #region User Panel

        public async Task<FilterReservationViewModel?> FilterReservationUserPanelViewModel(FilterReservationViewModel filter)
        {
            return await _reservation.FilterReservationUserPanelViewModel(filter);
        }

        public async Task<ShowReservationDetailUserSideViewModel?> FillShowReservationUserSideViewModel(ulong reservationId, ulong userId)
        {
            #region Get User By Id

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Reservation Date Time By Id

            var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationId);
            if (reservationDateTime == null) return null;
            if (reservationDateTime.PatientId != userId) return null;

            #endregion

            #region Get Reservation Date By Id

            var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
            if (reservationDate == null) return null;

            #endregion

            #region Get Doctor By Doctor Id

            var doctor = await _userService.GetUserById(reservationDate.UserId);
            if (doctor == null) return null;

            #endregion

            #region Fill View Model

            ShowReservationDetailUserSideViewModel model = new ShowReservationDetailUserSideViewModel()
            {
                DoctorReservationDate = reservationDate,
                DoctorReservationDateTime = reservationDateTime,
                User = doctor
            };

            #endregion

            #region Get Doctor Work Address

            var officeAddress = await _workAddress.GetUserWorkAddressById(reservationDate.UserId);

            if (officeAddress != null)
            {
                model.WorkAddress = officeAddress.Address;
            }

            #endregion

            return model;
        }

        public async Task<FilterReservationViewModel?> FilterReservationUserPanelViewComponent(FilterReservationViewModel filter)
        {
            return await _reservation.FilterReservationUserPanelViewComponent(filter);
        }

        //This Is Filter For Reservation Date From Today 
        public async Task<FilterDoctorFamilyReservationDateViewModel?> FilterFamilyDoctorReservationDateFromUserPanel(FilterDoctorFamilyReservationDateViewModel filter)
        {
            return await _reservation.FilterFamilyDoctorReservationDateFromUserPanel(filter);
        }

        //Filter Family Doctor Reservation DateTime In UserPanel ViewModel
        public async Task<FilterFamilyDoctorReservationDateTimeUserPanelViewModel?> FilterFamilyDoctorReservationDateTimeUserPanel(FilterFamilyDoctorReservationDateTimeUserPanelViewModel filter)
        {
            return await _reservation.FilterFamilyDoctorReservationDateTimeUserPanel(filter);
        }

        #endregion

        #region Admin Panel

        //Filter Date Time Reservation
        public async Task<FilterReservationAdminSideViewModel?> FilterReservationAdminPanelViewModel(FilterReservationAdminSideViewModel filter)
        {
            return await _reservation.FilterReservationAdminPanelViewModel(filter);
        }

        public async Task<ShowReservationDetailAdminSideViewModel?> FillShowReservationDetailAdminSideViewModel(ulong reservationId)
        {
            #region Get Reservation Date Time By Id

            var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationId);
            if (reservationDateTime == null) return null;
            if (reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Canceled) return null;


            #endregion

            #region Get Reservation Date By Id

            var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
            if (reservationDate == null) return null;

            #endregion

            #region Get Doctor By Doctor Id

            var doctor = await _userService.GetUserById(reservationDate.UserId);
            if (doctor == null) return null;

            #endregion

            #region Fill View Model

            ShowReservationDetailAdminSideViewModel model = new ShowReservationDetailAdminSideViewModel()
            {
                DoctorReservationDate = reservationDate,
                DoctorReservationDateTime = reservationDateTime,
                Doctor = doctor
            };

            #endregion

            #region Get Patient 

            if (reservationDateTime.PatientId != null)
            {
                var patient = await _userService.GetUserById(reservationDateTime.PatientId.Value);
                model.Patient = patient;
            }

            #endregion

            #region Get Doctor Work Address

            var officeAddress = await _workAddress.GetUserWorkAddressById(reservationDate.UserId);

            if (officeAddress != null)
            {
                model.WorkAddress = officeAddress.Address;
            }

            #endregion

            return model;
        }

        public async Task<FilterClosedReservationAdminViewModel?> FilterClosedReservationAdminPanelViewModel(FilterClosedReservationAdminViewModel filter)
        {
            return await _reservation.FilterClosedReservationAdminPanelViewModel(filter);
        }

        //List Of Request For Cancelation Reservation
        public async Task<FilterCancelReservationRequestsViewModel?> FilterCancelReservationRequestsViewModel(FilterCancelReservationRequestsViewModel filter)
        {
            return await _reservation.FilterCancelReservationRequestsViewModel(filter);
        }

        //List Of Request For Cancelation Reservatio Date Time 
        public async Task<FilterCancelationRequestReservationDateTimeViewModel?> FilterCancelationRequestReservationDateTime(FilterCancelationRequestReservationDateTimeViewModel filter)
        {
            return await _reservation.FilterCancelationRequestReservationDateTime(filter);
        }

        #endregion

        #region Supporter Panel 

        public async Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter)
        {
            return await _reservation.FilterReservationSupporterPanelViewModel(filter);
        }

        public async Task<ShowReservationDetailSupporterSideViewModel?> FillShowReservationDetailSupporterSideViewModel(ulong reservationId)
        {
            #region Get Reservation Date Time By Id

            var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationId);
            if (reservationDateTime == null) return null;

            #endregion

            #region Get Reservation Date By Id

            var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
            if (reservationDate == null) return null;

            #endregion

            #region Get Doctor By Doctor Id

            var doctor = await _userService.GetUserById(reservationDate.UserId);
            if (doctor == null) return null;

            #endregion

            #region Fill View Model

            ShowReservationDetailSupporterSideViewModel model = new ShowReservationDetailSupporterSideViewModel()
            {
                DoctorReservationDate = reservationDate,
                DoctorReservationDateTime = reservationDateTime,
                Doctor = doctor
            };

            #endregion

            #region Get Patient 

            if (reservationDateTime.PatientId != null)
            {
                var patient = await _userService.GetUserById(reservationDateTime.PatientId.Value);
                model.Patient = patient;
            }

            #endregion

            #region Get Doctor Work Address

            var officeAddress = await _workAddress.GetUserWorkAddressById(reservationDate.UserId);

            if (officeAddress != null)
            {
                model.WorkAddress = officeAddress.Address;
            }

            #endregion

            return model;
        }

        public async Task<bool> CloseReservation(ulong reservationTimeId)
        {
            #region Get Reservation Time By Id 

            var reservationTime = await _reservation.GetDoctorReservationDateTimeById(reservationTimeId);
            if (reservationTime == null) return false;

            #endregion

            #region Get Reservation Tariff

            var reservationTariff = await _siteSettingService.GetReservationTariff();
            if (reservationTariff == 0) return false;

            #endregion

            #region Add Transaction And Log

            if (reservationTime.PatientId.HasValue)
            {
                #region Get Patient By User Id

                var patient = await _userService.GetUserById(reservationTime.PatientId.Value);
                if (patient == null) return false;

                #endregion

                #region Add Transaction

                if (reservationTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Reserved)
                {
                    //Fill Model
                    AdminCreateWalletViewModel model = new AdminCreateWalletViewModel
                    {
                        Description = "بازگشت هزینه ی نوبت دریافت شده به علت لغو نوبت .",
                        GatewayType = Domain.Entities.Wallet.GatewayType.System,
                        PaymentType = Domain.Entities.Wallet.PaymentType.ChargeWallet,
                        Price = reservationTariff,
                        TransactionType = Domain.Entities.Wallet.TransactionType.Deposit,
                        UserId = patient.Id
                    };

                    var res = await _walletService.CreateWalletAsync(model);

                    if (res == AdminCreateWalletResponse.UserNotFound) return false;
                }


                #endregion

                #region Add Log For Close Reservation

                LogForCloseReservation log = new LogForCloseReservation()
                {
                    UserId = patient.Id,
                    DoctorReservationDateTimeId = reservationTimeId,
                };

                await _reservation.AddLogForCloseReservation(log);

                #endregion
            }

            #endregion

            #region Change Reservation State 

            reservationTime.DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.Canceled;
            reservationTime.DoctorReservationType = null;
            reservationTime.PatientId = null;

            await _reservation.UpdateReservationDateTime(reservationTime);

            #endregion

            return true;
        }

        #endregion

        #region Site Side

        //Get Reservation Date By Reservation Date And User Id
        public async Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(DateTime reservationDate, ulong userId)
        {
            return await _reservation.GetDoctorReservationDateByReservationDateAndUserId(reservationDate , userId);
        }

        //Get Reservation Date By Reservation Date And User Id
        public async Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(string reservationDate , ulong userId)
        {
            #region Convert Logged Date To Date Time 

            var spliteDate = reservationDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime date = new DateTime(year, month, day, new PersianCalendar());

            #endregion

            return await GetDoctorReservationDateByReservationDateAndUserId(date, userId);
        }

        //Get List Of Doctor Reservation Date Time By Reservation Date Id
        public async Task<List<DoctorReservationDateTime>?> GetListOfDoctorReservationDateTimeByReservationDateId(ulong reservationDateId)
        {
            return await _reservation.GetListOfDoctorReservationDateTimeByReservationDateId(reservationDateId);
        }

        //Get Reservation Date Time By Reservation Date And User Id
        public async Task<List<DoctorReservationDateTime>?> GetDoctorReservationDateByReservationDateTimeAndUserId(string loggedreservationDate, ulong userId)
        {
            #region Convert Logged Date To Date Time 

            var spliteDate = loggedreservationDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime date = new DateTime(year, month, day, new PersianCalendar());

            #endregion

            #region Get Doctor Reservation Date 

            var reservationDate = await GetDoctorReservationDateByReservationDateAndUserId(date, userId);
            if (reservationDate == null) return null;

            #endregion

            #region Get Doctor Reservation Date Time 

            var doctorReservationDateTime = await _reservation.GetListOfDoctorReservationDateTimeByReservationDateId(reservationDate.Id);

            #endregion

            return doctorReservationDateTime;
        }

        //Get Reservation Date Time To User Patient
        public async Task<bool> GetReservationDateTimeToUserPatient(ChooseTypeOfReservationViewModel model , ulong patientId)
        {
            #region get Doctor Reservation Date Time By Id 

            var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(model.ReservationDateTimeId);
            if(reservationDateTime == null) return false;
            if (reservationDateTime.DoctorReservationDate.UserId != model.DoctorId) return false;
            if (reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved) return false;

            #endregion

            #region Update Method 

            reservationDateTime.DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.WaitingForComplete;
            reservationDateTime.PatientId = patientId;
            reservationDateTime.DoctorReservationType = model.DoctorReservationType;

            #region Get User Office Address

            var workAddress = await _workAddress.GetUserWorkAddressById(model.DoctorId);

            if (workAddress == null && model.DoctorReservationType == Domain.Enums.DoctorReservation.DoctorReservationType.Reserved) return false;
            if (workAddress != null && model.DoctorReservationType == Domain.Enums.DoctorReservation.DoctorReservationType.Reserved)
            {
                reservationDateTime.WorkAddressId = workAddress.Id;
            }

            #endregion

            await _reservation.UpdateReservationDateTime(reservationDateTime);

            #endregion

            return true;
        }

        //Reserve Doctor Reservation Date Time After Success Payment
        public async Task ReserveDoctorReservationDateTimeAfterSuccessPayment(ulong reservationDateTimeId)
        {
            #region get Doctor Reservation Date Time By Id 

            var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationDateTimeId);

            #endregion

            #region Update Method 

            reservationDateTime.DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.Reserved;

            await _reservation.UpdateReservationDateTime(reservationDateTime);

            #endregion
        }

        #endregion
    }
}
