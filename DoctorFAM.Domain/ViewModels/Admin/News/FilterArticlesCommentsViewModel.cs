using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Article.Admin
{
    public class FilterNewsCommentsViewModel : BasePaging<Domain.Entities.News.NewsComment>
    {
        #region Constructor

        public FilterNewsCommentsViewModel()
        {
            filterNewsCommentAdminSideOrder = FilterNewsCommentAdminSideOrder.CreateDate_Des;
        }

        #endregion

        #region Properties

        public ulong? ArticleId { get; set; }

        public FilterNewsCommentAdminSideOrder filterNewsCommentAdminSideOrder { get; set; }

        #endregion
    }

    public enum FilterNewsCommentAdminSideOrder
    {
        [Display(Name = "تاریخ ثبت نام - نزولی")]
        CreateDate_Des,
        [Display(Name = "تاریخ ثبت نام - صعودی ")]
        CreateDate_Asc
    }
}
