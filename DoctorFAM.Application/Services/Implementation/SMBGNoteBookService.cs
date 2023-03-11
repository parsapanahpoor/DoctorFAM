using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.A1C;
using DoctorFAM.Domain.Entities.A1C_SMBG_NoteBook_;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Enums.SMBG;
using DoctorFAM.Domain.Interfaces.Dapper;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.Diabet.SMBG_NoteBook;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class SMBGNoteBookService : ISMBGNoteBookService
    {
        #region Ctor

        private readonly ISMBGNoteBookRepository _smbgRepository;
        private readonly ISiteSettingService _siteSettingService;
        private readonly IUserService _userService;
        private readonly ISMBGNoteBookDapper _smbgDapper;

        public SMBGNoteBookService(ISMBGNoteBookRepository smbgRepository, IUserService userService , ISiteSettingService siteSettingService
                                    , ISMBGNoteBookDapper smbgDapper)
        {
            _smbgRepository = smbgRepository;
            _userService = userService;
            _siteSettingService = siteSettingService;
            _smbgDapper = smbgDapper;
        }

        #endregion

        #region Site Side 

        //Add Usage Insulin Data To The Data Base
        public async Task<bool> AddUsageInsulinDataToTheDataBase(LogForUsageInsulinSiteSideViewModel model)
        {
            #region Get User By User Id 

            var user = await _userService.GetUserById(model.UserId);
            if (user == null) return false;

            #endregion

            #region Get Insulin By Id

            var insulin = await _siteSettingService.GetInsulinById(model.InsulinId);
            if (insulin == null) return false;

            #endregion

            #region Fill Model 

            LogForUsageInsulin insulinUsage = new LogForUsageInsulin()
            {
                BloodSugar = model.BloodSugar,
                InsulinId= model.InsulinId,
                UserId= model.UserId,
                CountOfInsulinUsage= model.CountOfInsulinUsage,
                CreateDate = DateTime.Now,
                IsDelete = false,
                TimeOfUsageInsulinState= model.TimeOfUsageInsulinState,
                TimeOfUsageInsulinType = model.TimeOfUsageInsulinType 
            };

            //Add Insulin Usage To The Data Base
            await _smbgRepository.AddInsulinUsageToTheDataBase(insulinUsage);

            #endregion

            return true;
        }

        //Fill Log For Usage Insulin Site Side View Model
        public async Task<LogForUsageInsulinSiteSideViewModel?> LogForUsageInsulinSiteSideViewModel(ulong userId , TimeOfUsageInsulinState timeOfUsageInsulinState)
        {
            #region Get User By User Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Fill Model 

            LogForUsageInsulinSiteSideViewModel model = new LogForUsageInsulinSiteSideViewModel()
            {
                TimeOfUsageInsulinState= timeOfUsageInsulinState,
                UserId = userId,
            };

            #endregion

            return model;
        }

        //Fill Index SMBG Page View Model
        public async Task<IndexSMBGPageViewModel> FillIndexSMBGPageViewModel(ulong userId)
        {
            #region Get User By User Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            //Create Instance
            IndexSMBGPageViewModel model = new IndexSMBGPageViewModel();

            #region Fill Log For A1C

            model.logForUsersA1c = await _smbgRepository.GetLogsOfUserA1CByUserId(userId);

            #region Fill Show User Insulin Usage History

            //Get User Create Dates
            var createDates =  await _smbgDapper.GetUserInsulineUsagesCreateDates(userId);

            if (createDates != null && createDates.Any())
            {
                foreach (var item in createDates)
                {
                    ShowUserInsulinUsageHistory userInsulinUsage = new ShowUserInsulinUsageHistory();

                    userInsulinUsage.CreateDate = item;
                    userInsulinUsage.LogForUsageInsulin = await _smbgRepository.GetListOfUserInsulinUsageByCreateDate(item, userId);

                    model.ShowUserInsulinUsageHistory.Add(userInsulinUsage);
                }
            }

            #endregion

            #endregion

            return model;
        }

        //Calculate Log Users A1C 
        public async Task<bool> CalculateLogUsersA1C(decimal a1c , ulong userId)
        {
            #region Get User By User Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return false;

            #endregion

            #region Log For A1c

            LogForUsersA1C model = new LogForUsersA1C()
            {
                UserId = userId,
                A1C = a1c,
                CreateDate = DateTime.Now
            };

            //Add To The Data Base 
            await _smbgRepository.CreateLogForUsersA1C(model);

            #endregion

            return true;
        }

        #endregion
    }
}
