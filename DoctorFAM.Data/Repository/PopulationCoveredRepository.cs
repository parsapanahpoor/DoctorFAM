using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.PopulationCovered;
using DoctorFAM.Domain.ViewModels.UserPanel.PopulationCovered;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class PopulationCoveredRepository : IPopulationCoveredRepository
    {
        #region ctor

        private readonly DoctorFAMDbContext _context;

        public PopulationCoveredRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin Side

        public async Task<FilterPopulationCoveredAdminViewModel> FilterPopulationCoveredAdmin(FilterPopulationCoveredAdminViewModel filter)
        {
            var query = _context.PopulationCovered
                .Include(a => a.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(s => EF.Functions.Like(s.NationalId, $"%{filter.NationalId}%"));
            }

            if (filter.UserId != null && filter.UserId != 0)
            {
                query = query.Where(s => s.UserId == filter.UserId);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Count Of All Population Covered 
        public async Task<int> CountOfAllPopulationCovered()
        {
            return await _context.PopulationCovered.Where(p => !p.IsDelete).CountAsync(); 
        }

        #endregion

        #region User Panel Side

        //Check Is Exist National Id 
        public async Task<bool> CheckIsExistNationalId(string nationalId, ulong userId)
        {
            var user = await _context.PopulationCovered.FirstOrDefaultAsync(s => !s.IsDelete && s.NationalId == nationalId.Trim());

            if (user == null) return true;
            if (user.UserId == userId) return true;

            return false;
        }

        //Is Exist Recorde By National Id 
        public async Task<bool> IsExistRecordeByNationalId(string nationalId)
        {
            return await _context.PopulationCovered.AnyAsync(p => !p.IsDelete && p.NationalId == nationalId.ToLower().Trim());
        }

        //Get User By National Id From Poplation Covered
        public async Task<PopulationCovered?> GetUserByNationalIdFromPopulationCovered(string nationalId)
        {
            return await _context.PopulationCovered.FirstOrDefaultAsync(p=> !p.IsDelete && p.NationalId == nationalId.Trim().ToLower());
        }

        public async Task AddPopulationCovered(PopulationCovered population)
        {
            await _context.PopulationCovered.AddAsync(population);
            await _context.SaveChangesAsync();
        }

        public async Task<FilterPopulationCoveredUserViewModel> FilterPopulationCoveredUser(FilterPopulationCoveredUserViewModel filter)
        {
            var query = _context.PopulationCovered.Where(p=> !p.IsDelete && p.UserId == filter.UserId)
                .Include(a => a.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(s => EF.Functions.Like(s.NationalId, $"%{filter.NationalId}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<PopulationCovered?> GetPopulationCoveredById(ulong id)
        {
            return await _context.PopulationCovered.Include(p=> p.Insurance)
                                    .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == id); 
        }

        public async Task UpdatePopulationCovered(PopulationCovered population)
        {
            _context.PopulationCovered.Update(population);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Site Side 

        public async Task<List<PopulationCovered>> GetUserPopulation(ulong userId)
        {
            return await _context.PopulationCovered.Include(p=> p.Insurance)
                                        .Where(p => !p.IsDelete && p.UserId == userId).ToListAsync();
        }

        #endregion
    }
}
