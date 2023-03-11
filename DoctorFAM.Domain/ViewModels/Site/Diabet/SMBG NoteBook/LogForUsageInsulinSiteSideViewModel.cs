using DoctorFAM.Domain.Enums.SMBG;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Diabet.SMBG_NoteBook
{
    public class LogForUsageInsulinSiteSideViewModel
    {
        #region properties

        public ulong UserId { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public ulong InsulinId { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public int CountOfInsulinUsage { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public int BloodSugar { get; set; }

        public TimeOfUsageInsulinState TimeOfUsageInsulinState { get; set; }

        public TimeOfUsageInsulinType? TimeOfUsageInsulinType { get; set; }

        #endregion
    }
}
