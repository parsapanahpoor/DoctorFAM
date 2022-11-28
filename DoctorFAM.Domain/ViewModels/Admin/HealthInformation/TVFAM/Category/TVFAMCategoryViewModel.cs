using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthInformation.TVFAM.Category
{
    public class TVFAMCategoryViewModel
    {
        #region Properties

        [Display(Name = " GroupName    ")]
        [Required(ErrorMessage = "Please Enter {0}")]
        [MaxLength(400, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string CategoryName { get; set; }

        public ulong? ParentId { get; set; }

        public ulong? CatgeoryId { get; set; }

        #endregion
    }
}
