using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory
{
    public class FilterListOfHomeLaboratoryRequestViewModel : BasePaging<Request>
    {
        #region Ctor

        public FilterListOfHomeLaboratoryRequestViewModel()
        {
            FilterRequestLaboratorySideOrder = FilterRequestAdminSideOrder.CreateDate_Des;
        }

        #endregion

        #region ulong 

        public ulong UserId { get; set; }

        public ulong? LaboratoryOwnerId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Username { get; set; }

        public FilterRequestAdminSideOrder FilterRequestLaboratorySideOrder { get; set; }

        #endregion
    }
}
