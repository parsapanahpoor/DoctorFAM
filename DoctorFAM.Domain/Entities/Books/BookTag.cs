using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Entities.Books
{
    public class BookTag:BaseEntity
    {
        #region Properties

        public ulong BookId { get; set; }

        [Display(Name = "تگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }

        #endregion

        #region Relations

        //public Book Book { get; set; }

        #endregion
    }
}
