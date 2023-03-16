using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.Books
{
    public class BookCategory:BaseEntity
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

        public BookCategory? Parent { get; set; }

        [ForeignKey("ParentId")]
        public ICollection<BookCategory> Children { get; set; }

        //public ICollection<BookSelectedCategory> BookSelectedCategories { get; set; }

        #endregion
    }
}
