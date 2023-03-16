using DoctorFAM.Domain.Entities.Books;
using DoctorFAM.Domain.ViewModels.Common;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Books
{
    public class FilterBookAdminSideViewModel: BasePaging<Entities.Books.Book>
    {
        #region Constructor

        public FilterBookAdminSideViewModel()
        {
            filterBookAdminSideOrder = FilterBookAdminSideOrder.CreateDate_Des;
            filterBookAdminSideState = FilterBookAdminSideState.All;
        }

        #endregion

        #region Properties

        public string? Title { get; set; }       
        public FilterBookAdminSideOrder filterBookAdminSideOrder { get; set; }
        public FilterBookAdminSideState filterBookAdminSideState { get; set; }

        #endregion
    }

    public enum FilterBookAdminSideOrder
    {
        [Display(Name = "تاریخ ثبت  - نزولی")]
        CreateDate_Des,
        [Display(Name = "تاریخ ثبت  - صعودی ")]
        CreateDate_Asc
    }

    public enum FilterBookAdminSideState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "فعال")]
        IsActive,
        [Display(Name = " غیرفعال ")]
        NotActive
    }
}
