using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit
{
    public class ListOfAvailableShiftForSelectViewModel
    {
        #region properties

        public ulong ShiftId { get; set; }

        public string ShiftName { get; set; }

        #endregion
    }
}
