using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.SelfAssessment;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class SelfAssessmentService : ISelfAssessmentService
    {
        #region Ctor

        private readonly ISelfAssessmentRepository _selfAssessmentRepository;
        private readonly IUserService _userService;

        public SelfAssessmentService(ISelfAssessmentRepository selfAssessmentRepository, IUserService userService)
        {
            _selfAssessmentRepository = selfAssessmentRepository;
            _userService = userService;
        }

        #endregion

        #region Diabet Self Assessment 

        #region Site Side 

        //Process Diabet Self Assessment Site Side
        public async Task<decimal?> ProcessDiabetSelfAssessmentSiteSide(SelfAssessmentSiteSideViewModel model , ulong? userId)
        {
            #region If User Login

            if (userId.HasValue)
            {
                #region Get User By Id 

                var user = await _userService.GetUserById(userId.Value);
                if (user == null) return null;

                #endregion

                #region Log For Informations

                DiabetSelfAssessment selfAssessment = new DiabetSelfAssessment()
                {
                    A1C = model.A1C,
                    FBS = model.FBS,
                    Twohpp = model.Twohpp,
                    UserId = user.Id
                };

                //Add To The Data Base 
                await _selfAssessmentRepository.AddDiabetSelfAssessmentToTheDataBase(selfAssessment);

                #endregion
            }

            #endregion

            #region Proceess

            var pFBS = (((decimal)model.FBS - (decimal)100) * (decimal)100) / 25;

            var p2HPP = (((decimal)model.Twohpp - (decimal)140) * (decimal)100) / (decimal)59;

            var pA1C = ((model.A1C - (decimal)5.7) * (decimal)100) / (decimal)0.7;

            #region Conditions 

            if (pFBS >= p2HPP && pFBS >= pA1C)
            {
                return pFBS; 
            }

            if (p2HPP >= pFBS && p2HPP >= pA1C)
            {
                return p2HPP;
            }

            if (pA1C >= pFBS && pA1C >= p2HPP)
            {
                return pA1C;
            }

            #endregion

            #endregion

            return null;
        }

        #endregion

        #region User Panel 



        #endregion

        #endregion
    }
}
