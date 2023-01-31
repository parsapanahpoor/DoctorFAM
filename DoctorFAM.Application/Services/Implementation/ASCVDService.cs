using AngleSharp.Dom;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.ASCVD;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Database;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DoctorFAM.Application.Services.Implementation
{
    public class ASCVDService : IASCVDService
    {
        #region Ctor

        private readonly IASCVDRepository _ascvdRepository;
        private readonly IUserService _userService;

        public ASCVDService(IASCVDRepository ascvdRepository, IUserService userService)
        {
            _ascvdRepository = ascvdRepository;
            _userService = userService;
        }

        #endregion

        #region Site Side

        //Process ASCVD
        public async Task<double?> ProcessASCVD(ASCVDSiteSideViewModel model, ulong? userId)
        {
            #region Get User By Id 

            if (userId.HasValue)
            {
                var user = await _userService.GetUserById(userId.Value);
                if (user == null) return null;
            }

            #endregion

            #region Process Parameters

            double saa = 0;

            double mnxb = 0;

            double aaw = 0;
            double whw = 0;
            double aam = 0;
            double whm = 0;

            var tfH = (model.TreatmentforHypertension == true) ? 1 : 0;

            var inAge = Math.Log(model.Age, 2);

            var inTot = Math.Log(model.TotalCholesterol, 2);

            var inHdl = Math.Log(model.HDLCholesterol, 2);

            var trInSbp = Math.Log(model.SystolicBloodPressure) * tfH;

            var ntInSbp = Math.Log(model.SystolicBloodPressure) * tfH;

            var age2 = inAge * inAge;

            var ageTc = inAge * inTot;

            var ageHdl = inAge * inHdl;

            var ageTsbp = inAge * trInSbp;

            var ageNtSbp = inAge * ntInSbp;

            var ageSmoke = inAge * ((model.Smoker) ? 1 : 0);

            var ageDm = inAge * ((model.DiabetesMelitus) ? 1 : 0);

            #endregion

            #region Process

            if (model.Gender == Domain.Enums.Gender.Gender.Female && model.Race == Domain.Enums.Race.Race.AfricanAmericans)
            {
                saa = 0.95334;
                mnxb = 86.6081;

                aaw = (17.1141 * inAge) + (0.9396 * inTot) + (-18.9196 * inHdl) + (4.4748 * ageHdl) + (29.2907 * trInSbp)
                    + (-6.4321 * ageNtSbp) + (27.8197 * ntInSbp) + (-6.0873 * ageNtSbp) + (0.6908 * ((model.Smoker) ? 1 : 0))
                    + (0.8738 * ((model.DiabetesMelitus) ? 1 : 0));

                var predic = ((1 - Math.Pow(saa, Math.Exp(aaw - mnxb))) * 100);

                #region Add To The Data Base If User Login 

                if (userId.HasValue)
                {
                    var ascvd = new ASCVD()
                    {
                        Age = model.Age,
                        CreateDate = DateTime.Now,
                        DiabetesMelitus = model.DiabetesMelitus,
                        Gender = model.Gender,
                        HDLCholesterol = model.HDLCholesterol,
                        IsDelete = false,
                        Race = model.Race,
                        Smoker = model.Smoker,
                        SystolicBloodPressure = model.SystolicBloodPressure,
                        TotalCholesterol = model.TotalCholesterol,
                        TreatmentforHypertension = model.TreatmentforHypertension,
                        UserId = userId.Value,
                        CVDPredic = predic
                    };

                    if (predic < 5)
                    {
                        ascvd.ASCVDStatus = Domain.Enums.ASCVD.ASCVDStatus.LowRisk;
                    }
                    if (predic >= 5 && predic < 7.4)
                    {
                        ascvd.ASCVDStatus = Domain.Enums.ASCVD.ASCVDStatus.BorderLineRisk;
                    }
                    if (predic >= 7.5 && predic < 19.9)
                    {
                        ascvd.ASCVDStatus = Domain.Enums.ASCVD.ASCVDStatus.IntermediateRisk;
                    }
                    if (predic >= 20)
                    {
                        ascvd.ASCVDStatus = Domain.Enums.ASCVD.ASCVDStatus.HighRisk;
                    }

                    //Add To The Data Base 
                    await _ascvdRepository.AddAscvdToTheDataBase(ascvd);
                }

                #endregion

                return predic; 
            }

            if (model.Gender == Domain.Enums.Gender.Gender.Female && model.Race == Domain.Enums.Race.Race.White)
            {
                saa = 0.96652;
                mnxb = -29.1817;

                whw = (-29.799 * inAge) + (4.884 * age2) + (13.54 * inTot) + (-3.114 * ageTc) + (-13.578 * inHdl)
                    + (3.149 * ageHdl) + (2.019 * trInSbp) + (1.957 * ntInSbp) + (7.574 * ((model.Smoker) ? 1 : 0)) +
                    (-1.665 * ageSmoke) + (0.661 * ((model.DiabetesMelitus) ? 1 : 0));

                return ((1 - Math.Pow(saa, Math.Exp(whw - mnxb))) * 100);
            }

            if (model.Gender == Domain.Enums.Gender.Gender.Male && model.Race == Domain.Enums.Race.Race.AfricanAmericans)
            {
                saa = 0.89536;
                mnxb = 19.5425;

                aam = (2.469 * inAge) + (0.302 * inTot) + (-0.307 * inHdl) + (1.916 * trInSbp) + (1.809 * ntInSbp)
                      + (0.549 * ((model.Smoker) ? 1 : 0)) + (0.645 * ((model.DiabetesMelitus) ? 1 : 0));

                return ((1 - Math.Pow(saa, Math.Exp(aam - mnxb))) * 100);
            }

            if (model.Gender == Domain.Enums.Gender.Gender.Male && model.Race == Domain.Enums.Race.Race.White)
            {
                saa = 0.91436;
                mnxb = 61.1816;

                whm = (12.344 * inAge) + (11.853 * inTot) + (-2.664 * ageTc) + (-7.99 * inHdl) + (1.769 * ageHdl)
                      + (1.797 * trInSbp) + (1.764 * ntInSbp) + (7.837 * ((model.Smoker) ? 1 : 0)) + (-1.795 * ageSmoke) + (0.658 * ((model.DiabetesMelitus) ? 1 : 0));

                return ((1 - Math.Pow(saa, Math.Exp(whm - mnxb))) * 100);
            }

            #endregion

            return null;
        }

        #endregion
    }
}
