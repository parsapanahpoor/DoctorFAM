using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.DurgAlert;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DrugAlertService : IDrugAlertService
    {
        #region Ctor 

        private readonly IDrugAlertRepository _drugAlertRepository;
        private readonly IUserService _userService;

        public DrugAlertService(IDrugAlertRepository drugAlertRepository, IUserService userService)
        {
            _drugAlertRepository = drugAlertRepository;
            _userService = userService;
        }

        #endregion

        #region Site Side 

        //Create Drug Alert Site Side
        public async Task<CreateDrugAlertSiteSideViewModelResult> CreateDrugAlertSide(CreateDrugAlertSiteSideViewModel model, ulong userId)
        {
            #region Instance Return Mode

            CreateDrugAlertSiteSideViewModelResult returModel = new CreateDrugAlertSiteSideViewModelResult();

            #endregion

            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                returModel.Result = false;

                return returModel;
            }

            #endregion

            #region Fill Entity Model 

            DrugAlert entity = new DrugAlert()
            {
                UserId = user.Id,
                DrugName = model.DrugName.SanitizeText(),
                CountOfUsage = model.CountOfUsage,
                DrugAlertDurationType = model.DrugAlertDurationType,
            };

            //Add Drug Alert To The Data Base
            await _drugAlertRepository.CreateDrugAler(entity);

            #endregion

            returModel.Result = true;
            returModel.CreatedDrugAlertId = entity.Id;

            return returModel;
        }

        //Fill Create Drug Alert Site Side View Model 
        public async Task<CreateDrugAlertDetailSiteSideViewModel?> FillCreateDrugAlertSiteSideViewModel(ulong createDrugAlertId , ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Create Drug Alert Detail

            var createdDeurgAlert = await _drugAlertRepository.GetDrugAlertById(createDrugAlertId);
            if (createdDeurgAlert == null || createdDeurgAlert.UserId != userId) return null;

            #endregion

            #region Fill Return Model 

            CreateDrugAlertDetailSiteSideViewModel returnModel = new CreateDrugAlertDetailSiteSideViewModel()
            {
                 DrugAlert = createdDeurgAlert,
                 CreatedDrugAlertId = createDrugAlertId
            };

            #endregion

            return returnModel;
        }

        //Create Drug Alert Detail 
        public async Task<bool> CrerateDrugAlertDetail(CreateDrugAlertDetailSiteSideViewModel model , ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return false;

            #endregion

            #region Get Create Drug Alert Detail

            var createdDeurgAlert = await _drugAlertRepository.GetDrugAlertById(model.CreatedDrugAlertId);
            if (createdDeurgAlert == null || createdDeurgAlert.UserId != userId) return false;

            #endregion

            #region Create Drug Alert Detial 

            //If Drug Alert Type Is Daily
            if (model.Hour != null && model.Hour.Any())
            {
                foreach (var daily in model.Hour)
                {
                    DrugAlertDetail drugAlertDetail = new DrugAlertDetail()
                    {
                        DrugAlertId = createdDeurgAlert.Id,
                        Hour = daily
                    };

                    //Create Drug Alert Detail 
                    await _drugAlertRepository.CreateDrugAlertDetail(drugAlertDetail);
                }

                //Save Changes
                await _drugAlertRepository.SaveChanges();
            }

            if (model.DateTime != null && model.DateTime.Any())
            {
                foreach (var dateTime in model.DateTime)
                {
                    DrugAlertDetail drugAlertDetail = new DrugAlertDetail()
                    {
                        DrugAlertId = createdDeurgAlert.Id,
                        DateTime = dateTime.ToMiladiDateTime(),
                    };

                    //Create Drug Alert Detail 
                    await _drugAlertRepository.CreateDrugAlertDetail(drugAlertDetail);
                }

                //Save Changes 
                await _drugAlertRepository.SaveChanges();
            }

            #endregion

            return true;
        }

        //List Of User Drug Alerts Site Side View Model 
        public async Task<ListOfUserDrugsAlertSiteSideViewModel?> FillListOfUserDrugAlertsSiteSideViewModel(ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Fill View Model 

            ListOfUserDrugsAlertSiteSideViewModel model = new ListOfUserDrugsAlertSiteSideViewModel()
            {
                 DrugAlerts = await _drugAlertRepository.GetListOfUserDrugAlerts(userId)
            };

            #endregion

            return model;
        }

        //Get Drug Alerts Detail By Drug Alert Id 
        public async Task<List<DrugAlertDetail>?> GetDrugAlertsDetailByDrugAlertId(ulong drugAlertId)
        {
            return await _drugAlertRepository.GetDrugAlertsDetailByDrugAlertId(drugAlertId);
        }

        //Delete Drug Alert 
        public async Task<bool> DeleteDrugAlert(ulong drugAlertId , ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return false;

            #endregion

            #region Get Drug Alert 

            var drugAlert = await _drugAlertRepository.GetDrugAlertById(drugAlertId);
            if (drugAlert == null || drugAlert.UserId != userId) return false;

            #endregion

            #region Get Drug Alerts Detail By Drug Alert Id 

            var drugAlertDetail = await _drugAlertRepository.GetDrugAlertsDetailByDrugAlertId(drugAlert.Id);

            #endregion

            #region Delete Drug Alert 

            drugAlert.IsDelete = true;

            //Doing

            #endregion

            return true;
        }

        #endregion
    }
}
