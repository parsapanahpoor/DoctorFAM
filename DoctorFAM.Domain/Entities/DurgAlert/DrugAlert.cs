using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.DrugAlert;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.DurgAlert
{
    public class DrugAlert : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        [MaxLength(500)]
        public string DrugName { get; set; }

        public DrugAlertDurationType DrugAlertDurationType { get; set; }

        public int CountOfUsage { get; set; }

        #endregion

        #region relation 

        public ICollection<DrugAlertDetail> DrugAlertDetails { get; set; }

        #endregion
    }
}
