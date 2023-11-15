#region Usings

using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Account;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Domain.ViewModels.Tourist.Token;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

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
    private readonly IWalletRepository _walletRepository;
    private readonly ISMSService _smsService;
    private readonly IFamilyDoctorRepository _familyDoctorRepository;

    public ReservationService(IReservationRepository reservation, IOrganizationService organizationService, IWorkAddressService workAddress
                             , IDoctorsRepository doctorsRepository, IUserService userService, ISiteSettingService siteSettingService
                                , IWalletService walletService, IWalletRepository walletRepository, ISMSService smsService
                                    , IFamilyDoctorRepository familyDoctorRepository)
    {
        _reservation = reservation;
        _organizationService = organizationService;
        _workAddress = workAddress;
        _doctorsRepository = doctorsRepository;
        _userService = userService;
        _siteSettingService = siteSettingService;
        _walletService = walletService;
        _walletRepository = walletRepository;
        _smsService = smsService;
        _familyDoctorRepository = familyDoctorRepository;
    }

    #endregion

    #region Doctor Panel

    public async Task SendSMSForReminderToReservation()
    {
        var userMobiles = await _reservation.SendSMSForReminderToReservation();

        if (userMobiles != null && userMobiles.Any())
        {
            foreach (var userMobile in userMobiles)
            {
                var message = Messages.SendSMSForReminderToReservation(userMobile.DoctorUsername);

                await _smsService.SendSimpleSMS(userMobile.UserMobile, message);
            }
        }
    }

    //List Of Appointments Received
    public async Task<ListOfAppointmentsReceivedJoinDoctorSideDTO?> ListOfAppointmentsReceived(ListOfAppointmentsReceivedJoinDoctorSideDTO filter, ulong userId)
    {
        #region Get Organization 

        var organization = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
        if (!organization.HasValue) return null;

        filter.DoctorUserId = organization.Value;

        #endregion

        return await _reservation.ListOfAppointmentsReceived(filter);
    }

    //List Of People Who Have Visited
    public async Task<ListOfPeopleWhoHaveVisitedDoctorSideDTO?> ListOfPeopleWhoHaveVisited(ListOfPeopleWhoHaveVisitedDoctorSideDTO filter, ulong userId)
    {
        #region Get Organization 

        var organization = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
        if (!organization.HasValue) return null;

        filter.DoctorUserId = organization.Value;

        #endregion

        return await _reservation.ListOfPeopleWhoHaveVisited(filter);
    }

    //Fill Add Reservation Date Time With Computer View Model
    public async Task<AddReservationDateTimeWithComputerViewModel?> FillAddReservationDateTimeWithComputerViewModel(ulong reservationDateId, ulong doctorId)
    {
        #region Get Reservation Date By Id

        var reservationDate = await _reservation.GetReservationDateById(reservationDateId);
        if (reservationDate == null) return null;
        if (reservationDate.UserId != doctorId) return null;

        #endregion

        #region Fill View Model 

        AddReservationDateTimeWithComputerViewModel model = new AddReservationDateTimeWithComputerViewModel()
        {
            ReservationDateId = reservationDateId
        };

        #endregion

        return model;
    }

    //Add Cancel Reservation Request 
    public async Task<bool> CreateCancelReservationRequestFromDoctorPanel(CancelReservationRequestViewModel model, ulong userId)
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

        return await _reservation.GetReservationDateTimeByReservationDateIdSelectList(reservationDateId, organization.OwnerId);
    }

    //Get List Of Reservation Dete Time By Reservation Date Id For Select List From Dentist Panel
    public async Task<List<SelectListViewModel>> GetReservationDateTimeByReservationDateIdSelectListFromDentistPanel(ulong reservationDateId, ulong userId)
    {
        #region Get Organization 

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return null;

        #endregion

        #region Get Doctor Reservation Date By Id 

        var reservation = await _reservation.GetReservationDateById(reservationDateId);
        if (reservation == null) return null;
        if (reservation.UserId != organization.OwnerId) return null;

        #endregion

        return await _reservation.GetReservationDateTimeByReservationDateIdSelectList(reservationDateId, organization.OwnerId);
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

    public async Task<List<DoctorReservationDate>?> FilterDoctorReservationDateSideWithoutPaging(FilterAppointmentViewModelWithoutPaging filter)
    {
        return await _reservation.FilterDoctorReservationDateSideWithoutPaging(filter);
    }

    //This Is Filter For Reservation Date From Today By Dentist Panel
    public async Task<FilterAppointmentViewModel?> FilterDoctorReservationDateSideByDentistPanel(FilterAppointmentViewModel filter)
    {
        return await _reservation.FilterDoctorReservationDateSideByDentistPanel(filter);
    }

    //List Of Doctor Reservation Date After Date Time Now
    public async Task<List<DoctorReservationDate>> ListOfDoctorReservationDateAfterDateTimeNow(ulong userId)
    {
        return await _reservation.ListOfDoctorReservationDateAfterDateTimeNow(userId);
    }

    //List Of Doctor Reservation Date After Date Time Now In Dentist Panel
    public async Task<List<DoctorReservationDate>> ListOfDoctorReservationDateAfterDateTimeNowInDentistPanel(ulong userId)
    {
        return await _reservation.ListOfDoctorReservationDateAfterDateTimeNowInDentistPanel(userId);
    }

    public async Task<FilterAppointmentViewModel> FiltrDoctorReservationDateHistory(FilterAppointmentViewModel filter)
    {
        return await _reservation.FiltrDoctorReservationDateHistory(filter);
    }

    //This Is History Of All Records That In Reservation Date By User Id ByDentistPanel 
    public async Task<FilterAppointmentViewModel?> FiltrDoctorReservationDateHistoryByDentistPanel(FilterAppointmentViewModel filter)
    {
        return await _reservation.FiltrDoctorReservationDateHistoryByDentistPanel(filter);
    }

    //Add Reservation Date 
    public async Task<bool> AddReservationDate(AddReservationDateViewModel model, ulong userId)
    {
        #region Is Exist Any Reservastion Date 

        if (await _reservation.IsExistAnyDuplicateReservationDate(model.ReservationDate.ToMiladiDateTime(), userId))
        {
            return false;
        }

        #endregion

        #region Fill Entity

        DoctorReservationDate reservation = new DoctorReservationDate()
        {
            UserId = userId,
            CreateDate = DateTime.Now,
            ReservationDate = model.ReservationDate.ToMiladiDateTime()
        };

        #endregion

        #region Add Reservation Date Method

        await _reservation.AddDoctorReservationDate(reservation);

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
                reservationTime.DoctorReservationState = DoctorReservationState.NotReserved;
                reservationTime.DoctorReservationTypeSelected = model.DoctorReservationType;
                reservationTime.WorkAddressId = model.LocationId;

                await _reservation.AddReservationDateTime(reservationTime);

                //Update Last Parameters For Proccess Next Reservation Date Time 
                hours = endTime.Hour;
                minute = endTime.Minute;
            }

            await _reservation.Savechanges();
        }

        #endregion

        return true;
    }

    //Add Reservation Date From Dentist Panel
    public async Task<bool> AddReservationDateFromDentistPanel(AddReservationDateViewModel model, ulong organizationOwnerId)
    {
        #region Is Exist Any Reservastion Date 

        if (await _reservation.IsExistAnyDuplicateReservationDate(model.ReservationDate.ToMiladiDateTime(), organizationOwnerId))
        {
            return false;
        }

        #endregion

        #region Fill Entity

        DoctorReservationDate reservation = new DoctorReservationDate()
        {
            UserId = organizationOwnerId,
            CreateDate = DateTime.Now,
            ReservationDate = model.ReservationDate.ToMiladiDateTime()
        };

        #endregion

        #region Add Reservation Date Method

        await _reservation.AddDoctorReservationDate(reservation);

        #endregion

        #region Get Doctor Office Address

        var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(organizationOwnerId);

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
                reservationTime.DoctorReservationState = DoctorReservationState.NotReserved;
                if (doctorOffice != null) reservationTime.WorkAddressId = doctorOffice.Id;

                await _reservation.AddReservationDateTime(reservationTime);

                //Update Last Parameters For Proccess Next Reservation Date Time 
                hours = endTime.Hour;
                minute = endTime.Minute;
            }

            await _reservation.Savechanges();
        }

        #endregion

        return true;
    }

    //Add Reservation Date Time With Coputer   
    public async Task<bool> AddReservationDateTimeWithCoputer(AddReservationDateTimeWithComputerViewModel model, ulong userId)
    {
        #region Get Reservation Date  

        var reservationDate = await _reservation.GetReservationDateById(model.ReservationDateId);
        if (reservationDate == null) return false;
        if (reservationDate.UserId != userId) return false;

        #endregion

        #region Get Doctor Office Address

        var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(userId);

        #endregion

        #region Get Reservation Date Times By This Reservation Date Id

        var reservationDateTimes = await GetListOfDoctorReservationDateTimeByReservationDateId(reservationDate.Id);

        #endregion

        #region Add Reservation Date State Is computerized

        //If Start Time Is Smaller Than End Time 
        if (model.StartTime >= model.EndTime) return false;

        int hours = model.StartTime;
        int minute = 0;

        int startTime = model.StartTime;
        int endTimeComingFromModel = model.EndTime;
        int periodNumber = model.PeriodNumber;

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
            reservationTime.DoctorReservationDateId = reservationDate.Id;
            reservationTime.DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved;
            reservationTime.DoctorReservationTypeSelected = model.DoctorReservationType;
            reservationTime.WorkAddressId = model.LocationId;

            #region Check Is Exist Doctor Reservation Date Time With This Time 

            if (reservationDateTimes != null && reservationDateTimes.Any())
            {
                var startTimes = Int32.Parse(reservationTime.StartTime.Substring(0, 2));
                var endTimes = Int32.Parse(reservationTime.EndTime.Substring(0, 2));

                foreach (var item in reservationDateTimes)
                {
                    var lastStart = Int32.Parse(item.StartTime.Substring(0, 2));
                    var lastEnd = Int32.Parse(item.EndTime.Substring(0, 2));

                    if (lastStart < endTimes && lastEnd > startTimes)
                    {
                        return false;
                    }
                }
            }

            #endregion

            await _reservation.AddReservationDateTime(reservationTime);

            //Update Last Parameters For Proccess Next Reservation Date Time 
            hours = endTime.Hour;
            minute = endTime.Minute;
        }

        await _reservation.Savechanges();

        #endregion

        return true;
    }

    //Add Reservation Date Time With Coputer From Dentist Panel  
    public async Task<bool> AddReservationDateTimeWithCoputerFromDentistPanel(AddReservationDateTimeWithComputerViewModel model, ulong userId)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return false;

        #endregion

        #region Get Reservation Date  

        var reservationDate = await _reservation.GetReservationDateById(model.ReservationDateId);
        if (reservationDate == null) return false;
        if (reservationDate.UserId != organization.OwnerId) return false;

        #endregion

        #region Get Doctor Office Address

        var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(organization.OwnerId);

        #endregion

        #region Get Reservation Date Times By This Reservation Date Id

        var reservationDateTimes = await GetListOfDoctorReservationDateTimeByReservationDateId(reservationDate.Id);

        #endregion

        #region Add Reservation Date State Is computerized

        //If Start Time Is Smaller Than End Time 
        if (model.StartTime >= model.EndTime) return false;

        int hours = model.StartTime;
        int minute = 0;

        int startTime = model.StartTime;
        int endTimeComingFromModel = model.EndTime;
        int periodNumber = model.PeriodNumber;

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
            reservationTime.DoctorReservationDateId = reservationDate.Id;
            reservationTime.DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved;
            if (doctorOffice != null) reservationTime.WorkAddressId = doctorOffice.Id;

            #region Check Is Exist Doctor Reservation Date Time With This Time 

            if (reservationDateTimes != null && reservationDateTimes.Any())
            {
                var startTimes = Int32.Parse(reservationTime.StartTime.Substring(0, 2));
                var endTimes = Int32.Parse(reservationTime.EndTime.Substring(0, 2));

                foreach (var item in reservationDateTimes)
                {
                    var lastStart = Int32.Parse(item.StartTime.Substring(0, 2));
                    var lastEnd = Int32.Parse(item.EndTime.Substring(0, 2));

                    if (lastStart <= startTimes && lastEnd >= endTimes)
                    {
                        return false;
                    }
                }
            }

            #endregion

            await _reservation.AddReservationDateTime(reservationTime);

            //Update Last Parameters For Proccess Next Reservation Date Time 
            hours = endTime.Hour;
            minute = endTime.Minute;
        }

        await _reservation.Savechanges();

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

    //Filter Reservation Date Time Dentist Side
    public async Task<FilterReservationDateTimeDoctorPAnel?> FilterReservationDateTimeDentistSide(FilterReservationDateTimeDoctorPAnel filter)
    {
        return await _reservation.FilterReservationDateTimeDentistSide(filter);
    }

    public async Task<DoctorReservationDate?> GetReservationDateById(ulong reservationDateId)
    {
        return await _reservation.GetReservationDateById(reservationDateId);
    }

    public async Task<bool> DeleteReservationDate(ulong reservationDateId, ulong userId)
    {
        #region Get Organization by UserId

        var organization = await _organizationService.GetOrganizationByUserId(userId);
        if (organization == null) return false;

        #endregion

        #region Get Reservation Id

        var reservation = await _reservation.GetReservationDateById(reservationDateId);
        if (reservation == null) return false;
        if (organization.OwnerId != reservation.UserId) return false;

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

    //Delete Reservation Date From Dentist Panel
    public async Task<bool> DeleteReservationDateFromDentistPanel(ulong reservationDateId, ulong userId)
    {
        #region Get Organization by UserId

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return false;

        #endregion

        #region Get Reservation Id

        var reservation = await _reservation.GetReservationDateById(reservationDateId);
        if (reservation == null) return false;
        if (organization.OwnerId != reservation.UserId) return false;

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
        #region Get Reservation By Id 

        var reservationDate = await _reservation.GetReservationDateById(reservationDateId);
        if (reservationDate == null) return null;

        #endregion

        #region Fill View Model

        AddReservationDateTimeViewModel model = new AddReservationDateTimeViewModel()
        {
            ReservationDateId = reservationDateId,
        };

        #endregion

        return model;
    }

    //Fill Add Reservation Date Time From Dentist Panel
    public async Task<AddReservationDateTimeViewModel?> FillAddReservationDateTimeFromDentistPanel(ulong reservationDateId, ulong userId)
    {
        #region Get Organization By User Id 

        var organizationOwnerId = await _organizationService.GetDentistOrganizationOwnerIdByUserId(userId);
        if (organizationOwnerId == 0) return null;

        #endregion

        #region Get Reservation By Id 

        var reservationDate = await _reservation.GetReservationDateById(reservationDateId);
        if (reservationDate == null) return null;
        if (reservationDate.UserId != organizationOwnerId) return null;

        #endregion

        #region Fill View Model

        AddReservationDateTimeViewModel model = new AddReservationDateTimeViewModel()
        {
            ReservationDateId = reservationDateId,
        };

        #endregion

        return model;
    }


    //Fill Add Between Patient Time Doctor Side View Model
    public async Task<AddBetweenPatientTimeDoctorSideViewModel?> FillAddBetweenPatientTimeDoctorSideViewModel(ulong reservationDateId, ulong userId)
    {
        #region Get Organization OwnerId 

        ulong? ownerId = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
        if (ownerId == null || ownerId == 0) return null;

        #endregion

        #region Get Reservation By Id 

        var reservationDate = await _reservation.GetReservationDateByIdWithAsNoTracking(reservationDateId);
        if (reservationDate == null) return null;
        if (reservationDate.UserId != ownerId.Value) return null;

        #endregion

        AddBetweenPatientTimeDoctorSideViewModel model = new AddBetweenPatientTimeDoctorSideViewModel()
        {
            ReservationDateId = reservationDate.Id
        };

        return model;
    }

    public async Task<bool> AddReservationDateTimeDoctorPanel(AddReservationDateTimeViewModel model, ulong userId)
    {
        #region Get Reservation By Id 

        var reservationDate = await _reservation.GetReservationDateById(model.ReservationDateId);
        if (reservationDate == null) return false;
        if (reservationDate.UserId != userId) return false;

        #endregion

        #region Get Doctor Office Address

        var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(userId);

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

    //Add Reservation Date Time Dentist Panel
    public async Task<bool> AddReservationDateTimeDentistPanel(AddReservationDateTimeViewModel model, ulong userId)
    {
        #region Get Organization By User Id 

        var organizationOwnerId = await _organizationService.GetDentistOrganizationOwnerIdByUserId(userId);
        if (organizationOwnerId == 0) return false;

        #endregion

        #region Get Reservation By Id 

        var reservationDate = await _reservation.GetReservationDateById(model.ReservationDateId);
        if (reservationDate == null) return false;
        if (reservationDate.UserId != organizationOwnerId) return false;

        #endregion

        #region Get Doctor Office Address

        var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(organizationOwnerId);

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
        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationDateTimeId);
        if (reservationDateTime == null) return false;
        if (reservationDateTime.DoctorReservationDate.UserId != userId) return false;

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

    //Delete Reservation Date Time From Dentist Panel
    public async Task<bool> DeleteReservationDateTimeFromDentistPanel(ulong reservationDateTimeId, ulong userId)
    {
        #region Get Organization By User Id 

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return false;

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

    //Check Doctor Reservation Date Time Validation For Add Doctor Personal Patient (Doctor Booking)
    public async Task<DoctorPersonalBookingViewModel?> FillDoctorPersonalBooking(ulong reservationDateTimeId, ulong userId)
    {
        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationDateTimeId);
        if (reservationDateTime == null) return null;
        if (reservationDateTime.PatientId != null) return null;
        if (reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved) return null;

        #endregion

        #region Get Reservation Date

        var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null) return null;
        if (reservationDate.UserId != userId) return null;

        #endregion

        #region Fill Model

        DoctorPersonalBookingViewModel model = new DoctorPersonalBookingViewModel()
        {
            DoctorReservationDateTimeId = reservationDateTime.Id,
            WorkAddressId = reservationDateTime.WorkAddressId.Value,
        };

        #endregion

        return model;
    }

    //Check Doctor Reservation Date Time Validation For Add Doctor Personal Patient (Doctor Booking) From Dentist Panel
    public async Task<DoctorPersonalBookingViewModel?> FillDoctorPersonalBookingFromDentistPanel(ulong reservationDateTimeId, ulong userId)
    {
        #region Get Organization By User Id 

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return null;

        #endregion

        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationDateTimeId);
        if (reservationDateTime == null) return null;
        if (reservationDateTime.PatientId != null) return null;
        if (reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved) return null;

        #endregion

        #region Get Reservation Date

        var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null) return null;
        if (reservationDate.UserId != organization.OwnerId) return null;

        #endregion

        #region Fill Model

        DoctorPersonalBookingViewModel model = new DoctorPersonalBookingViewModel()
        {
            DoctorReservationDateTimeId = reservationDateTime.Id,
        };

        #endregion

        return model;
    }

    //Get Doctor Reservation Booking By Doctor Reservation Date Time 
    public async Task<DoctorPersonalBooking?> GetDoctorReservationBookingByDoctorReservationDateTime(ulong doctorReservationDateTimeId)
    {
        return await _reservation.GetDoctorReservationBookingByDoctorReservationDateTime(doctorReservationDateTimeId);
    }

    //Get Doctor Reservation Date Time By Include Relation With Doctor Booking
    public async Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(ulong reservationDateTimeId)
    {
        return await _reservation.GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(reservationDateTimeId);
    }

    public async Task<ShowPatientDetailViewModel?> ShowPatientDetailViewModel(ulong reservationDateTimeId, ulong userId)
    {
        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(reservationDateTimeId);
        if (reservationDateTime == null) return null;
        if (reservationDateTime.PatientId == null) return null;
        if (reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved
            && reservationDateTime.DoctorReservationState == Domain.Enums.DoctorReservation.DoctorReservationState.Canceled) return null;

        #endregion

        #region Get Reservation Date

        var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null) return null;
        if (reservationDate.UserId != userId) return null;

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
            User = patient,
            DoctorBooking = reservationDateTime.DoctorBooking,
            UserRequestDescription = reservationDateTime.UserRequestDescription,
            WorkAddress = await _workAddress.GetWorkAddressById(reservationDateTime.WorkAddressId.Value),
        };

        #endregion

        return model;
    }

    //Show Patient Detail ViewModel From Dentist Panel
    public async Task<ShowPatientDetailViewModel?> ShowPatientDetailViewModelFromDentistPanel(ulong reservationDateTimeId, ulong userId)
    {
        #region Get Organization By User Id 

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return null;

        #endregion

        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(reservationDateTimeId);
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
            User = patient,
            DoctorBooking = reservationDateTime.DoctorBooking,
        };

        #endregion

        return model;
    }

    //Check That Is Doctor Reservation Is Doctor Personal Booking 
    public async Task<bool> CheckThatIsDoctorReservationIsDoctorPersonalBooking(ulong reservationId, ulong userId)
    {
        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(reservationId);
        if (reservationDateTime == null) return false;
        if (reservationDateTime.PatientId == null) return false;

        #endregion

        #region return Result 

        if (reservationDateTime.PatientId == userId)
        {
            return true;
        }

        #endregion

        return false;
    }

    //Check That Is Doctor Reservation Is Doctor Personal Booking From Dentist Panel
    public async Task<bool> CheckThatIsDoctorReservationIsDoctorPersonalBookingFromDentistPanel(ulong reservationId, ulong userId)
    {
        #region Get Organization By User Id 

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return false;

        #endregion

        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(reservationId);
        if (reservationDateTime == null) return false;
        if (reservationDateTime.PatientId == null) return false;

        #endregion

        #region return Result 

        if (reservationDateTime.PatientId == organization.OwnerId)
        {
            return true;
        }

        #endregion

        return false;
    }

    //Add Patient To Doctor Booking 
    public async Task<bool> AddPatientToDoctorBooking(DoctorPersonalBookingViewModel model, ulong userId)
    {
        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(model.DoctorReservationDateTimeId);
        if (reservationDateTime == null) return false;
        if (reservationDateTime.PatientId != null) return false;
        if (reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved) return false;

        #endregion

        #region Get User By Mobile Number 

        //var user = await _userService.GetUserByMobile(model.Mobile);

        #endregion

        #region Get Reservation Date

        var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null) return false;
        if (reservationDate.UserId != userId) return false;

        #endregion

        #region Add Patient To Doctor Booking 

        #region Update Doctor Reservation Date Time 

        reservationDateTime.PatientId = userId;
        reservationDateTime.DoctorReservationState = DoctorReservationState.Reserved;
        reservationDateTime.DoctorReservationType = DoctorReservationType.Reserved;
        reservationDateTime.DoctorBooking = true;
        reservationDateTime.UserRequestDescription = model.UserRequetsDescription;

        //Update Method 
        await _reservation.UpdateReservationDateTime(reservationDateTime);

        #endregion

        #region Doctor Personal Booking 


        DoctorPersonalBooking booking = new DoctorPersonalBooking()
        {
            DoctorReservationDateTimeId = reservationDateTime.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            NationalId = model.NationalId,
        };

        //Add Method 
        await _reservation.AddDoctorPersonalBooking(booking);

        #endregion

        #endregion

        #region Send SMS

        var doctorUserInfo = await _userService.GetUserByIdWithAsNoTracking(reservationDate.UserId);
        if (doctorUserInfo != null)
        {
            var message = Messages.SendSMSForBetweenPatientInReservationSiteSide(reservationDateTime.StartTime, reservationDate.ReservationDate.ToShamsi(), doctorUserInfo.Username);

            await _smsService.SendSimpleSMS(model.Mobile, message);
        }

        #endregion

        return true;
    }

    //Add Between Patient Time 
    public async Task<bool> AddBetweenPatientTime(AddBetweenPatientTimeDoctorSideViewModel model, ulong userId)
    {
        #region Get Organization OwnerId 

        ulong? ownerId = await _organizationService.GetOrganizationOwnerIdByOrganizationMemberUserIdWithAsNoTracking(userId);
        if (ownerId == null || ownerId == 0) return false;

        #endregion

        #region Get Reservation By Id 

        var reservationDate = await _reservation.GetReservationDateByIdWithAsNoTracking(model.ReservationDateId);
        if (reservationDate == null) return false;
        if (reservationDate.UserId != ownerId.Value) return false;

        #endregion

        #region Get Doctor Office Address

        var doctorOffice = await _workAddress.GetLastWorkAddressByUserId(ownerId.Value);

        #endregion

        #region Fill Entity

        //int hours = model.StartTime;
        //int minute = 0;

        //int startTime = model.StartTime;

        ////Sampling From Time DateTime 
        //DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minute, 0);

        ////Fill Reservation Date Time 
        //var startReservationTime = time.ToString($"{time.Hour.ToString("00")}:{time.Minute.ToString("00")}:00");

        var startTimeByNumbers = $"{model.StartTimeHour.ToString("00")}:{model.StartTimeMinute.ToString("00")}:00";

        DoctorReservationDateTime dateTime = new DoctorReservationDateTime
        {
            CreateDate = DateTime.Now,
            DoctorReservationDateId = model.ReservationDateId,
            DoctorReservationState = DoctorReservationState.Reserved,
            StartTime = startTimeByNumbers,
            EndTime = startTimeByNumbers,
            PatientId = ownerId.Value,
            DoctorReservationType = DoctorReservationType.Reserved,
            DoctorBooking = true,
            UserRequestDescription = model.UserRequestDescription,
            WorkAddressId = model.LocationId
        };

        dateTime.WorkAddressId = model.LocationId;

        //Add Reservation Date Time 
        var reservationDatetimeId = await _reservation.AddReservationDateTimeWithReturnId(dateTime);

        #region Doctor Personal Booking 

        DoctorPersonalBooking booking = new DoctorPersonalBooking()
        {
            DoctorReservationDateTimeId = reservationDatetimeId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            NationalId = model.NationalId,
        };

        //Add Method 
        await _reservation.AddDoctorPersonalBooking(booking);

        #endregion

        #endregion

        #region Send SMS

        var doctorUserInfo = await _userService.GetUserByIdWithAsNoTracking(ownerId.Value);
        if (doctorUserInfo != null)
        {
            var message = Messages.SendSMSForBetweenPatientInReservationSiteSide(dateTime.StartTime, reservationDate.ReservationDate.ToShamsi(), doctorUserInfo.Username);

            await _smsService.SendSimpleSMS(model.Mobile, message);
        }

        #endregion

        return true;
    }

    //Add Patient To Doctor Booking From Dentist
    public async Task<bool> AddPatientToDoctorBookingFromDentist(DoctorPersonalBookingViewModel model, ulong userId)
    {
        #region Get Organization By User Id 

        var organization = await _organizationService.GetDentistOrganizationByUserId(userId);
        if (organization == null) return false;

        #endregion

        #region Get Reservation Date Time By Id

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(model.DoctorReservationDateTimeId);
        if (reservationDateTime == null) return false;
        if (reservationDateTime.PatientId != null) return false;
        if (reservationDateTime.DoctorReservationState != Domain.Enums.DoctorReservation.DoctorReservationState.NotReserved) return false;

        #endregion

        #region Get User By Mobile Number 

        //var user = await _userService.GetUserByMobile(model.Mobile);

        #endregion

        #region Get Reservation Date

        var reservationDate = await _reservation.GetReservationDateById(reservationDateTime.DoctorReservationDateId);
        if (reservationDate == null) return false;
        if (reservationDate.UserId != organization.OwnerId) return false;

        #endregion

        #region Add Patient To Doctor Booking 

        #region Update Doctor Reservation Date Time 

        reservationDateTime.PatientId = organization.OwnerId;
        reservationDateTime.DoctorReservationState = Domain.Enums.DoctorReservation.DoctorReservationState.Reserved;
        reservationDateTime.DoctorReservationType = Domain.Enums.DoctorReservation.DoctorReservationType.Reserved;
        reservationDateTime.DoctorBooking = true;

        //Update Method 
        await _reservation.UpdateReservationDateTime(reservationDateTime);

        #endregion

        #region Doctor Personal Booking 


        DoctorPersonalBooking booking = new DoctorPersonalBooking()
        {
            DoctorReservationDateTimeId = reservationDateTime.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Mobile = model.Mobile,
            NationalId = model.NationalId,
        };

        //Add Method 
        await _reservation.AddDoctorPersonalBooking(booking);

        #endregion

        #endregion

        return true;
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

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(reservationId);
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
            Doctor = doctor,
            LogForAnotherPatient = reservationDateTime.PatientId.HasValue ? await _reservation.FillLogForAnotherPatient(reservationDateTime.Id, reservationDateTime.PatientId.Value) : null,
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

    //List Of Doctor Personal Booking
    public async Task<List<DoctorPersonalBooking>> ListOfDoctorPersonalBooking()
    {
        return await _reservation.ListOfDoctorPersonalBooking();
    }

    #endregion

    #region Supporter Panel 

    //Get The Owner Of Comment For Log For Waiting For Payment Reservation Request
    public async Task<User?> GetTheOwnerOfCommentForLogForWaitingForPaymentReservationRequest(ulong id)
    {
        #region Get Request By Id

        var request = await GetLogForWaitingforReservationRequestById(id);
        if (request == null) return null;

        #endregion

        return await _userService.GetUserById(request.SupporterUserId.Value);
    }

    //Seen Log For Waiting For Payment Reservation Requests
    public async Task<bool> SeenLogForWaitingForPaymentReservationRequests(ulong requestId, ulong userId)
    {
        #region Get Request By Id

        var request = await GetLogForWaitingforReservationRequestById(requestId);
        if (request == null) return false;
        if (request.IsSeenBySupporters) return false;

        #endregion

        #region Update 

        #region Add Comment For Log 

        LogForDoctorReservationDateTimeWaitingForPaymentComment comment = new LogForDoctorReservationDateTimeWaitingForPaymentComment()
        {
            UserId = userId,
            LogForDoctorReservationDateTimeWaitingForPaymentId = requestId,
            Comment = "این درخواست توسط پشتیبانی بررسی شده است."
        };

        await _reservation.AddCommentForLogofWaitingForPaymentRequestReservation(comment);

        #endregion

        request.IsSeenBySupporters = true;
        request.SupporterUserId = userId;

        _reservation.UpdateLogForWaitingforReservationRequestById(request);
        await _reservation.Savechanges();

        #endregion

        return true;
    }

    //Get Log For Waiting for Reservation Request By Id 
    public async Task<LogForDoctorReservationDateTimeWaitingForPayment?> GetLogForWaitingforReservationRequestById(ulong id)
    {
        return await _reservation.GetLogForWaitingforReservationRequestById(id);
    }

    //Fill ListOfSelectedReservationsSupporterSideDTO
    public async Task<List<ListOfSelectedReservationsSupporterSideDTO>?> FillListOfSelectedReservationsSupporterSideDTO()
    {
        return await _reservation.FillListOfSelectedReservationsSupporterSideDTO();
    }

    public async Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter)
    {
        return await _reservation.FilterReservationSupporterPanelViewModel(filter);
    }

    public async Task<FilterWaitingForReservationRequestsSupporterSideViewModel?> FilterListOfWaitingForPaymentRequests(FilterWaitingForReservationRequestsSupporterSideViewModel filter)
    {
        return await _reservation.FilterListOfWaitingForPaymentRequests(filter);
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
            Doctor = doctor,
            LogForAnotherPatient = reservationDateTime.PatientId.HasValue ? await _reservation.FillLogForAnotherPatientSupporterSide(reservationDateTime.Id, reservationDateTime.PatientId.Value) : null,
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

    public async Task<ShowReservationDetailSupporterSideViewModel?> FillShowWaitingForPaymentReservationRequestDetailSupporterSideViewModel(ulong reservationId, ulong patientUserId)
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

        var patient = await _userService.GetUserById(patientUserId);
        model.Patient = patient;

        #endregion

        #region Get Doctor Work Address

        if (reservationDateTime.WorkAddressId.HasValue)
        {
            var officeAddress = await _workAddress.GetWorkAddressById(reservationDateTime.WorkAddressId.Value);

            if (officeAddress != null)
            {
                model.WorkAddress = officeAddress.Address;
            }
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

        var wallet = await _walletService.GetWalletTransactionByReservationDateTimeId(reservationTimeId);
        if (wallet == null)
        {
            return false;
        }

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
                    Price = wallet.Price,
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

    //Fill List Of Comments For Waiting For Payment Reservation Request Supporter Side DTO
    public async Task<List<ListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO>?> FillListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO(ulong id)
    {
        return await _reservation.FillListOfCommentsForWaitingForPaymentReservationRequestSupporterSideDTO(id);
    }

    //Add Comment For Waiting For Payment Reservation Request 
    public async Task AddCommentForWaitingForPaymentReservationRequest(ulong requestId, ulong userId, string comment)
    {
        LogForDoctorReservationDateTimeWaitingForPaymentComment model = new LogForDoctorReservationDateTimeWaitingForPaymentComment()
        {
            Comment = comment,
            UserId = userId,
            LogForDoctorReservationDateTimeWaitingForPaymentId = requestId
        };

        await _reservation.AddCommentForLogofWaitingForPaymentRequestReservation(model);
        await _reservation.Savechanges();
    }

    #endregion

    #region Site Side

    //Is Exist Any Waiting For Payment Reservation Request By User Id
    public async Task<ulong?> IsExistAnyWaitingForPaymentReservationRequestByUserId(ulong userId)
    {
        return await _reservation.IsExistAnyWaitingForPaymentReservationRequestByUserId(userId);
    }

    //Get And Delete Another Patient 
    public async Task GetAndDeleteAnotherPatient(ulong reservationDateTimeId, ulong userId)
    {
        await _reservation.GetAndDeleteAnotherPatient(reservationDateTimeId, userId);
    }

    public async Task<ReservationFactorSiteSideViewModel?> ShowInvoiceBeforeRedirectToBankProtable(ulong reservationDateTimeId, ulong userId)
    {
        #region Get Reservation Date Time By Id 

        var reservationDateTime = await GetDoctorReservationDateTimeById(reservationDateTimeId);
        if (reservationDateTime == null ||
           reservationDateTime.PatientId == null ||
           reservationDateTime.PatientId.Value != userId ||
           reservationDateTime.DoctorReservationState != DoctorReservationState.WaitingForComplete)

            return null;

        #endregion

        #region Get User By User Id 

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
        if (user == null) return null;

        #endregion

        #region Fill Model 

        var model = new ReservationFactorSiteSideViewModel()
        {
            PatientUsername = user.FirstName + user.LastName,
            PatientMobile = user.Mobile,
            ReservationDate = reservationDateTime.DoctorReservationDate.ReservationDate,
            ReservationDateTime = reservationDateTime.StartTime,
            DoctorUserId = reservationDateTime.DoctorReservationDate.UserId,
            PatientNationalId = (string.IsNullOrEmpty(user.NationalId)) ? "وارد نشده" : user.NationalId,
            ReservationDateTimeId = reservationDateTimeId
        };

        #endregion

        #region Get Reservation Tariff 

        #region Get Current Doctor Office

        var doctorOffice = await _organizationService.GetOrganizationByUserId(reservationDateTime.DoctorReservationDate.UserId);
        if (doctorOffice == null) return null;
        if (doctorOffice.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

        #endregion

        #region Get Doctor Reservation Tariff

        var reservationTariff = await _doctorsRepository.GetDoctorReservationTariffByDoctorUserId(doctorOffice.OwnerId);
        if (reservationTariff == null) return null;

        #endregion

        #region Check Doctor Population Covered 

        var populationCovered = await _familyDoctorRepository.GetUserSelectedFamilyDoctorByUserAndDoctorId(userId, doctorOffice.OwnerId);

        //If User Is In Doctor Population Covered 
        if (populationCovered != null && populationCovered.IsUserInDoctorPopulationCoveredOutOfDoctorFAM)
        {
            //If Reservation Type Is In Person 
            if (reservationDateTime.DoctorReservationType == DoctorReservationType.Reserved)
            {
                model.ReservationPrice = reservationTariff.InPersonReservationTariffForDoctorPopulationCovered;
            }

            //If Reservation Type Is Online 
            if (reservationDateTime.DoctorReservationType == DoctorReservationType.Onile || reservationDateTime.DoctorReservationType == DoctorReservationType.BothOnlineAndReserved)
            {
                model.ReservationPrice = reservationTariff.OnlineReservationTariffForDoctorPopulationCovered;
            }
        }

        else
        {
            //If Reservation Type Is In Person
            if (reservationDateTime.DoctorReservationType == DoctorReservationType.Reserved)
            {
                model.ReservationPrice = reservationTariff.InPersonReservationTariffForAnonymousPersons;
            }

            //If Reservation Type Is Online 
            if (reservationDateTime.DoctorReservationType == DoctorReservationType.Onile || reservationDateTime.DoctorReservationType == DoctorReservationType.BothOnlineAndReserved)
            {
                model.ReservationPrice = reservationTariff.OnlineReservationTariffForAnonymousPersons;
            }
        }

        #endregion

        #endregion

        return await FillReservationFactorSiteSideViewModel(model , reservationDateTime.WorkAddressId.Value , userId);
    }

    //Update Log For Reservation Date Times In Waiting For Payment State
    public async Task<bool> RemoveLogForReservationDateTimesInWaitingForPaymentState(ulong doctorReservationDateTimeId, ulong userId)
    {
        //Get Log 
        var log = await _reservation.GetLogForReservationDateTimesInWaitingForPaymentState(doctorReservationDateTimeId, userId);
        if (log == null) return false;

        //Update Log 
        log.IsDelete = true;

        _reservation.RemoveLogForReservationDateTimesInWaitingForPaymentState(log);
        await _reservation.Savechanges();

        return true;
    }

    //Log For Reservation Date Times In Waiting For Payment State
    public async Task<bool> LogForReservationDateTimesInWaitingForPaymentState(ulong doctorReservationDateTimeId, ulong userId)
    {
        //Get Log 
        var log = await _reservation.GetLogForReservationDateTimesInWaitingForPaymentState(doctorReservationDateTimeId, userId);
        if (log != null) return true;

        #region Fill Entity

        LogForDoctorReservationDateTimeWaitingForPayment entity = new LogForDoctorReservationDateTimeWaitingForPayment()
        {
            CreateDate = DateTime.Now,
            DoctorReservationDateTimeId = doctorReservationDateTimeId,
            IsDelete = false,
            IsSeenBySupporters = false,
            PatientUserId = userId,
            SupporterUserId = null
        };

        #endregion

        //Add To The Data Base
        await _reservation.LogForReservationDateTimesInWaitingForPaymentState(entity);
        await _reservation.Savechanges();

        return true;
    }

    //Get List Of Reservation Request That Pass A Day For Pay Reservation Tariff
    public async Task GetListOfReservationRequestThatPassADayForPayReservationTariff()
    {
        await _reservation.GetListOfReservationRequestThatPassADayForPayReservationTariff();
    }

    //Get Doctor Reservation Alert By Doctor User Id
    public async Task<string?> GetDoctorReservationAlertByDoctorUserId(ulong userId)
    {
        return await _reservation.GetDoctorReservationAlertByDoctorUserId(userId);
    }

    //Get List Of Doctor Reservation Date And Doctor Reservation Date Time For Show Site Side 
    public async Task<List<ListOfReservationDateAndReservationDateTimeViewModel>?> GetListOfDoctorReservationDateAndDoctorReservationDateTimeForShowSiteSide(ulong doctorUserId)
    {
        return await _reservation.GetListOfDoctorReservationDateAndDoctorReservationDateTimeForShowSiteSide(doctorUserId);
    }

    //List Of Future Doctor Days For Reservation 
    public async Task<List<DoctorReservationDate>> ListOfFutureDaysOfDoctorReservation(ulong doctorUserId)
    {
        return await _reservation.ListOfFutureDaysOfDoctorReservation(doctorUserId);
    }

    public async Task<bool> ChargeUserWallet(ulong userId, int price)
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
            Description = "شارژ حساب کاربری برای پرداخت هزینه ی دریافت نوبت",
            IsFinally = true
        };

        await _walletRepository.CreateWalletAsync(wallet);
        return true;
    }

    public async Task<bool> ChargeUserWalletForZeroReservationPrice(ulong userId, int price, ulong? requestId)
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
            Description = "شارژ حساب کاربری برای پرداخت هزینه ی دریافت نوبت",
            IsFinally = true,
            RequestId = requestId
        };

        await _walletRepository.CreateWalletAsync(wallet);
        return true;
    }

    public async Task<bool> PayReservationTariff(ulong userId, int price, ulong? requestId)
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
            PaymentType = PaymentType.Reservation,
            Price = price,
            Description = "پرداخت مبلغ دریافت نوبت",
            IsFinally = true,
            RequestId = requestId
        };

        await _walletRepository.CreateWalletAsync(wallet);
        return true;
    }

    //Pay Doctor Reservation Payed Share Percentage
    public async Task<bool> PayDoctorReservationPayedSharePercentage(ulong doctorUserId, int price, ulong requestId, bool isUserInDoctorPopulationCovered, DoctorReservationType doctorReservationType)
    {
        #region Create Wallet

        var wallet = new Wallet
        {
            UserId = doctorUserId,
            TransactionType = TransactionType.Deposit,
            GatewayType = GatewayType.Zarinpal,
            PaymentType = PaymentType.ChargeWallet,
            Description = "واریز مبلغ دریافت نوبت",
            IsFinally = true,
            RequestId = requestId
        };

        #region proccess price 

        int sitePercentage = 0;

        if (isUserInDoctorPopulationCovered == true)
        {
            if (doctorReservationType == DoctorReservationType.Reserved)
            {
                sitePercentage = await _siteSettingService.GetInPersonReservationTariffForDoctorPopulationCoveredSiteShare();
            }
            if (doctorReservationType == DoctorReservationType.Onile)
            {
                sitePercentage = await _siteSettingService.GetOnlineReservationTariffForDoctorPopulationCoveredSiteShare();
            }
        }
        else
        {
            if (doctorReservationType == DoctorReservationType.Reserved)
            {
                sitePercentage = await _siteSettingService.GetInPersonReservationTariffForAnonymousPersonsSiteShare();
            }
            if (doctorReservationType == DoctorReservationType.Onile)
            {
                sitePercentage = await _siteSettingService.GetOnlineReservationTariffForAnonymousPersonsSiteShare();
            }
        }

        //Add Site Cash Desk
        await _siteSettingService.AddSiteCashDesk(sitePercentage);

        //Process Doctor Percentage
        wallet.Price = price - sitePercentage;

        #endregion

        #endregion

        await _walletRepository.CreateWalletAsync(wallet);
        return true;
    }

    //Get Reservation Date By Reservation Date And User Id
    public async Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(DateTime reservationDate, ulong userId)
    {
        return await _reservation.GetDoctorReservationDateByReservationDateAndUserId(reservationDate, userId);
    }

    //Get Reservation Date By Reservation Date And User Id
    public async Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(string reservationDate, ulong userId)
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
    public async Task<bool> GetReservationDateTimeToUserPatient(ChooseTypeOfReservationViewModel model, ulong patientId)
    {
        #region get Doctor Reservation Date Time By Id 

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(model.ReservationDateTimeId);
        if (reservationDateTime == null) return false;
        if (reservationDateTime.DoctorReservationDate.UserId != model.DoctorId) return false;
        if (reservationDateTime.DoctorReservationState != DoctorReservationState.NotReserved) return false;

        #endregion

        #region Update Method 

        reservationDateTime.DoctorReservationState = DoctorReservationState.WaitingForComplete;
        reservationDateTime.PatientId = patientId;
        reservationDateTime.DoctorReservationType = model.DoctorReservationType;
        reservationDateTime.UserRequestForReserveDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
        reservationDateTime.UserRequestDescription = model.ReservationRequestDescription;

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

    //Cancel Payment From User And Make Reservation Time Free 
    public async Task<bool> CancelPaymentFromUserAndMakeReservationTimeFree(ulong reservationDateId , ulong userId)
    {
        #region get Doctor Reservation Date Time By Id 

        var reservationDateTime = await _reservation.GetDoctorReservationDateTimeById(reservationDateId);
        if (reservationDateTime == null) return false;
        if (reservationDateTime.DoctorReservationState != DoctorReservationState.WaitingForComplete) return false;
        if (!reservationDateTime.PatientId.HasValue || reservationDateTime.PatientId.Value != userId) return false;

        #endregion

        #region Update Method 

        reservationDateTime.DoctorReservationState = DoctorReservationState.NotReserved;
        reservationDateTime.PatientId = null;
        reservationDateTime.DoctorReservationType = null;
        reservationDateTime.UserRequestForReserveDate = null;
        reservationDateTime.UserRequestDescription = null;

        await _reservation.UpdateReservationDateTime(reservationDateTime);

        #endregion

        #region Get Another Patient

        await _reservation.GetAndDeleteAnotherPatient(reservationDateId , userId);

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

    //Fill Reservation Factor Site Side View Model
    public async Task<ReservationFactorSiteSideViewModel?> FillReservationFactorSiteSideViewModel(ReservationFactorSiteSideViewModel model, ulong workAddressId, ulong PatientUserId)
    {
        #region Get Doctor User 

        var doctorUser = await _userService.GetUserByIdWithAsNoTracking(model.DoctorUserId);
        if (doctorUser == null) return null;

        #endregion

        #region Get Doctor By User Id 

        var doctor = await _doctorsRepository.GetDoctorByUserId(model.DoctorUserId);
        if (doctor == null) return null;

        #endregion

        #region Get Doctor Info

        //Get Doctor Info By Id
        var info = await _doctorsRepository.GetDoctorsInfoByDoctorId(doctor.Id);
        if (info == null) return null;

        #endregion

        #region Get Doctor Skill By Doctor Id

        model.DoctorSpeciality = await _doctorsRepository.GetListOfDoctorSkillsByDoctorId(info.DoctorId);

        #endregion

        #region Get Doctor Work Addresses

        model.DoctorAddress = await _workAddress.GetWorkAddressById(workAddressId);

        #endregion

        #region Fill Model 

        model.DoctorMobile = info.ClinicPhone;
        model.DoctorUsername = doctorUser.Username;
        model.AnotherPatientSiteSide = await _reservation.FillLogForAnotherPatient(model.ReservationDateTimeId, PatientUserId);

        #endregion

        return model;
    }

    //Fill Reservation Factor User Side View Model
    public async Task<ReservationFactorUserSideViewModel?> FillReservationFactorUserSideViewModel(ulong reservationId, ulong userId)
    {
        #region Create Model 

        ReservationFactorUserSideViewModel model = new ReservationFactorUserSideViewModel();

        #endregion

        #region Get User By Id

        var user = await _userService.GetUserByIdWithAsNoTracking(userId);
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

        #region Get Doctor By Doctor user Id

        var doctorUser = await _userService.GetUserByIdWithAsNoTracking(reservationDate.UserId);
        if (doctorUser == null) return null;

        #endregion

        #region Get Doctor By User Id

        var doctor = await _doctorsRepository.GetDoctorByUserId(doctorUser.Id);
        if (doctor == null) return null;

        #endregion

        #region Get Doctor Info

        //Get Doctor Info By Id
        var info = await _doctorsRepository.GetDoctorsInfoByDoctorId(doctor.Id);
        if (info == null) return null;

        #endregion

        #region Get Doctor Skill By Doctor Id

        model.DoctorSpeciality = await _doctorsRepository.GetListOfDoctorSkillsByDoctorId(info.DoctorId);

        #endregion

        #region Get Doctor Work Address

        #region Get Doctor Work Addresses

        model.DoctorAddress = await _workAddress.GetWorkAddressById(reservationDateTime.WorkAddressId.Value);

        #endregion

        #endregion

        #region Fill Insances

        model.ReservationId = reservationId;
        model.DoctorUserId = doctorUser.Id;
        model.PatientUsername = user.Username;
        model.PatientMobile = user.Mobile;
        model.DoctorUsername = doctorUser.Username;
        model.DoctorMobile = doctorUser.Mobile;
        model.ReservationDate = reservationDate.ReservationDate;
        model.ReservationDateTime = reservationDateTime.StartTime;
        model.PatientNationalId = user.NationalId;
        model.LogForAnotherPatientUserSide = await _reservation.FillLogForAnotherPatientUserSide(reservationId, userId);

        #endregion

        return model;
    }

    //Get Doctor Reservation Date Time Doctor Selected Reservation Type
    public async Task<DoctorReservationType> GetDoctorReservationDateTimeDoctorSelectedReservationType(ulong doctorReservationDateTimeId)
    {
        return await _reservation.GetDoctorReservationDateTimeDoctorSelectedReservationType(doctorReservationDateTimeId);
    }

    //Get Patient User Informations For Get Reservation Time From Doctors
    public async Task<UserInfoForGetReservation?> GetPatientUserInformationsForGetReservationTimeFromDoctors(ulong userId)
    {
        return await _reservation.GetPatientUserInformationsForGetReservationTimeFromDoctors(userId);
    }

    #endregion
}
