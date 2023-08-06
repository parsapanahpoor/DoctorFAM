#region Usings 

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Laboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.Employee;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using Microsoft.EntityFrameworkCore;

#endregion

namespace DoctorFAM.Data.Repository;

public class LaboratoryRepository : ILaboratoryRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public LaboratoryRepository(DoctorFAMDbContext context)
    {
        _context = context;
    }

    #endregion

    #region Laboratory Side 

    //Create Request Excel File For Compelete From Admin 
    public async Task CreateRequestExcelFileForCompeleteFromAdmin(RequestForUploadExcelFileFromDoctorsToSite model)
    {
        await _context.RequestForUploadExcelFileFromDoctorsToSite.AddAsync(model);
        await _context.SaveChangesAsync();
    }

    //Get Doctor's Free SMS Count
    public async Task<int> GetLaboratoryFreeSMSCount()
    {
        return await _context.SiteSettings.Where(p => !p.IsDelete).Select(p => p.CountOFFreeSMSForDoctors).FirstOrDefaultAsync();
    }

    public async Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId)
    {
        return await _context.PatientRequestDateTimeDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == requestId);
    }

    public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
    {
        return await _context.PaitientRequestDetails.FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
    }

    public async Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId)
    {
        return await _context.HomeLaboratoryRequestDetails.Where(p => !p.IsDelete && p.RequestId == requestId).ToListAsync();
    }

    //Add User Laboratory Member Role Without Save Changes
    public async Task AddUserLaboratoryMemberRoleWithoutSaveChanges(UserRole userRole)
    {
        await _context.AddAsync(userRole);
    }

    //Save Changes
    public async Task Savechanges()
    {
        await _context.SaveChangesAsync();
    }

    //Check Is Exist Laboratory Info By User ID
    public async Task<bool> IsExistAnyLaboratoryInfoByUserId(ulong userId)
    {
        return await _context.LaboratoryInfos.Include(p => p.Laboratory).AnyAsync(p => !p.IsDelete && p.Laboratory.UserId == userId);
    }

    //Get Laboratory Information By User Id
    public async Task<LaboratoryInfo?> GetLaboratoryInformationByUserId(ulong userId)
    {
        return await _context.LaboratoryInfos.Include(p => p.Laboratory).FirstOrDefaultAsync(p => p.Laboratory.UserId == userId && !p.IsDelete);
    }

    //Get Laboratory By User Id
    public async Task<Laboratory?> GetLaboratoryByUserId(ulong userId)
    {
        return await _context.Laboratory.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
    }

    //Fill Laboratory Side Bar Panel
    public async Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId)
    {
        #region Get Laboratory Office

        var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                            .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Labratory);

        #endregion

        LaboratorySideBarViewModel model = new LaboratorySideBarViewModel();

        #region Laboratory State 

        //If Laboratory Registers Now
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.LaboratoryInfoState = "NewUser";

        //If Laboratory State Is WatingForConfirm
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.LaboratoryInfoState = "WatingForConfirm";

        //If Laboratory State Is Rejected
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.LaboratoryInfoState = "Rejected";

        //If Laboratory State Is Accepted
        if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.LaboratoryInfoState = "Accepted";

        #endregion

        return model;
    }

    //Is Exist Any Laboratory By This User Id 
    public async Task<bool> IsExistAnyLaboratoryByUserId(ulong userId)
    {
        return await _context.Laboratory.AnyAsync(p => p.UserId == userId && !p.IsDelete);
    }

    //Add Laboratory To Data Base
    public async Task<ulong> AddLaboratory(Laboratory laboratory)
    {
        await _context.Laboratory.AddAsync(laboratory);
        await _context.SaveChangesAsync();

        return laboratory.Id;
    }

    //Update Laboratory Info 
    public async Task UpdateLaboratoryInfo(LaboratoryInfo laboratoryInfo)
    {
         _context.LaboratoryInfos.Update(laboratoryInfo);
        await _context.SaveChangesAsync();
    }

    //Add Laboratory Info
    public async Task AddLaboratoryInfo(LaboratoryInfo laboratoryInfo)
    {
        await _context.LaboratoryInfos.AddAsync(laboratoryInfo);
        await _context.SaveChangesAsync();
    }

    //Filter Laboratory Office Employees
    public async Task<FilterLaboratoryOfficeEmployeesViewmodel> FilterLaboratoryOfficeEmployees(FilterLaboratoryOfficeEmployeesViewmodel filter)
    {
        #region Get organization 

        var laboratoryOffice = await _context.OrganizationMembers.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.userId);
        if (laboratoryOffice == null) return null;

        #endregion

        var query = _context.OrganizationMembers
            .Include(p => p.User)
            .Where(s => !s.IsDelete && s.OrganizationId == laboratoryOffice.OrganizationId)
            .OrderByDescending(s => s.CreateDate)
            .AsQueryable();


        #region Filter

        if (!string.IsNullOrEmpty(filter.Mobile))
        {
            query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.Username))
        {
            query = query.Where(s => s.User.Username.Contains(filter.Username));
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //Filter List Of Home Laboratory Request ViewModel From User Or Supporter Panel 
    public async Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfHomeLaboratoryRequestViewModel(FilterListOfHomeLaboratoryRequestViewModel filter)
    {
        #region Get Laboratory Work Address

        var workAddress = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.LaboratoryOwnerId);
        if (workAddress == null) return null;

        #endregion

        var query = _context.Requests
         .Include(p => p.PatientRequestDateTimeDetails)
         .Include(p => p.Patient)
         .Include(p => p.User)
         .Include(p => p.PaitientRequestDetails)
         .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeLab && s.PaitientRequestDetails.CountryId == workAddress.CountryId
                && s.PaitientRequestDetails.StateId == workAddress.StateId && s.PaitientRequestDetails.CityId == workAddress.CityId
                && s.RequestState == Domain.Enums.Request.RequestState.Paid)
         .OrderByDescending(s => s.CreateDate)
         .AsQueryable();

        #region Status

        switch (filter.FilterRequestLaboratorySideOrder)
        {
            case FilterRequestAdminSideOrder.CreateDate_Des:
                break;
            case FilterRequestAdminSideOrder.CreateDate_Asc:
                query = query.OrderBy(p => p.CreateDate);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.Username))
        {
            query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
        }

        if (!string.IsNullOrEmpty(filter.FirstName))
        {
            query = query.Where(s => EF.Functions.Like(s.User.FirstName, $"%{filter.FirstName}%"));
        }

        if (!string.IsNullOrEmpty(filter.LastName))
        {
            query = query.Where(s => EF.Functions.Like(s.User.LastName, $"%{filter.LastName}%"));
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    #endregion

    #region Admin Side

    //Filter Laboratory Info Admin Side
    public async Task<ListOfLaboratoryInfoViewModel> FilterListOfLaboratoryInfoViewModel(ListOfLaboratoryInfoViewModel filter)
    {
        var query = _context.Organizations
            .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.Labratory)
            .Include(p => p.User)
            .OrderByDescending(s => s.CreateDate)
            .AsQueryable();

        #region State

        switch (filter.LaboratoryState)
        {
            case LaboratoryState.All:
                break;
            case LaboratoryState.Accepted:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                break;
            case LaboratoryState.WaitingForConfirm:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                break;
            case LaboratoryState.Rejected:
                query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Rejected);
                break;
        }

        #endregion

        #region Filter

        if (!string.IsNullOrEmpty(filter.Email))
        {
            query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.Email}%"));
        }

        if (!string.IsNullOrEmpty(filter.Mobile))
        {
            query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
        }

        if (!string.IsNullOrEmpty(filter.FullName))
        {
            query = query.Where(s => s.User.Username.Contains(filter.FullName));
        }

        if (!string.IsNullOrEmpty(filter.NationalCode))
        {
            query = query.Where(s => s.User.NationalId.Contains(filter.NationalCode));
        }

        #endregion

        await filter.Paging(query);

        return filter;
    }

    //Get LaboratoryInfo Info By Nurse Id
    public async Task<LaboratoryInfo?> GetLaboratoryInfoByLaboratoryId(ulong LaboratoryId)
    {
        return await _context.LaboratoryInfos.Include(p => p.Laboratory).FirstOrDefaultAsync(p => !p.IsDelete && p.LaboratoryId == LaboratoryId);
    }

    //Get Laboratory By Consultant Id
    public async Task<Laboratory?> GetLaboratoryById(ulong laboratoryId)
    {
        return await _context.Laboratory.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == laboratoryId);
    }

    //Get Laboratory Info By Laboratory Info Id
    public async Task<LaboratoryInfo?> GetLaboratoryInfoById(ulong laboratoryInfoId)
    {
        return await _context.LaboratoryInfos.Include(p => p.Laboratory).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == laboratoryInfoId);
    }

    #endregion
}
