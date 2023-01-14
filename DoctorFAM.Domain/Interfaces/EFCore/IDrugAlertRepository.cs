using DoctorFAM.Domain.Entities.DurgAlert;
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

        //Save Changes
        Task SaveChanges();

        #endregion
    }
}
