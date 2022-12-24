using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.News
{
    public class NewsTag : BaseEntity
    {
        #region Properties

        public ulong NewsId { get; set; }

        [Display(Name = "تگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }

        #endregion

        #region Relations

        public News News { get; set; }

        #endregion
    }
}
