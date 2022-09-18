using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Common;
using DoctorFAM.Domain.ViewModels.Site.OnlineVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class OnlineVisitService : IOnlineVisitService
    {
        #region Ctor

        private readonly IOnlineVisitRepository _onlineVisitRepository;
        private readonly IUserService _userService;
        private readonly IRequestService _requestService;
        private readonly IPatientService _patientService;

        public OnlineVisitService(IOnlineVisitRepository onlineVisitRepository, IUserService userService, IRequestService requestService, IPatientService patientService)
        {
            _onlineVisitRepository = onlineVisitRepository;
            _userService = userService;
            _requestService = requestService;
            _patientService = patientService;
        }

        #endregion

        #region Site Side 

        //Create Online Visit Request
        public async Task<ulong?> CreateOnlineVisitRequest(ulong userId)
        {
            #region User Validation

            if (await _userService.GetUserById(userId) == null)
            {
                return null;
            }

            #endregion

            #region Fill Entitie

            Random key = new Random();

            Request request = new Request()
            {
                RequestType = Domain.Enums.RequestType.RequestType.OnlineVisit,
                RequestState = Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UserId = userId,
                BusinessKey = (ulong)key.Next(0, 1000000000)
            };

            #endregion

            #region Add Request Method

            await _requestService.AddRequest(request);

            #endregion

            return request.Id;
        }

        //Validation For Create Patient 
        public async Task<CreatePatientResult> ValidateCreatePatient(PatientDetailForOnlineVisitViewModel model)
        {
            var result = await _requestService.IsExistRequestByRequestId(model.RequestId);

            if (result == false) return CreatePatientResult.RequestIdNotFound;

            return CreatePatientResult.Success;
        }

        //Create Patient Detail For Online Visit Request
        public async Task<ulong> CreatePatientDetail(PatientDetailForOnlineVisitViewModel patient)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(patient.UserId);
            if (user == null) return 0;

            #endregion

            #region Fill Entity Patient

            Patient model = new Patient
            {
                RequestId = patient.RequestId,
                Age = patient.Age,
                Gender = patient.Gender,
                InsuranceType = patient.InsuranceType,
                NationalId = patient.NationalId,
                PatientName = patient.PatientName.SanitizeText(),
                PatientLastName = patient.PatientLastName.SanitizeText(),
                RequestDescription = " درخواست برای ویزیت آنلاین ",
                UserId = patient.UserId
            };

            #endregion

            #region Add Patient

            await _patientService.AddPatient(model);

            #endregion

            #region Fill Paitient Request Detail

            PatienAddressViewModel request = new PatienAddressViewModel()
            {
                RequestId = patient.RequestId,
                PatientId = model.Id,
                CountryId = patient.CountryId,
                StateId = patient.StateId,
                CityId = patient.CityId,
                Mobile = user.Mobile,
                Phone = user.Mobile,
                Vilage = null,
                Distance = 0,
                FullAddress = " Online Visit "
            };

            #endregion

            #region Add Patient Request Detail 

            var res = await _requestService.CreatePatientRequestDetail(request);
            if (res == CreatePatientAddressResult.Failed || res == CreatePatientAddressResult.LocationNotFound
                || res == CreatePatientAddressResult.RquestNotFound || res == CreatePatientAddressResult.PatientNotFound)
            {
                return 0;
            }

            #endregion

            return model.Id;
        }

        //Add Online Vist Request 
        public async Task<bool> AddOnlineVisitRequest(OnlineVisitRquestDetailViewModel onlineVisitRquest, ulong userId)
        {
            #region Get Request By Id

            var request = await _requestService.GetRequestById(onlineVisitRquest.RequestId);
            if (request == null || request.UserId != userId || request.RequestState != Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser)
            {
                return false;
            }

            #endregion

            #region Get Patient By Id

            var patient = await _patientService.GetPatientById(onlineVisitRquest.PatientId);
            if (patient == null || patient.Id != request.PatientId)
            {
                return false;
            }

            #endregion

            #region Add Online Visit Request 

            #region Fill Online Visit Detail  Model 

            var model = new OnlineVisitRequestDetail()
            {
                OnlineVisitRequestDescription = onlineVisitRquest.OnlineVisitRequestDescription,
                OnlineVisitRequestType = onlineVisitRquest.OnlineVisitRequestType,
                RequestId = onlineVisitRquest.RequestId,
            };

            #endregion

            #region Add File

            if (onlineVisitRquest.OnlineVisitRequestFile != null)
            {
                if (Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName).ToLower() == ".jpg"
                        && Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName).ToLower() == ".png"
                        && Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName).ToLower() == ".jpeg")
                {
                    var res = onlineVisitRquest.OnlineVisitRequestFile.IsImage();
                    if (!res)
                    {
                        return false;
                    }
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(onlineVisitRquest.OnlineVisitRequestFile.FileName);

                if (!Directory.Exists(PathTools.OnlineVisitRequestFilePathServer))
                    Directory.CreateDirectory(PathTools.OnlineVisitRequestFilePathServer);

                string OriginPath = PathTools.OnlineVisitRequestFilePathServer + imageName;

                using (var stream = new FileStream(OriginPath, FileMode.Create))
                {
                    if (!Directory.Exists(OriginPath)) onlineVisitRquest.OnlineVisitRequestFile.CopyTo(stream);
                }

                model.OnlineVisitRequestFile = imageName;
            }

            #endregion

            await _onlineVisitRepository.AddOnlineRequestDetail(model);

            #endregion

            return true;
        }

        #endregion
    }
}
