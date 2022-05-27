using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.HealthHouse
{
    public class FilterHomeVisistViewModel : BasePaging<Request>
    {
        #region Ctor

        public FilterHomeVisistViewModel()
        {
            RequestState = RequestStateForFilterAdminSide.All;
            FilterRequestAdminSideOrder = FilterRequestAdminSideOrder.CreateDate_Des;
        }

        #endregion

        #region Properties

        public string? Username { get; set; }

        public string? UserMobile { get; set; }

        public string? UserEmail { get; set; }

        public RequestStateForFilterAdminSide RequestState { get; set; }

        public FilterRequestAdminSideOrder FilterRequestAdminSideOrder { get; set; }

        #endregion
    }
  
}
