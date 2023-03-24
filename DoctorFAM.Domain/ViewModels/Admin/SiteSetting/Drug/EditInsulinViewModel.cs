using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.SiteSetting.Drug
{
    public class EditInsulinViewModel
    {
        #region properties

        public ulong Id { get; set; }

        public string InsulineName { get; set; }

        public bool LongEffect { get; set; }

        public bool ShortEffect { get; set; }

        #endregion
    }
}
