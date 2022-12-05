using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Resume
{
    public class ResumeAboutMeAdminPanelViewModel
    {
        #region properties

        public ulong? AboutMeId { get; set; }

        public string? Text { get; set; }

        public ulong ResumeId { get; set; }

        #endregion
    }
}
