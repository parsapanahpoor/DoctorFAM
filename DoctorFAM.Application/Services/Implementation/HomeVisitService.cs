using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.Interfaces;
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

        public HomeVisitService(DoctorFAMDbContext context, IHomeVisitRepository homeVisit, IRequestService requestService ,
                                IUserService userService)
        {
            _context = context;
            _homeVisit = homeVisit;
            _requestService = requestService;
            _userService = userService;
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

        public async Task<bool> IsExistHomeVisitRequestById(ulong requestId)
        {
            return await _context.Requests.AnyAsync(p => p.Id == requestId
                                                    && p.RequestType == RequestType.HomeVisit
                                                    && !p.IsDelete);
        }

        public async Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model)
        {
            var result = await IsExistHomeVisitRequestById(model.RequestId);

            if (result == false) return CreatePatientResult.RequestIdNotFound;

            return CreatePatientResult.Success;
        }

        public async Task<ulong> CreatePatientDetail(PatientViewModel patient)
        {
            //Fill Entity
            Patient model = new Patient
            {
                RequestId = patient.RequestId,
                Age = patient.Age,
                Gender = patient.Gender,
                InsuranceType=patient.InsuranceType,
                NationalId = patient.NationalId,
                PatientName = patient.PatientName,
                PatientLastName = patient.PatientLastName,
                RequestDescription = patient.RequestDescription,
            };

            await _context.Patients.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }


        #endregion

        #region Site Side

        #endregion
    }
}
