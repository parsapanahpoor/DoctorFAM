using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class DoctorsRepostory : IDoctorsRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public DoctorsRepostory(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Doctors Panel Side

        public async Task<FilterDoctorOfficeEmployeesViewmodel> FilterDoctorOfficeEmployees(FilterDoctorOfficeEmployeesViewmodel filter)
        {
            #region Get organization 

            var doctorOffice = await _context.OrganizationMembers.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.userId);
            if (doctorOffice == null) return null;

            #endregion

            var query = _context.OrganizationMembers
                .Include(p => p.User)
                .Where(s => !s.IsDelete && s.OrganizationId == doctorOffice.OrganizationId)
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

        public async Task<bool> IsExistAnyDoctorByUserId(ulong userId)
        {
            return await _context.Doctors.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        public async Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).AnyAsync(p => !p.IsDelete && p.Doctor.UserId == userId);
        }

        //Fill Doctor Side Bar Panel 
        public async Task<DoctorSideBarViewModel> GetDoctorsSideBarInfo(ulong userId)
        {
            #region Get Doctor Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);

            #endregion

            DoctorSideBarViewModel model = new DoctorSideBarViewModel();

            #region Doctor State 

            //If Doctor Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.DoctorInfoState = "NewUser";

            //If Doctor State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.DoctorInfoState = "WatingForConfirm";

            //If Doctor State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.DoctorInfoState = "Rejected";

            //If Doctor State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.DoctorInfoState = "Accepted";

            #endregion

            #region Get Doctors Interests

            var doctor = await GetDoctorByUserId(OrganitionMember.Organization.OwnerId);

            var doctorInterest = await _context.DoctorsSelectedInterests.Include(p => p.Interest).ThenInclude(p => p.InterestInfo).Where(p => !p.IsDelete && p.DoctorId == doctor.Id).ToListAsync();

            if (doctorInterest != null && doctorInterest.Any())
            {
                //Doctor Has HomeVisit Interest
                if (doctorInterest.Any(p => p.InterestId == 1)) model.HomeVisit = true;

                //Doctor Has Death Certificate Interest
                if (doctorInterest.Any(p => p.InterestId == 4)) model.DeathCertificate = true;

                //Doctor Has Family Doctor Interests
                if (doctorInterest.Any(p => p.InterestId == 3)) model.DoctorFamily = true;
            }

            #endregion

            return model;
        }

        public async Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).FirstOrDefaultAsync(p => p.Doctor.UserId == userId && !p.IsDelete);
        }

        public async Task UpdateDoctorsInfo(DoctorsInfo doctorsInfo)
        {
            _context.DoctorsInfos.Update(doctorsInfo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorState(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task AddDoctorsInfo(DoctorsInfo doctorsInfo)
        {
            await _context.DoctorsInfos.AddAsync(doctorsInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<Doctor?> GetDoctorByUserId(ulong userId)
        {
            return await _context.Doctors.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        public async Task<Doctor?> GetDoctorById(ulong doctorId)
        {
            return await _context.Doctors.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == doctorId);
        }

        public async Task<ulong> AddDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return doctor.Id;
        }

        public async Task<List<DoctorsInterestInfo>> GetDoctorInterestsInfo()
        {
            return await _context.InterestInfos.Include(p => p.Interest).Where(p => !p.IsDelete).ToListAsync();
        }

        public async Task<List<DoctorsInterestInfo>> GetDoctorSelectedInterests(ulong doctorId)
        {
            var interest = await _context.DoctorsSelectedInterests.Include(p => p.Interest).ThenInclude(p => p.InterestInfo)
                                .Where(p => !p.IsDelete && p.DoctorId == doctorId).Select(p => p.Interest).ToListAsync();

            List<DoctorsInterestInfo> model = new List<DoctorsInterestInfo>();

            foreach (var item in interest)
            {
                foreach (var interestInfo in await _context.InterestInfos.Where(p => !p.IsDelete && p.InterestId == item.Id).ToListAsync())
                {
                    model.Add(interestInfo);
                }
            }

            return model;
        }

        public async Task AddDoctorSelectedInterest(DoctorsSelectedInterests doctorsSelectedInterests)
        {
            await _context.DoctorsSelectedInterests.AddAsync(doctorsSelectedInterests);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistInterestForDoctor(ulong interestId, ulong doctorId)
        {
            return await _context.DoctorsSelectedInterests.AnyAsync(p => !p.IsDelete && p.DoctorId == doctorId && p.InterestId == interestId);
        }

        public async Task<bool> IsExistInterestById(ulong interestId)
        {
            return await _context.Interests.AnyAsync(p => !p.IsDelete && p.Id == interestId);
        }

        public async Task DeleteDoctoreSelectedInterest(DoctorsSelectedInterests item)
        {
            _context.DoctorsSelectedInterests.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<DoctorsSelectedInterests?> GetDoctorSelectedInterestByDoctorIdAndInetestId(ulong interestId, ulong doctorId)
        {
            return await _context.DoctorsSelectedInterests.FirstOrDefaultAsync(p => !p.IsDelete && p.InterestId == interestId &&
            p.DoctorId == doctorId);
        }

        public async Task<DoctorsSelectedInterests?> GetDoctorSelectedInterestByDoctorIdAndInterestId(ulong interestId, ulong doctorId)
        {
            return await _context.DoctorsSelectedInterests.FirstOrDefaultAsync(p => p.InterestId == interestId && p.DoctorId == doctorId && !p.IsDelete);
        }

        #endregion

        #region Admin Side

        public async Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter)
        {
            var query = _context.Organizations
                .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice)
                .Include(p => p.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.DoctorsState)
            {
                case DoctorsState.All:
                    break;

                case DoctorsState.Accepted:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                    break;

                case DoctorsState.WaitingForConfirm:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                    break;

                case DoctorsState.Rejected:
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

        public async Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == doctorInfoId);
        }

        public async Task<DoctorsInfo?> GetDoctorsInfoByDoctorId(ulong doctorId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).FirstOrDefaultAsync(p => !p.IsDelete && p.DoctorId == doctorId);
        }

        #endregion

        #region Site Side 

        //Get List Of All Doctors
        public async Task<List<ListOfAllDoctorsViewModel>> ListOfDoctors()
        {
            //Get List Of Doctors
            var doctors = await _context.Doctors.Include(p => p.User).Include(p => p.DoctorsInfos)
                .Where(p => !p.IsDelete).ToListAsync();

            List<ListOfAllDoctorsViewModel> model = new List<ListOfAllDoctorsViewModel>();

            foreach (var item in doctors)
            {
                if (await _context.Organizations.AnyAsync(p => !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice
                                                                        && p.OrganizationInfoState == OrganizationInfoState.Accepted && p.OwnerId == item.UserId))
                {
                    ListOfAllDoctorsViewModel modelChild = new ListOfAllDoctorsViewModel()
                    {
                        UserId = item.UserId,
                        Username = item.User.Username,
                        UserAvatar = item.User.Avatar,
                        Education = item.DoctorsInfos.Education,
                        Specialist = item.DoctorsInfos.Specialty
                    };

                    model.Add(modelChild);
                }
            }

            return model;
        }

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        public async Task<List<Doctor>?> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter)
        {
            var query = await _context.DoctorsSelectedInterests
                    .Include(p => p.Doctor)
                    .ThenInclude(p=> p.DoctorsInfos)
                    .Include(p => p.Doctor)
                    .ThenInclude(p => p.User)
                    .Where(s => !s.IsDelete && s.InterestId == 3)
                    .OrderByDescending(s => s.CreateDate)
                    .Select(p => p.Doctor)
                    .ToListAsync();

            var model = new List<Doctor>();

            foreach (var item in query)
            {
                if (await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == item.UserId && p.OrganizationInfoState == OrganizationInfoState.Accepted) != null)
                {
                    model.Add(item);
                }
            }

            #region Filter

            if (!string.IsNullOrEmpty(filter.Username))
            {
                model = model.Where(s => s.User.Username.Contains(filter.Username)).ToList();
            }

            if (filter.CountryId.HasValue)
            {
                List<Doctor?> CountryModel = new List<Doctor?>();

                foreach (var item in model.Select(p => p.UserId))
                {
                    var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CountryId == filter.CountryId.Value);

                    if (address != null)
                    {
                        CountryModel.Add(await _context.DoctorsSelectedInterests
                                             .Include(p => p.Doctor).ThenInclude(p => p.User)
                                                .Where(s => !s.IsDelete && s.Doctor.UserId == address.UserId).Select(p => p.Doctor).FirstOrDefaultAsync());
                    }
                }

                model = CountryModel;
            }

            if (filter.StateId.HasValue)
            {
                List<Doctor?> StateModel = new List<Doctor?>();

                foreach (var item in query.Select(p => p.UserId))
                {
                    var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.StateId == filter.StateId.Value);

                    if (address != null)
                    {
                        StateModel.Add(await _context.DoctorsSelectedInterests
                                             .Include(p => p.Doctor).ThenInclude(p => p.User)
                                                .Where(s => !s.IsDelete && s.Doctor.UserId == address.UserId).Select(p => p.Doctor).FirstOrDefaultAsync());
                    }
                }

                model = StateModel;
            }

            if (filter.CityId.HasValue)
            {
                List<Doctor?> CityModel = new List<Doctor?>();

                foreach (var item in query.Select(p => p.UserId))
                {
                    var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CityId == filter.CityId.Value);

                    if (address != null)
                    {
                        CityModel.Add(await _context.DoctorsSelectedInterests
                                             .Include(p => p.Doctor).ThenInclude(p => p.User)
                                                .Where(s => !s.IsDelete && s.Doctor.UserId == address.UserId).Select(p => p.Doctor).FirstOrDefaultAsync());
                    }
                }

                model = CityModel;
            }

            #endregion

            return model;
        }

       

        #endregion
    }
}
