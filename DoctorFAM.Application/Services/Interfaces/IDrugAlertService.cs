using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.DrugAlert;
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
        Task<CreateDrugAlertSiteSideViewModelResult> CreateDrugAlertSide(CreateDrugAlertSiteSideViewModel model, ulong userId, List<int>? Hour, string? DateTimeInserted);

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

        #region Back Ground Task

        //Get List Of Weekly Usage Drugs
        Task FillListOfWeeklyDrugAlertViewModel();

        //Get List Of Monthly Usage Drugs
        Task FillListOfMonthlyDrugAlertViewModel();

        //Get List Of Yearly Usage Drugs
        Task FillListOfYearlyDrugAlertViewModel();

        //Get List Of Daily Usage Drugs
        Task FillListOfDailyDrugAlertViewModel();

        #endregion
    }
}
