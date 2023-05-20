using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory
{
    public class HomeLaboratoryInvoiceUserPanelSideViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public int Price { get; set; }

        public string InvoicePicFileName { get; set; }

        public bool IsFinalize { get; set; }

        #endregion
    }
}
