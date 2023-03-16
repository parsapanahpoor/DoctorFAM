using DoctorFAM.Domain.Entities.News;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.News
{
    public class FilterNewsAdminSideViewModel : BasePaging<Entities.News.News>
    {
        #region Constructor

        public FilterNewsAdminSideViewModel()
        {
            filterNewsAdminSideOrder = FilterNewsAdminSideOrder.CreateDate_Des;
            filterNewsAdminSideState = FilterNewsAdminSideState.All;
        }

        #endregion

        #region Properties

        public string? Title { get; set; }
        public bool? CanInsertComment { get; set; }
        public FilterNewsAdminSideOrder filterNewsAdminSideOrder { get; set; }
        public FilterNewsAdminSideState filterNewsAdminSideState { get; set; }

        #endregion
    }

    public enum FilterNewsAdminSideOrder
    {
        [Display( Name = "تاریخ ثبت  - نزولی")]
        CreateDate_Des,
        [Display(Name = "تاریخ ثبت  - صعودی ")]
        CreateDate_Asc
    }

    public enum FilterNewsAdminSideState
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "فعال")]
        IsActive,
        [Display(Name = " غیرفعال ")]
        NotActive
    }
}
