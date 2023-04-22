using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Enums.FamilyDoctor;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class FamilyDoctorRepository : IFamilyDoctorRepository
    {
        #region Ctor 

        private readonly DoctorFAMDbContext _context;

        public FamilyDoctorRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        //Get User Selected Family Doctor By User And Doctor Id 
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserAndDoctorId(ulong userId, ulong doctorUserId)
        {
            return await _context.UserSelectedFamilyDoctor.FirstOrDefaultAsync(p => !p.IsDelete && p.PatientId == userId && p.DoctorId == doctorUserId
                                                                               && p.FamilyDoctorRequestState == FamilyDoctorRequestState.Accepted);
        }

        #endregion

        #region User Panel

        //Is Exist Any Family Doctor For Patient
        public async Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId)
        {
            return await _context.UserSelectedFamilyDoctor.AnyAsync(p => !p.IsDelete && p.PatientId == userId && p.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted);
        }

        //Get User Selected Family Doctor 
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId)
        {
            return await _context.UserSelectedFamilyDoctor
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.PatientId == userId);
        }

        //Get User Selected Family Doctor By Request Id
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestId(ulong requestId)
        {
            return await _context.UserSelectedFamilyDoctor
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == requestId);
        }

        //Get User Selected Family Doctor By Request Id With Doctor And Patient Information And Not Deleted
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestIdWithDoctorAndPatientInformation(ulong requestId)
        {
            return await _context.UserSelectedFamilyDoctor.Include(p => p.Doctor).Include(p => p.Patient)
                                                .ThenInclude(p => p.PopulationCovered).ThenInclude(p => p.Insurance)
                                                        .FirstOrDefaultAsync(p => p.Id == requestId);
        }

        //Add Family Doctor For This Patient 
        public async Task AddFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor)
        {
            await _context.UserSelectedFamilyDoctor.AddAsync(familyDoctor);
            await _context.SaveChangesAsync();
        }

        //Remove Family Doctor For This Patient 
        public async Task RemoveFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor)
        {
            familyDoctor.IsDelete = true;

            _context.UserSelectedFamilyDoctor.Update(familyDoctor);
            await _context.SaveChangesAsync();
        }

        //Get User Selected Family Doctor By Patient Id And Doctor Id With Accepted And Waiting State
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(ulong userId, ulong doctorId)
        {
            return await _context.UserSelectedFamilyDoctor.FirstOrDefaultAsync(p => !p.IsDelete && p.DoctorId == doctorId && p.PatientId == userId
                                                             && p.FamilyDoctorRequestState != Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline);
        }

        //Update User Selected Family Doctor 
        public async Task UpdateUserSelectedFamilyDoctor(UserSelectedFamilyDoctor userSelectedFamilyDoctor)
        {
            _context.UserSelectedFamilyDoctor.Update(userSelectedFamilyDoctor);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Doctor Panel 

        //List Of Doctor Population Covered Users
        public async Task<ListOfDoctorPopulationCoveredViewModel> FilterDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter)
        {
            #region Get organization 

            var doctorOffice = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.UserId);
            if (doctorOffice == null) return null;

            #endregion

            var query = _context.UserSelectedFamilyDoctor
                .Include(p => p.Patient)
                .ThenInclude(p => p.PopulationCovered)
                .Where(s => !s.IsDelete && s.DoctorId == doctorOffice.Organization.OwnerId && s.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm)
                .OrderByDescending(s => s.CreateDate)
                .Select(p => p.Patient)
                .AsQueryable();


            #region Filter

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.Mobile != null && EF.Functions.Like(s.Mobile, $"%{filter.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => s.Username.Contains(filter.Username));
            }

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(s => s.NationalId.Contains(filter.NationalId));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Fill Choose Users For Send SMS View Model
        public async Task<ChooseUsersForSendSMSViewModel?> ChooseUsersForSendSMSViewModel(ulong userId)
        {
            return await _context.Users.Where(p => !p.IsDelete && p.Id == userId)
                .Select(p => new ChooseUsersForSendSMSViewModel()
                {
                    UserId = p.Id,
                    Username = p.Username,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Mobile = p.Mobile,
                    UserAvatar = p.Avatar
                }).FirstOrDefaultAsync();
        }

        //List Of Current Doctor Population Covered Users Without Base Paging
        public async Task<List<ulong>?> ListOfCurrentDoctorPopulationCoveredUsersWithoutBasePaging(ulong doctorUserId)
        {
            #region Get organization 

            var doctorOffice = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == doctorUserId);
            if (doctorOffice == null) return null;

            #endregion

            return await _context.UserSelectedFamilyDoctor.Where(s => !s.IsDelete && s.DoctorId == doctorOffice.Organization.OwnerId
                                                                 && s.FamilyDoctorRequestState == FamilyDoctorRequestState.Accepted)
                                                                 .Select(p => p.PatientId).ToListAsync();
        }

        //List Of Current Doctor Population Covered Users
        public async Task<ListOfDoctorPopulationCoveredViewModel> FilterCurrentDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter)
        {
            #region Get organization 

            var doctorOffice = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.UserId);
            if (doctorOffice == null) return null;

            #endregion

            var query = _context.UserSelectedFamilyDoctor
                .Include(p => p.Patient)
                .ThenInclude(p => p.PopulationCovered)
                .Where(s => !s.IsDelete && s.DoctorId == doctorOffice.Organization.OwnerId && s.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted)
                .OrderByDescending(s => s.CreateDate)
                .Select(p => p.Patient)
                .AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.Mobile != null && EF.Functions.Like(s.Mobile, $"%{filter.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => s.Username.Contains(filter.Username));
            }

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(s => s.NationalId.Contains(filter.NationalId));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Get Lastest Family Doctor Request For Current Doctor 
        public async Task<List<UserSelectedFamilyDoctor>> GetLastestFamilyDoctorRequestForCurrentDoctor(ulong doctorId)
        {
            return await _context.UserSelectedFamilyDoctor.Where(p => !p.IsDelete && p.DoctorId == doctorId && p.FamilyDoctorRequestState == FamilyDoctorRequestState.WaitingForConfirm)
                                                                        .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        #endregion

        #region Admin And Supporter Side 

        //Count Of Awaiting Family Doctor Requests
        public async Task<int> CountOfAwaitingFamilyDoctorRequests()
        {
            return await _context.UserSelectedFamilyDoctor.Where(p => !p.IsDelete && p.FamilyDoctorRequestState == FamilyDoctorRequestState.WaitingForConfirm)
                            .CountAsync();
        }

        //Count Of Accepted Family Doctor Requests
        public async Task<int> CountOfAcceptedFamilyDoctorRequests()
        {
            return await _context.UserSelectedFamilyDoctor.Where(p => !p.IsDelete && p.FamilyDoctorRequestState == FamilyDoctorRequestState.Accepted)
                            .CountAsync();
        }

        //Get List Of Doctor Population Covered By Doctor Id
        public async Task<List<UserSelectedFamilyDoctor>?> GetListOfDoctorPopulationCoveredByDoctorId(ulong doctorId)
        {
            return await _context.UserSelectedFamilyDoctor.Include(p => p.Patient)
                                    .Where(p => !p.IsDelete && p.DoctorId == doctorId)
                                        .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //List Of Family Doctor Request Admin Side 
        public async Task<FilterFamilyDoctorViewModel> FilterFamilyDoctorRequestAdminAndSupporterSide(FilterFamilyDoctorViewModel filter)
        {
            var query = _context.UserSelectedFamilyDoctor
                .Include(p => p.Patient)
                .Include(p => p.Doctor)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region States 

            switch (filter.FamilyDoctorRequestStateAdminFilter)
            {
                case FamilyDoctorRequestStateAdminFilter.All:
                    break;
                case FamilyDoctorRequestStateAdminFilter.Accepted:
                    query = query.Where(s => s.FamilyDoctorRequestState == FamilyDoctorRequestState.Accepted);
                    break;
                case FamilyDoctorRequestStateAdminFilter.WaitingForConfirm:
                    query = query.Where(s => s.FamilyDoctorRequestState == FamilyDoctorRequestState.WaitingForConfirm);
                    break;
                case FamilyDoctorRequestStateAdminFilter.Decline:
                    query = query.Where(s => s.FamilyDoctorRequestState == FamilyDoctorRequestState.Decline);
                    break;
            }

            switch (filter.FamilyDoctorRequestDeleteState)
            {
                case FamilyDoctorRequestDeleteState.All:
                    break;
                case FamilyDoctorRequestDeleteState.Deleted:
                    query = query.Where(s => s.IsDelete);
                    break;
                case FamilyDoctorRequestDeleteState.NotDeleted:
                    query = query.Where(s => !s.IsDelete);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.PatientMobile))
            {
                query = query.Where(s => s.Patient.Mobile != null && EF.Functions.Like(s.Patient.Mobile, $"%{filter.PatientMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.PatientName))
            {
                query = query.Where(s => s.Patient.Username.Contains(filter.PatientName));
            }

            if (!string.IsNullOrEmpty(filter.PatientNationalId))
            {
                query = query.Where(s => s.Patient.NationalId.Contains(filter.PatientNationalId));
            }

            if (!string.IsNullOrEmpty(filter.DoctorMobile))
            {
                query = query.Where(s => s.Doctor.Mobile != null && EF.Functions.Like(s.Doctor.Mobile, $"%{filter.DoctorMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.DoctorName))
            {
                query = query.Where(s => s.Doctor.Username.Contains(filter.DoctorName));
            }

            if (!string.IsNullOrEmpty(filter.DoctorNationalId))
            {
                query = query.Where(s => s.Doctor.NationalId.Contains(filter.DoctorNationalId));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion
    }
}
