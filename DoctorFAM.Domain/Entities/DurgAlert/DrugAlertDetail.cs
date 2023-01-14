using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DurgAlert
{
    public class DrugAlertDetail : BaseEntity
    {
        #region properties

        public ulong DrugAlertId { get; set; }

        public int? Hour { get; set; }

        public DateTime? DateTime { get; set; }

        #endregion

        #region realtion

        public DrugAlert DrugAlert { get; set; }

        #endregion
    }
}
