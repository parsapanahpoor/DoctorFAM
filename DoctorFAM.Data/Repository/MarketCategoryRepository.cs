using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.MarketCategory;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.MarketCategory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class MarketCategoryRepository : IMarketCategoryRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public MarketCategoryRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin Side

        public async Task<FilterMarketCategoryViewModel> FilterMarketCategory(FilterMarketCategoryViewModel filter)
        {
            var query = _context.CategoryInfos
                .Include(a => a.Category)
                .ThenInclude(p => p.Parent)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.MarketCategoryStatus)
            {
                case MarketCategoryStatus.All:
                    break;
                case MarketCategoryStatus.NotDeleted:
                    query = query.Where(a => !a.Category.IsDelete);
                    break;
                case MarketCategoryStatus.Deleted:
                    query = query.Where(a => a.Category.IsDelete);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UniqueName))
            {
                query = query.Where(s => EF.Functions.Like(s.Category.UniqueName, $"%{filter.UniqueName}%"));
            }

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));
            }

            if (filter.ParentId != null)
            {
                query = query.Where(a => a.Category.ParentId == filter.ParentId);
                filter.ParentMarketCategory = await _context.Category.FirstOrDefaultAsync(a => a.Id == filter.ParentId);
            }

            else
            {
                query = query.Where(a => a.Category.ParentId == null);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<Category?> GetMarketCategoryById(ulong categoryId)
        {
            return await _context.Category.Include(p => p.CategoryInfo).FirstOrDefaultAsync(s => !s.IsDelete && s.Id == categoryId);
        }

        public async Task<bool> IsExistMarketCategoryByUniqueName(string uniqueName)
        {
            return await _context.Category.AnyAsync(p => p.UniqueName == uniqueName && !p.IsDelete);
        }

        public async Task<bool> IsExistMarketCategoryBycategoryId(ulong marketCategoryId)
        {
            return await _context.Category.AnyAsync(p => p.Id == marketCategoryId && !p.IsDelete);
        }

        public async Task<ulong> AddMarketCategory(Category category)
        {
            #region Add Category

            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();

            #endregion

            return category.Id;
        }

        public async Task AddMarketCategoryInfo(List<CategoryInfo> categoryInfo)
        {
            await _context.CategoryInfos.AddRangeAsync(categoryInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<EditMarketCategoryViewModel?> FillEditMarketCategoryViewModel(ulong marketCategoryId)
        {
            return await _context.Category
                            .Include(p => p.CategoryInfo)
                            .Where(p => p.Id == marketCategoryId && !p.IsDelete).Select(p => new EditMarketCategoryViewModel()
                            {
                                Id = p.Id,
                                UniqueName = p.UniqueName,
                                ParentId = p.ParentId,
                                CurrentInfos = p.CategoryInfo.AsQueryable().IgnoreQueryFilters().ToList()
                            }).FirstOrDefaultAsync();
        }

        public void UpdateMarketCategory(Category category)
        {
            _context.Category.Update(category);
        }

        public void UpdateMarketCategoryInfo(CategoryInfo categoryInfo)
        {
            _context.CategoryInfos.Update(categoryInfo);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMarketCategoryInfo(ulong categoryId)
        {
            var categoryInfo = await _context.CategoryInfos.Where(p => p.CategoryId == categoryId).IgnoreQueryFilters().ToListAsync();

            if (categoryInfo != null && categoryInfo.Any())
            {
                foreach (var item in categoryInfo)
                {
                    _context.CategoryInfos.Remove(item);
                }
            }
        }

        public async Task<List<Category>> GetChildMarketCategoryByParentId(ulong parentId)
        {
            return await _context.Category.Where(p => !p.IsDelete && p.ParentId == parentId).ToListAsync();
        }

        public async Task DeleteMArketCategory(Category category)
        {

            //Delete First PartOf Categorys
            category.IsDelete = true;
            _context.Category.Update(category);

            //Delete First PartOf CAtegoryInfo
            await DeleteMarketCategoryInfo(category.Id);

            //Get Seconde PartOf Category
            var secondePartOfChild = await GetChildMarketCategoryByParentId(category.Id);

            if (secondePartOfChild != null && secondePartOfChild.Any())
            {
                foreach (var item in secondePartOfChild)
                {
                    //Delete Seconde PartOf Category
                    item.IsDelete = true;
                    _context.Category.Update(item);

                    //Delete Seconde PartOf LocationInfo
                    await DeleteMarketCategoryInfo(item.Id);

                    //Get third PartOf Category
                    var thirdPartOfChild = await GetChildMarketCategoryByParentId(item.Id);

                    //Delete third PartOf CategoryInfo
                    if (thirdPartOfChild != null && thirdPartOfChild.Any())
                    {
                        foreach (var item2 in thirdPartOfChild)
                        {
                            //Delete third PartOf Category
                            item2.IsDelete = true;
                            _context.Category.Update(item2);

                            //Delete third PartOf CategoryInfo
                            await DeleteMarketCategoryInfo(item2.Id);

                            //Get fourth PartOf Category
                            var fourthPartOfChild = await GetChildMarketCategoryByParentId(item2.Id);

                            //Delete fourth PartOf CategoryInfo
                            if (fourthPartOfChild != null && fourthPartOfChild.Any())
                            {
                                foreach (var item3 in fourthPartOfChild)
                                {
                                    //Delete fourth PartOf Category
                                    item3.IsDelete = true;
                                    _context.Category.Update(item3);

                                    //Delete fourth PartOf CategoryInfo
                                    await DeleteMarketCategoryInfo(item3.Id);

                                    //Get fifth PartOf Category
                                    var fifthPartOfChild = await GetChildMarketCategoryByParentId(item3.Id);

                                    //Delete fifth PartOf CategoryInfo
                                    if (fifthPartOfChild != null && fifthPartOfChild.Any())
                                    {
                                        foreach (var item4 in fifthPartOfChild)
                                        {
                                            //Delete fifth PartOf Category
                                            item4.IsDelete = true;
                                            _context.Category.Update(item4);

                                            //Delete fifth PartOf CategoryInfo
                                            await DeleteMarketCategoryInfo(item4.Id);

                                            //Get sixth PartOf Category
                                            var sixthPartOfChild = await GetChildMarketCategoryByParentId(item4.Id);

                                            //Delete fifth PartOf CategoryInfo
                                            if (sixthPartOfChild != null && sixthPartOfChild.Any())
                                            {
                                                foreach (var item5 in sixthPartOfChild)
                                                {
                                                    //Delete sixth PartOf Category
                                                    item5.IsDelete = true;
                                                    _context.Category.Update(item4);

                                                    //Delete sixth PartOf CategoryInfo
                                                    await DeleteMarketCategoryInfo(item5.Id);


                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }

            await _context.SaveChangesAsync();

        }


        #endregion
    }
}
