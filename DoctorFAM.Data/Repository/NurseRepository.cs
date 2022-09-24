using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.Nurse.NurseSideBarInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class NurseRepository : INurseRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public NurseRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Nurse Side

        //Fill Nurse Side Bar Panel
        public async Task<NurseSideBarViewModel> GetNurseSideBarInfo(ulong userId)
        {
            #region Get Doctor Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Nurse);

            #endregion

            NurseSideBarViewModel model = new NurseSideBarViewModel();

            #region Nurse State 

            //If Nurse Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.NurseInfoState = "NewUser";

            //If Nurse State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.NurseInfoState = "WatingForConfirm";

            //If Nurse State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.NurseInfoState = "Rejected";

            //If Nurse State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.NurseInfoState = "Accepted";

            #endregion

            return model;
        }

        //Is Exist Any Nurse By This User Id 
        public async Task<bool> IsExistAnyNurseByUserId(ulong userId)
        {
            return await _context.Nurses.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        //Add Doctor To Data Base
        public async Task<ulong> AddNurse(Nurse nurse)
        {
            await _context.Nurses.AddAsync(nurse);
            await _context.SaveChangesAsync();

            return nurse.Id;
        }

        //Get Nurse By User Id
        public async Task<Nurse?> GetNurseByUserId(ulong userId)
        {
            return await _context.Nurses.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        //Get Nurse Information By User Id
        public async Task<NurseInfo?> GetNurseInformationByUserId(ulong userId)
        {
            return await _context.NurseInfo.Include(p => p.Nurse).FirstOrDefaultAsync(p => p.Nurse.UserId == userId && !p.IsDelete);
        }
        
        //Check Is Exist Nurse Info By User ID
        public async Task<bool> IsExistAnyNurseInfoByUserId(ulong userId)
        {
            return await _context.NurseInfo.Include(p => p.Nurse).AnyAsync(p => !p.IsDelete && p.Nurse.UserId == userId);
        }

        //Update Nurse Info 
        public async Task UpdateNurseInfo(NurseInfo nurseInfo)
        {
            _context.NurseInfo.Update(nurseInfo);
            await _context.SaveChangesAsync();
        }
        
        //Add Nurse Info
        public async Task AddNurseInfo(NurseInfo nurseInfo)
        {
            await _context.NurseInfo.AddAsync(nurseInfo);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side 

        //Get Nurse Info By Nurse Id
        public async Task<NurseInfo?> GetNurseInfoByNurseId(ulong NurseId)
        {
            return await _context.NurseInfo.Include(p => p.Nurse).FirstOrDefaultAsync(p => !p.IsDelete && p.NurseId == NurseId);
        }

        //Filter Nurse Info Admin Side
        public async Task<ListOfNurseInfoViewModel> FilterNurseInfoAdminSide(ListOfNurseInfoViewModel filter)
        {
            var query = _context.Organizations
                .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.Nurse)
                .Include(p => p.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.NurseState)
            {
                case NurseState.All:
                    break;
                case NurseState.Accepted:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                    break;
                case NurseState.WaitingForConfirm:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                    break;
                case NurseState.Rejected:
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

        //Get Nurse By Nurse Id
        public async Task<Nurse?> GetNurseById(ulong nurseId)
        {
            return await _context.Nurses.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == nurseId);
        }
            
        //Get Nurse Info By Nurse Info Id
        public async Task<NurseInfo?> GetNurseInfoById(ulong nurseInfoId)
        {
            return await _context.NurseInfo.Include(p => p.Nurse).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == nurseInfoId);
        }

        #endregion

        #region Site Side 

        //Get Activated Nurses For Send Correct Notification For Arrival Home Nurse Request 
        public async Task<List<string?>> GetActivatedNurses(ulong countryId, ulong stateId, ulong cityId)
        {
            #region Get Home Pharmacy Interests Pharmacys  

            var users = await _context.Nurses.Include(p => p.User).Where(p => !p.IsDelete).Select(p=> p.UserId).ToListAsync();
            if (users == null) return null;

            #endregion

            #region Check User Work Addresses 

            //Initial Model Of String 
            List<string?> returnValue = new List<string?>();

            foreach (var item in users)
            {
                //Check Nurses Location By Country Id && State Id && CityId
                var checkLocation = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.CityId == cityId && p.CountryId == countryId && p.StateId == stateId
                                                              && p.UserId == item);

                if (checkLocation != null)
                {
                    //Check Nurse Is Activated
                    var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == checkLocation.UserId
                                            && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Nurse && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

                    if (activated != null)
                    {
                        returnValue.Add(activated.OwnerId.ToString());
                    }
                }
            }

            #endregion

            return returnValue;
        }

        #endregion
    }
}
