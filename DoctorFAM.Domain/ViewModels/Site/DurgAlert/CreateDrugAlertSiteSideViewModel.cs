using DoctorFAM.Domain.Enums.DrugAlert;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.DurgAlert
{
    public class CreateDrugAlertSiteSideViewModel
    {
        #region properties

        [MaxLength(500)]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public string DrugName { get; set; }

        public DrugAlertDurationType DrugAlertDurationType { get; set; }

        #endregion
    }

    public class CreateDrugAlertSiteSideViewModelResult
    {
        #region properties

        public bool Result { get; set; }

        public ulong? CreatedDrugAlertId { get; set; }

        #endregion
    }
}
