﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkHistory
{
    public class WorkHistoryResumeInSitePanelViewModel
    {
        #region properties

        public ulong Id { get; set; }

        [MaxLength(300)]
        public string? WorkAddress { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(300)]
        public string? JobPosition { get; set; }

        #endregion
    }
}
