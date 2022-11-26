using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Entities.MarketCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.HealthInformation
{
    public class RadioFAMSelectedCategory : BaseEntity
    {
        #region properties

        public ulong HealthInformationId { get; set; }

        public ulong RadioFAMCategoryId { get; set; }

        #endregion

        #region relations

        public HealthInformation HealthInformation { get; set; }

        public RadioFAMCategory RadioFAMCategory { get; set; }

        #endregion
    }
}
