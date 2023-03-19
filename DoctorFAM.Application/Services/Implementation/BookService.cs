using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Books;
using DoctorFAM.Domain.ViewModels.Admin.Books;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.ViewModels.Admin.News;

namespace DoctorFAM.Application.Services.Implementation
{
    public class BookService : IBookService
    {
        #region Constructor

        private readonly DoctorFAMDbContext _context;
        private readonly IUserService _userService;

        public BookService(DoctorFAMDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        #endregion

        #region Mian Methods

        public async Task<bool> IsExistAnyBook()
        {
            return await _context.Book.AnyAsync(p => !p.IsDelete);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateBook(Book Book)
        {
            _context.Book.Update(Book);
        }

        public async Task<Book> GetBookByIdAsync(ulong BookId)
        {
            var Book = await _context.Book
                .FirstOrDefaultAsync(a => a.Id == BookId && !a.IsDelete);

            return Book;
        }

        #endregion

        #region Admin Side

        public async Task<FilterBookAdminSideViewModel> FilterBookAdminSideViewModel(FilterBookAdminSideViewModel filter)
        {
            var query = _context.Book
                .Where(a => !a.IsDelete)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State 

            #region Base On State (IsActive , IsDelete , ... )

            switch (filter.filterBookAdminSideState)
            {
                case FilterBookAdminSideState.All:
                    break;
                case FilterBookAdminSideState.IsActive:
                    query = query.Where(s => s.IsActive == true);
                    break;
                case FilterBookAdminSideState.NotActive:
                    query = query.Where(s => s.IsActive == false);
                    break;
            }

            #endregion

            #region Base On Ordering CreateDate

            switch (filter.filterBookAdminSideOrder)
            {
                case FilterBookAdminSideOrder.CreateDate_Des:
                    break;
                case FilterBookAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(s => s.CreateDate);
                    break;
            }

            #endregion

            #endregion



            await filter.Paging(query);

            return filter;
        }

        public async Task<CreateBookFromAdminPanelResponse> CreateBookFromAdminPanel(CreateBookAdminViewModel model, IFormFile Image)
        {
            #region Check Validation

            if (Image == null)
            {
                return CreateBookFromAdminPanelResponse.ImageNotUploaded;
            }

            if (string.IsNullOrEmpty(model.Writer))
            {
                return CreateBookFromAdminPanelResponse.WriterNotFound;
            }

            if (string.IsNullOrEmpty(model.AttachmentFileName)) return CreateBookFromAdminPanelResponse.BookFileNotFound;

            if (string.IsNullOrEmpty(model.Title))
            {
                return CreateBookFromAdminPanelResponse.TitleNotFound;
            }

            if (!Image.IsImage())
            {
                return CreateBookFromAdminPanelResponse.ImageNotFound;
            }

            #endregion

            #region Set Datas From ViewModel

            Book Book = new Book()
            {
                Title = model.Title.SanitizeText(),
                Introduction = model.Introduction.SanitizeText(),
                Writer = model.Writer.SanitizeText(),
                Translator = model.Translator.SanitizeText(),
                Publisher = model.Publisher.SanitizeText(),
                YearOfPublish = model.YearOfPublish.SanitizeText(),
                Price = model.Price,
                PagesNO = model.PagesNO,
                IsActive = model.IsActive,
                BookFile = model.AttachmentFileName
            };

            #endregion

            #region Books Image

            var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
            Image.AddImageToServer(imageName, PathTools.BooksImagePathServer, 400, 300, PathTools.BooksImagePathThumbServer);
            Book.Image = imageName;

            #endregion

            #region Add Books

            await _context.Book.AddAsync(Book);
            await _context.SaveChangesAsync();

            #endregion

            #region Short Key

            Book.ShortKey = Book.Id.ToString();
            UpdateBook(Book);
            await SaveChangesAsync();

            #endregion

            #region Books Tags

            if (!string.IsNullOrEmpty(model.BookTag))
            {
                var tags = model.BookTag.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new BookTag
                    {
                        BookId = Book.Id,
                        Title = item
                    };
                    await _context.BookTags.AddAsync(tag);
                }
                await SaveChangesAsync();
            }

            #endregion

            #region Selected Book Category

            BookSelectedCategory mainCategory = new BookSelectedCategory()
            {
                BookCategoryId = model.MainCategory,
                BookId = Book.Id
            };

            await _context.BookSelectedCategory.AddAsync(mainCategory);

            if (model.SubCategory != null && model.SubCategory != 0)
            {
                BookSelectedCategory subCategory = new BookSelectedCategory()
                {
                    BookCategoryId = model.SubCategory.Value,
                    BookId = Book.Id
                };

                await _context.BookSelectedCategory.AddAsync(subCategory);
            }

            await SaveChangesAsync();

            #endregion

            return CreateBookFromAdminPanelResponse.Success;
        }

        public async Task<EditBookAdminSideViewModel> FillEditBookAdminSideViewModel(Book Book)
        {
            #region Get List Of Book Selected Tags 

            var BookTag = await GetBookTagsByBookId(Book.Id);

            #endregion

            #region Create Instance From Return Model 

            EditBookAdminSideViewModel model = new EditBookAdminSideViewModel
            {
                Title = Book.Title,
                Introduction = Book.Introduction,
                Writer = Book.Writer,
                Translator = Book.Translator,
                Publisher = Book.Publisher,
                YearOfPublish = Book.YearOfPublish,
                PagesNO = Book.PagesNO,
                Price = Book.Price,
                AttachmentFileName = Book.BookFile,
                Image = Book.Image,
                IsActive = Book.IsActive,
                Id = Book.Id,
                BookTag = string.Join(",", BookTag.Select(p => p.Title).ToList())

            };

            #region Get Main Category 

            //var mainCategoryId = await _context.BookSelectedCategory
            // .Include(p => p.BookCategory)
            // .Where(p => !p.IsDelete && p.BookId == Book.Id && p.BookCategory.ParentId == null)
            // .Select(p => p.BookCategoryId)
            // .FirstOrDefaultAsync();

            //Get List OF Book Selected Category Ids 
            var bookSelectedCategoryIds = await _context.BookSelectedCategory
             .Where(p => !p.IsDelete && p.BookId == Book.Id)
             .Select(p => p.BookCategoryId).ToListAsync();

            //Create Instance
            List<BookCategory> bookCategories = new List<BookCategory>();

            if (bookSelectedCategoryIds != null && bookSelectedCategoryIds.Any())
            {
                BookCategory item = new BookCategory();

                foreach (var bookCatgeoryId in bookSelectedCategoryIds)
                {
                    item = await _context.BookCategories.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == bookCatgeoryId);
                    if (item is not null)
                    {
                        bookCategories.Add(item);
                    }
                }
            }

            if (bookCategories != null && bookCategories.Any())
            {
                if (bookCategories.Any(p => p.ParentId == null))
                {
                    model.MainCategory = bookCategories.FirstOrDefault(p => p.ParentId == null).Id;
                }

                if (bookCategories.Any(p => p.ParentId != null))
                {
                    model.SubCategory = bookCategories.FirstOrDefault(p => p.ParentId != null).Id;
                }
            }

            #endregion

            #endregion

            return model;
        }

        public async Task<EditBookFromAdminPanelResponse> EditBookFromAdminPanel(EditBookAdminSideViewModel model, IFormFile? Image)
        {
            #region Check Validation

            if (string.IsNullOrEmpty(model.Writer))
            {
                return EditBookFromAdminPanelResponse.WriterNotFound;
            }

            if (model.MainCategory == null || model.MainCategory == 0)
            {
                return EditBookFromAdminPanelResponse.MainCategoryNotFound;
            }

            if (Image != null && !Image.IsImage())
            {
                return EditBookFromAdminPanelResponse.ImageNotFound;
            }

            #endregion

            #region Get Book By Id

            var Book = await GetBookByIdAsync(model.Id);

            if (Book == null)
            {
                return EditBookFromAdminPanelResponse.BookFileNotFound;
            }

            #endregion

            #region Fill Properties

            Book.Title = model.Title.SanitizeText();
            Book.Writer = model.Writer.SanitizeText();
            Book.Publisher = model.Publisher.SanitizeText();
            Book.Translator = model.Translator.SanitizeText();
            Book.YearOfPublish = model.YearOfPublish.SanitizeText();
            Book.Price = model.Price;
            Book.PagesNO = model.PagesNO;
            Book.Introduction = model.Introduction.SanitizeText();
            Book.IsActive = model.IsActive;

            #endregion

            #region Book Image

            if (Image != null)
            {
                var imageName = Guid.NewGuid() + Path.GetExtension(Image.FileName);
                Image.AddImageToServer(imageName, PathTools.BooksImagePathServer, 400, 300, PathTools.BooksImagePathThumbServer);

                if (!string.IsNullOrEmpty(Book.Image))
                {
                    Book.Image.DeleteImage(PathTools.BooksImagePathServer, PathTools.BooksImagePathThumbServer);
                }

                Book.Image = imageName;
            }

            #endregion

            #region Attachment File 

            if (!string.IsNullOrEmpty(Book.BookFile) &&
                  !string.IsNullOrEmpty(model.AttachmentFileName) &&
                        model.AttachmentFileName != Book.BookFile)
            {
                Book.BookFile.DeleteFile(PathTools.BookAttachmentFilesServerPath);
            }

            if (string.IsNullOrEmpty(Book.BookFile) || Book.BookFile != model.AttachmentFileName)
            {
                Book.BookFile = model.AttachmentFileName;
            }

            #endregion

            #region Remove All Book Categories

            var BookCategories = await _context.BookSelectedCategory
                .Where(p => !p.IsDelete && p.BookId == model.Id)
                .ToListAsync();

            _context.RemoveRange(BookCategories);
            await SaveChangesAsync();

            #endregion

            #region Book Category

            BookSelectedCategory mainCategory = new BookSelectedCategory()
            {
                BookCategoryId = model.MainCategory,
                BookId = Book.Id
            };
            await _context.BookSelectedCategory.AddAsync(mainCategory);

            if (model.SubCategory != null && model.SubCategory != 0)
            {
                BookSelectedCategory subCategory = new BookSelectedCategory()
                {
                    BookCategoryId = model.SubCategory.Value,
                    BookId = Book.Id
                };
                await _context.BookSelectedCategory.AddAsync(subCategory);
            }

            await SaveChangesAsync();

            #endregion

            #region Book Tags

            var BookTags = await GetBookTagsByBookId(Book.Id);

            if (BookTags.Any())
            {
                _context.RemoveRange(BookTags);
                await SaveChangesAsync();
            }

            if (!string.IsNullOrEmpty(model.BookTag))
            {
                var tags = model.BookTag.Split(',').ToList();

                foreach (var item in tags)
                {
                    var tag = new BookTag
                    {
                        BookId = Book.Id,
                        Title = item
                    };
                    await _context.BookTags.AddAsync(tag);
                }
                await SaveChangesAsync();
            }

            #endregion

            UpdateBook(Book);
            await SaveChangesAsync();

            return EditBookFromAdminPanelResponse.Success;
        }

        #endregion

        #region Book Tags

        public async Task<bool> IsExistAnyTagForThisBook(ulong Id)
        {
            var tag = await _context.BookTags.AnyAsync(p => p.BookId == Id && !p.IsDelete);

            if (tag) return true;

            return false;
        }

        public async Task<List<BookTag>> GetBookTagsByBookId(ulong Id)
        {
            return await _context.BookTags.Where(p => p.BookId == Id && !p.IsDelete).ToListAsync();
        }

        public void RemoveBookTags(BookTag BookTag)
        {
            _context.BookTags.Remove(BookTag);
        }

        #endregion

        #region Book Category

        public async Task<FilterBookCategoryViewModel> FilterBookCategoryViewModel(FilterBookCategoryViewModel filter)
        {
            var query = _context.BookCategories
                .Where(a => a.IsDelete == false)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State 

            #region Base On State (IsActive , IsDelete , ... )

            switch (filter.filterBookCategoryAdminSideState)
            {
                case FilterBookCategoryAdminSideState.All:
                    break;
                case FilterBookCategoryAdminSideState.IsActive:
                    query = query.Where(s => s.IsActive == true);
                    break;
                case FilterBookCategoryAdminSideState.NotActive:
                    query = query.Where(s => s.IsActive == false);
                    break;
            }

            #endregion

            #region Base On Ordering CreateDate

            switch (filter.filterBookCatgeoryAdminSideOrder)
            {
                case FilterBookCatgeoryAdminSideOrder.CreateDate_Des:
                    break;
                case FilterBookCatgeoryAdminSideOrder.CreateDate_Asc:
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

        public async Task<bool> IsDuplicatedBookCategory(string UniqueName)
        {
            return await _context.BookCategories.AnyAsync(p => p.UniqueName == UniqueName && !p.IsDelete);
        }

        public async Task<CreateBookCategoryResult> AddMainBookCategory(CreateBookCategoryViewModel cat)
        {
            if (await IsDuplicatedBookCategory(cat.UniqueName))
            {
                return CreateBookCategoryResult.CategoryIsExist;
            }

            BookCategory category = new BookCategory()
            {
                Title = cat.Title.SanitizeText(),
                UniqueName = cat.UniqueName.SanitizeText(),
                IsActive = cat.IsActive,
                ParentId = cat.ParentId
            };

            await _context.BookCategories.AddAsync(category);
            await SaveChangesAsync();

            return CreateBookCategoryResult.success;
        }

        public async Task<EditBookCategoryViewModel> FillEditBookCategoryViewModel(BookCategory model)
        {
            EditBookCategoryViewModel cat = new EditBookCategoryViewModel()
            {
                UniqueName = model.UniqueName,
                Title = model.Title,
                ParentId = model.ParentId,
                BookCategoryId = model.Id,
                IsActive = model.IsActive,
            };

            return cat;
        }

        public async Task<BookCategory> GetBookCategoryById(ulong Id)
        {
            var category = await _context.BookCategories.FirstOrDefaultAsync(p => p.Id == Id && !p.IsDelete);

            return category;
        }

        public async Task<EditBookCategoryResult> EditBookCategoryResult(EditBookCategoryViewModel category, BookCategory Book)
        {
            if (category.Title != Book.Title && await IsDuplicatedBookCategory(category.Title))
            {
                return Domain.ViewModels.Admin.Books.EditBookCategoryResult.CategoryIsExist;
            }

            Book.Title = category.Title.SanitizeText();
            Book.UniqueName = category.UniqueName.SanitizeText();
            Book.IsActive = category.IsActive;

            _context.BookCategories.Update(Book);
            await _context.SaveChangesAsync();

            return Domain.ViewModels.Admin.Books.EditBookCategoryResult.success;
        }

        public async Task DeleteBookCategory(BookCategory cat)
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
                        _context.BookCategories.Update(item);
                    }
                }
            }

            #endregion

            _context.BookCategories.Update(cat);
            await SaveChangesAsync();
        }

        public async Task<List<BookCategory>> GetSubCategoriesOfMAinCategory(ulong MainCategoryId)
        {
            return await _context.BookCategories.Where(p => !p.IsDelete && p.ParentId.HasValue && p.ParentId == MainCategoryId).ToListAsync();
        }

        public async Task<List<SelectListViewModel>> GetAllMainCategories()
        {
            return await _context.BookCategories.Where(s => s.ParentId == null && !s.IsDelete && s.IsActive)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        public async Task<List<BookCategory>> GetAllParentCategories()
        {
            return await _context.BookCategories.Where(s => s.ParentId == null && !s.IsDelete && s.IsActive)
                               .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        public async Task<List<BookCategory>> GetLastestBookCategories(int countNumber)
        {
            return await _context.BookCategories.Where(p => !p.IsDelete && p.IsActive).OrderByDescending(p => p.CreateDate)
                                               .OrderByDescending(p => p.CreateDate).Take(countNumber).ToListAsync();
        }

        public async Task<bool> DeleteBookFromAdminPanel(ulong BookId)
        {
            var article = await GetBookByIdAsync(BookId);

            if (article == null || article.IsDelete)
            {
                return false;
            }

            article.IsDelete = true;

            UpdateBook(article);
            await SaveChangesAsync();

            return true;
        }

        public async Task<List<SelectListViewModel>> GetCategoriesChildrent(ulong MainCategoryId)
        {
            return await _context.BookCategories.Where(s => s.ParentId.HasValue && s.ParentId.Value == MainCategoryId && !s.IsDelete && s.IsActive)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Id,
                    Title = s.Title
                }).ToListAsync();
        }

        #endregion

        #region Site Side 

        public async Task<List<Book>?> LastestBookForShowOnLandingPage()
        {

            return await _context.Book.Where(p => !p.IsDelete && p.IsActive)
                                .OrderByDescending(p => p.CreateDate).Take(12).ToListAsync();
        }

        #endregion
    }
}
