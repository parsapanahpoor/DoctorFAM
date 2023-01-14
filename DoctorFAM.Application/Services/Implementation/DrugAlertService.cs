using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.DurgAlert;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.DurgAlert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DrugAlertService : IDrugAlertService
    {
        #region Ctor 

        private readonly IDrugAlertRepository _drugAlertRepository;
        private readonly IUserService _userService;

        public DrugAlertService(IDrugAlertRepository drugAlertRepository , IUserService userService)
        {
            _drugAlertRepository = drugAlertRepository;
            _userService = userService;
        }

        #endregion

        #region Site Side 

        //Create Drug Alert Site Side
        public async Task<CreateDrugAlertSiteSideViewModelResult> CreateDrugAlertSide(CreateDrugAlertSiteSideViewModel model , ulong userId)
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
                DrugAlertDurationType= model.DrugAlertDurationType,
            };

            //Add Drug Alert To The Data Base
            await _drugAlertRepository.CreateDrugAler(entity);

            #endregion

            returModel.Result = true;
            returModel.CreatedDrugAlertId = entity.Id;

            return returModel;
        }

        #endregion
    }
}
