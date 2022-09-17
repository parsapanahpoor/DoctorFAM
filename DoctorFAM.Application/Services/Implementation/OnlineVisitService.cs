using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using System;
using System.Collections.Generic;
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
        public async Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model)
        {
            var result = await _requestService.IsExistRequestByRequestId(model.RequestId);

            if (result == false) return CreatePatientResult.RequestIdNotFound;

            return CreatePatientResult.Success;
        }

        //Create Patient Detail For Online Visit Request
        public async Task<ulong> CreatePatientDetail(PatientViewModel patient)
        {
            #region Fill Entity

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

            return model.Id;
        }

        #endregion
    }
}
