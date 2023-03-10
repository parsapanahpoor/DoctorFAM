using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.A1C;
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

        private readonly IUserService _userService;

        public SMBGNoteBookService(ISMBGNoteBookRepository smbgRepository, IUserService userService)
        {
            _smbgRepository = smbgRepository;
            _userService = userService;
        }

        #endregion

        #region Site Side 

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

            #endregion

            return model;
        }

        //Calculate Log Users A1C 
        public async Task<bool> CalculateLogUsersA1C(int a1c , ulong userId)
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
