using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Requests
{
    public class HomeVisitRequestDetail : BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        public bool FemalePhysician { get; set; }

        public bool EmergencyVisit { get; set; }

        #endregion

        #region relations 

        public Request Request{ get; set; }

        #endregion
    }
}
