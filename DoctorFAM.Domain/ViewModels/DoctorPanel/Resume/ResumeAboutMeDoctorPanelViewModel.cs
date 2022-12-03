using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.Resume
{
    public class ResumeAboutMeDoctorPanelViewModel
    {
        #region properties

        public ulong? AboutMeId { get; set; }

        public string? Text { get; set; }

        #endregion
    }
}
