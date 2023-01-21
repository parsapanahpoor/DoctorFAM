using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface IPeriodicTestRepository 
    {
        #region Site Side 

        //Create Periodic Test Admin Side
        Task CreatePeriodicTestAdminSide(PeriodicTest test);

        //Get Periodic Test By Id 
        Task<PeriodicTest?> GetPeriodicTestById(ulong id);

        //Update Periodic Test Admin Side 
        Task UpdatePeriodicTestAdminSide(PeriodicTest test);

        //Get List Of Periodic Test 
        Task<List<PeriodicTest>?> GetListOfPeriodicTest();

        //Get List Of Diabet Part Of Periodic Test
        Task<List<SelectListViewModel>> GetListOfDiabetPartOfPeriodicTest();

        //Get List Of Blood Pressure Part Of Periodic Test
        Task<List<SelectListViewModel>> GetListOfBloodPressurePartOfPeriodicTest();

        #endregion

        #region Site Side 

        //Get List OF User Periodic Test By UserId
        Task<List<UserPeriodicTest>?> GetListOFUserPeriodicTestByUserId(ulong userId);

        //Add User Periodic Test Drom User
        Task AddUserPeriodicTestDromUser(UserPeriodicTest entity);

        //Get User Periodic Test By User Id And Periodic Id
        Task<UserPeriodicTest?> GetUserPeriodicTestByUserIdAndPeriodicId(ulong periodicId, ulong userId);

        //Update User Periodic Test
        Task UpdateUserPeriodicTest(UserPeriodicTest test);

        #endregion
    }
}
