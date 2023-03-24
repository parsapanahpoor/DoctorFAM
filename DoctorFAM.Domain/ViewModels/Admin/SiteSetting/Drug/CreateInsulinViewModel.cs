using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.SiteSetting.Drug
{
    public class CreateInsulinViewModel
    {
        #region properties

        public string InsulineName { get; set; }

        public bool LongEffect { get; set; }

        public bool ShortEffect { get; set; }

        #endregion
    }
}
