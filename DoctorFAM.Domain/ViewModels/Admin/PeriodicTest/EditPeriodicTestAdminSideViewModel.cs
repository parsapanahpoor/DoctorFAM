using DoctorFAM.Domain.Enums.PeriodicTestType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.PeriodicTest
{
    public class EditPeriodicTestAdminSideViewModel
    {
        #region properties

        public ulong PeriodicTestId { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }

        public int DurationPerMonth { get; set; }

        public PeriodicTestType PeriodicTestType { get; set; }

        #endregion
    }
}
