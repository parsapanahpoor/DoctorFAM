using DoctorFAM.Domain.Enums.Gender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Diabet
{
    public class GFRViewModel
    {
        #region properties

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }

        public decimal Keratenin { get; set; }

        #endregion
    }
}
