using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.RadioFAM.Category;
using DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HealthInformationRepository : IHealthInformationRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        private readonly IOrganizationRepository _organizationRepository;

        public HealthInformationRepository(DoctorFAMDbContext context , IOrganizationRepository organizationRepository)
        {
            _context = context;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region TV FAM

        #region Category 

        #region Admin Side 

        //Create TV FAM Selected Catgeories
        public async Task CreateTVFAMSelectedCatgeories(TVFAMSelectedCategory tVFAM)
        {
            await _context.TVFAMSelectedCategories.AddAsync(tVFAM);
        }

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

        //List OF TV FAM Category 
        public async Task<List<TVFAMCategoryViewModel>> ListOFTVFAMCategory()
        {
            return await _context.TVFAMCategoryInfos
               .Include(a => a.TVFAMCategory)
               .ThenInclude(p => p.Parent)
               .Where(p => !p.IsDelete)
                .Select(p => new TVFAMCategoryViewModel()
                {
                    CategoryName = p.Title,
                    ParentId = p.TVFAMCategory.ParentId,
                    CatgeoryId = p.TVFAMCategoryId
                }).ToListAsync();
        }

        #endregion

        #endregion

        #region TV FAM

        #region Admin Side 

        //Create Health Information 
        public async Task CreateTVFAMVideo(HealthInformation healthInformation)
        {
            await _context.HealthInformation.AddAsync(healthInformation);
            await _context.SaveChangesAsync();
        }

        //Create Health Information Tags 
        public async Task CreateHealthInformationTags(HealthInformationTag tag)
        {
            await _context.HealthInformationTags.AddAsync(tag);
        }

        //Filter Health Information (Video FAM) From Admin Side 
        public async Task<List<HealthInformation>> FilterTVFAMAdminSide()
        {
            return await _context.HealthInformation.Include(p => p.User)
                .Where(p => !p.IsDelete && p.HealthInformationType == Domain.Enums.HealtInformation.HealthInformationType.TVFAM)
                .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get Health Information By Id
        public async Task<HealthInformation?> GetHealthInformationById(ulong healthId)
        {
            return await _context.HealthInformation.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == healthId);
        }

        //Get Healt Informations Tags
        public async Task<List<HealthInformationTag>> GetHealtInformationsTags(ulong Id)
        {
            return await _context.HealthInformationTags.Where(p => !p.IsDelete && p.HealthInformationId == Id).ToListAsync();
        }

        //Get Health Information Selected Categories
        public async Task<List<ulong>> GetHealthInformationSelectedCategories(ulong healthId)
        {
            return await _context.TVFAMSelectedCategories.Where(p => !p.IsDelete && p.HealthInformationId == healthId)
                            .Select(p => p.TVFAMCategoryId).ToListAsync(); 
        }

        //Remove Health Information Tags 
        public async Task RemoveHealthInformationTags(List<HealthInformationTag> tags)
        {
            _context.HealthInformationTags.RemoveRange(tags);
            await _context.SaveChangesAsync(); 
        }

        //Remove Health Information Selected Category
        public async Task RemoveHealthInformationSelectedCategory(List<TVFAMSelectedCategory> tvFAMCategory)
        {
             _context.TVFAMSelectedCategories.RemoveRange(tvFAMCategory);
            await _context.SaveChangesAsync();
        }

        //Remove Health Information Selected Category
        public async Task RemoveHealthInformationSelectedCategory(TVFAMSelectedCategory tvFAMCategory)
        {
             _context.TVFAMSelectedCategories.Remove(tvFAMCategory);
            await _context.SaveChangesAsync();
        }

        //Get List Of Health Information Selected Categories
        public async Task<List<TVFAMSelectedCategory>> GetListOfHealthInformationSelectedCategories(ulong healthId)
        {
            return await _context.TVFAMSelectedCategories.Where(p => !p.IsDelete && p.HealthInformationId == healthId).ToListAsync();
        }

        //Update TV FAM 
        public async Task UpdateTVFAM(HealthInformation model)
        {
            _context.HealthInformation.Update(model);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Doctor Panel 

        //Filter Health Information (Video FAM) From Doctor Panel Side  
        public async Task<List<HealthInformation>> FilterTVFAMDoctorPanelSide(ulong ownerId)
        {
            return await _context.HealthInformation.Include(p => p.User)
                .Where(p => !p.IsDelete && p.HealthInformationType == Domain.Enums.HealtInformation.HealthInformationType.TVFAM
                        && p.OwnerId.Value == ownerId)
                .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        #endregion

        #endregion

        #endregion

        #region Radio FAM

        #region Category 

        #region Admin Side 

        //List Of Radio FAM Category 
        public async Task<FilterRadioFAMCategoryViewModel> FilterRadioFAMCategory(FilterRadioFAMCategoryViewModel filter)
        {
            var query = _context.RadioFAMCategoryInfos
               .Include(a => a.RadioFAMCategory)
               .ThenInclude(p => p.Parent)
               .OrderByDescending(s => s.CreateDate)
               .AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(filter.UniqueName))
            {
                query = query.Where(s => EF.Functions.Like(s.RadioFAMCategory.UniqueName, $"%{filter.UniqueName}%"));
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));
            }

            if (filter.ParentId != null)
            {
                query = query.Where(a => a.RadioFAMCategory.ParentId == filter.ParentId);
                filter.ParentRadioFAMCategory = await _context.RadioFAMCategories.FirstOrDefaultAsync(a => a.Id == filter.ParentId);
            }
            else
            {
                query = query.Where(a => a.RadioFAMCategory.ParentId == null);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Get Health Information Category By Health Information Category Id 
        public async Task<RadioFAMCategory?> GetRadioFAMCategoryByHealthInformationCategoryId(ulong RadioFAMCategoryId)
        {
            return await _context.RadioFAMCategories.Include(p => p.RadioFAMCategoryInfos)
                                    .FirstOrDefaultAsync(s => !s.IsDelete && s.Id == RadioFAMCategoryId);
        }

        //Is Exist Radio FAM Category By Unique Name
        public async Task<bool> IsExistRadioFAMCategoryByUniqueName(string uniqueName)
        {
            return await _context.RadioFAMCategories.AnyAsync(p => p.UniqueName == uniqueName && !p.IsDelete);
        }

        //Is Exist Any Radio FAM Category By Id 
        public async Task<bool> IsExistRadioFAMCategoryById(ulong RadioFAMCategoryId)
        {
            return await _context.RadioFAMCategories.AnyAsync(p => p.Id == RadioFAMCategoryId && !p.IsDelete);
        }

        //Add Radio FAM Categories
        public async Task<ulong> AddRadioFAMCategory(RadioFAMCategory RadioFAMCategory)
        {
            #region Add Radio FAM Categroy

            await _context.RadioFAMCategories.AddAsync(RadioFAMCategory);
            await _context.SaveChangesAsync();

            #endregion

            return RadioFAMCategory.Id;
        }

        //Add Radio FAM Category Info
        public async Task AddRadioFAMCategoryInfo(List<RadioFAMCategoryInfo> RadioFAMCategoryInfos)
        {
            await _context.RadioFAMCategoryInfos.AddRangeAsync(RadioFAMCategoryInfos);
            await _context.SaveChangesAsync();
        }

        //Fill Edit Radio FAM Category Info
        public async Task<EditRadioFAMCategoryViewModel?> FillRadioFAMCategoryViewModel(ulong RadioFAMCategoryId)
        {
            return await _context.RadioFAMCategories
                            .Include(p => p.RadioFAMCategoryInfos)
                            .Where(p => p.Id == RadioFAMCategoryId && !p.IsDelete).Select(p => new EditRadioFAMCategoryViewModel()
                            {
                                Id = p.Id,
                                UniqueName = p.UniqueName,
                                ParentId = p.ParentId,
                                CurrentInfos = p.RadioFAMCategoryInfos.AsQueryable().IgnoreQueryFilters().ToList(),
                            }).FirstOrDefaultAsync();
        }

        //Get Radio FAM Category By Radio FAM Category Id 
        public async Task<RadioFAMCategory?> GetRadioFAMCategoryById(ulong seRadioFAMCategoryId)
        {
            return await _context.RadioFAMCategories.Include(p => p.RadioFAMCategoryInfos)
                                    .FirstOrDefaultAsync(s => !s.IsDelete && s.Id == seRadioFAMCategoryId);
        }

        //Update Radio FAM Category
        public void UpdateRadioFAMCategory(RadioFAMCategory RadioFAMCategory)
        {
            _context.RadioFAMCategories.Update(RadioFAMCategory);
        }

        //Update Radio FAM Category Info
        public void UpdateRadioFAMCategoryInfo(RadioFAMCategoryInfo RadioFAMCategoryInfo)
        {
            _context.RadioFAMCategoryInfos.Update(RadioFAMCategoryInfo);
        }

        //Delete Radio FAM Category Info
        public async Task DeleteRadioFAMCategoryInfo(ulong RadioFAMCategoryId)
        {
            var RadioFAMCategoryInfo = await _context.RadioFAMCategoryInfos.Where(p => p.RadioFAMCategoryId == RadioFAMCategoryId).IgnoreQueryFilters().ToListAsync();

            if (RadioFAMCategoryInfo != null && RadioFAMCategoryInfo.Any())
            {
                foreach (var item in RadioFAMCategoryInfo)
                {
                    _context.RadioFAMCategoryInfos.Remove(item);
                }
            }
        }

        //Get Childs Of Radio FAM Category By Parent ID
        public async Task<List<RadioFAMCategory>> GetChildRadioFAMCategoryByParentId(ulong parentId)
        {
            return await _context.RadioFAMCategories.Where(p => !p.IsDelete && p.ParentId == parentId).ToListAsync();
        }

        //Delete RadioFAM Category And RadioFAM Category Info
        public async Task DeleteServiceCategory(RadioFAMCategory RadioFAMCategory)
        {
            //Delete First Part Of Categories
            RadioFAMCategory.IsDelete = true;
            _context.RadioFAMCategories.Update(RadioFAMCategory);

            //Delete First PartOf Category Info
            await DeleteRadioFAMCategoryInfo(RadioFAMCategory.Id);

            //Get Seconde Part Of Category Info
            var secondePartOfChild = await GetChildRadioFAMCategoryByParentId(RadioFAMCategory.Id);

            if (secondePartOfChild != null && secondePartOfChild.Any())
            {
                foreach (var item in secondePartOfChild)
                {
                    //Delete Seconde PartOf Category Info
                    item.IsDelete = true;
                    _context.RadioFAMCategories.Update(item);

                    //Delete Seconde PartOf Category Info
                    await DeleteRadioFAMCategoryInfo(item.Id);

                }
            }

            await _context.SaveChangesAsync();

        }

        #endregion

        #endregion

        #region Radio FAM

        #endregion

        #endregion
    }
}
