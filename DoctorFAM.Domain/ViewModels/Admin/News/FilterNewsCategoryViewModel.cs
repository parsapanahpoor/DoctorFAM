using DoctorFAM.Domain.Entities.News;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.News.Admin
{
    public class FilterNewsCategoryViewModel : BasePaging<NewsCategory>
    {
        #region Constructor

        public FilterNewsCategoryViewModel()
        {
            filterNewsCatgeoryAdminSideOrder = FilterNewsCatgeoryAdminSideOrder.CreateDate_Des;
            filterNewsCategoryAdminSideState = FilterNewsCategoryAdminSideState.All;
        }

        #endregion

        #region Properties

        public ulong? ParentId { get; set; }
        public string? Title { get; set; }
        public string? UniqueName { get; set; }
        public FilterNewsCatgeoryAdminSideOrder filterNewsCatgeoryAdminSideOrder { get; set; }
        public FilterNewsCategoryAdminSideState filterNewsCategoryAdminSideState { get; set; }

        #endregion
    }

    public enum FilterNewsCatgeoryAdminSideOrder
    {
        [Display(Name = "تاریخ ثبت نام - نزولی")]
        CreateDate_Des,
        [Display(Name = "تاریخ ثبت نام - صعودی ")]
        CreateDate_Asc
    }

    public enum FilterNewsCategoryAdminSideState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "فعال")]
        IsActive,
        [Display(Name = " غیرفعال ")]
        NotActive
    }
}
