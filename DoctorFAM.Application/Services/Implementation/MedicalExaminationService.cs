using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using DoctorFAM.Domain.ViewModels.Common;
using DoctorFAM.Domain.ViewModels.Site.MedicalExamination;
using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Application.Services.Implementation
{
    public class MedicalExaminationService : IMedicalExaminationService
    {
        #region Ctor 

        private readonly IMedicalExaminationRepository _medicalExamination;
        private readonly IUserService _userService;
        private readonly IDoctorsService _doctorService;
        private readonly IOrganizationRepository _organizationRepository;

        public MedicalExaminationService(IMedicalExaminationRepository medicalExamination, IUserService userService
                                                , IDoctorsService doctorService, IOrganizationRepository organizationRepository)
        {
            _medicalExamination = medicalExamination;
            _userService = userService;
            _doctorService = doctorService;
            _organizationRepository = organizationRepository;
        }

        #endregion

        #region Admin Side 

        //Create Medical Examination From Admin 
        public async Task<bool> CreateMedicalExaminationFromAdmin(CreateMEdicalExaminationAdminSideViewModel model)
        {
            #region Fill Entity

            Domain.Entities.PriodicExamination.MedicalExamination entity = new Domain.Entities.PriodicExamination.MedicalExamination()
            {
                MedicalExaminationName = model.MEdicalExaminationName.SanitizeText(),
                PriodMonth = model.PriodMonth
            };

            #endregion

            #region Add To The Data Base 

            await _medicalExamination.CreateMedicalExamination(entity);

            #endregion

            return true;
        }

        //Filter Medical Examination 
        public async Task<FilterMedicalExaminationAdminSideViewModel> FilterMedicalExamination(FilterMedicalExaminationAdminSideViewModel filter)
        {
            return await _medicalExamination.FilterMedicalExamination(filter);
        }

        //Get Medical Examination By Id 
        public async Task<MedicalExamination?> GetMedicalExaminationById(ulong medicalExaminationId)
        {
            return await _medicalExamination.GetMedicalExaminationById(medicalExaminationId);
        }

        //Fill Edit Medical Examination Admin Side View Model 
        public async Task<EditMedicalExaminationAdminSideViewModel?> FillEditMedicalExaminationAdminSideViewModel(ulong medicalExaminationId)
        {
            #region Get Medical Examination  

            var medical = await GetMedicalExaminationById(medicalExaminationId);
            if (medical == null) return null;

            #endregion

            #region Fill View Model 

            EditMedicalExaminationAdminSideViewModel returnModel = new EditMedicalExaminationAdminSideViewModel()
            {
                ExaminationId = medical.Id,
                MedicalExaminationName = medical.MedicalExaminationName,
                PriodMonth = medical.PriodMonth
            };

            #endregion

            return returnModel;
        }

        //Edit Medical Examination Admin Side
        public async Task<bool> EditMedicalExaminationAdminSide(EditMedicalExaminationAdminSideViewModel model)
        {
            #region Get Medical Examination  

            var medical = await GetMedicalExaminationById(model.ExaminationId);
            if (medical == null) return false;

            #endregion

            #region Update Medical Examination Fields

            medical.MedicalExaminationName = model.MedicalExaminationName;
            medical.PriodMonth = model.PriodMonth;

            #endregion

            //Update Medical Examination Method 
            await _medicalExamination.EditMedicalExaminationAdminSide(medical);

            return true;
        }

        //Delete Medical Examination Admin Side 
        public async Task<bool> DeleteMedicalExaminationAdminSide(ulong medicalExamination)
        {
            #region Get Medical Examination  

            var medical = await GetMedicalExaminationById(medicalExamination);
            if (medical == null) return false;

            #endregion

            #region Delete Medical Examination Fields

            medical.IsDelete = true;

            #endregion

            //Update Medical Examination Method 
            await _medicalExamination.EditMedicalExaminationAdminSide(medical);

            return true;
        }

        #endregion

        #region Site Side 

        //Get List Of Medical Examinations
        public async Task<List<MedicalExamination>?> GetListOfMedicalExaminations()
        {
            return await _medicalExamination.GetListOfMedicalExaminations();
        }

        //Get List Of Medical Examinations With Select List 
        public async Task<List<SelectListViewModel>> GetListOfMedicalExaminationsWithSelectList()
        {
            return await _medicalExamination.GetListOfMedicalExaminationsWithSelectList();
        }

        //Create Priodic Examination From Site Side 
        public async Task<CreatePriodicEcaminationFromUser> CreatePriodicPatientExaminationSiteSideViewModel(CreatePriodicPatientExaminationSiteSideViewModel model, ulong userId)
        {
            #region Check User

            var user = await _userService.GetUserById(userId);
            if (user == null) return CreatePriodicEcaminationFromUser.UserNotfound;

            #endregion

            #region Get Medical Examination By Id 

            var medicalExamination = await GetMedicalExaminationById(model.MedicalExaminationId);
            if (medicalExamination == null) return CreatePriodicEcaminationFromUser.MedicalExaminationNotFound;

            #endregion

            #region Fill Entity

            PriodicPatientsExamination entity = new PriodicPatientsExamination()
            {
                MedicalExaminationId = medicalExamination.Id,
                LastPatientMedicalExamination = model.LastMedicalExamination.ToMiladiDateTime(),
                UserId = user.Id
            };

            //Next Examination Date Time 
            if (!string.IsNullOrEmpty(model.NextMedicalExamination))
            {
                if (model.NextMedicalExamination.ToMiladiDateTime() < DateTime.Now)
                {
                    return CreatePriodicEcaminationFromUser.TimeNotValid;
                }

                entity.NextExaminationDate = model.NextMedicalExamination.ToMiladiDateTime();
            }
            else
            {
                entity.NextExaminationDate = model.LastMedicalExamination.ToMiladiDateTime().AddMonths(medicalExamination.PriodMonth);
            }

            #region Check Doctor 

            if (!string.IsNullOrEmpty(model.DoctorUserName))
            {
                var doctor = await _userService.GetUserByUsername(model.DoctorUserName);

                #region Get Organization

                var organization = await _organizationRepository.GetDoctorOrganizationByUserId(doctor.Id);
                if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice || organization.OrganizationInfoState != Domain.Entities.Doctors.OrganizationInfoState.Accepted)
                {
                    return CreatePriodicEcaminationFromUser.DoctorNotFound;
                }

                #endregion

                //Fill Entity
                entity.DoctorUserId = organization.OwnerId;
            }

            #endregion

            #endregion

            #region Add Method 

            await _medicalExamination.AddPriodicExaminationFromSite(entity);

            #endregion

            return CreatePriodicEcaminationFromUser.Success;
        }

        //List Of User Priodic Patient Examination 
        public async Task<List<ListOfUserPriodicExaminationSiteSideViewModel>?> ListOfUserPriodicPatientExamination(ulong userId)
        {
            #region Check User

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get User Priodic Examination By UserId

            var userPriodicExaminations = await _medicalExamination.GetUserPriodicExaminationByUserId(userId);
            if (userPriodicExaminations == null) return null;

            #endregion

            #region Fill View Model 

            //Initial New Instance
            List<ListOfUserPriodicExaminationSiteSideViewModel> model = new List<ListOfUserPriodicExaminationSiteSideViewModel>();

            if (userPriodicExaminations != null && userPriodicExaminations.Any())
            {
                foreach (var priodic in userPriodicExaminations)
                {
                    model.Add(new ListOfUserPriodicExaminationSiteSideViewModel()
                    {
                        PriodicPatientsExaminations = priodic,
                        Doctors = ((priodic.DoctorUserId.HasValue) ? await _userService.GetUserById(priodic.DoctorUserId.Value) : null)
                    }); 
                }
            }

            #endregion

            return model;
        }

        //Get Priodic Examination By Priodic Examination Id
        public async Task<PriodicPatientsExamination?> GetPriodicExaminationByPriodicExaminationId(ulong priodicExaminationId)
        {
            return await _medicalExamination.GetPriodicExaminationByPriodicExaminationId(priodicExaminationId);
        }

        //Delete Priodic Examination From User
        public async Task<bool> DeletePriodicExaminationFromUser(ulong priodicExaminationId, ulong userId)
        {
            #region Get Priodic Examination 

            var priodicExamination = await GetPriodicExaminationByPriodicExaminationId(priodicExaminationId);
            if (priodicExamination == null || priodicExamination.UserId != userId) return false;

            #endregion

            #region Update State 

            priodicExamination.IsDelete = true;

            //Update Method
            await _medicalExamination.UpdatePriodicExamination(priodicExamination);

            #endregion

            return true;
        }

        //Check That Current User Has Any Priodic Examination In This Week
        public async Task<List<PriodicPatientsExamination>?> CheckThatCurrentUserHasAnyPriodicExaminationInThisWeek(ulong userId)
        {
            return await _medicalExamination.CheckThatCurrentUserHasAnyPriodicExaminationInThisWeek(userId);
        }

        #endregion

        #region User Panel

        #endregion
    }
}
