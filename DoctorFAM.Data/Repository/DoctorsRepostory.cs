using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId)
        {
            return await _context.DoctorsInfos.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        public async Task<string> GetDoctorsInfosState(ulong userId)
        {
            //If Doctor Registers Now
            if (!await _context.DoctorsInfos.AnyAsync(p => !p.IsDelete && p.UserId == userId) ) return "NewUser";

            //If Doctor State Is WatingForConfirm
            if (await _context.DoctorsInfos.AnyAsync(p => p.UserId == userId && !p.IsDelete && p.DoctorsInfosType == DoctorsInfosType.WatingForConfirm)) return "WatingForConfirm";

            //If Doctor State Is Rejected
            if (await _context.DoctorsInfos.AnyAsync(p => p.UserId == userId && !p.IsDelete && p.DoctorsInfosType == DoctorsInfosType.Rejected)) return "Rejected";

            //If Doctor State Is Accepted
            if (await _context.DoctorsInfos.AnyAsync(p => p.UserId == userId && !p.IsDelete && p.DoctorsInfosType == DoctorsInfosType.Accepted)) return "Accepted";

            return "NewUser";
        }

        public async Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId)
        {
            return await _context.DoctorsInfos.FirstOrDefaultAsync(p => p.UserId == userId && !p.IsDelete);
        }

        public async Task UpdateDoctorsInfo(DoctorsInfo doctorsInfo)
        {
            _context.DoctorsInfos.Update(doctorsInfo);
            await _context.SaveChangesAsync();
        }

        public async Task AddDoctorsInfo(DoctorsInfo doctorsInfo)
        {
            await _context.DoctorsInfos.AddAsync(doctorsInfo);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side

        public async Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter)
        {
            var query = _context.DoctorsInfos
                .Where(s => !s.IsDelete)
                .Include(p => p.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.DoctorsState)
            {
                case DoctorsState.All:
                    break;

                case DoctorsState.Accepted:
                    query = query.Where(s => s.DoctorsInfosType == DoctorsInfosType.Accepted);
                    break;

                case DoctorsState.WaitingForConfirm:
                    query = query.Where(s => s.DoctorsInfosType == DoctorsInfosType.WatingForConfirm);
                    break;

                case DoctorsState.Rejected:
                    query = query.Where(s => s.DoctorsInfosType == DoctorsInfosType.Rejected);
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

            if (filter.NationalCode != null && filter.NationalCode != 0)
            {
                query = query.Where(s => s.NationalCode == filter.NationalCode);
            }

            if (filter.MedicalSystemCode != null && filter.MedicalSystemCode != 0)
            {
                query = query.Where(s => s.MedicalSystemCode == filter.MedicalSystemCode);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId)
        {
            return await _context.DoctorsInfos.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == doctorInfoId);
        }

        #endregion
    }
}
