using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Resume.WorkingAddress
{
    public class EditWorkingAddressDoctorPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        public string WorkingAddress { get; set; }

        [MaxLength(300, ErrorMessage = "Please Enter {0} Less Than {1} Character")]
        public string WorkingAddressTitle { get; set; }

        [MaxLength(500)]
        public string Days { get; set; }

        [MaxLength(300)]
        public string Times { get; set; }

        #endregion
    }
}
