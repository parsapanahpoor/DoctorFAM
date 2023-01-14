using DoctorFAM.Domain.ViewModels.Site.DurgAlert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IDrugAlertService
    {
        #region Site Side 

        //Create Drug Alert Site Side
        Task<CreateDrugAlertSiteSideViewModelResult> CreateDrugAlertSide(CreateDrugAlertSiteSideViewModel model, ulong userId);

        #endregion
    }
}
