using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Nurse.HomeNurse
{
    public class FilterListOfHomeNurseRequestViewModel : BasePaging<Request>
    {
        #region Ctor

        public FilterListOfHomeNurseRequestViewModel()
        {
            FilterRequestNurseSideOrder = FilterRequestAdminSideOrder.CreateDate_Des;
        }

        #endregion

        #region properties 

        public ulong NurseId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Username { get; set; }

        public FilterRequestAdminSideOrder FilterRequestNurseSideOrder { get; set; }

        #endregion
    }
}
