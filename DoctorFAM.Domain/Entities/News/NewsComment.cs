using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.News
{
    public class NewsComment : BaseEntity
    {
        #region Properties

        public ulong NewsId { get; set; }

        public ulong UserId { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر داشته باشد")]
        public string Comment { get; set; }

        public bool IsRead { get; set; } = false;

        public ulong? ParentId { get; set; }

        #endregion

        #region Relations

        public User User { get; set; }

        public News News { get; set; }

        public NewsComment? Parent { get; set; }

        [ForeignKey("ParentId")]
        public ICollection<NewsComment> Children { get; set; }

        #endregion
    }
}
