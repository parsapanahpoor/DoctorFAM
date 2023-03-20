﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.HealthInformation
{
    public class RadioFAMAPIViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public string musicName { get; set; }

        public string musicSrc { get; set; }

        public string musicImageSrc { get; set; }

        public string CreateDate { get; set; }

        #endregion
    }
}
