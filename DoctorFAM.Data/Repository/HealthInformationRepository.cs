using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HealthInformationRepository : IHealthInformationRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public HealthInformationRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region TV FAM

        #region Category 

        #region Admin Side 

        //List Of TV FAM Category 
        public async Task<FilterTVFAMCategoryViewModel> FilterTVFAMCategory(FilterTVFAMCategoryViewModel filter)
        {
            var query = _context.TVFAMCategoryInfos
               .Include(a => a.TVFAMCategory)
               .ThenInclude(p => p.Parent)
               .OrderByDescending(s => s.CreateDate)
               .AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(filter.UniqueName))
            {
                query = query.Where(s => EF.Functions.Like(s.TVFAMCategory.UniqueName, $"%{filter.UniqueName}%"));
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));
            }

            if (filter.ParentId != null)
            {
                query = query.Where(a => a.TVFAMCategory.ParentId == filter.ParentId);
                filter.ParentTVFAMCategory = await _context.TVFAMCategories.FirstOrDefaultAsync(a => a.Id == filter.ParentId);
            }
            else
            {
                query = query.Where(a => a.TVFAMCategory.ParentId == null);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Get Health Information Category By Health Information Category Id 
        public async Task<TVFAMCategory?> GetHealthInformationCategoryByHealthInformationCategoryId(ulong tvFAMCategoryId)
        {
            return await _context.TVFAMCategories.Include(p => p.TVFAMCategoryInfo)
                                    .FirstOrDefaultAsync(s => !s.IsDelete && s.Id == tvFAMCategoryId);
        }

        //Is Exist TV FAM Category By Unique Name
        public async Task<bool> IsExistTVFAMCategoryByUniqueName(string uniqueName)
        {
            return await _context.TVFAMCategories.AnyAsync(p => p.UniqueName == uniqueName && !p.IsDelete);
        }

        //Is Exist Any TV FAM Category By Id 
        public async Task<bool> IsExistTVFAMCategoryById(ulong tvFAMCategoryId)
        {
            return await _context.TVFAMCategories.AnyAsync(p => p.Id == tvFAMCategoryId && !p.IsDelete);
        }

        //Add TV FAM Categories
        public async Task<ulong> AddTVFAMCategory(TVFAMCategory tvFAMCategory)
        {
            #region Add TV FAM Categroy

            await _context.TVFAMCategories.AddAsync(tvFAMCategory);
            await _context.SaveChangesAsync();

            #endregion

            return tvFAMCategory.Id;
        }

        //Add TV FAM Category Info
        public async Task AddTVFAMCategoryInfo(List<TVFAMCategoryInfo> tvFAMCategoryInfos)
        {
            await _context.TVFAMCategoryInfos.AddRangeAsync(tvFAMCategoryInfos);
            await _context.SaveChangesAsync();
        }

        //Fill Edit TV FAM Category Info
        public async Task<EditTVFAMCategoryViewModel?> FillTVFAMCategoryViewModel(ulong tvFAMCategoryId)
        {
            return await _context.TVFAMCategories
                            .Include(p => p.TVFAMCategoryInfo)
                            .Where(p => p.Id == tvFAMCategoryId && !p.IsDelete).Select(p => new EditTVFAMCategoryViewModel()
                            {
                                Id = p.Id,
                                UniqueName = p.UniqueName,
                                ParentId = p.ParentId,
                                CurrentInfos = p.TVFAMCategoryInfo.AsQueryable().IgnoreQueryFilters().ToList(),
                            }).FirstOrDefaultAsync();
        }

        //Get Tv FAM Category By Tv FAM Category Id 
        public async Task<TVFAMCategory?> GetTVFAMCategoryById(ulong setvFAMCategoryId)
        {
            return await _context.TVFAMCategories.Include(p => p.TVFAMCategoryInfo)
                                    .FirstOrDefaultAsync(s => !s.IsDelete && s.Id == setvFAMCategoryId);
        }

        //Update TV FAM Category
        public void UpdateTVFAMCategory(TVFAMCategory tvFAMCategory)
        {
            _context.TVFAMCategories.Update(tvFAMCategory);
        }

        //Save Changes 
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        //Update TV FAM Category Info
        public void UpdateTVFAMCategoryInfo(TVFAMCategoryInfo tvFAMCategoryInfo)
        {
            _context.TVFAMCategoryInfos.Update(tvFAMCategoryInfo);
        }

        //Delete TV FAM Category Info
        public async Task DeleteTVFAMCategoryInfo(ulong tvFAMCategoryId)
        {
            var tvFAMCategoryInfo = await _context.TVFAMCategoryInfos.Where(p => p.TVFAMCategoryId == tvFAMCategoryId).IgnoreQueryFilters().ToListAsync();

            if (tvFAMCategoryInfo != null && tvFAMCategoryInfo.Any())
            {
                foreach (var item in tvFAMCategoryInfo)
                {
                    _context.TVFAMCategoryInfos.Remove(item);
                }
            }
        }

        //Get Childs Of TV FAM Category By Parent ID
        public async Task<List<TVFAMCategory>> GetChildTVFAMCategoryByParentId(ulong parentId)
        {
            return await _context.TVFAMCategories.Where(p => !p.IsDelete && p.ParentId == parentId).ToListAsync();
        }

        //Delete TVFAM Category And TVFAM Category Info
        public async Task DeleteServiceCategory(TVFAMCategory tvFAMCategory)
        {
            //Delete First Part Of Categories
            tvFAMCategory.IsDelete = true;
            _context.TVFAMCategories.Update(tvFAMCategory);

            //Delete First PartOf Category Info
            await DeleteTVFAMCategoryInfo(tvFAMCategory.Id);

            //Get Seconde Part Of Category Info
            var secondePartOfChild = await GetChildTVFAMCategoryByParentId(tvFAMCategory.Id);

            if (secondePartOfChild != null && secondePartOfChild.Any())
            {
                foreach (var item in secondePartOfChild)
                {
                    //Delete Seconde PartOf Category Info
                    item.IsDelete = true;
                    _context.TVFAMCategories.Update(item);

                    //Delete Seconde PartOf Category Info
                    await DeleteTVFAMCategoryInfo(item.Id);

                }
            }

            await _context.SaveChangesAsync();

        }

        #endregion

        #endregion

        #region TV FAM

        #endregion

        #endregion

        #region Radio FAM

        #region Category 



        #endregion

        #region Radio FAM

        #endregion

        #endregion
    }
}
