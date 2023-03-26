using AngleSharp.Common;
using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.DrugAlert;
using DoctorFAM.Domain.ViewModels.Site.DurgAlert;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DrugAlertService : IDrugAlertService
    {
        #region Ctor 

        private readonly IDrugAlertRepository _drugAlertRepository;
        private readonly IUserService _userService;
        private readonly ISMSService _smsService;

        public DrugAlertService(IDrugAlertRepository drugAlertRepository, IUserService userService, ISMSService smsService)
        {
            _drugAlertRepository = drugAlertRepository;
            _userService = userService;
            _smsService = smsService;
        }

        #endregion

        #region Site Side 

        //Create Drug Alert Site Side
        public async Task<CreateDrugAlertSiteSideViewModelResult> CreateDrugAlertSide(CreateDrugAlertSiteSideViewModel model, ulong userId, List<int>? Hour, string? DateTimeInserted)
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
                DrugLabel = model.LabelName.SanitizeText(),
                DrugAlertDurationType = model.DrugAlertDurationType,
            };

            //Add Drug Alert To The Data Base
            await _drugAlertRepository.CreateDrugAler(entity);

            #endregion

            #region Add drug Alert Detail

            //If Drug Alert Type Is Daily
            if (model.DrugAlertDurationType == Domain.Enums.DrugAlert.DrugAlertDurationType.Daily && Hour != null && Hour.Any())
            {
                foreach (var daily in Hour)
                {
                    DrugAlertDetail drugAlertDetail = new DrugAlertDetail()
                    {
                        DrugAlertId = entity.Id,
                        Hour = daily
                    };

                    //Create Drug Alert Detail 
                    await _drugAlertRepository.CreateDrugAlertDetail(drugAlertDetail);
                }

                #region Update Count Of Usage

                entity.CountOfUsage = Hour.Count();

                //Update 
                _drugAlertRepository.UpdateDrugAlertWithoutSaveChanges(entity);

                #endregion

                //Save Changes
                await _drugAlertRepository.SaveChanges();
            }

            if (entity.DrugAlertDurationType != Domain.Enums.DrugAlert.DrugAlertDurationType.Daily && !string.IsNullOrEmpty(DateTimeInserted))
            {
                DrugAlertDetail drugAlertDetail = new DrugAlertDetail()
                {
                    DrugAlertId = entity.Id,
                    DateTime = DateTimeInserted.ToMiladiDateTime(),
                };

                //Create Drug Alert Detail 
                await _drugAlertRepository.CreateDrugAlertDetail(drugAlertDetail);

                #region Update Count Of Usage

                entity.CountOfUsage = 1;

                //Update 
                _drugAlertRepository.UpdateDrugAlertWithoutSaveChanges(entity);

                #endregion

                //Save Changes 
                await _drugAlertRepository.SaveChanges();
            }

            #endregion

            returModel.Result = true;
            returModel.CreatedDrugAlertId = entity.Id;

            return returModel;
        }

        //Fill Create Drug Alert Site Side View Model 
        public async Task<CreateDrugAlertDetailSiteSideViewModel?> FillCreateDrugAlertSiteSideViewModel(ulong createDrugAlertId, ulong userId)
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
        public async Task<bool> CrerateDrugAlertDetail(CreateDrugAlertDetailSiteSideViewModel model, ulong userId)
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
        public async Task<bool> DeleteDrugAlert(ulong drugAlertId, ulong userId)
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

            //Update Method 
            _drugAlertRepository.UpdateDrugAlertWithoutSaveChanges(drugAlert);

            #endregion

            #region Delete Drug Alerts Detail 

            if (drugAlertDetail != null && drugAlertDetail.Any())
            {
                foreach (var item in drugAlertDetail)
                {
                    item.IsDelete = true;

                    //Update Method
                    _drugAlertRepository.UpdateDrugAlertDetailWithoutSavechanges(item);
                }
            }

            #endregion

            //Save Changes 
            await _drugAlertRepository.SaveChanges();

            return true;
        }

        //Fill Show Drug Alert Detail Site Side View Model
        public async Task<ShowDrugAlertDetailSiteSideViewModel> FillShowDrugAlertDetailSiteSideViewModel(ulong drugId, ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Drug Alert 

            var drugAlert = await _drugAlertRepository.GetDrugAlertById(drugId);
            if (drugAlert == null || drugAlert.UserId != userId) return null;

            #endregion

            #region Get Drug Alerts Detail By Drug Alert Id 

            var drugAlertDetail = await _drugAlertRepository.GetDrugAlertsDetailByDrugAlertId(drugAlert.Id);

            #endregion

            #region Instance For Model

            ShowDrugAlertDetailSiteSideViewModel model = new ShowDrugAlertDetailSiteSideViewModel { };

            if (drugAlert.DrugAlertDurationType == Domain.Enums.DrugAlert.DrugAlertDurationType.Daily)
            {
                if (drugAlertDetail != null && drugAlertDetail.Any())
                {
                    foreach (var item in drugAlertDetail)
                    {
                        model.Houre.Add(item.Hour.Value);
                    }
                }
            }
            else
            {
                if (drugAlertDetail != null && drugAlertDetail.Any())
                {
                    foreach (var item in drugAlertDetail)
                    {
                        model.DateTime = item.DateTime;
                    }
                }
            }

            #endregion

            return model;
        }

        #endregion

        #region Back Ground Task

        //Get List Of Weekly Usage Drugs
        public async Task FillListOfWeeklyDrugAlertViewModel()
        {
            //Get List Of Data With Conditions
            var res = await _drugAlertRepository.FillListOfWeeklyDrugAlertViewModel();

            if (res is not null)
            {
                foreach (var item in res.DistinctBy(p => p.Mobile))
                {
                    #region Send SMS

                    var message = Messages.SendSMSForWeeklyUsageOfDrug(string.Join(",", res.Where(p => p.Mobile == item.Mobile).Select(p => p.DrugAlert.DrugName).ToList()));

                    await _smsService.SendSimpleSMS(item.Mobile, message);

                    #endregion
                }

                #region Update Record To One Week

                foreach (var item in res)
                {
                    if (item.DrugAlertDetail.DateTime.HasValue)
                    {
                        item.DrugAlertDetail.DateTime = item.DrugAlertDetail.DateTime.Value.AddDays(7);

                        _drugAlertRepository.UpdateDrugAlertDetailWhitoutSaveChanges(item.DrugAlertDetail);
                    }
                }

                await _drugAlertRepository.SaveChanges();

                #endregion
            }
        }

        //Get List Of Monthly Usage Drugs
        public async Task FillListOfMonthlyDrugAlertViewModel()
        {
            //Get List Of Data With Conditions
            var res = await _drugAlertRepository.FillListOfMonthlyDrugAlertViewModel();

            if (res is not null)
            {
                foreach (var item in res.DistinctBy(p => p.Mobile))
                {
                    #region Send SMS

                    var message = Messages.SendSMSForWeeklyUsageOfDrug(string.Join(",", res.Where(p => p.Mobile == item.Mobile).Select(p => p.DrugAlert.DrugName).ToList()));

                    await _smsService.SendSimpleSMS(item.Mobile, message);

                    #endregion
                }

                #region Update Record To One Week

                foreach (var item in res)
                {
                    if (item.DrugAlertDetail.DateTime.HasValue)
                    {
                        item.DrugAlertDetail.DateTime = item.DrugAlertDetail.DateTime.Value.AddMonths(1);

                        _drugAlertRepository.UpdateDrugAlertDetailWhitoutSaveChanges(item.DrugAlertDetail);
                    }
                }

                await _drugAlertRepository.SaveChanges();

                #endregion
            }
        }

        //Get List Of Yearly Usage Drugs
        public async Task FillListOfYearlyDrugAlertViewModel()
        {
            //Get List Of Data With Conditions
            var res = await _drugAlertRepository.FillListOfYearlyDrugAlertViewModel();

            if (res is not null)
            {
                foreach (var item in res.DistinctBy(p => p.Mobile))
                {
                    #region Send SMS

                    var message = Messages.SendSMSForWeeklyUsageOfDrug(string.Join(",", res.Where(p => p.Mobile == item.Mobile).Select(p => p.DrugAlert.DrugName).ToList()));

                    await _smsService.SendSimpleSMS(item.Mobile, message);

                    #endregion
                }

                #region Update Record To One Week

                foreach (var item in res)
                {
                    if (item.DrugAlertDetail.DateTime.HasValue)
                    {
                        item.DrugAlertDetail.DateTime = item.DrugAlertDetail.DateTime.Value.AddYears(1);

                        _drugAlertRepository.UpdateDrugAlertDetailWhitoutSaveChanges(item.DrugAlertDetail);
                    }
                }

                await _drugAlertRepository.SaveChanges();

                #endregion
            }
        }

        //Get List Of Daily Usage Drugs
        public async Task FillListOfDailyDrugAlertViewModel()
        {
            //Get List Of Data With Conditions
            var res = await _drugAlertRepository.FillListOfDailyDrugAlertViewModel();

            if (res is not null)
            {
                foreach (var item in res.DistinctBy(p => p.Mobile))
                {
                    #region Send SMS

                    var message = Messages.SendSMSForWeeklyUsageOfDrug(string.Join(",", res.Where(p => p.Mobile == item.Mobile).Select(p => p.DrugAlert.DrugName).ToList()));

                    await _smsService.SendSimpleSMS(item.Mobile, message);

                    #endregion
                }
            }
        }

        #endregion
    }
}
