using DoctorFAM.Application.Interfaces;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeVisit;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class HomeVisitService : IHomeVisitService
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public IHomeVisitRepository _homeVisit;

        public IRequestService _requestService;

        public IUserService _userService;

        public IPatientService _patientService;

        private readonly ILocationService _locationServoce;

        public HomeVisitService(DoctorFAMDbContext context, IHomeVisitRepository homeVisit, IRequestService requestService,
                                IUserService userService, IPatientService patientService, ILocationService locationServoce)
        {
            _context = context;
            _homeVisit = homeVisit;
            _requestService = requestService;
            _userService = userService;
            _patientService = patientService;
            _locationServoce = locationServoce;
        }

        #endregion

        #region Home Visit Methods 

        public async Task<ulong?> CreateHomeVisitRequest(ulong userId)
        {
            #region User Validation

            if (await _userService.GetUserById(userId) == null)
            {
                return null;
            }

            #endregion

            #region Fill Entitie

            Request request = new Request()
            {
                RequestType = Domain.Enums.RequestType.RequestType.HomeVisit,
                RequestState = Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser,
                CreateDate = DateTime.Now,
                IsDelete = false,
                UserId = userId
            };

            #endregion

            #region Add Request Method

            await _requestService.AddRequest(request);

            #endregion

            return request.Id;
        }

        public async Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model)
        {
            var result = await _requestService.IsExistRequestByRequestId(model.RequestId);

            if (result == false) return CreatePatientResult.RequestIdNotFound;

            return CreatePatientResult.Success;
        }

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
                RequestDescription = patient.RequestDescription.SanitizeText(),
                UserId = patient.UserId
            };

            #endregion

            #region MyRegion

            await _patientService.AddPatient(model);

            #endregion

            return model.Id;
        }


        #endregion

        #region Site Side

        #endregion

        #region Admin Side

        public async Task<FilterHomeVisistViewModel> FilterHomeVisit(FilterHomeVisistViewModel filter)
        {
            return await _homeVisit.FilterHomeVisit(filter);
        }

        public async Task<HomeVisitRequestDetailViewModel> ShowHomeVisitDetail(ulong requestId)
        {
            #region Get request By Id

            var request = await GetRquestForHomeVisitById(requestId);

            if (request == null) return null;

            #endregion

            #region Get Patient By Id 

            var patient = await GetPatientByRequestId(requestId);

            #endregion

            #region Get Patient Request Detail 

            var requestDetail = await GetRequestPatientDetailByRequestId(requestId);

            #endregion

            #region Fill View Model

            HomeVisitRequestDetailViewModel model = new HomeVisitRequestDetailViewModel()
            {
                Email = request.User.Email,
                Username = request.User.Username,
                Mobile = request.User.Mobile,
                RequestState = request.RequestState,
                PatientName = patient?.PatientName,
                PatientLastName = patient?.PatientLastName,
                NationalId = patient?.NationalId,
                Gender = patient?.Gender,
                Age = patient?.Age,
                InsuranceType = patient?.InsuranceType,
                RequestDescription = patient?.RequestDescription,
                Vilage = requestDetail?.Vilage,
                FullAddress = requestDetail?.FullAddress,
                Phone = requestDetail?.Phone,
                RequestDetailMobile = requestDetail?.Mobile,
                Distance = requestDetail?.Distance
            };

            #endregion

            #region Get Location

            if (requestDetail != null)
            {
                var country = await _locationServoce.GetLocationById(requestDetail.CountryId);

                var state = await _locationServoce.GetLocationById(requestDetail.StateId);

                var city = await _locationServoce.GetLocationById(requestDetail.CityId);

                model.Country = country.UniqueName;

                model.State = state.UniqueName;

                model.City = city.UniqueName;
            }

            #endregion

            return model;
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _homeVisit.GetPatientByRequestId(requestId);
        }

        public async Task<Request?> GetRquestForHomeVisitById(ulong requestId)
        {
            return await _homeVisit.GetRquestForHomeVisitById(requestId);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _homeVisit.GetRequestPatientDetailByRequestId(requestId);
        }

        #endregion
    }
}
