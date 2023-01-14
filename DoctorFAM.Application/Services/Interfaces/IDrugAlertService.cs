using DoctorFAM.Domain.Entities.DurgAlert;
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

        //Fill Create Drug Alert Site Side View Model 
        Task<CreateDrugAlertDetailSiteSideViewModel?> FillCreateDrugAlertSiteSideViewModel(ulong createDrugAlertId, ulong userId);

        //Create Drug Alert Detail 
        Task<bool> CrerateDrugAlertDetail(CreateDrugAlertDetailSiteSideViewModel model, ulong userId);

        //List Of User Drug Alerts Site Side View Model 
        Task<ListOfUserDrugsAlertSiteSideViewModel?> FillListOfUserDrugAlertsSiteSideViewModel(ulong userId);

        //Get Drug Alerts Detail By Drug Alert Id 
        Task<List<DrugAlertDetail>?> GetDrugAlertsDetailByDrugAlertId(ulong drugAlertId);

        //Delete Drug Alert 
        Task<bool> DeleteDrugAlert(ulong drugAlertId, ulong userId);

        //Fill Show Drug Alert Detail Site Side View Model
        Task<ShowDrugAlertDetailSiteSideViewModel> FillShowDrugAlertDetailSiteSideViewModel(ulong drugId, ulong userId);

        #endregion
    }
}
