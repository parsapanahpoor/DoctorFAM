using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.SiteSetting.OnlineVisit
{
    public record CreateOnlineVisitWorkShiftAdminSideViewModel
    {
        #region propertiers

        public int StartShiftTime { get; set; }

        public int EndShiftTime { get; set; }

        public int PeriodOfShiftTime { get; set; }

        #endregion

        #region relations

        #endregion
    }
}
