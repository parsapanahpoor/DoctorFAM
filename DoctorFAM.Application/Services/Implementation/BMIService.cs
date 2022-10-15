using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.Dapper;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class BMIService : IBMIService
    {
        #region Ctor

        private readonly IBMIRepository _bmiRepository;
        private readonly IBMIRepositoryDapper _bmiDapper;
        private readonly IUserService _userService;

        public BMIService(IBMIRepository bmiRepository, IUserService userService , IBMIRepositoryDapper bmiDapper)
        {
            _bmiRepository = bmiRepository;
            _userService = userService;
            _bmiDapper = bmiDapper;
        }

        #endregion

        #region Site Side

        //Process BMI From Site With User Informations 
        public async Task<BMI> ProcessBMI(BMIViewModel bmi, ulong? userId)
        {
            #region Proccess BMI Result 

            double height = (((double)bmi.Height / (double)100));

            double bmiResult = ((double)bmi.Weight) / (height * height);

            #endregion

            #region Fill Entity

            BMI model = new BMI()
            {
                CreateDate = DateTime.Now,
                Height = bmi.Height,
                Weight = bmi.Weight,
                BMIResult = (int)bmiResult,
            };

            #endregion

            #region BMI Result State 

            if (bmiResult < 18) model.BMIResultState = Domain.Enums.Diabet_Results.BMIResult.Underweight;

            if (bmiResult > 18 && bmiResult < 24) model.BMIResultState = Domain.Enums.Diabet_Results.BMIResult.Appropriate;

            if (bmiResult > 25 && bmiResult < 29) model.BMIResultState = Domain.Enums.Diabet_Results.BMIResult.Overweight;

            if (bmiResult > 30 && bmiResult < 39) model.BMIResultState = Domain.Enums.Diabet_Results.BMIResult.fat;

            if (bmiResult > 40) model.BMIResultState = Domain.Enums.Diabet_Results.BMIResult.ExcessiveObesity;

            #endregion

            #region If User is Loged In 

            if (userId != null)
            {
                if (await _userService.IsExistUserById(userId.Value))
                {
                    var user = await _userService.GetUserById(userId.Value);

                    model.UserId = userId;
                }
            }

            #endregion

            #region Add Method

            //Add Method By EF Core
            //await _bmiRepository.CreateBMI(model);

            //Add Method By Dapper
            _bmiDapper.CreateBMI(model);

            #endregion

            return model;
        }

        //Process GFR From Site With User Informations 
        public async Task<decimal> ProcessGFR(GFRViewModel gfr, ulong? userId)
        {
            #region Proccess GFR Result 

            var header = ((140 - gfr.Age) * gfr.Weight) * 10;

            var footer = (72 * (gfr.Keratenin * 10));

            var res = (header / footer) * 100;

            if (gfr.Gender == Domain.Enums.Gender.Gender.Female)
            {
                res = (res * 85) / 100;
            }

            #endregion

            #region Fill Entity

            GFR model = new GFR()
            {
                CreateDate = DateTime.Now,
                Weight = gfr.Weight,
                Keratenin = (int)gfr.Keratenin,
                Gender = gfr.Gender,
                GFRResult = (int)res,
                Age = gfr.Age ,
            };

            #endregion

            #region GFR Result State 

            if (res < 1500) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.DarkRed;
            if (1500 < res && res <= 3000) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Red;
            if (3000 < res && res <= 4500) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Orange;
            if (4500 < res && res <= 6000) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Yellow;
            if (6000 < res && res <= 9000) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Green;
            if (9000 < res && res <= 12000) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.DarkGreen;

            #endregion

            #region If User is Loged In 

            if (userId != null)
            {
                if (await _userService.IsExistUserById(userId.Value))
                {
                    var user = await _userService.GetUserById(userId.Value);

                    model.UserId = userId;
                }
            }

            #endregion

            #region Add Method

            //Add EF Core Method
            //await _bmiRepository.CreateGFR(model);

            //Add Dapper Method 
            await _bmiDapper.CreateGFR(model);

            #endregion

            return res;
        }

        #endregion

        #region User Panel 

        //Get List Of User BMI History
        public async Task<List<BMI>?> GetListOfUserBMIHistory(ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if(user == null) return null;

            #endregion

            #region Get User BMI History

            //EF Core
            //var model = await _bmiRepository.GetUserBMIHistory(userId);

            //Dapper
            var model = await _bmiDapper.GetUserBMIHistory(userId);

            #endregion

            return model;
        }

        //Get List Of User GFR History
        public async Task<List<GFR>?> GetListOfUserGFRHistory(ulong userId)
        {
            #region Get User By Id 

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get User GFR History

            //EF Core
            //var model = await _bmiRepository.GetUserGFRHistory(userId);

            //Dapper
            var model = await _bmiDapper.GetUserGFRHistory(userId);

            #endregion

            return model;
        }

        #endregion
    }
}
