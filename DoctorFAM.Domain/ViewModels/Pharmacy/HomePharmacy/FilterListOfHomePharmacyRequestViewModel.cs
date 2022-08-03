using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Pharmacy.HomePharmacy
{
    public class FilterListOfHomePharmacyRequestViewModel : BasePaging<Request>
    {
        #region Ctor

        public FilterListOfHomePharmacyRequestViewModel()
        {
            FilterRequestPharmacySideOrder = FilterRequestAdminSideOrder.CreateDate_Des;
        }

        #endregion

        #region ulong 

        public ulong PharmacyId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Username { get; set; }

        public FilterRequestAdminSideOrder FilterRequestPharmacySideOrder { get; set; }

        #endregion
    }
}
