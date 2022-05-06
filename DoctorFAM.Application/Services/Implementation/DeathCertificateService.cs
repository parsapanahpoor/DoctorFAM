using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Enums.RequestType;
using DoctorFAM.Domain.ViewModels.Site.Patient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DeathCertificateService : IDeathCertificateService
    {
        #region Ctor
        public DoctorFAMDbContext _context { get; set; }

        public DeathCertificateService(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<ulong> CreateDeathCertificateRequest(string? userName)
        {
            //Fill Entitie
            Request request = new Request()
            {
                RequestType = Domain.Enums.RequestType.RequestType.DeathCertificate,
                CreateDate = DateTime.Now,
                IsDelete = false
            };

            #region Get User By userName

            var user = await _context.Users.FirstOrDefaultAsync(p => p.Username == userName && !p.IsDelete);

            if (user != null)
            {
                request.UserId = user.Id;
            }

            #endregion

            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();

            return request.Id;
        }

        public async Task<bool> IsExistDeathCertificateRequestById(ulong requestId)
        {
            return await _context.Requests.AnyAsync(p => p.Id == requestId
                                                   && p.RequestType == RequestType.DeathCertificate
                                                   && !p.IsDelete);
        }

        public async Task<CreatePatientResult> ValidateCreatePatient(PatientViewModel model)
        {
            var result = await IsExistDeathCertificateRequestById(model.RequestId);

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
                InsuranceType = patient.InsuranceType,
                NationalId = patient.NationalId,
                PatientName = patient.PatientName,
                PatientLastName = patient.PatientLastName,
                RequestDescription = patient.RequestDescription,
            };

            await _context.Patients.AddAsync(model);
            await _context.SaveChangesAsync();

            return model.Id;
        }

       

       
    }
}
