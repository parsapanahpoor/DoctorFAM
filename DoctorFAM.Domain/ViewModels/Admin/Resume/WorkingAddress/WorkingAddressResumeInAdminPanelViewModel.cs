using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Resume.WorkingAddress
{
    public class WorkingAddressResumeInAdminPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public string WorkingAddress { get; set; }

        [MaxLength(300)]
        public string WorkingAddressTitle { get; set; }

        [MaxLength(500)]
        public string Days { get; set; }

        [MaxLength(300)]
        public string Times { get; set; }

        #endregion
    }
}
