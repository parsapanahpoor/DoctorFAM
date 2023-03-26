using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.BackgroundTasks.PriodicTest
{
    public class SendSMSForPriodicTestViewModel
    {
        #region properties

        public ulong UserSelectedPriodicTestId { get; set; }

        public string? PeriodicTestType { get; set; }

        public string? Mobile { get; set; }

        #endregion
    }
}
