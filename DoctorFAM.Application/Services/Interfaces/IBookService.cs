using DoctorFAM.Domain.ViewModels.Admin.Books;
using DoctorFAM.Domain.Entities.Books;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IBookService
    {
        #region Main Methodes

        Task SaveChangesAsync();

        void UpdateBook(Book Book);

        Task<Book> GetBookByIdAsync(ulong BookId);

        Task<bool> IsExistAnyBook();

        #endregion

        #region Admin Side

        Task<FilterBookAdminSideViewModel> FilterBookAdminSideViewModel(FilterBookAdminSideViewModel filter);

        Task<CreateBookFromAdminPanelResponse> CreateBookFromAdminPanel(CreateBookAdminViewModel model, IFormFile Image, IFormFile BookFile);

        Task<EditBookAdminSideViewModel> FillEditBookAdminSideViewModel(Book Book);

        Task<EditBookFromAdminPanelResponse> EditBookFromAdminPanel(EditBookAdminSideViewModel model, IFormFile Image, IFormFile BookFile);

        Task<bool> DeleteBookFromAdminPanel(ulong BookId);

        #endregion

        #region Book Tags

        Task<bool> IsExistAnyTagForThisBook(ulong Id);

        Task<List<BookTag>> GetBookTagsByBookId(ulong Id);

        void RemoveBookTags(BookTag BookTag);

        #endregion

        #region Book Category

        Task<FilterBookCategoryViewModel> FilterBookCategoryViewModel(FilterBookCategoryViewModel filter);

        Task<bool> IsDuplicatedBookCategory(string UniqueName);

        Task<CreateBookCategoryResult> AddMainBookCategory(CreateBookCategoryViewModel cat);

        Task<EditBookCategoryViewModel> FillEditBookCategoryViewModel(BookCategory model);

        Task<BookCategory> GetBookCategoryById(ulong Id);

        Task<EditBookCategoryResult> EditBookCategoryResult(EditBookCategoryViewModel category, BookCategory Book);

        Task DeleteBookCategory(BookCategory cat);

        Task<List<BookCategory>> GetSubCategoriesOfMAinCategory(ulong MainCategoryId);

        Task<List<SelectListViewModel>> GetAllMainCategories();

        Task<List<SelectListViewModel>> GetCategoriesChildrent(ulong MainCategoryId);

        Task<List<BookCategory>> GetAllParentCategories();

        Task<List<BookCategory>> GetLastestBookCategories(int countNumber);

        #endregion

        #region Site Side 

        Task<List<Book>?> LastestBookForShowOnLandingPage();

        #endregion
    }
}
