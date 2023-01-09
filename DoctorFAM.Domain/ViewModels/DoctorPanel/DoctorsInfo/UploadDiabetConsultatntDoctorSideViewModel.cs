﻿using DoctorFAM.Domain.Entities.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo
{
    public class UploadDiabetConsultatntDoctorSideViewModel
    {
        #region properties

        public string? Description { get; set; }

        public List<DiabetConsultantsResume>? DiabetConsultantsResumes { get; set; }

        #endregion
    }
}