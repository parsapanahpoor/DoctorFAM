using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.News
{
    public class NewsCategory : BaseEntity
    {
        #region Properties

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(260)]
        public string Title { get; set; }

        [Display(Name = "عنوان در Url")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string UniqueName { get; set; }

        public ulong? ParentId { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        #endregion

        #region Relations

        public NewsCategory? Parent { get; set; }

        [ForeignKey("ParentId")]
        public ICollection<NewsCategory> Children { get; set; }

        public ICollection<NewsSelectedCategory> NewsSelectedCategories { get; set; }

        #endregion
    }
}
