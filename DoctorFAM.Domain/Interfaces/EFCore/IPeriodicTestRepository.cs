using DoctorFAM.Domain.Entities.PeriodicTest;
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

        #endregion
    }
}
