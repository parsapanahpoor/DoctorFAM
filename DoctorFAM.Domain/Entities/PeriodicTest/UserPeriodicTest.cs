using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.PeriodicTest
{
    public class UserPeriodicTest : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        public ulong PeriodicTestId { get; set; }

        public DateTime LastUserTest{ get; set; }

        public DateTime? DoctorOrderForNextTest{ get; set; }

        public DateTime SystemOrderForNextTest  { get; set; }

        #endregion

        #region relations

        public PeriodicTest PeriodicTest { get; set; }

        #endregion
    }
}
