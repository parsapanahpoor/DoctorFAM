#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Dentist;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.Reservation;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Globalization;

#endregion

namespace DoctorFAM.Data.Repository;

public class ReservationRepository : IReservationRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    private readonly IOrganizationRepository _organizationRepository;

    private readonly IDoctorsRepository _doctorRepository;

    private readonly IUserRepository _userRepository;

    public ReservationRepository(DoctorFAMDbContext context, IOrganizationRepository organizationRepository, IDoctorsRepository doctorRepository, IUserRepository userRepository)
    {
        _context = context;
        _organizationRepository = organizationRepository;
        _doctorRepository = doctorRepository;
        _userRepository = userRepository;
    }

    #endregion

    #region Doctor

    //List Of Doctor Reservation Date After Date Time Now
    public async Task<List<DoctorReservationDate>> ListOfDoctorReservationDateAfterDateTimeNow(ulong userId)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserIdWithAsNoTracking(userId);
        if (organization == null) return null;

        #endregion

        var query = await _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == organization.OwnerId && ((s.ReservationDate.Year > DateTime.Now.Year)
                                      || (s.ReservationDate.Year == DateTime.Now.Year
                                           && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)))
            .OrderBy(s => s.ReservationDate)
            .ToListAsync();

        return query;
    }

    //List Of Doctor Reservation Date After Date Time Now In Dentist Panel
    public async Task<List<DoctorReservationDate>> ListOfDoctorReservationDateAfterDateTimeNowInDentistPanel(ulong userId)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserId(userId);
        if (organization == null) return null;

        #endregion

        var query = await _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == organization.OwnerId && ((s.ReservationDate.Year > DateTime.Now.Year)
                                      || (s.ReservationDate.Year == DateTime.Now.Year
                                           && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)))
            .OrderBy(s => s.ReservationDate)
            .ToListAsync();

        return query;
    }

    //Cancel Reservation Date Time State Whitout Save Changes
    public async Task CancelReservationDateTime(DoctorReservationDateTime reservationDateTime)
    {
        reservationDateTime.DoctorReservationState = DoctorReservationState.Canceled;

        _context.DoctorReservationDateTimes.Update(reservationDateTime);
    }

    //Save Changes
    public async Task Savechanges()
    {
        await _context.SaveChangesAsync();
    }

    //Add Reservation Date Cancelation
    public async Task AddReservationDateCancelation(ReservationDateCancelation date)
    {
        await _context.ReservationDateCancelations.AddAsync(date);
        await _context.SaveChangesAsync();
    }

    //Add Reservation Date Time Cancelation Whitout Save Changes
    public async Task AddReservationDateTimeCancelation(ReservationDateTimeCancelation dateTime)
    {
        await _context.ReservationDateTimeCancelations.AddAsync(dateTime);
    }

    //Get List Of Reservation Dete Time By Reservation Date Id For Select List  
    public async Task<List<SelectListViewModel>> GetReservationDateTimeByReservationDateIdSelectList(ulong reservationDateId, ulong userId)
    {
        return _context.DoctorReservationDateTimes.Where(p => !p.IsDelete && p.DoctorReservationDateId == reservationDateId &&
                                                        p.DoctorReservationDate.UserId == userId && p.DoctorReservationState != DoctorReservationState.Canceled)
            .Select(p => new SelectListViewModel()
            {
                Id = p.Id,
                Title = $"{p.StartTime} - {p.EndTime}"
            }).ToList();
    }

    //Get Future Doctor Reservation For Cancel Reservation Request To List
    public async Task<List<DoctorReservationDate>> GetReservationsForAddCancelRequest(ulong userId)
    {
        return await _context.DoctorReservationDates.Where(s => s.ReservationDate.Year >= DateTime.Now.Year && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear && !s.IsDelete && s.UserId == userId).ToListAsync();
    }

    //Get Doctor Reservation Date By Date 
    public async Task<DoctorReservationDate?> GetDoctorReservationDateByDate(DateTime date, ulong userId)
    {
        return await _context.DoctorReservationDates.FirstOrDefaultAsync(p => !p.IsDelete && p.ReservationDate == date && p.UserId == userId);
    }

    //In Add Reservation Date Check Date In Not Duplicate
    public async Task<bool> IsExistAnyDuplicateReservationDate(DateTime date, ulong userId)
    {
        return await _context.DoctorReservationDates.AnyAsync(p => !p.IsDelete && p.ReservationDate == date && p.UserId == userId);
    }

    //This Is Filter For Reservation Date From Today 
    public async Task<List<DoctorReservationDate>?> FilterDoctorReservationDateSideWithoutPaging(FilterAppointmentViewModelWithoutPaging filter)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        #endregion

        return await _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == organization.OwnerId && ((s.ReservationDate.Year > DateTime.Now.Year)
                                      || (s.ReservationDate.Year == DateTime.Now.Year
                                           && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)))
            .OrderBy(s => s.ReservationDate)
            .ToListAsync();
    }

    //This Is Filter For Reservation Date From Today 
    public async Task<FilterAppointmentViewModel?> FilterDoctorReservationDateSide(FilterAppointmentViewModel filter)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        #endregion

        var query = _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == organization.OwnerId && ((s.ReservationDate.Year > DateTime.Now.Year)
                                      || (s.ReservationDate.Year == DateTime.Now.Year
                                           && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)))
            .OrderBy(s => s.ReservationDate)
            .AsQueryable();

        #region Status

        switch (filter.FilterRequestOrder)
        {
            case FilterRequestOrder.CreateDate_Des:
                break;
            case FilterRequestOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate <= toDate);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //This Is Filter For Reservation Date From Today By Dentist Panel
    public async Task<FilterAppointmentViewModel?> FilterDoctorReservationDateSideByDentistPanel(FilterAppointmentViewModel filter)
    {
        #region Get Owner Dentist Organization By EmployeeId 

        var organization = await _organizationRepository.GetDentistOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        #endregion

        var query = _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == organization.OwnerId && ((s.ReservationDate.Year > DateTime.Now.Year)
                                      || (s.ReservationDate.Year == DateTime.Now.Year
                                           && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)))
            .OrderBy(s => s.ReservationDate)
            .AsQueryable();

        #region Status

        switch (filter.FilterRequestOrder)
        {
            case FilterRequestOrder.CreateDate_Des:
                break;
            case FilterRequestOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate <= toDate);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //This Is History Of All Records That In Reservation Date By User Id ByDentistPanel 
    public async Task<FilterAppointmentViewModel?> FiltrDoctorReservationDateHistoryByDentistPanel(FilterAppointmentViewModel filter)
    {
        #region Get Owner Dentist Organization By EmployeeId 

        var organization = await _organizationRepository.GetDentistOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        #endregion

        var query = _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == organization.OwnerId)
            .OrderByDescending(s => s.ReservationDate)
            .AsQueryable();

        #region Status

        switch (filter.FilterRequestOrder)
        {
            case FilterRequestOrder.CreateDate_Des:
                break;
            case FilterRequestOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate <= toDate);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //This Is Filter For Reservation Date From Today 
    public async Task<FilterDoctorFamilyReservationDateViewModel?> FilterFamilyDoctorReservationDateFromUserPanel(FilterDoctorFamilyReservationDateViewModel filter)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
        if (organization == null) return null;
        if (organization.OrganizationInfoState != Domain.Entities.Doctors.OrganizationInfoState.Accepted) return null;

        #endregion

        var query = _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == filter.UserId && ((s.ReservationDate.Year > DateTime.Now.Year)
                                                                      || (s.ReservationDate.Year == DateTime.Now.Year
                                                                           && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)))
            .OrderBy(s => s.ReservationDate)
            .AsQueryable();

        #region Status

        switch (filter.FilterRequestOrder)
        {
            case FilterRequestOrder.CreateDate_Des:
                break;
            case FilterRequestOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate <= toDate);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //This Is History Of All Records That In Reservation Date By User Id  
    public async Task<FilterAppointmentViewModel?> FiltrDoctorReservationDateHistory(FilterAppointmentViewModel filter)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        #endregion

        var query = _context.DoctorReservationDates
            .Include(p => p.DoctorReservationDateTimes)
            .Where(s => !s.IsDelete && s.UserId == organization.OwnerId)
            .OrderByDescending(s => s.ReservationDate)
            .AsQueryable();

        #region Status

        switch (filter.FilterRequestOrder)
        {
            case FilterRequestOrder.CreateDate_Des:
                break;
            case FilterRequestOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.ReservationDate <= toDate);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    public async Task AddDoctorReservationDate(DoctorReservationDate doctorReservationDate)
    {
        await _context.DoctorReservationDates.AddAsync(doctorReservationDate);
        await _context.SaveChangesAsync();
    }

    public async Task<List<DoctorReservationDateTime>?> GetListOfReservationDateTimesByReservationDateId(ulong reservationDateId)
    {
        return await _context.DoctorReservationDateTimes.Where(p => !p.IsDelete && p.DoctorReservationDateId == reservationDateId).ToListAsync();
    }

    public async Task<FilterReservationDateTimeDoctorPAnel?> FilterReservationDateTimeDoctorSide(FilterReservationDateTimeDoctorPAnel filter)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        #endregion

        #region Create Instance

        FilterReservationDateTimeDoctorPAnel model = new FilterReservationDateTimeDoctorPAnel();

        #endregion

        #region Check Doctor Reservation Date 

        var resOfDoctorReservationDate = await _context.DoctorReservationDates.AnyAsync(p => !p.IsDelete && p.UserId == organization.OwnerId);
        if (resOfDoctorReservationDate == false) return null;

        model.ReservationDateId = filter.ReservationDateId;

        #endregion

        #region Get Doctor Reservation Date Time

        var reservationDateTimes = await _context.DoctorReservationDateTimes
                                            .Where(s => !s.IsDelete && s.DoctorReservationDateId == filter.ReservationDateId
                                                        && s.DoctorReservationState != DoctorReservationState.Canceled)
                                            .OrderBy(s => s.StartTime)
                                            .Select(p => new DoctorReservationDateTimeDoctorSideViewModel()
                                            {
                                                Id = p.Id,
                                                DoctorBooking = p.DoctorBooking,
                                                DoctorReservationState = p.DoctorReservationState,
                                                DoctorReservationType = p.DoctorReservationType,
                                                EndTime = p.EndTime,
                                                PatientId = p.PatientId,
                                                StartTime = p.StartTime,
                                                SelectedDoctorReservationType = p.DoctorReservationTypeSelected
                                            }).ToListAsync();
        #endregion

        #region Fill Return Model 

        List<DoctorReservationDateTimeDoctorSideViewModel> sampleModel = new List<DoctorReservationDateTimeDoctorSideViewModel>();

        if (reservationDateTimes != null && reservationDateTimes.Any())
        {
            foreach (var item in reservationDateTimes)
            {
                if (item.PatientId.HasValue)
                {
                    if (item.PatientId.Value == organization.OwnerId && item.DoctorBooking)
                    {
                        item.PatientDetail = await _context.DoctorPersonalBooking.Where(p => !p.IsDelete && p.DoctorReservationDateTimeId == item.Id)
                                                                                  .Select(p => new DoctorReservationDateTimePatientDetailDoctorSideViewModel()
                                                                                  {
                                                                                      PatientMobile = p.Mobile,
                                                                                      PatientUsername = $"{p.FirstName} {p.LastName}"
                                                                                  }).FirstOrDefaultAsync();

                        //Add To Return Model 
                        sampleModel.Add(item);
                    }
                    else
                    {
                        item.PatientDetail = await _context.Users.Where(p => !p.IsDelete && p.Id == item.PatientId.Value)
                                                                               .Select(p => new DoctorReservationDateTimePatientDetailDoctorSideViewModel()
                                                                               {
                                                                                   PatientMobile = p.Mobile,
                                                                                   PatientUsername = (p.FirstName != null && p.LastName != null) ? p.FirstName + p.LastName : "عدم دسترسی",
                                                                                   PatientUserId = p.Id
                                                                               }).FirstOrDefaultAsync();

                        //Add To Return Model 
                        sampleModel.Add(item);
                    }
                }
                else
                {
                    //Add To Return Model 
                    sampleModel.Add(item);
                }
            }
        }

        model.DoctorReservationDateTimes = sampleModel;

        #endregion

        return model;
    }

    //Filter Reservation Date Time Dentist Side
    public async Task<FilterReservationDateTimeDoctorPAnel?> FilterReservationDateTimeDentistSide(FilterReservationDateTimeDoctorPAnel filter)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetDentistOrganizationByUserId(filter.UserId);
        if (organization == null) return null;

        #endregion

        #region Create Instance

        FilterReservationDateTimeDoctorPAnel model = new FilterReservationDateTimeDoctorPAnel();

        #endregion

        #region Check Doctor Reservation Date 

        var resOfDoctorReservationDate = await _context.DoctorReservationDates.AnyAsync(p => !p.IsDelete && p.UserId == organization.OwnerId);
        if (resOfDoctorReservationDate == false) return null;

        model.ReservationDateId = filter.ReservationDateId;

        #endregion

        #region Get Doctor Reservation Date Time

        var reservationDateTimes = await _context.DoctorReservationDateTimes
                                            .Where(s => !s.IsDelete && s.DoctorReservationDateId == filter.ReservationDateId
                                                        && s.DoctorReservationState != DoctorReservationState.Canceled)
                                            .OrderBy(s => s.StartTime)
                                            .Select(p => new DoctorReservationDateTimeDoctorSideViewModel()
                                            {
                                                Id = p.Id,
                                                DoctorBooking = p.DoctorBooking,
                                                DoctorReservationState = p.DoctorReservationState,
                                                DoctorReservationType = p.DoctorReservationType,
                                                EndTime = p.EndTime,
                                                PatientId = p.PatientId,
                                                StartTime = p.StartTime,
                                            }).ToListAsync();
        #endregion

        #region Fill Return Model 

        List<DoctorReservationDateTimeDoctorSideViewModel> sampleModel = new List<DoctorReservationDateTimeDoctorSideViewModel>();

        if (reservationDateTimes != null && reservationDateTimes.Any())
        {
            foreach (var item in reservationDateTimes)
            {
                if (item.PatientId.HasValue)
                {
                    if (item.PatientId.Value == organization.OwnerId && item.DoctorBooking)
                    {
                        item.PatientDetail = await _context.DoctorPersonalBooking.Where(p => !p.IsDelete && p.DoctorReservationDateTimeId == item.Id)
                                                                                  .Select(p => new DoctorReservationDateTimePatientDetailDoctorSideViewModel()
                                                                                  {
                                                                                      PatientMobile = p.Mobile,
                                                                                      PatientUsername = $"{p.FirstName} {p.LastName}"
                                                                                  }).FirstOrDefaultAsync();

                        //Add To Return Model 
                        sampleModel.Add(item);
                    }
                    else
                    {
                        item.PatientDetail = await _context.Users.Where(p => !p.IsDelete && p.Id == item.PatientId.Value)
                                                                               .Select(p => new DoctorReservationDateTimePatientDetailDoctorSideViewModel()
                                                                               {
                                                                                   PatientMobile = p.Mobile,
                                                                                   PatientUsername = (p.FirstName != null && p.LastName != null) ? p.FirstName + p.LastName : "عدم دسترسی"
                                                                               }).FirstOrDefaultAsync();

                        //Add To Return Model 
                        sampleModel.Add(item);
                    }
                }
                else
                {
                    //Add To Return Model 
                    sampleModel.Add(item);
                }
            }
        }

        model.DoctorReservationDateTimes = sampleModel;

        #endregion

        return model;
    }

    public async Task<DoctorReservationDate?> GetReservationDateById(ulong reservationDateId)
    {
        return await _context.DoctorReservationDates.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == reservationDateId);
    }

    public async Task<DoctorReservationDate?> GetReservationDateByIdWithAsNoTracking(ulong reservationDateId)
    {
        return await _context.DoctorReservationDates
                             .AsNoTracking()
                             .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == reservationDateId);
    }

    public async Task UpdateReservationDate(DoctorReservationDate date)
    {
        _context.DoctorReservationDates.Update(date);
        await _context.SaveChangesAsync();
    }

    public async Task AddReservationDateTime(DoctorReservationDateTime dateTime)
    {
        await _context.DoctorReservationDateTimes.AddAsync(dateTime);
    }

    //Add Reservation Date Time With Return Id
    public async Task<ulong> AddReservationDateTimeWithReturnId(DoctorReservationDateTime dateTime)
    {
        await _context.DoctorReservationDateTimes.AddAsync(dateTime);
        await _context.SaveChangesAsync();

        return dateTime.Id;
    }

    public async Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeById(ulong reservationDateTimeId)
    {
        return await _context.DoctorReservationDateTimes.Include(p => p.DoctorReservationDate).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == reservationDateTimeId);
    }

    //Get Doctor Reservation Date Time By Include Relation With Doctor Booking
    public async Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeByIncludeRelationWithDoctorBooking(ulong reservationDateTimeId)
    {
        return await _context.DoctorReservationDateTimes.Include(p => p.DoctorPersonalBooking)
                                                           .Include(p => p.DoctorReservationDate)
                                                            .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == reservationDateTimeId);
    }

    public async Task UpdateReservationDateTime(DoctorReservationDateTime reservationDateTime)
    {
        _context.DoctorReservationDateTimes.Update(reservationDateTime);
        await _context.SaveChangesAsync();
    }

    //Add Doctor Personal Booking 
    public async Task AddDoctorPersonalBooking(DoctorPersonalBooking booking)
    {
        await _context.DoctorPersonalBooking.AddAsync(booking);
        await _context.SaveChangesAsync();
    }

    //Get Doctor Reservation Booking By Doctor Reservation Date Time 
    public async Task<DoctorPersonalBooking?> GetDoctorReservationBookingByDoctorReservationDateTime(ulong doctorReservationDateTimeId)
    {
        return await _context.DoctorPersonalBooking.FirstOrDefaultAsync(p => !p.IsDelete && p.DoctorReservationDateTimeId == doctorReservationDateTimeId);
    }

    #endregion

    #region User Panel

    public async Task<FilterReservationViewModel?> FilterReservationUserPanelViewModel(FilterReservationViewModel filter)
    {
        #region Get User By User Id

        var user = await _context.Users.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == filter.UserId);
        if (user == null) return null;

        #endregion

        //var query = _context.DoctorReservationDateTimes
        //    .Include(p => p.DoctorReservationDate)
        //    .ThenInclude(p => p.User)
        //    .Where(p => !p.IsDelete && p.PatientId == filter.UserId)
        //    .OrderByDescending(s => s.DoctorReservationDate.ReservationDate)
        //    .ThenByDescending(s => s.Id)
        //    .AsQueryable();

        var query = _context.DoctorReservationDateTimes
           .Include(p => p.DoctorReservationDate)
           .ThenInclude(p => p.User)
           .Where(p => !p.IsDelete && p.PatientId == filter.UserId)
           .OrderBy(s => s.DoctorReservationDate.ReservationDate)
           .ThenByDescending(s => s.Id)
           .AsQueryable();

        #region Status

        switch (filter.FilterDoctorReservationState)
        {
            case FilterDoctorReservationState.All:
                break;
            case FilterDoctorReservationState.Reserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.Reserved);
                break;
            case FilterDoctorReservationState.NotReserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.NotReserved);
                break;
            case FilterDoctorReservationState.WaitingForComplete:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.WaitingForComplete);
                break;
        }

        switch (filter.FilterDoctorReservationType)
        {
            case FilterDoctorReservationType.All:
                break;
            case FilterDoctorReservationType.Onile:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Onile);
                break;
            case FilterDoctorReservationType.Reserved:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Reserved);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.DoctorReservationDate.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate <= toDate);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    public async Task<FilterReservationViewModel?> FilterReservationUserPanelViewComponent(FilterReservationViewModel filter)
    {
        #region Get User By User Id

        var user = await _context.Users.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == filter.UserId);
        if (user == null) return null;

        #endregion

        //var query = _context.DoctorReservationDateTimes
        //    .Include(p => p.DoctorReservationDate)
        //    .ThenInclude(p => p.User)
        //    .Where(p => !p.IsDelete && p.PatientId == filter.UserId)
        //    .OrderByDescending(s => s.DoctorReservationDate.ReservationDate)
        //    .AsQueryable();

        var query = _context.DoctorReservationDateTimes
           .Include(p => p.DoctorReservationDate)
           .ThenInclude(p => p.User)
           .Where(p => !p.IsDelete && p.PatientId == filter.UserId)
           .OrderBy(s => s.DoctorReservationDate.ReservationDate)
           .AsQueryable();

        #region Status

        switch (filter.FilterDoctorReservationState)
        {
            case FilterDoctorReservationState.All:
                break;
            case FilterDoctorReservationState.Reserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.Reserved);
                break;
            case FilterDoctorReservationState.NotReserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.NotReserved);
                break;
            case FilterDoctorReservationState.WaitingForComplete:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.WaitingForComplete);
                break;
        }

        switch (filter.FilterDoctorReservationType)
        {
            case FilterDoctorReservationType.All:
                break;
            case FilterDoctorReservationType.Onile:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Onile);
                break;
            case FilterDoctorReservationType.Reserved:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Reserved);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.DoctorReservationDate.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate <= toDate);
        }

        query = query.Where(p => p.DoctorReservationDate.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear
                            && p.DoctorReservationDate.ReservationDate.Year >= DateTime.Now.Year && p.DoctorReservationState == DoctorReservationState.Reserved);

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //Filter Family Doctor Reservation DateTime In UserPanel ViewModel
    public async Task<FilterFamilyDoctorReservationDateTimeUserPanelViewModel?> FilterFamilyDoctorReservationDateTimeUserPanel(FilterFamilyDoctorReservationDateTimeUserPanelViewModel filter)
    {
        #region Get Owner Organization By EmployeeId 

        var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
        if (organization == null) return null;
        if (organization.OrganizationInfoState != Domain.Entities.Doctors.OrganizationInfoState.Accepted) return null;

        #endregion

        var query = _context.DoctorReservationDateTimes
            .Include(p => p.DoctorReservationDate)
            .Where(s => !s.IsDelete && s.DoctorReservationDate.UserId == organization.OwnerId
                            && s.DoctorReservationDateId == filter.ReservationDateId &&
                                            (s.DoctorReservationState == DoctorReservationState.NotReserved || s.DoctorReservationState == DoctorReservationState.Reserved))
            .OrderBy(s => s.CreateDate)
            .AsQueryable();

        #region Status

        switch (filter.FilterRequestOrder)
        {
            case FilterRequestOrder.CreateDate_Des:
                break;
            case FilterRequestOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.FilterFamilyDoctorReservationInUserPanelState)
        {
            case FilterFamilyDoctorReservationInUserPanelState.All:
                break;
            case FilterFamilyDoctorReservationInUserPanelState.Reserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.Reserved);
                break;
            case FilterFamilyDoctorReservationInUserPanelState.NotReserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.NotReserved);
                break;
        }

        switch (filter.FilterDoctorReservationType)
        {
            case FilterDoctorReservationType.All:
                break;
            case FilterDoctorReservationType.Onile:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Onile);
                break;
            case FilterDoctorReservationType.Reserved:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Reserved);
                break;
        }

        #endregion

        #region Filter

        #endregion

        await filter.Paging(query);

        return filter;
    }

    #endregion

    #region Admin Side 

    public async Task<FilterReservationAdminSideViewModel?> FilterReservationAdminPanelViewModel(FilterReservationAdminSideViewModel filter)
    {
        var query = _context.DoctorReservationDateTimes
        .Include(s => s.User)
        .Include(p => p.DoctorReservationDate)
        .ThenInclude(p => p.User)
        .Where(p => !p.IsDelete)
        .OrderByDescending(s => s.DoctorReservationDate.ReservationDate)
        .AsQueryable();

        #region Status

        switch (filter.FilterDoctorReservationState)
        {
            case FilterDoctorReservationState.All:
                break;
            case FilterDoctorReservationState.Reserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.Reserved);
                break;
            case FilterDoctorReservationState.NotReserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.NotReserved);
                break;
            case FilterDoctorReservationState.WaitingForComplete:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.WaitingForComplete);
                break;
        }

        switch (filter.FilterDoctorReservationType)
        {
            case FilterDoctorReservationType.All:
                break;
            case FilterDoctorReservationType.Onile:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Onile);
                break;
            case FilterDoctorReservationType.Reserved:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Reserved);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.DoctorReservationDate.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate <= toDate);
        }

        if (!string.IsNullOrEmpty(filter.PatientName))
        {
            query = query.Where(s => s.User.Username.Contains(filter.PatientName));
        }

        if (!string.IsNullOrEmpty(filter.DoctorName))
        {
            query = query.Where(s => s.DoctorReservationDate.User.Username.Contains(filter.DoctorName));
        }

        if (!string.IsNullOrEmpty(filter.PatientMobile))
        {
            query = query.Where(s => s.User.Mobile == filter.PatientMobile);
        }

        if (!string.IsNullOrEmpty(filter.DoctorMobile))
        {
            query = query.Where(s => s.DoctorReservationDate.User.Mobile == filter.DoctorMobile);
        }

        if (!string.IsNullOrEmpty(filter.DoctorNationalNumber))
        {
            query = query.Where(s => s.DoctorReservationDate.User.NationalId == filter.DoctorNationalNumber);
        }

        if (!string.IsNullOrEmpty(filter.PatientNationalNumber))
        {
            query = query.Where(s => s.User.NationalId == filter.PatientNationalNumber);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    public async Task<FilterClosedReservationAdminViewModel?> FilterClosedReservationAdminPanelViewModel(FilterClosedReservationAdminViewModel filter)
    {
        var query = _context.LogForCloseReservations
        .Include(s => s.User)
        .Include(p => p.DoctorReservationDateTime)
        .ThenInclude(p => p.DoctorReservationDate)
        .ThenInclude(p => p.User)
        .Where(p => !p.IsDelete)
        .OrderByDescending(s => s.CreateDate)
        .AsQueryable();

        #region Status

        switch (filter.FilterDoctorReservationState)
        {
            case FilterDoctorReservationState.All:
                break;
            case FilterDoctorReservationState.Reserved:
                query = query.Where(p => p.DoctorReservationDateTime.DoctorReservationState == DoctorReservationState.Reserved);
                break;
            case FilterDoctorReservationState.NotReserved:
                query = query.Where(p => p.DoctorReservationDateTime.DoctorReservationState == DoctorReservationState.NotReserved);
                break;
            case FilterDoctorReservationState.WaitingForComplete:
                query = query.Where(p => p.DoctorReservationDateTime.DoctorReservationState == DoctorReservationState.WaitingForComplete);
                break;
        }

        switch (filter.FilterDoctorReservationType)
        {
            case FilterDoctorReservationType.All:
                break;
            case FilterDoctorReservationType.Onile:
                query = query.Where(p => p.DoctorReservationDateTime.DoctorReservationType == DoctorReservationType.Onile);
                break;
            case FilterDoctorReservationType.Reserved:
                query = query.Where(p => p.DoctorReservationDateTime.DoctorReservationType == DoctorReservationType.Reserved);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.DoctorReservationDateTime.DoctorReservationDate.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDateTime.DoctorReservationDate.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDateTime.DoctorReservationDate.ReservationDate <= toDate);
        }

        if (!string.IsNullOrEmpty(filter.PatientName))
        {
            query = query.Where(s => s.User.Username.Contains(filter.PatientName));
        }

        if (!string.IsNullOrEmpty(filter.DoctorName))
        {
            query = query.Where(s => s.DoctorReservationDateTime.DoctorReservationDate.User.Username.Contains(filter.DoctorName));
        }

        if (!string.IsNullOrEmpty(filter.PatientMobile))
        {
            query = query.Where(s => s.User.Mobile == filter.PatientMobile);
        }

        if (!string.IsNullOrEmpty(filter.DoctorMobile))
        {
            query = query.Where(s => s.DoctorReservationDateTime.DoctorReservationDate.User.Mobile == filter.DoctorMobile);
        }

        if (!string.IsNullOrEmpty(filter.DoctorNationalNumber))
        {
            query = query.Where(s => s.DoctorReservationDateTime.DoctorReservationDate.User.NationalId == filter.DoctorNationalNumber);
        }

        if (!string.IsNullOrEmpty(filter.PatientNationalNumber))
        {
            query = query.Where(s => s.User.NationalId == filter.PatientNationalNumber);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    public async Task AddLogForCloseReservation(LogForCloseReservation log)
    {
        await _context.LogForCloseReservations.AddAsync(log);
        await _context.SaveChangesAsync();
    }

    //List Of Request For Cancelation Reservation Date 
    public async Task<FilterCancelReservationRequestsViewModel?> FilterCancelReservationRequestsViewModel(FilterCancelReservationRequestsViewModel filter)
    {
        var query = _context.ReservationDateCancelations
        .Include(p => p.DoctorReservationDate)
        .ThenInclude(p => p.User)
        .Where(p => !p.IsDelete)
        .OrderByDescending(s => s.DoctorReservationDate.ReservationDate)
        .AsQueryable();

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate <= toDate);
        }

        if (!string.IsNullOrEmpty(filter.DoctorName))
        {
            query = query.Where(s => s.DoctorReservationDate.User.Username.Contains(filter.DoctorName));
        }

        if (!string.IsNullOrEmpty(filter.DoctorMobile))
        {
            query = query.Where(s => s.DoctorReservationDate.User.Mobile == filter.DoctorMobile);
        }

        if (!string.IsNullOrEmpty(filter.DoctorNationalNumber))
        {
            query = query.Where(s => s.DoctorReservationDate.User.NationalId == filter.DoctorNationalNumber);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //List Of Request For Cancelation Reservatio Date Time 
    public async Task<FilterCancelationRequestReservationDateTimeViewModel?> FilterCancelationRequestReservationDateTime(FilterCancelationRequestReservationDateTimeViewModel filter)
    {
        var query = _context.ReservationDateTimeCancelations
            .Include(p => p.DoctorReservationDateTime)
            .ThenInclude(p => p.User)
            .Where(s => !s.IsDelete && s.ReservationDateCancelationId == filter.ReservationDateId && s.DoctorReservationDateTime.DoctorReservationState != DoctorReservationState.Canceled)
            .OrderByDescending(s => s.CreateDate)
            .AsQueryable();

        await filter.Paging(query);

        return filter;
    }

    //List Of Doctor Personal Booking
    public async Task<List<DoctorPersonalBooking>> ListOfDoctorPersonalBooking()
    {
        return await _context.DoctorPersonalBooking.Include(p => p.DoctorReservationDateTime)
                        .ThenInclude(p => p.DoctorReservationDate)
                        .ThenInclude(p => p.User)
                        .Where(p => !p.IsDelete)
                        .OrderByDescending(p => p.CreateDate)
                        .ToListAsync();
    }

    #endregion

    #region Supporter Side 

    public async Task<FilterReservationSupporterSideViewModel?> FilterReservationSupporterPanelViewModel(FilterReservationSupporterSideViewModel filter)
    {
        var query = _context.DoctorReservationDateTimes
        .Include(s => s.User)
        .Include(p => p.DoctorReservationDate)
        .ThenInclude(p => p.User)
        .Where(p => !p.IsDelete)
        .OrderByDescending(s => s.DoctorReservationDate.ReservationDate)
        .AsQueryable();

        #region Status

        switch (filter.FilterDoctorReservationState)
        {
            case FilterDoctorReservationState.All:
                break;
            case FilterDoctorReservationState.Reserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.Reserved);
                break;
            case FilterDoctorReservationState.NotReserved:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.NotReserved);
                break;
            case FilterDoctorReservationState.WaitingForComplete:
                query = query.Where(p => p.DoctorReservationState == DoctorReservationState.WaitingForComplete);
                break;
        }

        switch (filter.FilterDoctorReservationType)
        {
            case FilterDoctorReservationType.All:
                break;
            case FilterDoctorReservationType.Onile:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Onile);
                break;
            case FilterDoctorReservationType.Reserved:
                query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Reserved);
                break;
        }

        switch (filter.FilterReservationOrder)
        {
            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                break;

            case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.DoctorReservationDate.ReservationDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.FromDate))
        {
            var spliteDate = filter.FromDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate >= fromDate);
        }

        if (!string.IsNullOrEmpty(filter.ToDate))
        {
            var spliteDate = filter.ToDate.Split('/');
            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

            query = query.Where(s => s.DoctorReservationDate.ReservationDate <= toDate);
        }

        if (!string.IsNullOrEmpty(filter.PatientName))
        {
            query = query.Where(s => s.User.Username.Contains(filter.PatientName));
        }

        if (!string.IsNullOrEmpty(filter.DoctorName))
        {
            query = query.Where(s => s.DoctorReservationDate.User.Username.Contains(filter.DoctorName));
        }

        if (!string.IsNullOrEmpty(filter.PatientMobile))
        {
            query = query.Where(s => s.User.Mobile == filter.PatientMobile);
        }

        if (!string.IsNullOrEmpty(filter.DoctorMobile))
        {
            query = query.Where(s => s.DoctorReservationDate.User.Mobile == filter.DoctorMobile);
        }

        if (!string.IsNullOrEmpty(filter.DoctorNationalNumber))
        {
            query = query.Where(s => s.DoctorReservationDate.User.NationalId == filter.DoctorNationalNumber);
        }

        if (!string.IsNullOrEmpty(filter.PatientNationalNumber))
        {
            query = query.Where(s => s.User.NationalId == filter.PatientNationalNumber);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }


    #endregion

    #region Site Side 

    //Get Doctor Reservation Alert By Doctor User Id
    public async Task<string?> GetDoctorReservationAlertByDoctorUserId(ulong userId)
    {
        return await _context.DoctorsReservationTariffs
                             .AsNoTracking()
                             .Where(p => p.DoctorUserId == userId && !p.IsDelete)
                             .Select(p => p.DoctorReservationAlert)
                             .FirstOrDefaultAsync();
    }

    //Get List Of Reservation Request That Pass A Day For Pay Reservation Tariff
    public async Task GetListOfReservationRequestThatPassADayForPayReservationTariff()
    {
        #region Current Date Time

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        #endregion

        #region Get List Of Reservations

        var model = await _context.DoctorReservationDateTimes
                             .Where(p => !p.IsDelete && p.DoctorReservationState == DoctorReservationState.WaitingForComplete
                                    && p.UserRequestForReserveDate.HasValue && DateTime.Compare(p.UserRequestForReserveDate.Value, dateTime) >= 1)
                             .ToListAsync();

        #endregion

        #region Remove Patients From Requests

        if (model != null && model.Any())
        {
            foreach (var reservation in model)
            {
                reservation.UserRequestForReserveDate = null;
                reservation.DoctorReservationState = DoctorReservationState.Reserved;
                reservation.PatientId = null;
                reservation.WorkAddressId = null;
                reservation.DoctorReservationType = null;

                _context.DoctorReservationDateTimes.Update(reservation);
            }

            await _context.SaveChangesAsync();
        }

        #endregion
    }

    //Get List Of Doctor Reservation Date And Doctor Reservation Date Time For Show Site Side 
    public async Task<List<ListOfReservationDateAndReservationDateTimeViewModel>?> GetListOfDoctorReservationDateAndDoctorReservationDateTimeForShowSiteSide(ulong doctorUserId)
    {
        #region Current Date Time

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        #endregion

        return await _context.DoctorReservationDates.AsNoTracking()
                                            .Where(p => !p.IsDelete && p.UserId == doctorUserId
                                                    && DateTime.Compare(p.ReservationDate, dateTime) >= 0)
                                            .OrderBy(s => s.ReservationDate)
                                            .Select(p => new ListOfReservationDateAndReservationDateTimeViewModel()
                                            {
                                                DoctorReservationDate = p,
                                                DoctorReservationDateTimes = _context.DoctorReservationDateTimes.AsNoTracking()
                                                                                        .Where(s => !s.IsDelete && s.DoctorReservationDateId == p.Id
                                                                                                && s.DoctorReservationState == DoctorReservationState.NotReserved
                                                                                                && !s.PatientId.HasValue).ToList()
                                            }).Take(7).ToListAsync();
    }

    //List Of Future Days Of Doctor Reservation 
    public async Task<List<DoctorReservationDate>> ListOfFutureDaysOfDoctorReservation(ulong doctorUserId)
    {
        return await _context.DoctorReservationDates.Where(s => !s.IsDelete && s.UserId == doctorUserId && ((s.ReservationDate.Year > DateTime.Now.Year)
                                    || (s.ReservationDate.Year == DateTime.Now.Year
                                         && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)))
                                              .OrderBy(s => s.ReservationDate)
                                                  .ToListAsync();
    }

    //Get Reservation Date By Reservation Date And User Id
    public async Task<DoctorReservationDate?> GetDoctorReservationDateByReservationDateAndUserId(DateTime reservationDate, ulong userId)
    {
        return await _context.DoctorReservationDates.FirstOrDefaultAsync(p => !p.IsDelete && p.ReservationDate.Year == reservationDate.Year
                                                                            && p.ReservationDate.DayOfYear == reservationDate.DayOfYear
                                                                            && p.UserId == userId);
    }

    //Get List Of Doctor Reservation Date Time By Reservation Date Id
    public async Task<List<DoctorReservationDateTime>?> GetListOfDoctorReservationDateTimeByReservationDateId(ulong reservationDateId)
    {
        return await _context.DoctorReservationDateTimes.Where(p => !p.IsDelete && p.DoctorReservationDateId == reservationDateId
                                                                && p.DoctorReservationState != DoctorReservationState.Canceled).OrderBy(p => p.StartTime).ToListAsync();
    }

    //Get Doctor Reservation Date Time Doctor Selected Reservation Type
    public async Task<DoctorReservationType> GetDoctorReservationDateTimeDoctorSelectedReservationType(ulong doctorReservationDateTimeId)
    {
        return await _context.DoctorReservationDateTimes
                             .Where(p => !p.IsDelete && p.Id == doctorReservationDateTimeId && p.DoctorReservationTypeSelected.HasValue)
                             .Select(p => p.DoctorReservationTypeSelected.Value)
                             .FirstOrDefaultAsync();
    }

    //Get Patient User Informations For Get Reservation Time From Doctors
    public async Task<UserInfoForGetReservation?> GetPatientUserInformationsForGetReservationTimeFromDoctors(ulong userId)
    {
        return await _context.Users
                             .AsNoTracking()
                             .Where(p => !p.IsDelete && p.Id == userId)
                             .Select(p => new UserInfoForGetReservation()
                             {
                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 NationalCode = p.NationalId
                             })
                             .FirstOrDefaultAsync();
    }

    #endregion
}