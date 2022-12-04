using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.Service
{
    public class EditServiceDoctorPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public ulong ResumeId { get; set; }

        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string ServiceTitle { get; set; }

        #endregion
    }
}
