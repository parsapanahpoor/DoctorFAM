using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Resume.Honor
{
    public class HonorResumeInAdminPanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [MaxLength(300)]
        public string HonorTitle { get; set; }

        public DateTime HonorDate { get; set; }

        public string? Description { get; set; }

        public string ImageName { get; set; }

        #endregion
    }
}
