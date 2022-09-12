using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class FamilyDoctorService : IFamilyDoctorService
    {
        #region Ctor

        private readonly IFamilyDoctorRepository _familyDoctor;
        private readonly IDoctorsService _doctorService;
        private readonly IOrganizationService _organizationService;
        private readonly IUserService _userService;

        public FamilyDoctorService(IFamilyDoctorRepository familyDoctor , IDoctorsService doctorServicec, IOrganizationService organizationService
                                    ,IUserService userService)
        {
            _familyDoctor = familyDoctor;
            _doctorService = doctorServicec;
            _organizationService = organizationService;
            _userService = userService;
        }

        #endregion

        #region User Panel 

        //Is Exist Any Family Doctor For Patient
        public async Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId)
        {
            return await _familyDoctor.IsExistAnyFamilyDoctorForPatient(userId);
        }

        //Get User Selected Family Doctor 
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId)
        {
            return await _familyDoctor.GetUserSelectedFamilyDoctorByUserId(userId);
        }

        //Choosing A Doctor Family
        public async Task<bool> ChoosingFamilyDoctor(ulong doctorUserId , ulong patientId)
        {
            #region Get Doctor By Doctor Id

            var doctor = await _doctorService.GetDoctorByUserId(doctorUserId);
            if (doctor == null) return false;

            #endregion

            #region Get Users

            var doctorUser = await _userService.GetUserById(doctor.UserId);
            if (doctorUser == null) return false;

            var patient = await _userService.GetUserById(patientId);
            if (patient == null) return false; 

            #endregion

            #region Check Validation 

            #region Organization Validation 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctor.UserId);
            if (organization == null) return false;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

            #endregion

            #region Validation Doctor Interest

            var getDoctorInterest = await _doctorService.GetDoctorSelectedInterests(doctor.Id);
            if (!getDoctorInterest.Any(p => !p.IsDelete && p.InterestId == 3)) return false;

            #endregion

            #region Get Get User Selected Family Doctor By User Id

            var userSelectedFamilyDoctor = await GetUserSelectedFamilyDoctorByUserId(patientId);
            if (userSelectedFamilyDoctor != null
                                && (userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm
                                                    || userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted))
            {
                return false;
            }

            if (userSelectedFamilyDoctor != null && userSelectedFamilyDoctor.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline)
            {
                await _familyDoctor.RemoveFamilyDoctorForThisPatient(userSelectedFamilyDoctor);
            }

            #endregion

            #endregion

            #region Add Family Doctor For Patient Method 

            UserSelectedFamilyDoctor model = new UserSelectedFamilyDoctor()
            {
                CreateDate = DateTime.Now,
                DoctorId = doctor.UserId,
                PatientId = patientId,
                FamilyDoctorRequestState = Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.WaitingForConfirm,
                IsDelete = false,
                RejectDescription = null
            };

            await _familyDoctor.AddFamilyDoctorForThisPatient(model);

            #endregion

            return true;
        }

        #endregion
    }
}
