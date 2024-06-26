﻿using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.HomeVisit
{
    public class ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel : BasePaging<Request>
    {
        #region Ctor

        public ListOfPayedHomeVisitsRequestsDoctorPanelSideViewModel()
        {
            FilterRequestAdminSideOrder = FilterRequestAdminSideOrder.CreateDate_Des;
        }

        #endregion

        #region properties

        public string? Username { get; set; }

        public string? UserMobile { get; set; }

        public string? UserEmail { get; set; }

        public ulong DoctorId { get; set; }

        public FilterRequestAdminSideOrder FilterRequestAdminSideOrder { get; set; }

        #endregion
    }
}
