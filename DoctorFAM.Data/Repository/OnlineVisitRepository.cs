#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.UserPanel.OnlineVisit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using DoctorFAM.Domain.Entities.Patient;

#endregion

namespace DoctorFAM.Data.Repository;

public class OnlineVisitRepository : IOnlineVisitRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public OnlineVisitRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Old Version

    #region Site Side

    //Add Online Request Detail 
    public async Task AddOnlineRequestDetail(OnlineVisitRequestDetail model)
    {
        await _context.OnlineVisitRequestDetails.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    //Get Activated And Online Visit Interests Online Visit For Send Correct Notification For Arrival Online Visit Request 
    public async Task<List<string?>> GetActivatedAndDoctorsInterestOnlineVisit()
    {
        #region Get Online Visit Interests Online Visit  

        var users = await _context.DoctorsSelectedInterests.Include(p => p.Doctor)
                            .Where(p => !p.IsDelete && p.InterestId == 1).Select(p => p.Doctor.UserId).ToListAsync();
        if (users == null) return null;

        #endregion

        #region Check User Work Addresses 

        //Initial Model Of String 
        List<string?> returnValue = new List<string?>();

        foreach (var item in users)
        {
            //Check Online Visit Is Activated
            var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == item
                                    && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

            if (activated != null)
            {
                returnValue.Add(activated.OwnerId.ToString());
            }

        }

        #endregion

        return returnValue;
    }

    //Filter Online Visit Requests 
    public async Task<FilterOnlineVisitViewModel> FilterOnlineVisitRequests(FilterOnlineVisitViewModel filter)
    {
        var query = _context.Requests
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.Country)
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.State)
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.City)
         .Include(p => p.User)
         .Include(p => p.OnlineVisitRequestDetail)
         .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit && s.RequestState == RequestState.Paid)
         .OrderByDescending(s => s.CreateDate)
         .AsQueryable();

        #region Status

        switch (filter.FilterRequestAdminSideOrder)
        {
            case FilterRequestAdminSideOrder.CreateDate_Des:
                break;
            case FilterRequestAdminSideOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.OnlineVisitRequestTypeForFilter)
        {
            case OnlineVisitRequestTypeForFilter.All:
                break;
            case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.DrugCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.UserMobile))
        {
            query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.Username))
        {
            query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
        }

        if (filter.CountryId != null)
        {
            query = query.Where(p => p.PaitientRequestDetails.CountryId == filter.CountryId);
        }

        if (filter.CityId != null)
        {
            query = query.Where(p => p.PaitientRequestDetails.CityId == filter.CityId);
        }

        if (filter.StateId != null)
        {
            query = query.Where(p => p.PaitientRequestDetails.StateId == filter.StateId);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    #endregion

    #region Doctor Side 

    //Get Online Visit Request Detail 
    public async Task<OnlineVisitRequestDetail?> GetOnlineVisitRequestDetail(ulong requestId)
    {
        return await _context.OnlineVisitRequestDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == requestId);
    }

    //Filter Your Online Visit Request 
    public async Task<FilterOnlineVisitViewModel?> FilterYourOnlineVisitRequest(FilterOnlineVisitViewModel filter)
    {

        #region Get Doctor Organization

        var member = await _context.OrganizationMembers.Include(p => p.Organization)
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.UserId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);

        if (member == null) return null;

        var organization = await _context.Organizations.FirstOrDefaultAsync(p => p.Id == member.OrganizationId && !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);

        if (organization == null) return null;

        #endregion

        var query = _context.Requests
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.Country)
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.State)
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.City)
         .Include(p => p.User)
         .Include(p => p.OnlineVisitRequestDetail)
         .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit
                    && s.OperationId == organization.OwnerId && (s.RequestState == RequestState.SelectedFromDoctor || s.RequestState == RequestState.Finalized))
         .OrderByDescending(s => s.CreateDate)
         .AsQueryable();

        #region Status

        switch (filter.FilterRequestAdminSideOrder)
        {
            case FilterRequestAdminSideOrder.CreateDate_Des:
                break;
            case FilterRequestAdminSideOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.OnlineVisitRequestTypeForFilter)
        {
            case OnlineVisitRequestTypeForFilter.All:
                break;
            case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.DrugCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.UserMobile))
        {
            query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.Username))
        {
            query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    #endregion

    #region User Panel side 

    //Filter User Onlien Visit Requests 
    public async Task<FilterOnlineVisitRequestUserPanelViewModel> FilterOnlineVisitRequestUserPanel(FilterOnlineVisitRequestUserPanelViewModel filter)
    {
        var query = _context.Requests
            .Include(p => p.OnlineVisitRequestDetail)
            .Include(p => p.Operation)
         .Where(s => !s.IsDelete && s.UserId == filter.UserId && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit)
         .OrderByDescending(s => s.CreateDate)
         .AsQueryable();

        #region Status

        switch (filter.FilterRequestAdminSideOrder)
        {
            case FilterRequestAdminSideOrder.CreateDate_Des:
                break;
            case FilterRequestAdminSideOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.OnlineVisitRequestTypeForFilter)
        {
            case OnlineVisitRequestTypeForFilter.All:
                break;
            case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.DrugCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                break;
        }

        #endregion

        #region Filter

        #endregion

        await filter.Paging(query);

        return filter;
    }

    #endregion

    #region Admin And Supporter Side 

    //Filter Online Visit Requests Admin Side 
    public async Task<FilterOnlineVisitAdminSideViewModel> FilterOnlineVisitRequestsAdminSide(FilterOnlineVisitAdminSideViewModel filter)
    {
        var query = _context.Requests
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.Country)
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.State)
         .Include(p => p.PaitientRequestDetails)
         .ThenInclude(p => p.City)
         .Include(p => p.User)
         .Include(p => p.OnlineVisitRequestDetail)
         .Include(p => p.Operation)
         .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.OnlineVisit)
         .OrderByDescending(s => s.CreateDate)
         .AsQueryable();

        #region Status

        switch (filter.FilterRequestAdminSideOrder)
        {
            case FilterRequestAdminSideOrder.CreateDate_Des:
                break;
            case FilterRequestAdminSideOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        switch (filter.OnlineVisitRequestTypeForFilter)
        {
            case OnlineVisitRequestTypeForFilter.All:
                break;
            case OnlineVisitRequestTypeForFilter.DiseaseCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DiseaseCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.DrugCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.DrugCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.ParaclinicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.ParaclinicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.PsychologicalCounseling:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.PsychologicalCounseling);
                break;
            case OnlineVisitRequestTypeForFilter.EmergencyConsultation:
                query = query.Where(p => p.OnlineVisitRequestDetail.OnlineVisitRequestType == Domain.Enums.OnlineVisitRequest.OnlineVisitRequestType.EmergencyConsultation);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.UserMobile))
        {
            query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.Username))
        {
            query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
        }

        if (!string.IsNullOrEmpty(filter.NationalId))
        {
            query = query.Where(s => EF.Functions.Like(s.User.NationalId, $"%{filter.NationalId}%"));
        }

        if (!string.IsNullOrEmpty(filter.DoctorUserMobile))
        {
            query = query.Where(s => s.Operation.Mobile != null && EF.Functions.Like(s.Operation.Mobile, $"%{filter.DoctorUserMobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.DoctorUsername))
        {
            query = query.Where(s => EF.Functions.Like(s.Operation.Username, $"%{filter.DoctorUsername}%"));
        }

        if (!string.IsNullOrEmpty(filter.DoctorNatinalId))
        {
            query = query.Where(s => EF.Functions.Like(s.Operation.NationalId, $"%{filter.DoctorNatinalId}%"));
        }

        if (filter.CountryId != null)
        {
            query = query.Where(p => p.PaitientRequestDetails.CountryId == filter.CountryId);
        }

        if (filter.CityId != null)
        {
            query = query.Where(p => p.PaitientRequestDetails.CityId == filter.CityId);
        }

        if (filter.StateId != null)
        {
            query = query.Where(p => p.PaitientRequestDetails.StateId == filter.StateId);
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    #endregion

    #endregion

    #region Doctor Panel

    //Save Changes
    public async Task Savechanges()
    {
        await _context.SaveChangesAsync();
    }

    //Update Doctor And Patient Record
    public void UpdateDoctorAndPatientRecordWithoutSaveChanges(OnlineVisitDoctorsAndPatientsReservationDetail request)
    {
        _context.OnlineVisitDoctorsAndPatientsReservationDetails.Update(request);
    }

    //Update Online Visit Request Without Save Changes 
    public void UpdateOnlineVisitRequestWithoutSaveChanges(OnlineVisitUserRequestDetail request)
    {
        _context.OnlineVisitUserRequestDetails.Update(request);
    }

    //Get Online Visit Doctor Reservation Id By Business Key And Doctor User Id
    public async Task<OnlineVisitDoctorsReservationDate> GetOnlineVisitDoctorReservationByBusinessKeyAndDoctorUserId(ulong doctorUserId , int businessKey)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                    .Where(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.BusinessKey == businessKey)
                                    .FirstOrDefaultAsync();
    }

    //Get Doctor And Patient Request Detail By Doctor User Id And Shift Id And Shift Time Id
    public async Task<OnlineVisitDoctorsAndPatientsReservationDetail?> GetDoctorAndPatientRequestDetailByDoctorUserIdAndShiftIdAndShiftTimeId(ulong doctorReservationId , ulong shiftId , ulong shiftTimeId)
    {
        return await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                        .FirstOrDefaultAsync(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == doctorReservationId && p.OnlineVisitWorkShiftDetail == shiftTimeId && p.OnlineVisitWorkShiftId == shiftId
                                                                && p.PatientUserId == null);
    }

    //Get Online Visit User Request Detail By Id
    public async Task<OnlineVisitUserRequestDetail?> GetOnlineVisitUserRequestDetailById(ulong requestId)
    {
        return await _context.OnlineVisitUserRequestDetails.AsNoTracking().FirstOrDefaultAsync(p => !p.IsDelete && p.Id == requestId);
    }

    //Fill Online Visit User Request Detail Doctor Side ViewModel
    public async Task<OnlineVisitUserRequestDetailDoctorSideViewModel?> FillOnlineVisitUserRequestDetailDoctorSideViewModel(ulong requestId)
    {
        var request = await GetOnlineVisitUserRequestDetailById(requestId);
        if (request == null) return null;

        return new OnlineVisitUserRequestDetailDoctorSideViewModel()
        {
            BusinessKey = request.DayDatebusinessKey,
            User = await _context.Users.AsNoTracking().FirstOrDefaultAsync(p => !p.IsDelete && p.Id == request.UserId),
            WorkShift = await _context.OnlineVisitWorkShift.AsNoTracking()
                                        .Where(p => !p.IsDelete && p.Id == request.WorkShiftDateId)
                                        .Select(p => p.StartShiftTime + " تا " + p.EndShiftTime).FirstOrDefaultAsync(),
            WorkShiftTime = await _context.OnlineVisitWorkShiftDetails.AsNoTracking()
                                        .Where(p => !p.IsDelete && p.Id == request.WorkShiftDateTimeId)
                                        .Select(p => p.StartTime + " تا " + p.EndTime).FirstOrDefaultAsync(),
            OnlineVisitRequestDate =await  _context.OnlineVisitDoctorsReservationDates.AsNoTracking().Where(p=>!p.IsDelete && p.BusinessKey == request.DayDatebusinessKey).Select(p=> p.OnlineVisitShiftDate).FirstOrDefaultAsync(),
            RequestId = request.Id,
            IsRequestTakenByDoctor = request.IsTakenFromDoctor
        };
    }

    //Get Online Visit User Request Detail For Show In List Of Doctors Lastest Request
    public async Task<ListOfLastestOnlineVisitRequestDoctorSideViewModel?> GetOnlineVisitUserRequestDetailForShowInListOfDoctorsLastestRequest(DateTime dateTime, int businessKey, ulong workShiftId)
    {
        return await _context.OnlineVisitUserRequestDetails.AsNoTracking()
                                .Where(p => !p.IsDelete && p.IsFinaly && !p.IsTakenFromDoctor && p.DayDatebusinessKey == businessKey && p.WorkShiftDateId == workShiftId)
                                .Select(p => new ListOfLastestOnlineVisitRequestDoctorSideViewModel()
                                {
                                    RequestCreateDate = p.CreateDate,
                                    UserRequestId = p.Id,
                                    WorkShiftDate = dateTime,
                                    WorkShift = _context.OnlineVisitWorkShift.Where(s => !s.IsDelete && s.Id == workShiftId)
                                                            .Select(s => s.StartShiftTime + "-" + s.EndShiftTime)
                                                            .FirstOrDefault(),
                                    WorkShiftTime = _context.OnlineVisitWorkShiftDetails.Where(s => !s.IsDelete && s.OnlineVisitWorkShiftId == workShiftId && s.Id == p.WorkShiftDateTimeId)
                                                        .Select(s => s.StartTime + " تا " + s.EndTime).FirstOrDefault(),
                                    User = _context.Users.AsNoTracking().Where(s => !s.IsDelete && s.Id == p.UserId)
                                                        .Select(s => new OnlineVisitRequestUser()
                                                        {
                                                            Mobile = s.Mobile,
                                                            UserAvatar = s.Avatar,
                                                            UserId = s.Id,
                                                            Username = s.Username
                                                        }).FirstOrDefault()
                                }).FirstOrDefaultAsync();
    }

    //Get List Of Doctor Selected Shift Ids By Doctor Reservation Id
    public async Task<List<ulong>> GetListOfDoctorSelectedShiftIdsByDoctorReservationId(ulong doctorReservationId)
    {
        return await _context.OnlineVisitDoctorSelectedWorkShifts.AsNoTracking()
                                .Where(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == doctorReservationId)
                                .Select(p => p.OnlineVisitWorkShiftId)
                                .ToListAsync();
    }

    //Get List Of Doctor Online Visti Reservation Id By Doctor User Id
    public async Task<List<OnlineVisitDoctorsReservationDate>> GetListOfDoctorOnlineVistiReservationIdByDoctorUserId(ulong doctorUserId)
    {
        #region Current Date Time

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        #endregion

        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                    .Where(p => p.DoctorUserId == doctorUserId && !p.IsDelete && DateTime.Compare(p.OnlineVisitShiftDate, dateTime) >= 0)
                                    .ToListAsync();
    }

    //Select List For Show List Of Avalable Shifts 
    public async Task<List<SelectListViewModel>> SelectListForShowListOfAvailableShifts()
    {
        return await _context.OnlineVisitWorkShift.AsNoTracking().Where(p => !p.IsDelete)
                                    .OrderBy(p => p.Id)
                                    .Select(p => new SelectListViewModel()
                                    {
                                        Id = p.Id,
                                        Title = $"از ساعت {p.StartShiftTime} تا ساعت {p.EndShiftTime}"
                                    }).ToListAsync();
    }

    //Show List Of Available Shifts For Select
    public async Task<List<ListOfAvailableShiftForSelectViewModel>?> ShowListOfAvailableShiftsForSelect()
    {
        return await _context.OnlineVisitWorkShift.AsNoTracking().Where(p => !p.IsDelete)
                                .OrderBy(p => p.Id)
                                .Select(p => new ListOfAvailableShiftForSelectViewModel()
                                {
                                    ShiftName = $"از ساعت {p.StartShiftTime} تا ساعت {p.EndShiftTime}",
                                    ShiftId = p.Id
                                }).ToListAsync();
    }

    //Add OnlineVisitDoctorsReservationDate To The Data Base 
    public async Task AddOnlineVisitDoctorsReservationDateToTheDataBase(OnlineVisitDoctorsReservationDate model)
    {
        await _context.OnlineVisitDoctorsReservationDates.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    //Add OnlineVisitDoctorSelectedWorkShift Without Save Changes
    public async Task AddOnlineVisitDoctorSelectedWorkShiftWithoutSaveChanges(OnlineVisitDoctorSelectedWorkShift model)
    {
        await _context.OnlineVisitDoctorSelectedWorkShifts.AddAsync(model);
    }

    //Get List Of Work Shifts Time Detail Id By Work Shift Id
    public async Task<List<ulong>> GetListOfWorkShiftsTimeDetailIdByWorkShiftId(ulong workShiftId)
    {
        return await _context.OnlineVisitWorkShiftDetails.AsNoTracking().Where(p => !p.IsDelete && p.OnlineVisitWorkShiftId == workShiftId)
                                                                .Select(p => p.Id).ToListAsync();
    }

    //Add OnlineVisitDoctorsAndPatientsReservationDetail To The Data Base Without Save Changes
    public async Task AddOnlineVisitDoctorsAndPatientsReservationDetailToTheDataBaseWithoutSaveChanges(OnlineVisitDoctorsAndPatientsReservationDetail model)
    {
        await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AddAsync(model);
    }

    //Save Changes
    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    //Get Validates Work Shift Dates By Doctor UserId For Show In Doctor Panel 
    public async Task<List<ListOfWorkShiftDatesFromDoctorPanelViewModel>> GetValidatesWorkShiftDatesByDoctorUserIdForShowInDoctorPanel(ulong doctorUserId)
    {
        #region Current Date Time

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        #endregion

        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                .Where(p => !p.IsDelete && DateTime.Compare(p.OnlineVisitShiftDate, dateTime) >= 0 && p.DoctorUserId == doctorUserId)
                                .Select(p => new ListOfWorkShiftDatesFromDoctorPanelViewModel()
                                {
                                    OnlineVisitShiftDate = p.OnlineVisitShiftDate,
                                    BusinessKey = p.BusinessKey,
                                    OnlineVisitDoctorsReservationDateId = p.Id,
                                    CountOfWorkShifts = _context.OnlineVisitDoctorSelectedWorkShifts.AsNoTracking()
                                                                .Where(s => !s.IsDelete && s.OnlineVisitDoctorsReservationDateId == p.Id)
                                                                        .Count(),
                                    CountOfAllShiftTime = _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                                                    .Where(s => !p.IsDelete && s.OnlineVisitDoctorsReservationDateId == p.Id).Count()
                                }).ToListAsync();
    }

    //Is Exist Any Work Shift Date For Current Doctor
    public async Task<bool> IsExistAnyWorkShiftDateForCurrentDoctor(ulong doctorUserId, int businessKey)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                            .AnyAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.BusinessKey == businessKey);
    }

    //Fill Work Shift Date Detail Doctor Panel 
    public async Task<List<WorkShiftDateDetailDoctorPanelViewModel>> FillWorkShiftDateDetailDoctorPanel(ulong OnlineVisitDoctorsReservationDateId)
    {
        return await _context.OnlineVisitDoctorSelectedWorkShifts.AsNoTracking().Where(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == OnlineVisitDoctorsReservationDateId)
                                .Select(p => new WorkShiftDateDetailDoctorPanelViewModel()
                                {
                                    OnlineVisitDoctorsReservationDateId = p.OnlineVisitDoctorsReservationDateId,
                                    WorkShiftId = p.OnlineVisitWorkShiftId,
                                    EndTime = _context.OnlineVisitWorkShift.AsNoTracking().Where(s => !s.IsDelete && s.Id == p.OnlineVisitWorkShiftId).Select(p => p.EndShiftTime).FirstOrDefault(),
                                    StartTime = _context.OnlineVisitWorkShift.AsNoTracking().Where(s => !s.IsDelete && s.Id == p.OnlineVisitWorkShiftId).Select(p => p.StartShiftTime).FirstOrDefault(),
                                    CountOfFreeTime = _context.OnlineVisitWorkShiftDetails.AsNoTracking().Count(s => !s.IsDelete && s.OnlineVisitWorkShiftId == p.OnlineVisitWorkShiftId),
                                }).ToListAsync();
    }

    //Get Work Shift Date By OnlineVisitDoctorsReservationDateId
    public async Task<DateTime> GetWorkShiftDateByOnlineVisitDoctorsReservationDateId(ulong OnlineVisitDoctorsReservationDateId)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking().Where(p => !p.IsDelete && p.Id == OnlineVisitDoctorsReservationDateId)
                                .Select(p => p.OnlineVisitShiftDate).FirstOrDefaultAsync();
    }

    //Is Exist Any OnlineVisitDoctorsReservationDate By Doctor UserId
    public async Task<bool> IsExistAnyOnlineVisitDoctorsReservationDateByDoctorUserId(ulong OnlineVisitDoctorsReservationDateId, ulong doctorUserId)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking().AnyAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId &&
                                                                                    p.Id == OnlineVisitDoctorsReservationDateId);
    }

    //Fill OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel
    public async Task<List<OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId)
    {
        return await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                .Where(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == doctorReservationDateId && p.OnlineVisitWorkShiftId == shiftId)
                                    .Select(p => new OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel()
                                    {
                                        Id = p.Id,
                                        EndTime = _context.OnlineVisitWorkShiftDetails.AsNoTracking()
                                                        .Where(s => !s.IsDelete && s.Id == p.OnlineVisitWorkShiftDetail)
                                                            .Select(s => s.EndTime).FirstOrDefault(),

                                        StartTime = _context.OnlineVisitWorkShiftDetails.AsNoTracking()
                                                        .Where(s => !s.IsDelete && s.Id == p.OnlineVisitWorkShiftDetail)
                                                            .Select(s => s.StartTime).FirstOrDefault(),

                                        Patient = _context.Users.AsNoTracking().Where(s => !s.IsDelete && s.Id == p.PatientUserId)
                                                            .Select(s => new OnlineVisitPatientInformationDoctorPanelSideViewModel()
                                                            {
                                                                Mobile = s.Mobile,
                                                                UserAvatar = s.Avatar,
                                                                UserId = s.Id,
                                                                Username = s.Username
                                                            }).FirstOrDefault()
                                    }).ToListAsync();
    }

    //Show Online Visit User Request Detail
    public async Task<OnlineVisitUserRequestDetailDoctorSideViewModel?> ShowOnlineVisitUserRequestDetail(ulong doctorAndPatientRequestId)
    {
       return await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                            .Where(p => !p.IsDelete && p.Id == doctorAndPatientRequestId && p.PatientUserId.HasValue)
                            .Select(p => new OnlineVisitUserRequestDetailDoctorSideViewModel()
                            {
                                IsRequestTakenByDoctor= true,
                                WorkShift = _context.OnlineVisitWorkShift.AsNoTracking().Where(s=> !s.IsDelete && s.Id == p.OnlineVisitWorkShiftId)
                                                    .Select(s=> s.StartShiftTime + " تا " + s.EndShiftTime).FirstOrDefault(),
                                WorkShiftTime = _context.OnlineVisitWorkShiftDetails.AsNoTracking().Where(s => !s.IsDelete && s.Id == p.OnlineVisitWorkShiftDetail)
                                                    .Select(s => s.StartTime + " تا " + s.EndTime).FirstOrDefault(),
                                RequestId = p.OnlineVisitDoctorsReservationDateId,
                                User = _context.Users.AsNoTracking().FirstOrDefault(s=> !s.IsDelete && s.Id == p.PatientUserId)
                            }).FirstOrDefaultAsync();
    }

    //Get Online Visit Doctor Reservation Date By Id
    public async Task<OnlineVisitDoctorsReservationDate?> GetOnlineVisitDoctorReservationDateById(ulong id)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                    .FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == id);
    }

    #endregion

    #region Admin Side 

    //Fill List Of Work Shifts Dates Admin Side View Model
    public async Task<List<ListOfWorkShiftsDatesAdminSideViewModel>> FillListOfWorkShiftsDatesAdminSideViewModel()
    {
        #region Current Date Time

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        #endregion

        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking().Where(p => !p.IsDelete && DateTime.Compare(p.OnlineVisitShiftDate, dateTime) >= 0)
                                        .GroupBy(p => p.OnlineVisitShiftDate)
                                        .Select(p => new ListOfWorkShiftsDatesAdminSideViewModel()
                                        {
                                            WorkShiftDate = p.Select(s => s.OnlineVisitShiftDate).FirstOrDefault(),
                                            CountOfOnlineDoctors = _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                                                        .Where(s => !s.IsDelete && s.OnlineVisitShiftDate == p.Select(s => s.OnlineVisitShiftDate).FirstOrDefault())
                                                                            .Count(),
                                            BusinessKey = p.Select(s => s.BusinessKey).FirstOrDefault(),

                                        }).ToListAsync();
    }

    //Get Doctor Work Shift Reservation Id By BusinessKet That Render From Dat
    public async Task<List<ulong>> GetDoctorWorkShiftReservationIdByBusinessKetThatRenderFromDate(int businessKey)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking().Where(p => !p.IsDelete && p.BusinessKey == businessKey)
                            .Select(p => p.Id).ToListAsync();
    }

    //Get Doctor Work Shift Seleceted Reservation Dates By Doctor Work Shift Reservation Ids
    public async Task<List<OnlineVisitWorkShift>?> GetDoctorWorkShiftSelecetedReservationDateByDoctorWorkShiftReservationId(ulong selectedReservationId)
    {
        var id = await _context.OnlineVisitDoctorSelectedWorkShifts.AsNoTracking().Where(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == selectedReservationId)
                                                .Select(p => p.OnlineVisitWorkShiftId).ToListAsync();

        //Create Return Model 
        List<OnlineVisitWorkShift> returnModels = new List<OnlineVisitWorkShift>();

        foreach (var item in id)
        {
            OnlineVisitWorkShift returnModel = new OnlineVisitWorkShift();

            returnModel = await _context.OnlineVisitWorkShift.AsNoTracking().Where(p => !p.IsDelete && p.Id == item).FirstOrDefaultAsync();
            if (returnModel is not null)
            {
                returnModels.Add(returnModel);
            }
        }

        return returnModels;
    }

    //Fill ListOfDoctorsInSelectedShiftAdminSideViewModel
    public Task<List<ListOfDoctorsInSelectedShiftAdminSideViewModel>> FillListOfDoctorsInSelectedShiftAdminSideViewModel(ulong workShiftId, int dateBusinessKey)
    {
        var onlineVisitDoctorSelectedDate = _context.OnlineVisitDoctorSelectedWorkShifts.AsNoTracking()
                                .Where(p => !p.IsDelete && p.OnlineVisitWorkShiftId == workShiftId);

        var onlineVisitDoctorReservationDate = _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                                            .Where(p => !p.IsDelete && p.BusinessKey == dateBusinessKey);

        var returnModel = onlineVisitDoctorReservationDate.Join(onlineVisitDoctorSelectedDate, r => r.Id, d => d.OnlineVisitDoctorsReservationDateId,
            (onlineVisitDoctorReservationDate, onlineVisitDoctorSelectedDate)
                => new ListOfDoctorsInSelectedShiftAdminSideViewModel()
                {
                    DoctorReservationDateId = onlineVisitDoctorReservationDate.Id,
                    SelectedDateTime = onlineVisitDoctorReservationDate.OnlineVisitShiftDate,
                    WorkShiftId = workShiftId,
                    CountOFAllTimes = _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                           .Count(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == onlineVisitDoctorReservationDate.Id && p.OnlineVisitWorkShiftId == workShiftId),

                    CountOfFressTimes = _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                           .Count(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == onlineVisitDoctorReservationDate.Id && !p.PatientUserId.HasValue && p.OnlineVisitWorkShiftId == workShiftId),

                    CountOfReservedTimes = _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                           .Count(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == onlineVisitDoctorReservationDate.Id && p.PatientUserId.HasValue && p.OnlineVisitWorkShiftId == workShiftId),

                    WorkShiftInfo = _context.OnlineVisitWorkShift.Where(d => !d.IsDelete && d.Id == workShiftId)
                                                             .Select(d => d.StartShiftTime.ToString() + " تا " + d.EndShiftTime.ToString()).FirstOrDefault(),

                    DoctorUser = _context.Users.AsNoTracking().Where(u => !u.IsDelete && u.Id == onlineVisitDoctorReservationDate.DoctorUserId)
                                    .Select(u => new DoctorsInfosInSelectedShiftAdminSide()
                                    {
                                        Mobile = u.Mobile,
                                        UserAvatar = u.Avatar,
                                        UserId = u.Id,
                                        Username = u.Username
                                    }).FirstOrDefault()
                }
            ).ToListAsync();

        return returnModel;
    }

    //Fill OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel
    public async Task<List<OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel>?> FillOnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel(ulong doctorReservationDateId, ulong shiftId)
    {
        return await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                .Where(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == doctorReservationDateId && p.OnlineVisitWorkShiftId == shiftId)
                                    .Select(p => new OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel()
                                    {
                                        EndTime = _context.OnlineVisitWorkShiftDetails.AsNoTracking()
                                                        .Where(s => !s.IsDelete && s.Id == p.OnlineVisitWorkShiftDetail)
                                                            .Select(s => s.EndTime).FirstOrDefault(),

                                        StartTime = _context.OnlineVisitWorkShiftDetails.AsNoTracking()
                                                        .Where(s => !s.IsDelete && s.Id == p.OnlineVisitWorkShiftDetail)
                                                            .Select(s => s.StartTime).FirstOrDefault(),

                                        Patient = _context.Users.AsNoTracking().Where(s => !s.IsDelete && s.Id == p.PatientUserId)
                                                            .Select(s => new OnlineVisitPatientInformationAdminPanelSideViewModel()
                                                            {
                                                                Mobile = s.Mobile,
                                                                UserAvatar = s.Avatar,
                                                                UserId = s.Id,
                                                                Username = s.Username
                                                            }).FirstOrDefault()
                                    }).ToListAsync();
    }

    #endregion

    #region Site Side 

    //List Of Work Shift Days
    public async Task<List<ListOfDaysForShowSiteSideViewModel>> FillListOfDaysForShowSiteSideViewModel()
    {
        #region Current Date Time

        var dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);

        #endregion

        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                        .Where(p => !p.IsDelete && DateTime.Compare(p.OnlineVisitShiftDate, dateTime) >= 0)
                                        .GroupBy(p => p.OnlineVisitShiftDate)
                                        .Select(p => new ListOfDaysForShowSiteSideViewModel()
                                        {
                                            WorkShiftDate = p.Select(s => s.OnlineVisitShiftDate).FirstOrDefault(),
                                            BusinessKey = p.Select(s => s.BusinessKey).FirstOrDefault(),

                                        }).ToListAsync();
    }

    //Get List Of Docotrs Reservation Dates With Date Business Key
    public async Task<List<ulong>> GetListOfDocotrsReservationDatesWithDateBusinessKey(int businessKey)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                            .Where(p => !p.IsDelete && p.BusinessKey == businessKey)
                                            .Select(p => p.Id).ToListAsync();
    }

    //Fill ListOfShiftSiteSideViewModel
    public async Task<List<ListOfShiftSiteSideViewModel>> FillListOfShiftSiteSideViewModel(ulong listOFDoctorsInThisDay, int businessKey)
    {
        return await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                            .Where(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == listOFDoctorsInThisDay
                                                    && !p.PatientUserId.HasValue && !p.IsExistAnyRequestForThisShift)
                                            .Select(p => new ListOfShiftSiteSideViewModel()
                                            {
                                                businessKey = businessKey,
                                                WorkShiftDateTimeId = p.OnlineVisitWorkShiftDetail,
                                                WorkShiftDateId = p.OnlineVisitWorkShiftId
                                            }).ToListAsync();
    }

    //Get String Of Start Time And End Shift Time
    public string GetStringOfStartTimeAndEndShiftTime(ulong WorkShiftDateTimeId)
    {
        return _context.OnlineVisitWorkShiftDetails.AsNoTracking()
                                                       .Where(d => d.Id == WorkShiftDateTimeId)
                                                        .Select(d =>  d.StartTime).FirstOrDefault();
    }

    //Check That Is Exist Free Shift 
    public async Task<int> CheckThatIsExistFreeShift(ulong WorkShiftDateTimeId, ulong WorkShiftDateId, List<ulong> doctorReservations)
    {
        int returnModel = 0;

        foreach (var item in doctorReservations)
        {
            var doctorAndPatientDetail = await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                                .AnyAsync(p => !p.IsDelete && p.OnlineVisitDoctorsReservationDateId == item
                                                        && p.OnlineVisitWorkShiftId == WorkShiftDateId
                                                        && p.OnlineVisitWorkShiftDetail == WorkShiftDateTimeId
                                                        && !p.PatientUserId.HasValue && !p.IsExistAnyRequestForThisShift);

            if (doctorAndPatientDetail)
            {
                returnModel = returnModel + 1;
            }
        }

        return returnModel;
    }

    //Add User Online Visit Request To The Data Base
    public async Task AddUserOnlineVisitRequestToTheDataBase(OnlineVisitUserRequestDetail model)
    {
        await _context.OnlineVisitUserRequestDetails.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    //Get Online Visit User Request Detail By Id And User Id
    public async Task<OnlineVisitUserRequestDetail?> GetOnlineVisitUserRequestDetailByIdAndUserId(ulong id, ulong userId)
    {
        return await _context.OnlineVisitUserRequestDetails.AsNoTracking()
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Id == id);
    }

    //Update Online Visit User Request Detail To Finaly
    public async Task UpdateOnlineVisitUserRequestDetailToFinaly(OnlineVisitUserRequestDetail model)
    {
        model.IsFinaly = true;

        _context.OnlineVisitUserRequestDetails.Update(model);
        await _context.SaveChangesAsync();
    }

    //Get Online Visit Doctor Reservations By Date BusinessKey
    public async Task<List<OnlineVisitDoctorsReservationDate>> GetOnlineVisitDoctorReservationsByDateBusinessKey(int businessKey)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                 .Where(p => !p.IsDelete && p.BusinessKey == businessKey).ToListAsync();
    }

    //Get List Of Online Visit Doctors Reservation By Work Shift Id And Work Shift Time Id
    public async Task<List<ulong>> GetListOfOnlineVisitDoctorsReservationByWorkShiftIdAndWorkShiftTimeId(ulong workShiftId, ulong workShiftTimeId)
    {
        return await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                               .Where(p => !p.IsDelete && p.OnlineVisitWorkShiftDetail == workShiftTimeId && p.OnlineVisitWorkShiftId == workShiftId
                                        && !p.PatientUserId.HasValue)
                               .Select(p => p.OnlineVisitDoctorsReservationDateId).ToListAsync();
    }

    //Get Doctors Id By Online Visit Doctors Reservation Id And Date Business Key
    public async Task<ulong?> GetDoctorsIdByOnlineVisitDoctorsReservationIdAndDateBusinessKey(ulong id, int dateBusinessKey)
    {
        return await _context.OnlineVisitDoctorsReservationDates.AsNoTracking()
                                .Where(p => !p.IsDelete && p.BusinessKey == dateBusinessKey && p.Id == id)
                                    .Select(p => p.DoctorUserId).FirstOrDefaultAsync();
    }

    //Update Randome Record Of Reservation Doctor And Patient For Exist Request For Select
    public async Task UpdateRandomeRecordOfReservationDoctorAndPatientForExistRequestForSelect(List<ulong> onlineVisitDoctorReservationId, ulong shiftTimeId, ulong shiftDateId)
    {
        foreach (var item in onlineVisitDoctorReservationId)
        {
            var reservationTime = await _context.OnlineVisitDoctorsAndPatientsReservationDetails.AsNoTracking()
                                                    .FirstOrDefaultAsync(p => !p.IsDelete
                                                                            && p.OnlineVisitDoctorsReservationDateId == item
                                                                            && !p.PatientUserId.HasValue
                                                                            && !p.IsExistAnyRequestForThisShift
                                                                            && p.OnlineVisitWorkShiftDetail == shiftTimeId
                                                                            && p.OnlineVisitWorkShiftId == shiftDateId);

            if (reservationTime != null)
            {
                reservationTime.IsExistAnyRequestForThisShift = true;
                _context.OnlineVisitDoctorsAndPatientsReservationDetails.Update(reservationTime);

                await _context.SaveChangesAsync();

                return;
            }
        }
    }

    #endregion
}
