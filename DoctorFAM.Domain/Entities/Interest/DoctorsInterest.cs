using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Interest
{
    public class DoctorsInterest : BaseEntity
    {
        #region properties

        public bool DoctorPanelSide { get; set; }

        public bool ConsultantPanelSide { get; set; }

        #endregion

        #region relation

        public ICollection<DoctorsInterestInfo> InterestInfo { get; set; }

        public ICollection<DoctorsSelectedInterests> DoctorsSelectedInterests { get; set; }

        #endregion
    }
}
