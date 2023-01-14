﻿using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Enums.DrugAlert;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.DurgAlert
{
    public class CreateDrugAlertDetailSiteSideViewModel
    {
        #region properties

        public DrugAlert? DrugAlert { get; set; }

        public int? Hour{ get; set; }

        public string? DateTime { get; set; }

        #endregion
    }
}
