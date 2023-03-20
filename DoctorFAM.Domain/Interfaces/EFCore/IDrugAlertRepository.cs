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

        #endregion
    }
}
