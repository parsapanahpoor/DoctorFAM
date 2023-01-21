using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.PeriodicTest;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Site.PeriodicTest;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;

        public PeriodicTestService(IPeriodicTestRepository periodicTestRepository, IUserService userService)
        {
            _periodicTestRepository = periodicTestRepository;
            _userService = userService;
        }

        #endregion

        #region Admin Side 

        //Create Periodic Test Admin Side 
        public async Task<bool> CreatePeriodicTestAdminSide(CreatePeriodicTestAdminSideViewModel model)
        {
            #region Fill Entity

            PeriodicTest entity = new PeriodicTest()
            {
                Name = model.Name.SanitizeText(),
                PeriodicTestType = model.PeriodicTestType,
                DurationPerMonth = model.DurationPerMonth,
            };

            #endregion

            //Add To The Data Base 
            await _periodicTestRepository.CreatePeriodicTestAdminSide(entity);

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
                PeriodicTestId = periodicTest.Id,
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

            periodicTest.Name = model.Name.SanitizeText();
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

        //Get List Of Diabet Part Of Periodic Test
        public async Task<List<SelectListViewModel>> GetListOfDiabetPartOfPeriodicTest()
        {
            return await _periodicTestRepository.GetListOfDiabetPartOfPeriodicTest();
        }

        //Get List Of Blood Pressure Part Of Periodic Test
        public async Task<List<SelectListViewModel>> GetListOfBloodPressurePartOfPeriodicTest()
        {
            return await _periodicTestRepository.GetListOfBloodPressurePartOfPeriodicTest();
        }

        #endregion

        #region Site Side 

        //Get List OF User Periodic Test By UserId
        public async Task<List<UserPeriodicTest>?> GetListOFUserPeriodicTestByUserId(ulong userId)
        {
            return await _periodicTestRepository.GetListOFUserPeriodicTestByUserId(userId);
        }

        //Create Periodic Test From User
        public async Task<CreatePeridicTestResult> CreateUserPeriodicTestSiteSide(CreatePeriodicTestSiteSideViewModel model, ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return CreatePeridicTestResult.Faild;

            #endregion

            #region Get Periodic Test By Id

            var periodic = await _periodicTestRepository.GetPeriodicTestById(model.PeriodicTestId);
            if (periodic == null) return CreatePeridicTestResult.Faild;

            #endregion

            #region Fields Validations 

            if (!string.IsNullOrEmpty(model.DoctorOrderNextDate))
            {
                if (model.DoctorOrderNextDate.ToMiladiDateTime() <= DateTime.Now)
                {
                    return CreatePeridicTestResult.DoctorOrderDateIsNotValid;
                }
            }

            #endregion

            #region Fill Entity

            UserPeriodicTest entity = new UserPeriodicTest()
            {
                LastUserTest = model.LastTestDate.ToMiladiDateTime(),
                PeriodicTestId = model.PeriodicTestId,
                DoctorOrderForNextTest = ((string.IsNullOrEmpty(model.DoctorOrderNextDate)) ? null : model.DoctorOrderNextDate.ToMiladiDateTime()),
                UserId = userId,
                SystemOrderForNextTest = model.LastTestDate.ToMiladiDateTime().AddMonths(periodic.DurationPerMonth)
            };

            #endregion

            #region Add Method 

            await _periodicTestRepository.AddUserPeriodicTestDromUser(entity) ;

            #endregion

            return  CreatePeridicTestResult.Success;
        }

        //Delete User Periodic Selected Test
        public async Task<bool> DeleteUserPeriodicSelectedTest(ulong periodicId , ulong userId)
        {
            #region Get User Periodic Test

            var test = await _periodicTestRepository.GetUserPeriodicTestByUserIdAndPeriodicId( periodicId, userId );
            if(test == null) return false;

            #endregion

            #region Update 

            test.IsDelete = true;

            //Update Method
            await _periodicTestRepository.UpdateUserPeriodicTest(test);

            #endregion

            return true; 
        }

        #endregion
    }
}
