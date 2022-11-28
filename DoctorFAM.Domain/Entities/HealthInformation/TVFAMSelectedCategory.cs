using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.HealthInformation
{
    public class TVFAMSelectedCategory : BaseEntity
    {
        #region properties

        public ulong HealthInformationId { get; set; }

        public ulong TVFAMCategoryId { get; set; }

        #endregion

        #region relations

        public HealthInformation HealthInformation { get; set; }

        public TVFAMCategory TVFAMCategory { get; set; }

        #endregion
    }
}
