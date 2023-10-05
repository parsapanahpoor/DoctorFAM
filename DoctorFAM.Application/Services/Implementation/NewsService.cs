using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoctorFAM.Domain.Entities.News;
using DoctorFAM.Domain.ViewModels.Admin.News;


namespace DoctorFAM.Application.Services.Implementation
{
    public class NewsService : DoctorFAM.Application.Services.Interfaces.INewsService
    {
        #region Constructor

        private readonly DoctorFAMDbContext _context;
        private readonly IUserService _userService;

        public NewsService(DoctorFAMDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        #endregion

        #region Mian Methods

        public async Task<bool> IsExistAnyNews()
        {
            return await _context.News.AnyAsync(p => !p.IsDelete);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateNews(News News)
        {
            _context.News.Update(News);
        }

        public async Task<News> GetNewsByIdAsync(ulong NewsId)
        {
            var News = await _context.News
                .FirstOrDefaultAsync(a => a.Id == NewsId && !a.IsDelete);

            return News;
        }

        #endregion

        #region Admin Side

        public async Task<FilterNewsAdminSideViewModel> FilterNewsAdminSideViewModel(FilterNewsAdminSideViewModel filter)
        {
            var query = _context.News
                .Where(a => !a.IsDelete)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State 

            #region Base On State (IsActive , IsDelete , ... )

            switch (filter.filterNewsAdminSideState)
            {
                case FilterNewsAdminSideState.All:
                    break;
                case FilterNewsAdminSideState.IsActive:
                    query = query.Where(s => s.IsActive == true);
                    break;
                case FilterNewsAdminSideState.NotActive:
                    query = query.Where(s => s.IsActive == false);
                    break;
            }

            #endregion

            #region Base On Ordering CreateDate

            switch (filter.filterNewsAdminSideOrder)
            {
                case FilterNewsAdminSideOrder.CreateDate_Des:
                    break;
                case FilterNewsAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(s => s.CreateDate);
                    break;
            }

            #endregion

            #endregion

            #region Filter By Properties

            if (!string.IsNullOrEmpty(filter.Title))
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));

            if (filter.CanInsertComment == true)
                query = query.Where(s => s.CanInsertComment == true);

            if (filter.CanInsertComment == false)
                query = query.Where(s => s.CanInsertComment == false);

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<CreateNewsFromAdminPanelResponse> CreateNewsFromAdminPanel(CreateNewsAdminViewModel model, IFormFile NewsImage)
        {
            #region Check Validation

            if (NewsImage == null)
            {
                return CreateNewsFromAdminPanelResponse.ImageNotUploaded;
            }

            if (string.IsNullOrEmpty(model.Description))
            {
                return CreateNewsFromAdminPanelResponse.DescriptionNotFound;
            }

            if (model.MainCategory == null || model.MainCategory == 0)
            {
                return CreateNewsFromAdminPanelResponse.MainCategoryNotFound;
            }

            if (!NewsImage.IsImage())
            {
                return CreateNewsFromAdminPanelResponse.ImageNotFound;
            }

            #endregion

            #region Set Datas From ViewModel

            News News = new News()
            {
                Title = model.Title.SanitizeText(),
                Description = model.Description.SanitizeText(),
                ShortDescription = model.ShortDescription.SanitizeText(),
                IsActive = model.IsActive,
                CanInsertComment = model.CanInsertComment,
                URL = model.URL.SanitizeText()
            };

            #endregion

            #region News Image

            var imageName = Guid.NewGuid() + Path.GetExtension(NewsImage.FileName);
            NewsImage.AddImageToServer(imageName, PathTools.NewsPathServer, 400, 300, PathTools.NewsPathThumbServer);
            News.Image = imageName;

            #endregion

            #region Add News

            await _context.News.AddAsync(News);
            await _context.SaveChangesAsync();

            #endregion

            #region Short Key

            News.ShortKey = News.Id.ToString();
            UpdateNews(News);
            await SaveChangesAsync();

            #endregion

            #region News Tags

            if (!string.IsNullOrEmpty(model.NewsTag))
            {
                var tags = model.NewsTag.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new NewsTag
                    {
                        NewsId = News.Id,
                        Title = item
                    };
                    await _context.NewsTags.AddAsync(tag);
                }
                await SaveChangesAsync();
            }

            #endregion

            #region Selected News Category

            NewsSelectedCategory mainCategory = new NewsSelectedCategory()
            {
                NewsCategoryId = model.MainCategory,
                NewsId = News.Id
            };

            await _context.NewsSelectedCategory.AddAsync(mainCategory);

            if (model.SubCategory != null && model.SubCategory != 0)
            {
                NewsSelectedCategory subCategory = new NewsSelectedCategory()
                {
                    NewsCategoryId = model.SubCategory.Value,
                    NewsId = News.Id
                };

                await _context.NewsSelectedCategory.AddAsync(subCategory);
            }

            await SaveChangesAsync();

            #endregion

            return CreateNewsFromAdminPanelResponse.Success;
        }

        public async Task<EditNewsAdminSideViewModel> FillEditNewsAdminSideViewModel(News News)
        {
            var mainCategoryId = await _context.NewsSelectedCategory
                .Include(p => p.NewsCategory)
                .Where(p => !p.IsDelete && p.NewsId == News.Id && p.NewsCategory.ParentId == null)
                .Select(p => p.NewsCategoryId)
                .FirstOrDefaultAsync();

            var subCategory = await _context.NewsSelectedCategory
                .Include(p => p.NewsCategory)
                .Where(p => !p.IsDelete && p.NewsId == News.Id && p.NewsCategory.ParentId != null)
                .Select(p => p.NewsCategoryId)
                .FirstOrDefaultAsync();

            var NewsTag = await GetNewsTagsByNewsId(News.Id);

            EditNewsAdminSideViewModel model = new EditNewsAdminSideViewModel
            {
                Title = News.Title,
                ShortDescription = News.ShortDescription,
                Description = News.Description,
                imagename = News.Image,
                IsActive = News.IsActive,
                CanInsertComment = News.CanInsertComment,
                Id = News.Id,
                MainCategory = mainCategoryId,
                SubCategory = subCategory,
                NewsTag = string.Join(",", NewsTag.Select(p => p.Title).ToList()),
                URL = News.URL.SanitizeText()
            };

            return model;
        }

        public async Task<EditNewsFromAdminPanelResponse> EditNewsFromAdminPanel(EditNewsAdminSideViewModel model, IFormFile NewsImage)
        {
            #region Check Validation

            if (string.IsNullOrEmpty(model.Description))
            {
                return EditNewsFromAdminPanelResponse.DescriptionNotFound;
            }

            if (model.MainCategory == null || model.MainCategory == 0)
            {
                return EditNewsFromAdminPanelResponse.MainCategoryNotFound;
            }

            if (NewsImage != null && !NewsImage.IsImage())
            {
                return EditNewsFromAdminPanelResponse.ImageNotFound;
            }

            var News = await GetNewsByIdAsync(model.Id);

            if (News == null)
            {
                return EditNewsFromAdminPanelResponse.NewsNotFound;
            }

            #endregion

            #region Fill Properties

            News.Title = model.Title.SanitizeText();
            News.ShortDescription = model.ShortDescription.SanitizeText();
            News.Description = model.Description.SanitizeText();
            News.IsActive = model.IsActive;
            News.CanInsertComment = model.CanInsertComment;
            News.URL = model.URL;

            #endregion

            #region News Image

            if (NewsImage != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(NewsImage.FileName);
                NewsImage.AddImageToServer(imageName, PathTools.NewsPathServer, 400, 300, PathTools.NewsPathThumbServer);

                if (!string.IsNullOrEmpty(News.Image))
                {
                    News.Image.DeleteImage(PathTools.NewsPathServer, PathTools.NewsPathThumbServer);
                }

                News.Image = imageName;
            }

            #endregion

            #region Remove All News Categories

            var NewsCategories = await _context.NewsSelectedCategory
                .Where(p => !p.IsDelete && p.NewsId == model.Id)
                .ToListAsync();

            _context.RemoveRange(NewsCategories);
            await SaveChangesAsync();

            #endregion

            #region News Category

            NewsSelectedCategory mainCategory = new NewsSelectedCategory()
            {
                NewsCategoryId = model.MainCategory,
                NewsId = News.Id
            };
            await _context.NewsSelectedCategory.AddAsync(mainCategory);

            if (model.SubCategory != null && model.SubCategory != 0)
            {
                NewsSelectedCategory subCategory = new NewsSelectedCategory()
                {
                    NewsCategoryId = model.SubCategory.Value,
                    NewsId = News.Id
                };
                await _context.NewsSelectedCategory.AddAsync(subCategory);
            }

            await SaveChangesAsync();

            #endregion

            #region News Tags

            var NewsTags = await GetNewsTagsByNewsId(News.Id);

            if (NewsTags.Any())
            {
                _context.RemoveRange(NewsTags);
                await SaveChangesAsync();
            }

            if (!string.IsNullOrEmpty(model.NewsTag))
            {
                var tags = model.NewsTag.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new NewsTag
                    {
                        NewsId = News.Id,
                        Title = item
                    };
                    await _context.NewsTags.AddAsync(tag);
                }
                await SaveChangesAsync();
            }

            #endregion

            UpdateNews(News);
            await SaveChangesAsync();

            return EditNewsFromAdminPanelResponse.Success;
        }

        #endregion

        #region News Tags

        public async Task<bool> IsExistAnyTagForThisNews(ulong Id)
        {
            var tag = await _context.NewsTags.AnyAsync(p => p.NewsId == Id && !p.IsDelete);

            if (tag) return true;

            return false;
        }

        public async Task<List<NewsTag>> GetNewsTagsByNewsId(ulong Id)
        {
            return await _context.NewsTags.Where(p => p.NewsId == Id && !p.IsDelete).ToListAsync();
        }

        public void RemoveNewsTags(NewsTag NewsTag)
        {
            _context.NewsTags.Remove(NewsTag);
        }

        #endregion

        #region News Category

        public async Task<FilterNewsCategoryViewModel> FilterNewsCategoryViewModel(FilterNewsCategoryViewModel filter)
        {
            var query = _context.NewsCategories
                .Where(a => a.IsDelete == false)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State 

            #region Base On State (IsActive , IsDelete , ... )

            switch (filter.filterNewsCategoryAdminSideState)
            {
                case FilterNewsCategoryAdminSideState.All:
                    break;
                case FilterNewsCategoryAdminSideState.IsActive:
                    query = query.Where(s => s.IsActive == true);
                    break;
                case FilterNewsCategoryAdminSideState.NotActive:
                    query = query.Where(s => s.IsActive == false);
                    break;
            }

            #endregion

            #region Base On Ordering CreateDate

            switch (filter.filterNewsCatgeoryAdminSideOrder)
            {
                case FilterNewsCatgeoryAdminSideOrder.CreateDate_Des:
                    break;
                case FilterNewsCatgeoryAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(s => s.CreateDate);
                    break;
            }

            #endregion

            #endregion

            #region Filter By Properties

            if (!string.IsNullOrEmpty(filter.Title))
                query = query.Where(s => EF.Functions.Like(s.Title, $"%{filter.Title}%"));

            if (!string.IsNullOrEmpty(filter.UniqueName))
                query = query.Where(s => EF.Functions.Like(s.UniqueName, $"%{filter.UniqueName}%"));

            if (filter.ParentId != null)
            {
                query = query.Where(p => p.ParentId == filter.ParentId);
            }

            if (filter.ParentId == null)
            {
                query = query.Where(p => p.ParentId == null);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<bool> IsDuplicatedNewsCategory(string UniqueName)
        {
            return await _context.NewsCategories.AnyAsync(p => p.UniqueName == UniqueName && !p.IsDelete);
        }

        public async Task<CreateNewsCategoryResult> AddMainNewsCategory(CreateNewsCategoryViewModel cat)
        {
            if (await IsDuplicatedNewsCategory(cat.UniqueName))
            {
                return CreateNewsCategoryResult.CategoryIsExist;
            }

            NewsCategory category = new NewsCategory()
            {
                Title = cat.Title.SanitizeText(),
                UniqueName = cat.UniqueName.SanitizeText(),
                IsActive = cat.IsActive,
                ParentId = cat.ParentId
            };

            await _context.NewsCategories.AddAsync(category);
            await SaveChangesAsync();

            return CreateNewsCategoryResult.success;
        }

        public async Task<EditNewsCategoryViewModel> FillEditNewsCategoryViewModel(NewsCategory model)
        {
            EditNewsCategoryViewModel cat = new EditNewsCategoryViewModel()
            {
                UniqueName = model.UniqueName,
                Title = model.Title,
                ParentId = model.ParentId,
                NewsCategoryId = model.Id,
                IsActive = model.IsActive,
            };

            return cat;
        }

        public async Task<NewsCategory> GetNewsCategoryById(ulong Id)
        {
            var category = await _context.NewsCategories.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);

            return category;
        }

        public async Task<EditNewsCategoryResult> EditNewsCategoryResult(EditNewsCategoryViewModel category, NewsCategory News)
        {
            if (category.UniqueName != News.UniqueName && await IsDuplicatedNewsCategory(category.UniqueName))
            {
                return Domain.ViewModels.Admin.News.EditNewsCategoryResult.CategoryIsExist;
            }

            News.Title = category.Title.SanitizeText();
            News.UniqueName = category.UniqueName.SanitizeText();
            News.IsActive = category.IsActive;

            _context.NewsCategories.Update(News);
            await _context.SaveChangesAsync();

            return Domain.ViewModels.Admin.News.EditNewsCategoryResult.success;
        }

        public async Task DeleteNewsCategory(NewsCategory cat)
        {
            cat.IsDelete = true;

            #region This Part For Main Categpries

            if (cat.ParentId == null)
            {
                var subCategories = await GetSubCategoriesOfMAinCategory(cat.Id);
                if (subCategories.Any())
                {
                    foreach (var item in subCategories)
                    {
                        item.IsDelete = true;
                        _context.NewsCategories.Update(item);
                    }
                }
            }

            #endregion

            _context.NewsCategories.Update(cat);
            await SaveChangesAsync();
        }

        public async Task<List<NewsCategory>> GetSubCategoriesOfMAinCategory(ulong MainCategoryId)
        {
            return await _context.NewsCategories.Where(p => !p.IsDelete && p.ParentId.HasValue && p.ParentId == MainCategoryId).ToListAsync();
        }

        public async Task<List<SelectListViewModel>> GetAllMainCategories()
        {
            return await _context.NewsCategories.Where(s => s.ParentId == null && !s.IsDelete && s.IsActive)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        public async Task<List<SelectListViewModel>> GetCategoriesChildrent(ulong MainCategoryId)
        {
            return await _context.NewsCategories.Where(s => s.ParentId.HasValue && s.ParentId.Value == MainCategoryId && !s.IsDelete && s.IsActive)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        public async Task<List<NewsCategory>> GetAllParentCategories()
        {
            return await _context.NewsCategories.Where(s => s.ParentId == null && !s.IsDelete && s.IsActive)
                               .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        public async Task<List<NewsCategory>> GetLastestNewsCategories(int countNumber)
        {
            return await _context.NewsCategories.Where(p => !p.IsDelete && p.IsActive).OrderByDescending(p => p.CreateDate)
                                               .OrderByDescending(p => p.CreateDate).Take(countNumber).ToListAsync();
        }

        public async Task<bool> DeleteNewsFromAdminPanel(ulong NewsId)
        {
            var article = await GetNewsByIdAsync(NewsId);

            if (article == null || article.IsDelete)
            {
                return false;
            }

            article.IsDelete = true;

            UpdateNews(article);
            await SaveChangesAsync();

            return true;
        }

        #endregion

        #region Site Side 

        public async Task<List<News>?> LastestNewForShowOnLandingPage()
        {
            return await _context.News.Where(p => !p.IsDelete && p.IsActive)
                                .OrderByDescending(p=> p.CreateDate).Take(3).ToListAsync();
        }

        public async Task<List<News>?> LastestNewForShowOnSite()
        {
            return await _context.News.Where(p => !p.IsDelete && p.IsActive)
                                .OrderByDescending(p => p.CreateDate).ToListAsync();
        }
        #endregion
    }
}
