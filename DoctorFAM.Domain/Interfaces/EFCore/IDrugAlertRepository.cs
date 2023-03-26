using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.DrugAlert;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IDrugAlertRepository
    {
        #region Site Side 

        //Create Drug Aler
        Task CreateDrugAler(DrugAlert alert);

        //Get Drug Alert Detail By ID
        Task<DrugAlert?> GetDrugAlertById(ulong drugAlertId);

        //create Drug Alert Detail 
        Task CreateDrugAlertDetail(DrugAlertDetail alert);

        //Update Drug Alert Whitout Save changes 
        void UpdateDrugAlertWhitoutSavechanges(DrugAlert drug);

        //Save Changes
        Task SaveChanges();

        //Get List Of User Drug Alerts 
        Task<List<DrugAlert>?> GetListOfUserDrugAlerts(ulong userId);

        //Get Drug Alerts Detail By Drug Alert Id 
        Task<List<DrugAlertDetail>?> GetDrugAlertsDetailByDrugAlertId(ulong drugAlertId);

        //Update Drug Alert Without SaveChanges
        void UpdateDrugAlertWithoutSaveChanges(DrugAlert alert);

        //Update Drug Alert Detail Without Savechanges
        void UpdateDrugAlertDetailWithoutSavechanges(DrugAlertDetail alertDetail);

        #endregion

        #region Back Ground Task

        //Get List Of Weekly Usage Drugs
        Task<List<ListOfWeeklyDrugAlertViewModel>> FillListOfWeeklyDrugAlertViewModel();

        //Update Drug Alert Detail Whitout Save Changes
        void UpdateDrugAlertDetailWhitoutSaveChanges(DrugAlertDetail drugAlert);

        //Save Changes 
        Task Savechanges();

        //Get List Of Monthly Usage Drugs
        Task<List<ListOfMonthlyDrugAlertViewModel>> FillListOfMonthlyDrugAlertViewModel();

        //Get List Of Yearly Usage Drugs
        Task<List<ListOfYearlyDrugAlertViewModel>> FillListOfYearlyDrugAlertViewModel();

        //Get List Of Daily Usage Drugs
        Task<List<ListOfDailyDrugAlertViewModel>> FillListOfDailyDrugAlertViewModel();

        #endregion
    }
}
