using DoctorFAM.Domain.Entities.Books;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Admin.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.Books
{
    public class FilterBookCategoryViewModel: BasePaging<BookCategory>
    {
        #region Constructor

        public FilterBookCategoryViewModel()
        {
            filterBookCatgeoryAdminSideOrder = FilterBookCatgeoryAdminSideOrder.CreateDate_Des;
            filterBookCategoryAdminSideState = FilterBookCategoryAdminSideState.All;
        }

        #endregion

        #region Properties

        public ulong? ParentId { get; set; }
        public string? Title { get; set; }
        public string? UniqueName { get; set; }
        public FilterBookCatgeoryAdminSideOrder filterBookCatgeoryAdminSideOrder { get; set; }
        public FilterBookCategoryAdminSideState filterBookCategoryAdminSideState { get; set; }

        #endregion
    }

    public enum FilterBookCatgeoryAdminSideOrder
    {
        [Display(Name = "تاریخ ثبت  - نزولی")]
        CreateDate_Des,
        [Display(Name = "تاریخ ثبت  - صعودی ")]
        CreateDate_Asc
    }

    public enum FilterBookCategoryAdminSideState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "فعال")]
        IsActive,
        [Display(Name = " غیرفعال ")]
        NotActive
    }
}
