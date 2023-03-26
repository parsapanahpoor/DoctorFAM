using DoctorFAM.Domain.Entities.DurgAlert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.BackgroundTasks.DrugAlert
{
    public class ListOfDailyDrugAlertViewModel
    {
        #region properties

        public DoctorFAM.Domain.Entities.DurgAlert.DrugAlert DrugAlert { get; set; }

        public string? Mobile { get; set; }

        #endregion
    }
}
