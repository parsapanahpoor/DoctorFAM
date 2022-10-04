using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.BMI;
using DoctorFAM.Domain.Interfaces;
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

        private readonly IUserService _userService;

        public BMIService(IBMIRepository bmiRepository, IUserService userService)
        {
            _bmiRepository = bmiRepository;
            _userService = userService;
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

            await _bmiRepository.CreateBMI(model);

            #endregion

            return model;
        }

        //Process GFR From Site With User Informations 
        public async Task<GFR> ProcessGFR(GFRViewModel gfr, ulong? userId)
        {
            #region Proccess GFR Result 

            var header = ((140 - gfr.Age) * gfr.Weight);

            var footer = (72 * gfr.Keratenin);

            var res = header / footer;

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
                Keratenin = gfr.Keratenin,
                Gender = gfr.Gender,
                GFRResult = res,
                Age = gfr.Age ,
            };

            #endregion

            #region GFR Result State 

            if (res < 15) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.DarkRed;
            if (15 < res && res <= 30) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Red;
            if (30 < res && res <= 45) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Orange;
            if (45 < res && res <= 60) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Yellow;
            if (60 < res && res <= 90) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.Green;
            if (90 < res && res <= 120) model.GFRtResultState = Domain.Enums.Diabet_Results.GFRResult.DarkGreen;

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

            await _bmiRepository.CreateGFR(model);

            #endregion

            return model;
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

            var model = await _bmiRepository.GetUserBMIHistory(userId);

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

            var model = await _bmiRepository.GetUserGFRHistory(userId);

            #endregion

            return model;
        }

        #endregion
    }
}
