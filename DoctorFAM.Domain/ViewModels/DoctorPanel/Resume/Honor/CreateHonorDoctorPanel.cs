using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Honor
{
    public class CreateHonorDoctorPanel
    {
        #region properties

        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string HonorTitle { get; set; }

        public string HonorDate { get; set; }

        public string? Description { get; set; }

        #endregion
    }
}
