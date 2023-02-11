using DoctorFAM.Application.Security;
using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.ViewModels.Admin.PeriodicTest;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Site.PeriodicTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IPeriodicTestService 
    {
        #region Site Side 

        //Create Periodic Test Admin Side 
        Task<bool> CreatePeriodicTestAdminSide(CreatePeriodicTestAdminSideViewModel model);

        //Fill Edit Periodic Test Admin Side ViewModel 
        Task<EditPeriodicTestAdminSideViewModel?> FillEditPeriodicTestAdminSideViewModel(ulong periodicId);

        //Update Periodic Test Admin Side 
        Task<bool> UpdatePeriodicTestAdminSide(EditPeriodicTestAdminSideViewModel model);

        //Delete Periodic Test Admin Side 
        Task<bool> DeletePeriodicTesvtAdminSide(ulong periodicId);

        //Get List Of Periodic Test 
        Task<List<PeriodicTest>?> GetListOfPeriodicTest();

        //Get List Of Diabet Part Of Periodic Test
        Task<List<SelectListViewModel>> GetListOfDiabetPartOfPeriodicTest();

        //Get List Of Blood Pressure Part Of Periodic Test
        Task<List<SelectListViewModel>> GetListOfBloodPressurePartOfPeriodicTest();

        //Create Periodic Test From User
        Task<CreatePeridicTestResult> CreateUserPeriodicTestSiteSide(CreatePeriodicTestSiteSideViewModel model, ulong userId);

        //Get List OF User Periodic Test By UserId
        Task<List<UserPeriodicTest>?> GetListOFUserPeriodicTestByUserId(ulong userId);

        //Delete User Periodic Selected Test
        Task<bool> DeleteUserPeriodicSelectedTest(ulong periodicId, ulong userId);

        #endregion

        #region User Panel 

        //Check That Current User Has Any Priodic Test After Today
        Task<List<UserPeriodicTest>?> CheckThatCurrentUserHasAnyPriodicTestAfterToday(ulong userId);

        #endregion
    }
}
