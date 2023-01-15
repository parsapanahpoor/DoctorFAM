using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.PeriodicTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class PeriodicTestService : IPeriodicTestService
    {
        #region Ctor

        private readonly IPeriodicTestRepository _periodicTestRepository;

        public PeriodicTestService(IPeriodicTestRepository periodicTestRepository)
        {
            _periodicTestRepository = periodicTestRepository;
        }

        #endregion

        #region Site Side 

        //Create Periodic Test Admin Side 
        public async Task<bool> CreatePeriodicTestAdminSide(CreatePeriodicTestAdminSideViewModel model)
        {
            #region Fill Entity

            PeriodicTest entity = new PeriodicTest()
            {
                Name = model.Name.SanitizeText(),
                PeriodicTestType = model.PeriodicTestType,
                DurationPerMonth= model.DurationPerMonth,
            };

            #endregion

            //Add To The Data Base 
            await _periodicTestRepository.CreatePeriodicTestAdminSide(entity) ;

            return true;
        }

        //Fill Edit Periodic Test Admin Side ViewModel 
        public async Task<EditPeriodicTestAdminSideViewModel?> FillEditPeriodicTestAdminSideViewModel(ulong periodicId)
        {
            #region Get Periodic Test By Id 

            var periodicTest = await _periodicTestRepository.GetPeriodicTestById(periodicId);
            if (periodicTest == null) return null;

            #endregion

            #region Fill Return Model

            EditPeriodicTestAdminSideViewModel model = new EditPeriodicTestAdminSideViewModel()
            {
                DurationPerMonth = periodicTest.DurationPerMonth,
                Name = periodicTest.Name,
                PeriodicTestId= periodicTest.Id,
                PeriodicTestType = periodicTest.PeriodicTestType
            };

            #endregion

            return model;
        }

        //Update Periodic Test Admin Side 
        public async Task<bool> UpdatePeriodicTestAdminSide(EditPeriodicTestAdminSideViewModel model)
        {
            #region Get Periodic Test By Id 

            var periodicTest = await _periodicTestRepository.GetPeriodicTestById(model.PeriodicTestId);
            if (periodicTest == null) return false;

            #endregion

            #region Update 

            periodicTest.Name= model.Name.SanitizeText();
            periodicTest.DurationPerMonth = model.DurationPerMonth;
            periodicTest.PeriodicTestType = model.PeriodicTestType;

            //Update Method 
            await _periodicTestRepository.UpdatePeriodicTestAdminSide(periodicTest);

            #endregion

            return true; 
        }

        //Delete Periodic Test Admin Side 
        public async Task<bool> DeletePeriodicTesvtAdminSide(ulong periodicId)
        {
            #region Get Periodic Test By Id 

            var periodicTest = await _periodicTestRepository.GetPeriodicTestById(periodicId);
            if (periodicTest == null) return false;

            #endregion

            #region Delete 

            periodicTest.IsDelete = true;

            //Update Method 
            await _periodicTestRepository.UpdatePeriodicTestAdminSide(periodicTest);

            #endregion

            return true;
        }

        //Get List Of Periodic Test 
        public async Task<List<PeriodicTest>?> GetListOfPeriodicTest()
        {
            return await _periodicTestRepository.GetListOfPeriodicTest();
        }

        #endregion
    }
}
