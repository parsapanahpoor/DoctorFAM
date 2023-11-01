using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem.VIPPatient;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Education;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Honor;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Service;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkingAddress;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.Admin.FamilyDoctor;
using DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Speciality;
using System.Data;
using DoctorFAM.Domain.ViewModels.Site.Diabet;
using DoctorFAM.Domain.ViewModels.Site.BloodPressure;
using DoctorFAM.Domain.ViewModels.Admin.Doctors;
using DoctorFAM.Domain.Interfaces.Dapper;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.UsersInDoctorPopulationCovered;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Entities.SendSMS.FromDoctrors;
using DoctorFAM.Domain.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using DoctorFAM.Domain.ViewModels.Admin.Dashboard;
using DoctorFAM.Domain.ViewModels.Admin.SendSMS;
using System.Numerics;
using DoctorFAM.Domain.ViewModels.DoctorPanel.SendSMS;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DoctorsService : IDoctorsService
    {
        #region Ctor

        private readonly IDoctorsRepository _doctorRepository;
        private readonly IUserService _userService;
        private readonly IOrganizationService _organizationService;
        private readonly IWorkAddressService _workAddress;
        private readonly ILocationRepository _locationRepository;
        private readonly IReservationService _reservationService;
        private readonly ISMSService _smsservice;
        private readonly IResumeService _resumeService;
        private readonly ISpecialityRepository _specialityRepository;
        private readonly IUserRepositoryDapper _userRepositoryDapper;
        private readonly IFamilyDoctorRepository _familyDoctorService;
        private readonly ISiteSettingService _siteSetting;

        public DoctorsService(IDoctorsRepository doctorRepository, IUserService userService, IOrganizationService organizationService,
                                IWorkAddressService workAddress, ILocationRepository locationRepository
                                    , IReservationService reservationService, ISMSService smsservice, IResumeService resumeService, ISpecialityRepository specialityRepository
                                        , IUserRepositoryDapper userRepositoryDapper, IFamilyDoctorRepository familyDoctorService
                                            , ISiteSettingService siteSetting)
        {
            _doctorRepository = doctorRepository;
            _userService = userService;
            _organizationService = organizationService;
            _workAddress = workAddress;
            _locationRepository = locationRepository;
            _reservationService = reservationService;
            _smsservice = smsservice;
            _resumeService = resumeService;
            _specialityRepository = specialityRepository;
            _userRepositoryDapper = userRepositoryDapper;
            _familyDoctorService = familyDoctorService;
            _siteSetting = siteSetting;
        }

        #endregion

        #region Doctors Panel Side

        //List Of Doctor Send SMS Request Doctor Side View Model
        public async Task<List<ListOfDoctorSendSMSRequestDoctorSideViewModel>?> ListOfDoctorSendSMSRequestDoctorSideViewModel(ulong userId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice
                || organization.OrganizationInfoState != OrganizationInfoState.Accepted)
            {
                return null;
            }

            #endregion

            return await _doctorRepository.ListOfDoctorSendSMSRequestDoctorSideViewModel(organization.OwnerId);
        }

        //Fill Send SMS To Patient Detail Doctor Panel View Model
        public async Task<SendSMSToPatientDetailDoctorPanelViewModel?> SendSMSToPatientDetailDoctorPanelViewModel(ulong requestId, ulong currentUserId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(currentUserId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice
                || organization.OrganizationInfoState != OrganizationInfoState.Accepted)
            {
                return null;
            }

            #endregion

            #region Get Request For Send SMS From Doctor

            var request = await _doctorRepository.GetRequestForSendSMSFromDoctorToPatientByRequestId(requestId);
            if (request == null) return null;

            #endregion

            #region Get Doctor By User Id

            var doctor = await GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return null;

            #endregion

            #region Get Doctor SMS Percentage

            var smsCount = await _doctorRepository.GetDoctorSMSPercentageDoctorsInfoByDoctorId(doctor.UserId);

            #endregion

            #region Fill Instance

            SendSMSToPatientDetailDoctorPanelViewModel returnModel = new SendSMSToPatientDetailDoctorPanelViewModel()
            {
                RejectSMSDescription = request.DeclineDescription,
                RequestId = request.Id,
                DoctorUserId = request.DoctorUserId,
                PatientId = await _doctorRepository.GetListUserThatDoctorWantToSendThemSMS(requestId),
                SMSBody = request.SMSText,
                CountOfUserPercentageSMS = smsCount,
                SendSMSFromDoctorState = request.SendSMSFromDoctorState
            };

            #endregion

            return returnModel;
        }

        //Fill Send SMS To Patient View Model
        public async Task<SendSMSToPatientViewModel?> FillSendSMSToPatientViewModel(ulong userId, List<ulong> usersId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice
                || organization.OrganizationInfoState != OrganizationInfoState.Accepted)
            {
                return null;
            }

            #endregion

            #region Get Doctor By User Id

            var doctor = await GetDoctorByUserId(userId);
            if (doctor == null) return null;

            #endregion

            #region Get Doctor SMS Percentage

            var smsCount = await _doctorRepository.GetDoctorSMSPercentageDoctorsInfoByDoctorId(doctor.Id);

            #endregion

            return new SendSMSToPatientViewModel()
            {
                DoctorUserId = userId,
                CountOfUserPercentageSMS = smsCount,
                PatientId = usersId
            };
        }

        //Get Diabet Consualtant Resume By Id
        public async Task<DiabetConsultantsResume?> GetDiabetConsualtantResumeById(ulong resumeId)
        {
            return await _doctorRepository.GetDiabetConsualtantResumeById(resumeId);
        }

        //Delete Diabet Consultant Resume By Resume Id
        public async Task<bool> DeleteDiabetConsultantResumeByResumeId(ulong resumeId, ulong userId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return false;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Get Diabet Consultant Resume By Id 

            var resume = await _doctorRepository.GetDiabetConsualtantResumeById(resumeId);
            if (resume == null) return false;
            if (resume.UserId != organization.OwnerId) return false;

            #endregion

            #region Delete Resume

            resume.IsDelete = true;

            #region Resume File 

            if (resume.ResumePicture != null)
            {
                if (!string.IsNullOrEmpty(resume.ResumePicture))
                {
                    resume.ResumePicture.DeleteImage(PathTools.DiabetConsultantResumeFilesPathServer, PathTools.DiabetConsultantResumeFilesPathThumbServer);
                }
            }

            #endregion

            //Update Diabet Consultant Resume 
            await _doctorRepository.UpdateDiabetConsultantResume(resume);

            #endregion

            #region Update Organization 

            organization.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            //Update Method 
            await _organizationService.UpdateOrganization(organization);

            #endregion

            return true;
        }

        //Delete Blood Pressure Consultant Resume By Resume Id
        public async Task<bool> DeleteBloodPressureConsultantResumeByResumeId(ulong resumeId, ulong userId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return false;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Get Blood Pressure Consultant Resume By Id 

            var resume = await _doctorRepository.GetBloodPressureConsualtantResumeById(resumeId);
            if (resume == null) return false;
            if (resume.UserId != organization.OwnerId) return false;

            #endregion

            #region Delete Resume

            resume.IsDelete = true;

            #region Resume File 

            if (resume.ResumePicture != null)
            {
                if (!string.IsNullOrEmpty(resume.ResumePicture))
                {
                    resume.ResumePicture.DeleteImage(PathTools.BloodPressureConsultantResumeFilesPathServer, PathTools.BloodPressureConsultantResumeFilesPathThumbServer);
                }
            }

            #endregion

            //Update Blood Pressure Consultant Resume 
            await _doctorRepository.UpdateBloodPressureConsultantResume(resume);

            #endregion

            #region Update Organization 

            organization.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            //Update Method 
            await _organizationService.UpdateOrganization(organization);

            #endregion

            return true;
        }

        //Upload Doctor Diabet Consultant Resume File 
        public async Task<bool> UploadDoctorDiabetConsultantResumeFile(ulong userId, string? description, IFormFile? resumePicture)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return false;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Upload Resume 

            DiabetConsultantsResume model = new DiabetConsultantsResume()
            {
                CreateDate = DateTime.Now,
                Description = description,
                UserId = organization.OwnerId,
                IsDelete = false,
            };

            #region Resume File  

            if (resumePicture != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(resumePicture.FileName);
                resumePicture.AddImageToServer(imageName, PathTools.DiabetConsultantResumeFilesPathServer, 270, 270, PathTools.DiabetConsultantResumeFilesPathThumbServer);
                model.ResumePicture = imageName;
            }

            #endregion

            //Add To The Data Base 
            await _doctorRepository.UploadResumeFroDiabetConsultant(model);

            #endregion

            #region Update Organization 

            organization.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            //Update MEthod 
            await _organizationService.UpdateOrganization(organization);

            #endregion

            return true;
        }

        //Upload Doctor Blood Pressure Consultant Resume File 
        public async Task<bool> UploadDoctorBloodPressureConsultantResumeFile(ulong userId, string? description, IFormFile? resumePicture)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return false;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Upload Resume 

            BloodPressureConsultantResume model = new BloodPressureConsultantResume()
            {
                CreateDate = DateTime.Now,
                Description = description,
                UserId = organization.OwnerId,
                IsDelete = false,
            };

            #region Resume File  

            if (resumePicture != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(resumePicture.FileName);
                resumePicture.AddImageToServer(imageName, PathTools.BloodPressureConsultantResumeFilesPathServer, 270, 270, PathTools.BloodPressureConsultantResumeFilesPathThumbServer);
                model.ResumePicture = imageName;
            }

            #endregion

            //Add To The Data Base 
            await _doctorRepository.UploadResumeFroBloodPressureConsultant(model);

            #endregion

            #region Update Organization 

            organization.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            //Update MEthod 
            await _organizationService.UpdateOrganization(organization);

            #endregion

            return true;
        }

        //Get Doctor Diabet Consultant Resumes By Doctor User Id 
        public async Task<List<DiabetConsultantsResume>?> GetDoctorDiabetConsultantResumesByDoctorUserId(ulong doctorUserId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(doctorUserId);
            if (doctor == null) return null;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            return await _doctorRepository.GetDoctorDiabetConsultantResumesByDoctorUserId(organization.OwnerId);
        }

        //Get Doctor Blood Pressure Consultant Resumes By Doctor User Id 
        public async Task<List<BloodPressureConsultantResume>?> GetDoctorBloodPressureConsultantResumesByDoctorUserId(ulong doctorUserId)
        {
            #region Get Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(doctorUserId);
            if (doctor == null) return null;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            return await _doctorRepository.GetDoctorBloodPressureConsultantResumesByDoctorUserId(organization.OwnerId);
        }

        //Fill Diabet Consultatn Resume View Model
        public async Task<UploadDiabetConsultatntDoctorSideViewModel?> FillDiabetConsultatnResumeViewModel(ulong userId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return null;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            #region Fill Model 

            return new UploadDiabetConsultatntDoctorSideViewModel()
            {
                DiabetConsultantsResumes = await _doctorRepository.GetDoctorDiabetConsultantResumesByDoctorUserId(organization.OwnerId)
            };

            #endregion
        }

        //Fill Blood Pressure Consultatn Resume View Model
        public async Task<UploadBloodPressureConsultatntDoctorSideViewModel?> FillBloodPressureConsultatnResumeViewModel(ulong userId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return null;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            #region Fill Model 

            return new UploadBloodPressureConsultatntDoctorSideViewModel()
            {
                BloodPressureConsultantResume = await _doctorRepository.GetDoctorBloodPressureConsultantResumesByDoctorUserId(organization.OwnerId)
            };

            #endregion
        }

        //Update Doctor Speciality Selected
        public async Task<bool> UpdateDoctorSpecialitySelected(List<ulong>? speciallities, ulong userId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return false;

            #endregion

            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization == null || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Update Specialities

            // remove all Doctor Selected Specialities

            var doctrorLastSpecialities = await _specialityRepository.GetDoctoSelectedSpecialitiesByUserId(doctor.Id);

            if (doctrorLastSpecialities != null && doctrorLastSpecialities.Any()) await _specialityRepository.RemoveListOfUserSeletedSpecialities(doctrorLastSpecialities);

            // add Specialities To The Doctor Choices
            if (speciallities != null && speciallities.Any())
            {
                foreach (var specialityId in speciallities)
                {
                    if (await _specialityRepository.IsExistSpecialityBySpecialityId(specialityId))
                    {
                        var specsh = new DoctorFAM.Domain.Entities.Speciality.DoctorSelectedSpeciality
                        {
                            SpecialityId = specialityId,
                            DoctorId = doctor.Id,
                        };

                        await _specialityRepository.AddDoctorSelectedSpeciality(specsh);
                    }
                }
                await _specialityRepository.Savechanges();
            }

            #endregion

            #region Update Organization State 

            organization.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            await _organizationService.UpdateOrganization(organization);

            #endregion

            return true;
        }

        //Get Doctor Lable Of Sickness By Doctor User Id 
        public async Task<List<DoctorsLabelsForVIPInsertedDoctor>?> GetDoctorLableOfSicknessByDoctorUserId(ulong doctorUserId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            return await _doctorRepository.GetDoctorLableOfSicknessByDoctorUserId(doctorUserId);
        }

        //Show List Of SMS That Send From Doctor To Patient Incomes From Parsa System
        public async Task<List<LogForSendSMSToUsersIncomeFromParsa>?> ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            #region Initial List 

            return await _doctorRepository.ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(id, organization.OwnerId);

            #endregion
        }

        //Show List Of SMS That Send From Doctor To VIP Patient Incomes From Parsa System
        public async Task<List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem>?> ShowListOfSMSThatSendFromDoctorToVIPPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            #region Check User In Doctor VIP List 

            if (!await _doctorRepository.IsExistAnyUserVIPByThisIdInCurrentDoctorSystemFile(organization.OwnerId, id))
            {
                return null;
            }

            #endregion

            #region Initial List 

            return await _doctorRepository.ShowListOfSMSThatSendFromDoctorToVIPPatientIncomesFromParsaSystem(id);

            #endregion
        }

        //Is Exist Any User From Parsa System In Doctor Parsa System List
        public async Task<bool> IsExistAnyUserFromParsaSystemInDoctorParsaSystemList(ulong parsaSystemUserId, ulong doctorUserId)
        {
            return await _doctorRepository.IsExistAnyUserFromParsaSystemInDoctorParsaSystemList(parsaSystemUserId, doctorUserId);
        }

        //Send SMS From Doctor To The Users That Income From Parsa Sysem 
        public async Task<bool> SendSMSFromDoctorToTheUsersThatIncomeFromParsaSysem(SendSMSToPatientViewModel model)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(model.DoctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Model State Validation 

            if (model == null || model.PatientId.Count() == 0 || !model.PatientId.Any())
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.SMSBody))
            {
                return false;
            }

            //Check Patients Id That Exist In Doctor Population
            foreach (var item in model.PatientId)
            {
                if (!await IsExistAnyUserFromParsaSystemInDoctorParsaSystemList(item, organization.OwnerId))
                {
                    return false;
                }
            }

            #endregion

            #region Send SMS Method 

            #region Log For Send SMS

            List<LogForSendSMSToUsersIncomeFromParsa> logsForSMS = new List<LogForSendSMSToUsersIncomeFromParsa>();

            foreach (var item in model.PatientId)
            {
                logsForSMS.Add(new LogForSendSMSToUsersIncomeFromParsa()
                {
                    CreateDate = DateTime.Now,
                    DoctorUserId = organization.OwnerId,
                    IsDelete = false,
                    ParsaUserId = item,
                    SMSBody = model.SMSBody,
                });
            }

            await _doctorRepository.AddLogForSendSMSFromDoctorToUsersThatIncomeFromParsaSystemWithoutSaveChanges(logsForSMS);

            #endregion

            #region Send SMS

            foreach (var item in model.PatientId)
            {
                //Get The Current Patient With Validation 
                var patient = await _doctorRepository.GetUserFromParsaIncomingListByUserIdAndDoctorUserId(organization.OwnerId, item);

                if (patient != null)
                {
                    //Initial SMS Body With Algorithm
                    var message = Messages.SendSMSFromDoctorToTheUsersThatIncomeFromParsaSystem(model.SMSBody);

                    if (!string.IsNullOrEmpty(patient.PatientMobile))
                    {
                        //Send SMS
                        await _smsservice.SendSimpleSMS(patient.PatientMobile, message);

                        //Update Patient Info In Users That Income From Parsa System List 
                        patient.SMSSent = true;
                        patient.SMSSentDate = DateTime.Now;


                        //Update Method 
                        await _doctorRepository.UpdateParsaSystemRecord(patient);
                    }
                }
            }

            #endregion

            #endregion

            return true;
        }

        //Get VIP User From Parsa Incoming List By User Id And Doctor User Id
        public async Task<VIPUserInsertedFromDoctorSystem?> GetVIPUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId)
        {
            return await _doctorRepository.GetVIPUserFromParsaIncomingListByUserIdAndDoctorUserId(doctorId, parsaUserId);
        }

        //Send SMS From Doctor To The VIP Users That Income From Parsa Sysem 
        public async Task<bool> SendSMSFromVIPDoctorToTheUsersThatIncomeFromParsaSysem(SendSMSToPatientViewModel model)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(model.DoctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Model State Validation 

            if (model == null || model.PatientId.Count() == 0 || !model.PatientId.Any())
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.SMSBody))
            {
                return false;
            }

            //Check Patients Id That Exist In Doctor Parsa System Population
            foreach (var item in model.PatientId)
            {
                if (!await _doctorRepository.IsExistAnyVIPUserFromParsaSystemInDoctorParsaSystemList(item, organization.OwnerId))
                {
                    return false;
                }
            }

            #endregion

            #region Send SMS Method 

            #region Log For Send SMS

            List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem> logsForSMS = new List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem>();

            foreach (var item in model.PatientId)
            {
                logsForSMS.Add(new LogForSendSMSToVIPUsersIncomeFromDoctorSystem()
                {
                    CreateDate = DateTime.Now,
                    VIPUserInsertedFromDoctorSystemId = item,
                    IsDelete = false,
                    SMSBody = model.SMSBody,
                });
            }

            await _doctorRepository.AddLogForSendSMSFromDoctorToVIPUsersThatIncomeFromParsaSystemWithoutSaveChanges(logsForSMS);

            #endregion

            #region Send SMS

            foreach (var item in model.PatientId)
            {
                //Get The Current VIP Patient With Validation 
                var patient = await GetVIPUserFromParsaIncomingListByUserIdAndDoctorUserId(organization.OwnerId, item);

                if (patient != null)
                {
                    //Initial SMS Body With Algorithm
                    var message = Messages.SendSMSFromDoctorToTheUsersThatIncomeFromParsaSystem(model.SMSBody);

                    if (!string.IsNullOrEmpty(patient.PatientMobile))
                    {
                        //Send SMS
                        //await _smsservice.SendSimpleSMS(patient.PatientMobile, message);

                        //Update Patient Info In Users That Income From Parsa System List 
                        patient.SMSSent = true;
                        patient.SMSSentDate = DateTime.Now;


                        //Update Method 
                        await _doctorRepository.UpdateVIPParsaSystemRecord(patient);
                    }
                }
            }

            #endregion

            #endregion

            return true;
        }

        //Send SMS From Doctor To The VIP Users That Income From Parsa Sysem 
        public async Task<bool> SendSMSFromVIPDoctorToTheUsersThatIncomeFromParsaSysem(ulong doctorUserId, List<ulong> patientIds, string SMSBody)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Model State Validation 

            if (patientIds == null || patientIds.Count() == 0 || !patientIds.Any())
            {
                return false;
            }

            if (string.IsNullOrEmpty(SMSBody))
            {
                return false;
            }

            //Check Patients Id That Exist In Doctor Parsa System Population
            foreach (var item in patientIds)
            {
                if (!await _doctorRepository.IsExistAnyVIPUserFromParsaSystemInDoctorParsaSystemList(item, organization.OwnerId))
                {
                    return false;
                }
            }

            #endregion

            #region Send SMS Method 

            #region Log For Send SMS

            List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem> logsForSMS = new List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem>();

            foreach (var item in patientIds)
            {
                logsForSMS.Add(new LogForSendSMSToVIPUsersIncomeFromDoctorSystem()
                {
                    CreateDate = DateTime.Now,
                    VIPUserInsertedFromDoctorSystemId = item,
                    IsDelete = false,
                    SMSBody = SMSBody,
                });
            }

            await _doctorRepository.AddLogForSendSMSFromDoctorToVIPUsersThatIncomeFromParsaSystemWithoutSaveChanges(logsForSMS);

            #endregion

            #region Send SMS

            foreach (var item in patientIds)
            {
                //Get The Current VIP Patient With Validation 
                var patient = await GetVIPUserFromParsaIncomingListByUserIdAndDoctorUserId(organization.OwnerId, item);

                if (patient != null)
                {
                    //Initial SMS Body With Algorithm
                    var message = Messages.SendSMSFromDoctorToTheUsersThatIncomeFromParsaSystem(SMSBody);

                    if (!string.IsNullOrEmpty(patient.PatientMobile))
                    {
                        //Send SMS
                        //await _smsservice.SendSimpleSMS(patient.PatientMobile, message);

                        //Update Patient Info In Users That Income From Parsa System List 
                        patient.SMSSent = true;
                        patient.SMSSentDate = DateTime.Now;


                        //Update Method 
                        await _doctorRepository.UpdateVIPParsaSystemRecord(patient);
                    }
                }
            }

            #endregion

            #endregion

            return true;
        }

        //List Of Doctor Parsa System Users
        public async Task<List<UserInsertedFromParsaSystem>?> ListOfDoctorParsaSystemUsers(ulong DoctorUserId)
        {
            #region Get Organization

            var organization = await _organizationService.GetOrganizationByUserId(DoctorUserId);

            #endregion

            return await _doctorRepository.ListOfDoctorParsaSystemUsers(organization.OwnerId);
        }

        //List Of DOctor VIP Parsa System Users
        public async Task<List<ListOfVIPIncommingUsers>?> ListOfDoctorVIPParsaSystemUsers(ulong DoctorUserId, ulong? sicknessLabelId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(DoctorUserId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            #region Get List Of VIP Users

            var users = new List<VIPUserInsertedFromDoctorSystem>();

            if (sicknessLabelId.HasValue)
            {
                users = await _doctorRepository.ListOfDOctorVIPParsaSystemUsers(organization.OwnerId, sicknessLabelId.Value);
            }
            else
            {
                users = await _doctorRepository.ListOfDOctorVIPParsaSystemUsers(organization.OwnerId);
            }

            #endregion

            #region Fill View Model

            List<ListOfVIPIncommingUsers> returnModel = new List<ListOfVIPIncommingUsers>();

            foreach (var item in users)
            {
                ListOfVIPIncommingUsers model = new ListOfVIPIncommingUsers()
                {
                    PatientFirstName = item.PatientFirstName,
                    PatientLastName = item.PatientLastName,
                    PatientMobile = item.PatientMobile,
                    PatientNationalId = item.PatientNationalId,
                    SMSSent = item.SMSSent,
                    SMSSentDate = item.SMSSentDate,
                    LabelOFSickness = await _doctorRepository.GetLabelOfSicknessFromVIPUsers(item.Id),
                    Id = item.Id
                };

                returnModel.Add(model);
            }

            #endregion

            return returnModel;
        }

        //Get User From Parsa Incoming List By User Id And Doctor User Id
        public async Task<UserInsertedFromParsaSystem?> GetUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId)
        {
            return await _doctorRepository.GetUserFromParsaIncomingListByUserIdAndDoctorUserId(doctorId, parsaUserId);
        }

        //Remove User From Parsa System From Doctor Dashboard 
        public async Task<bool> RemoveUserFromParsaSystemFromDoctorDashboard(ulong doctorUserId, ulong userId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Get User By Parsa System Id And Doctor User Id

            var parsaUser = await GetUserFromParsaIncomingListByUserIdAndDoctorUserId(organization.OwnerId, userId);
            if (parsaUser == null) return false;
            if (!parsaUser.ShowInDashboard) return false;

            #endregion

            #region Update Show In DashBoard State

            parsaUser.ShowInDashboard = false;

            //update Method 
            await _doctorRepository.UpdateParsaSystemRecord(parsaUser);

            #endregion

            return true;
        }

        //Is Exist Any User By This Mobile Number In Current Doctor Parsa System File 
        public async Task<bool> IsExistAnyUserByThisMobileNumberInCurrentDoctorParsaSystemFile(ulong doctorUserId, string mobileNumber)
        {
            return await _doctorRepository.IsExistAnyUserByThisMobileNumberInCurrentDoctorParsaSystemFile(doctorUserId, mobileNumber);
        }

        //Is Exist Any User VIP By This Mobile Number And NationalId In Current Doctor System File 
        public async Task<bool> IsExistAnyUserVIPByThisMobileNumberAndNationalIdInCurrentDoctorSystemFile(ulong doctorUserId, string mobileNumber, string NationalId)
        {
            return await _doctorRepository.IsExistAnyUserVIPByThisMobileNumberAndNationalIdInCurrentDoctorSystemFile(doctorUserId, mobileNumber, NationalId);
        }

        //Check That Is User Has Any Active Family Doctor 
        public async Task<bool> CheckThatIsUserHasAnyActiveFamilyDoctor(string userMobile)
        {
            return await _doctorRepository.CheckThatIsUserHasAnyActiveFamilyDoctor(userMobile);
        }

        //Check That Is Exist User By Mobile In User Population Covered
        public async Task<bool> CheckThatIsExistUserByMobileInUserPopulationCovered(ulong doctorUserId, string userMobile)
        {
            return await _doctorRepository.CheckThatIsExistUserByMobileInUserPopulationCovered(doctorUserId, userMobile);
        }

        //Get List Of User That Comes From Parsa That Not Register To Doctor FAM
        public async Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatNotRegisterToDoctorFAM(ulong doctorId)
        {
            return await _doctorRepository.GetListOfUserThatComesFromParsaThatNotRegisterToDoctorFAM(doctorId);
        }

        //Get List Of User That Comes From Parsa That Registered To Doctor FAM
        public async Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatRegisteredToDoctorFAM(ulong doctorId)
        {
            return await _doctorRepository.GetListOfUserThatComesFromParsaThatRegisteredToDoctorFAM(doctorId);
        }

        //Get List Of User That Comes From Parsa
        public async Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsa(ulong doctorId)
        {
            return await _doctorRepository.GetListOfUserThatComesFromParsa(doctorId);
        }

        //Refresh List Of Users That Come From Parsa System 
        public async Task<bool> RefreshListOfUsersThatComeFromParsaSystem(ulong userId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Get List Of User That Come From Parsa

            //Not Regisetered Users In Site
            var users = await GetListOfUserThatComesFromParsaThatNotRegisterToDoctorFAM(organization.OwnerId);
            if (users == null) return false;

            foreach (var item in users)
            {
                //Validate Mobile Number
                if (item.PatientMobile == null) return false;

                if (await _userService.IsExistUserByMobile(item.PatientMobile.Trim()))
                {
                    item.IsRegisteredUser = true;

                    await _doctorRepository.RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(item);
                }

                if (await CheckThatIsUserHasAnyActiveFamilyDoctor(item.PatientMobile.Trim()))
                {
                    item.HasAnyFamilyDoctor = true;

                    await _doctorRepository.RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(item);
                }

                if (await CheckThatIsExistUserByMobileInUserPopulationCovered(organization.OwnerId, item.PatientMobile.Trim()))
                {
                    item.IsDelete = true;

                    await _doctorRepository.RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(item);
                }
            }

            //Regisetered Users In Site
            var registeredUser = await GetListOfUserThatComesFromParsaThatRegisteredToDoctorFAM(organization.OwnerId);

            foreach (var item in registeredUser)
            {
                //Validate Mobile Number
                if (item.PatientMobile == null) return false;

                if (await CheckThatIsUserHasAnyActiveFamilyDoctor(item.PatientMobile.Trim()))
                {
                    item.HasAnyFamilyDoctor = true;

                    await _doctorRepository.RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(item);
                }
                else
                {
                    if (item.HasAnyFamilyDoctor)
                    {
                        item.HasAnyFamilyDoctor = false;

                        await _doctorRepository.RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(item);
                    }
                }

                if (await CheckThatIsExistUserByMobileInUserPopulationCovered(organization.OwnerId, item.PatientMobile.Trim()))
                {
                    item.IsDelete = true;

                    await _doctorRepository.RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(item);
                }
            }

            await _doctorRepository.SaveChanges();

            #endregion

            return true;
        }

        //Upload Excel File That Get From Parsa System
        public async Task<bool> UploadExcelFileThatGetFromParsaSystem(ulong userId, IFormFile excelFile)
        {
            #region File Validation 

            if (!excelFile.IsExcelFile())
            {
                return false;
            }

            #endregion

            #region Get Doctor Organization 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted )
            {
                return false;
            }

            #endregion

            #region Work On Excel File 

            List<UserInsertedFromParsaSystem> list = new List<UserInsertedFromParsaSystem>();

            using (var stream = new MemoryStream())
            {
                await excelFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                    var rowCount = workSheet.Dimension.Rows;

                    if (rowCount >= 1)
                    {
                        for (int row = 1; row <= rowCount; row++)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[row, 4].Value.ToString()))
                            {
                                //Check Is Exist Any User With This Specification In User Population Covered
                                if (!await CheckThatIsExistUserByMobileInUserPopulationCovered(organization.OwnerId, workSheet.Cells[row, 4].Value.ToString())
                                    && !await IsExistAnyUserByThisMobileNumberInCurrentDoctorParsaSystemFile(organization.OwnerId, workSheet.Cells[row, 4].Value.ToString()))
                                {
                                    list.Add(new UserInsertedFromParsaSystem()
                                    {
                                        CreateDate = DateTime.Now,
                                        IsDelete = false,
                                        DoctorUserId = organization.OwnerId,
                                        PatientFirstName = workSheet.Cells[row, 1].Value.ToString(),
                                        PatientLastName = workSheet.Cells[row, 2].Value.ToString(),
                                        PatientNationalId = workSheet.Cells[row, 3].Value.ToString(),
                                        PatientMobile = workSheet.Cells[row, 4].Value.ToString(),
                                        ShowInDashboard = true,
                                        SMSSent = false,
                                        IsRegisteredUser = ((await _userService.IsExistUserByMobile(workSheet.Cells[row, 4].Value.ToString().Trim())) ? true : false),
                                        HasAnyFamilyDoctor = ((await CheckThatIsUserHasAnyActiveFamilyDoctor(workSheet.Cells[row, 4].Value.ToString().Trim()) ? true : false))
                                    });
                                }
                            }
                        }

                        #region Add List To the Data Base

                        await _doctorRepository.AddRangeOfUserFromParsaSystemToTheDataBase(list);

                        #endregion
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            #endregion

            return true;
        }

        //change Excel File Request From Admin Or Supporter Panel 
        public async Task<bool> ChangeExcelFileRequestFromAdminOrSupporterPanel(RequestForUploadExcelFileDetailAdminSideViewModel model)
        {
            #region Get Request By Id 

            var request = await _doctorRepository.GetRequestExcelFileById(model.requestId);
            if (request == null) return false;

            #endregion

            #region Change Request State 

            request.IsPending = model.IsPending;

            #endregion

            #region Update Mthod 

            await _doctorRepository.UpdateRequestExcelFileForCompeleteFromAdmin(request);

            #endregion

            return true;
        }

        //Fill ViewModel For Send SMS For Range Of VIP Patient
        public async Task<SendSMSForRangeOfVIPInsertedPatientViewModel?> FillSendSMSForRangeOfVIPInsertedPatientViewModel(string label, ulong doctorUserId)
        {
            #region Get Doctor Organization 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorUserId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            #region Check Is Exist Any Label By This Doctor 

            var doctorLabel = await _doctorRepository.GetLabelByDoctorUserIdAndLabelName(label, organization.OwnerId);
            if (doctorLabel == null) return null;

            #endregion

            #region Get List Of Patient

            var listOfPatient = await _doctorRepository.GetListOfVIPInsertedPAtientWithLabelName(doctorLabel.Id, organization.OwnerId);
            if (listOfPatient == null) return null;

            #endregion

            #region Fill Return Model

            SendSMSForRangeOfVIPInsertedPatientViewModel model = new SendSMSForRangeOfVIPInsertedPatientViewModel()
            {
                DoctorUserId = organization.OwnerId,
                VIPUserInsertedFromDoctorSystem = listOfPatient,
                LabelName = label
            };

            #endregion

            return model;
        }

        //Upload Excel File For VIP Patient That Income From Doctor System Organization
        public async Task<bool> UploadExcelFileForVIPPatientThatIncomeFromDoctorSystemOrganization(ulong userId, UploadExcelFileFromDoctorSystemViewModel model)
        {
            #region File Validation 

            if (!model.ExcelFile.IsExcelFile())
            {
                return false;
            }

            #endregion

            #region Get Doctor Organization 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Check Is Exist Any Label By This Doctor 

            var doctorLabel = await _doctorRepository.GetLabelByDoctorUserIdAndLabelName(model.LableForPatient, organization.OwnerId);

            #endregion

            #region Work On Excel File 

            List<VIPUserInsertedFromDoctorSystem> list = new List<VIPUserInsertedFromDoctorSystem>();

            using (var stream = new MemoryStream())
            {
                await model.ExcelFile.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
                    var rowCount = workSheet.Dimension.Rows;

                    if (rowCount >= 1)
                    {
                        for (int row = 1; row <= rowCount; row++)
                        {
                            if (!string.IsNullOrEmpty(workSheet.Cells[row, 4].Value.ToString())
                                && !string.IsNullOrEmpty(workSheet.Cells[row, 3].Value.ToString()))
                            {
                                //Check Is Exist Any VIP User With This Spicification
                                if (!await IsExistAnyUserVIPByThisMobileNumberAndNationalIdInCurrentDoctorSystemFile(organization.OwnerId, workSheet.Cells[row, 4].Value.ToString(), workSheet.Cells[row, 3].Value.ToString()))
                                {
                                    list.Add(new VIPUserInsertedFromDoctorSystem()
                                    {
                                        CreateDate = DateTime.Now,
                                        IsDelete = false,
                                        DoctorUserId = organization.OwnerId,
                                        PatientFirstName = workSheet.Cells[row, 1].Value.ToString(),
                                        PatientLastName = workSheet.Cells[row, 2].Value.ToString(),
                                        PatientNationalId = workSheet.Cells[row, 3].Value.ToString(),
                                        PatientMobile = workSheet.Cells[row, 4].Value.ToString(),
                                        SMSSent = false,
                                    });
                                }
                                else
                                {
                                    //Add New Label Of Sickness To The Existing Users
                                    await _doctorRepository.AddNewLabelOfSicknessToTheExistingUsers(organization.OwnerId, workSheet.Cells[row, 4].Value.ToString(), workSheet.Cells[row, 3].Value.ToString(), model.LableForPatient);
                                }
                            }
                        }

                        #region Add List To the Data Base

                        await _doctorRepository.TaskAddRangeOfVIPUserFromParsaSystemToTheDataBase(list);

                        #endregion

                        #region Add Label To Patient 

                        //Add New Label 
                        if (doctorLabel == null)
                        {
                            //Initial Instance Of Model
                            DoctorsLabelsForVIPInsertedDoctor label = new DoctorsLabelsForVIPInsertedDoctor()
                            {
                                DoctorUserId = organization.OwnerId,
                                LabelName = model.LableForPatient
                            };

                            //Add Label 
                            await _doctorRepository.AddDoctorLabelForInsertedVIPUsers(label);

                            //Add Label To The Inserted Patient
                            foreach (var item in list)
                            {
                                LabelOfVIPDoctorInsertedPatient labelPatient = new LabelOfVIPDoctorInsertedPatient()
                                {
                                    DoctorsLabelsForVIPInsertedDoctorId = label.Id,
                                    VIPUserInsertedFromDoctorSystemId = item.Id
                                };

                                await _doctorRepository.AddLabelOfSicknessToVipUsersThatIncomeFromDoctorSystem(labelPatient);
                            }
                        }
                        //Exist a Doctor Label Before
                        else
                        {
                            //Add Label To The Inserted Patient
                            foreach (var item in list)
                            {
                                LabelOfVIPDoctorInsertedPatient labelPatient = new LabelOfVIPDoctorInsertedPatient()
                                {
                                    DoctorsLabelsForVIPInsertedDoctorId = doctorLabel.Id,
                                    VIPUserInsertedFromDoctorSystemId = item.Id
                                };

                                await _doctorRepository.AddLabelOfSicknessToVipUsersThatIncomeFromDoctorSystem(labelPatient);
                            }
                        }

                        #endregion
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            #endregion

            return true;
        }

        //Request For Epload Excel File From Site
        public async Task<bool> RequestForEploadExcelFileFromSite(RequestForUploadExcelFileFromDoctorsToSiteViewModel model, ulong userId)
        {
            #region Validation 

            if (model.ExcelFile == null)
            {
                return false;
            }

            #endregion

            #region Get Doctor Organization 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return false;
            }

            #endregion

            #region Fill Entity

            RequestForUploadExcelFileFromDoctorsToSite instance = new RequestForUploadExcelFileFromDoctorsToSite()
            {
                DoctorId = organization.OwnerId,
                CreateDate = DateTime.Now,
                IsPending = true,
            };

            if (model.ExcelFile != null)
            {
                var excelFile = CodeGenerator.GenerateUniqCode() + Path.GetExtension(model.ExcelFile.FileName);
                model.ExcelFile.AddFileToServer(excelFile, PathTools.RequestExcelFilePathServer);
                instance.ExcelFile = excelFile;
            }

            #endregion

            #region Add To The Data Base 

            await _doctorRepository.CreateRequestExcelFileForCompeleteFromAdmin(instance);

            #endregion

            return true;
        }

        public async Task<List<DoctorsInterestInfo>> GetDoctorSelectedInterests(ulong doctorId)
        {
            return await _doctorRepository.GetDoctorSelectedInterests(doctorId);
        }

        public async Task<FilterDoctorOfficeEmployeesViewmodel> FilterDoctorOfficeEmployees(FilterDoctorOfficeEmployeesViewmodel filter)
        {
            return await _doctorRepository.FilterDoctorOfficeEmployees(filter);
        }

        public async Task AddDoctorForFirstTime(ulong userId)
        {
            #region Doctor Entity

            #region Fill Doctor Model

            Doctor doctor = new Doctor()
            {
                UserId = userId,
                CreateDate = DateTime.Now,
                IsDelete = false,
            };

            #endregion

            #region Add Methods 

            await _doctorRepository.AddDoctor(doctor);

            #endregion

            #endregion

            #region Organization Entity

            #region Fill Organization Model

            Organization organization = new Organization()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationInfoState = OrganizationInfoState.JustRegister,
                OrganizationType = Domain.Enums.Organization.OrganizationType.DoctorOffice,
                OwnerId = userId,
            };

            #endregion

            #region Add Method

            var organizationId = await _organizationService.AddOrganizationWithReturnId(organization);

            #endregion

            #endregion

            #region Organization Member

            #region Fill Model 

            OrganizationMember member = new OrganizationMember()
            {
                CreateDate = DateTime.Now,
                IsDelete = false,
                OrganizationId = organizationId,
                UserId = userId
            };

            #endregion

            #region Add Organization Member

            await _organizationService.AddOrganizationMember(member);

            #endregion

            #endregion
        }

        public async Task<bool> IsExistAnyDoctorByUserId(ulong userId)
        {
            return await _doctorRepository.IsExistAnyDoctorByUserId(userId);
        }

        public async Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId)
        {
            return await _doctorRepository.IsExistAnyDoctorInfoByUserId(userId);
        }

        public async Task<DoctorSideBarViewModel> GetDoctorsSideBarInfo(ulong userId)
        {
            return await _doctorRepository.GetDoctorsSideBarInfo(userId);
        }

        public async Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId)
        {
            return await _doctorRepository.GetDoctorsInformationByUserId(userId);
        }

        //Get Doctor Reservation Tariff By User Id 
        public async Task<DoctorsReservationTariffs?> GetDoctorReservationTariffByDoctorUserId(ulong doctorUserId)
        {
            return await _doctorRepository.GetDoctorReservationTariffByDoctorUserId(doctorUserId);
        }

        //Fill Doctors Reservation Tariff Doctor Panel Side ViewModel
        public async Task<DoctorsReservationTariffDoctorPanelSideViewModel?> FillDoctorsReservationTariffDoctorPanelSideViewModel(ulong userId)
        {
            #region Check Is User Exist 

            var user = await _userService.GetUserById(userId);

            if (user == null) return null;

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (doctorOffice == null) return null;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return null;

            #endregion

            #region Fill Return Model

            //Get Doctor Reservation Tariff
            var tariffs = await GetDoctorReservationTariffByDoctorUserId(doctorOffice.OwnerId);

            #region For The First Time

            if (tariffs == null)
            {
                DoctorsReservationTariffDoctorPanelSideViewModel returnModel = new DoctorsReservationTariffDoctorPanelSideViewModel()
                {
                    DoctorUserId = doctorOffice.OwnerId
                };

                return returnModel;
            }

            #endregion

            #region After First Time 

            if (tariffs != null)
            {
                DoctorsReservationTariffDoctorPanelSideViewModel returnModel = new DoctorsReservationTariffDoctorPanelSideViewModel()
                {
                    DoctorUserId = doctorOffice.OwnerId,
                    InPersonReservationTariffForAnonymousPersons = tariffs.InPersonReservationTariffForAnonymousPersons,
                    InPersonReservationTariffForDoctorPopulationCovered = tariffs.InPersonReservationTariffForDoctorPopulationCovered,
                    OnlineReservationTariffForAnonymousPersons = tariffs.OnlineReservationTariffForAnonymousPersons,
                    OnlineReservationTariffForDoctorPopulationCovered = tariffs.OnlineReservationTariffForDoctorPopulationCovered,
                    DoctorReservationAlert = tariffs.DoctorReservationAlert,
                };

                return returnModel;
            }

            #endregion

            #endregion

            return null;
        }

        //Add Or Edit Doctor Reservation Tariff Doctor Side 
        public async Task<DoctorsReservationTariffDoctorPanelSideViewModelResult> AddOrEditDoctorReservationTariffDoctorSide(DoctorsReservationTariffDoctorPanelSideViewModel inCommingModel)
        {
            #region Check Is User Exist 

            var user = await _userService.GetUserById(inCommingModel.DoctorUserId);

            if (user == null) return DoctorsReservationTariffDoctorPanelSideViewModelResult.failure;

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(inCommingModel.DoctorUserId);
            if (doctorOffice == null) return DoctorsReservationTariffDoctorPanelSideViewModelResult.failure;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return DoctorsReservationTariffDoctorPanelSideViewModelResult.failure;

            #endregion

            #region Add Or Edit Doctor Reservation Tariff

            //Get Doctor Reservation Tariff
            var tariffs = await GetDoctorReservationTariffByDoctorUserId(doctorOffice.OwnerId);

            #region Edit Doctor Organization State 

            doctorOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            await _organizationService.UpdateOrganization(doctorOffice);

            #endregion

            #region Add For The First Time

            #region Check Tarrifs From Doctor By Site Percentages

            if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForDoctorPopulationCovered(inCommingModel.InPersonReservationTariffForDoctorPopulationCovered))
            {
                return DoctorsReservationTariffDoctorPanelSideViewModelResult.InpersonReservationPopluationCoveredLessThanSiteShare;
            }

            if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForDoctorPopulationCovered(inCommingModel.OnlineReservationTariffForDoctorPopulationCovered))
            {
                return DoctorsReservationTariffDoctorPanelSideViewModelResult.OnlineReservationPopluationCoveredLessThanSiteShare;
            }

            if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForAnonymousPersons(inCommingModel.InPersonReservationTariffForAnonymousPersons))
            {
                return DoctorsReservationTariffDoctorPanelSideViewModelResult.InpersonReservationAnonymousePersoneLessThanSiteShare;
            }

            if (await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForAnonymousPersons(inCommingModel.OnlineReservationTariffForAnonymousPersons))
            {
                return DoctorsReservationTariffDoctorPanelSideViewModelResult.OnlineReservationAnonymousePersoneLessThanSiteShare;
            }

            #endregion

            if (tariffs == null)
            {
                //Create Instance
                DoctorsReservationTariffs model = new DoctorsReservationTariffs()
                {
                    DoctorUserId = doctorOffice.OwnerId,
                    InPersonReservationTariffForAnonymousPersons = inCommingModel.InPersonReservationTariffForAnonymousPersons,
                    InPersonReservationTariffForDoctorPopulationCovered = inCommingModel.InPersonReservationTariffForDoctorPopulationCovered,
                    OnlineReservationTariffForAnonymousPersons = inCommingModel.OnlineReservationTariffForAnonymousPersons,
                    OnlineReservationTariffForDoctorPopulationCovered = inCommingModel.OnlineReservationTariffForDoctorPopulationCovered,
                    DoctorReservationAlert = inCommingModel.DoctorReservationAlert
                };

                //Add Data To The Data Base 
                await _doctorRepository.AddDoctorsReservationTariffToTheDataBase(model);
            }

            #endregion

            #region Edit Reservation Tarrif 

            if (tariffs != null)
            {
                tariffs.InPersonReservationTariffForAnonymousPersons = inCommingModel.InPersonReservationTariffForAnonymousPersons;
                tariffs.InPersonReservationTariffForDoctorPopulationCovered = inCommingModel.InPersonReservationTariffForDoctorPopulationCovered;
                tariffs.OnlineReservationTariffForAnonymousPersons = inCommingModel.OnlineReservationTariffForAnonymousPersons;
                tariffs.OnlineReservationTariffForDoctorPopulationCovered = inCommingModel.OnlineReservationTariffForDoctorPopulationCovered;
                tariffs.DoctorReservationAlert = inCommingModel.DoctorReservationAlert;

                //Update Doctor Reservation Tariffs
                await _doctorRepository.UpdateDoctorReservationTariffs(tariffs);
            }

            #endregion

            #endregion

            return DoctorsReservationTariffDoctorPanelSideViewModelResult.success;
        }

        public async Task<ManageDoctorsInfoViewModel?> FillManageDoctorsInfoViewModel(ulong userId)
        {
            #region Check Is User Exist 

            var user = await _userService.GetUserById(userId);

            if (user == null) return null;

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (doctorOffice == null) return null;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return null;

            #endregion

            #region Get User Office Address

            var workAddress = await _workAddress.GetUserWorkAddressById(userId);

            #endregion

            #region Exist Doctor Information

            //Is Exist Doctor Informations
            if (await IsExistAnyDoctorInfoByUserId(userId))
            {
                //Get Current Doctor Information
                var doctorInfo = await GetDoctorsInformationByUserId(userId);

                //Fill Model For return Value
                ManageDoctorsInfoViewModel model = new ManageDoctorsInfoViewModel()
                {
                    UserId = userId,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DoctorsInfosType = doctorOffice.OrganizationInfoState,
                    Education = doctorInfo.Education,
                    MediacalFile = doctorInfo.MediacalFile,
                    MedicalSystemCode = doctorInfo.MedicalSystemCode,
                    NationalCode = doctorInfo.NationalCode,
                    Gender = doctorInfo.Gender,
                    RejectDescription = doctorOffice.RejectDescription,
                    Specialty = doctorInfo.Specialty,
                    ClinicPhone = doctorInfo.ClinicPhone,
                    GeneralPhone = doctorInfo.GeneralPhone,
                    FatherName = user.FatherName,
                    username = user.Username,
                    Mobile = user.Mobile,
                    Email = user.Email,
                    HomePhoneNumber = user.HomePhoneNumber,
                    AvatarName = user.Avatar
                };

                if (user.BithDay != null && user.BithDay.HasValue)
                {
                    model.BithDay = user.BithDay.Value.ToShamsi();
                }

                #region Get Doctor Skill By Doctor Id

                if (doctorInfo != null)
                {
                    var doctorSkills = await _doctorRepository.GetListOfDoctorSkillsByDoctorId(doctorInfo.DoctorId);

                    if (doctorSkills != null)
                    {
                        model.DoctorSkills = string.Join(",", doctorSkills.Select(p => p.DoctorSkil).ToList());
                    }
                }

                #endregion

                //Fill Doctor Cilinic Address
                if (workAddress != null)
                {
                    model.WorkAddress = workAddress.Address;
                    model.CountryId = workAddress.CountryId;
                    model.StateId = workAddress.StateId;
                    model.CityId = workAddress.CityId;
                }

                return model;
            }

            #endregion

            #region Not Exist Doctor Information

            else
            {
                //This Is First Time For Come in To This Action 
                ManageDoctorsInfoViewModel model = new ManageDoctorsInfoViewModel()
                {
                    UserId = userId
                };

                return model;
            }

            #endregion

            return null;
        }

        //Update Doctor Personal Info With Save Changes 
        public async Task UpdateDoctorPersonalInfoWithSaveChanges(DoctorsInfo doctorsInfo)
        {
            await _doctorRepository.UpdateDoctorsInfo(doctorsInfo);
        }

        //Get List Of Doctor Skills By Doctor Id
        public async Task<List<DoctorsSkils>> GetListOfDoctorSkillsByDoctorId(ulong doctorId)
        {
            return await _doctorRepository.GetListOfDoctorSkillsByDoctorId(doctorId);
        }

        public async Task<AddOrEditDoctorInfoResult> AddOrEditDoctorInfoDoctorsPanel(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile, IFormFile? UserAvatar)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(model.UserId);

            if (user == null) return AddOrEditDoctorInfoResult.Faild;

            if (UserAvatar != null && !UserAvatar.IsImage())
            {
                return AddOrEditDoctorInfoResult.NotValidImage;
            }

            if (UserAvatar != null)
            {
                if (!string.IsNullOrEmpty(user.Avatar))
                {
                    user.Avatar.DeleteImage(PathTools.UserAvatarPathServer, PathTools.UserAvatarPathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(UserAvatar.FileName);
                UserAvatar.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 270, 270, PathTools.UserAvatarPathThumbServer);
                user.Avatar = imageName;
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                if (!await _userService.IsValidEmailForUserEditByAdmin(model.Email, user.Id))
                {
                    return AddOrEditDoctorInfoResult.NotValidEmail;
                }
            }

            if (string.IsNullOrEmpty(model.NationalCode))
            {
                return AddOrEditDoctorInfoResult.NationalId;
            }

            if (!string.IsNullOrEmpty(model.NationalCode) && !await _userService.IsValidNationalIdForUserEditByAdmin(model.NationalCode, user.Id))
            {
                return AddOrEditDoctorInfoResult.NotValidNationalId;
            }

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(model.UserId);
            if (doctorOffice == null) return AddOrEditDoctorInfoResult.Faild;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return AddOrEditDoctorInfoResult.Faild;

            #endregion

            #region Get Doctor By User Id 

            //Get Doctor By UserId
            var doctor = await GetDoctorByUserId(user.Id);

            #endregion

            #region Is Exist Informations

            var existInfo = await IsExistAnyDoctorInfoByUserId(model.UserId);

            #endregion

            #region Image Not Found 

            if (existInfo == false && MediacalFile == null) return AddOrEditDoctorInfoResult.FileNotUploaded;

            if (MediacalFile != null && !MediacalFile.IsImage()) return AddOrEditDoctorInfoResult.FileNotUploaded;

            #endregion

            #region Edit Info

            if (existInfo == true)
            {
                #region Update Properties

                //Get Doctors Informations By Doctor Id
                var info = await GetDoctorsInformationByUserId(model.UserId);

                //Edit Properties 
                info.Specialty = model.Specialty.SanitizeText();
                info.Education = model.Education.SanitizeText();
                info.NationalCode = model.NationalCode;
                info.MedicalSystemCode = model.MedicalSystemCode;
                info.Gender = model.Gender;
                info.GeneralPhone = model.GeneralPhone;
                info.ClinicPhone = model.ClinicPhone;

                //Update Doctor Office State 
                doctorOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                #region Update User

                user.FirstName = model.FirstName.SanitizeText();
                user.LastName = model.LastName.SanitizeText();
                user.FatherName = model.FatherName.SanitizeText();
                user.Email = model.Email.SanitizeText();
                user.BithDay = model.BithDay.ToMiladiDateTime();
                user.NationalId = model.NationalCode.SanitizeText();
                user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();
                user.Username = model.username;
                user.HomePhoneNumber = model.HomePhoneNumber;

                await _userService.UpdateUser(user);

                #endregion

                #endregion

                #region Medical File 

                if (MediacalFile != null)
                {
                    if (!string.IsNullOrEmpty(info.MediacalFile))
                    {
                        info.MediacalFile.DeleteImage(PathTools.MediacalFilePathServer, PathTools.MediacalFilePathThumbServer);
                    }

                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                    MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                    info.MediacalFile = imageName;
                }

                #endregion

                #region Update Doctor Address

                var doctorAddress = await _workAddress.GetUserWorkAddressById(model.UserId);

                if (doctorAddress != null && !string.IsNullOrEmpty(model.WorkAddress))
                {
                    doctorAddress.Address = model.WorkAddress;
                    doctorAddress.CountryId = model.CountryId.Value;
                    doctorAddress.StateId = model.StateId.Value;
                    doctorAddress.CityId = model.CityId.Value;

                    await _workAddress.UpdateUserWorkAddress(doctorAddress);
                }

                if (doctorAddress == null && !string.IsNullOrEmpty(model.WorkAddress))
                {
                    WorkAddress workAddress = new WorkAddress()
                    {
                        Address = model.WorkAddress,
                        CountryId = model.CountryId.Value,
                        CityId = model.CityId.Value,
                        StateId = model.StateId.Value,
                        UserId = model.UserId,
                        CreateDate = DateTime.Now,
                    };

                    await _workAddress.AddWorkAddress(workAddress);
                }

                #endregion

                #region Doctor Selected Skils

                var doctorSkills = await GetListOfDoctorSkillsByDoctorId(doctor.Id);

                if (doctorSkills.Any())
                {
                    await _doctorRepository.RemoveDoctorSkills(doctorSkills);
                }

                if (!string.IsNullOrEmpty(model.DoctorSkills))
                {
                    var skills = model.DoctorSkills.Split(',').ToList();

                    foreach (var item in skills)
                    {
                        var skill = new DoctorsSkils
                        {
                            DoctorId = doctor.Id,
                            DoctorSkil = item
                        };
                        await _doctorRepository.AddDoctorSelectedSkilsWithoutSaveChanges(skill);
                    }
                }

                #endregion

                #region Update Methods

                await _doctorRepository.UpdateDoctorsInfo(info);

                await _organizationService.UpdateOrganization(doctorOffice);

                #endregion
            }

            #endregion

            #region Add Info

            if (existInfo == false)
            {
                if (doctor != null)
                {
                    #region Fill View Model

                    DoctorsInfo manageDoctorsInfoViewModel1 = new DoctorsInfo()
                    {
                        DoctorId = doctor.Id,
                        Education = model.Education.SanitizeText(),
                        MedicalSystemCode = model.MedicalSystemCode,
                        NationalCode = model.NationalCode,
                        Specialty = model.Specialty.SanitizeText(),
                        Gender = model.Gender,
                        GeneralPhone = model.GeneralPhone,
                        ClinicPhone = model.ClinicPhone,
                        CountOFFreeSMSForDoctors = await _doctorRepository.GetDoctorsFreeSMSCount()
                    };

                    #endregion

                    #region Update User Infos 

                    user.FatherName = model.FatherName.SanitizeText();
                    user.Email = model.Email.SanitizeText();
                    user.BithDay = model.BithDay.ToMiladiDateTime();
                    user.NationalId = model.NationalCode.SanitizeText();
                    user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();
                    user.Username = model.username;
                    user.HomePhoneNumber = model.HomePhoneNumber;

                    await _userService.UpdateUser(user);

                    #endregion

                    #region Medical File 

                    if (MediacalFile != null)
                    {
                        var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                        MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                        manageDoctorsInfoViewModel1.MediacalFile = imageName;
                    }

                    #endregion

                    #region Add Doctor Address

                    if (model.WorkAddress != null)
                    {
                        WorkAddress workAddress = new WorkAddress()
                        {
                            Address = model.WorkAddress,
                            CountryId = model.CountryId.Value,
                            CityId = model.CityId.Value,
                            StateId = model.StateId.Value,
                            UserId = model.UserId,
                            CreateDate = DateTime.Now,
                        };

                        await _workAddress.AddWorkAddress(workAddress);
                    }

                    #endregion

                    #region Update Doctor Office

                    doctorOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

                    #endregion

                    #region Doctor Selected Skils

                    if (!string.IsNullOrEmpty(model.DoctorSkills))
                    {
                        var skills = model.DoctorSkills.Split(',').ToList();

                        foreach (var item in skills)
                        {
                            var skill = new DoctorsSkils
                            {
                                DoctorId = doctor.Id,
                                DoctorSkil = item
                            };
                            await _doctorRepository.AddDoctorSelectedSkilsWithoutSaveChanges(skill);
                        }
                    }

                    #endregion

                    #region Update Methods

                    await _doctorRepository.AddDoctorsInfo(manageDoctorsInfoViewModel1);

                    await _organizationService.UpdateOrganization(doctorOffice);

                    #endregion
                }
                else
                {
                    #region Add Doctor

                    Doctor newDoctor = new Doctor()
                    {
                        CreateDate = DateTime.Now,
                        UserId = user.Id,
                        IsDelete = false
                    };

                    var newDoctorId = await _doctorRepository.AddDoctor(newDoctor);

                    #endregion

                    #region Add Doctor Address

                    if (model.WorkAddress != null)
                    {
                        WorkAddress workAddress = new WorkAddress()
                        {
                            Address = model.WorkAddress,
                            CountryId = model.CountryId.Value,
                            CityId = model.CityId.Value,
                            StateId = model.StateId.Value,
                            UserId = model.UserId,
                            CreateDate = DateTime.Now,
                        };

                        await _workAddress.AddWorkAddress(workAddress);
                    }

                    #endregion

                    #region Organization Entity

                    #region Fill Organization Model

                    Organization organization = new Organization()
                    {
                        CreateDate = DateTime.Now,
                        IsDelete = false,
                        OrganizationInfoState = OrganizationInfoState.JustRegister,
                        OrganizationType = Domain.Enums.Organization.OrganizationType.DoctorOffice,
                        OwnerId = model.UserId,
                    };

                    #endregion

                    #region Add Method

                    var organizationId = await _organizationService.AddOrganizationWithReturnId(organization);

                    #endregion

                    #endregion

                    #region Organization Member

                    #region Fill Model 

                    OrganizationMember member = new OrganizationMember()
                    {
                        CreateDate = DateTime.Now,
                        IsDelete = false,
                        OrganizationId = organizationId,
                        UserId = model.UserId,
                    };

                    #endregion

                    #region Add Organization Member

                    await _organizationService.AddOrganizationMember(member);

                    #endregion

                    #endregion

                    #region Fill View Model

                    DoctorsInfo manageDoctorsInfoViewModel = new DoctorsInfo()
                    {
                        DoctorId = newDoctor.Id,
                        Education = model.Education.SanitizeText(),
                        MedicalSystemCode = model.MedicalSystemCode,
                        NationalCode = model.NationalCode,
                        Specialty = model.Specialty.SanitizeText(),
                        GeneralPhone = model.GeneralPhone,
                        ClinicPhone = model.ClinicPhone,
                        CountOFFreeSMSForDoctors = await _doctorRepository.GetDoctorsFreeSMSCount()
                    };

                    #endregion

                    #region Update User Info 

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.FatherName = model.FatherName.SanitizeText();
                    user.Email = model.Email.SanitizeText();
                    user.BithDay = model.BithDay.ToMiladiDateTime();
                    user.NationalId = model.NationalCode.SanitizeText();
                    user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();
                    user.Username = model.username;
                    user.HomePhoneNumber = model.HomePhoneNumber;

                    await _userService.UpdateUser(user);

                    #endregion

                    #region Medical File 

                    if (MediacalFile != null)
                    {
                        var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                        MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                        manageDoctorsInfoViewModel.MediacalFile = imageName;
                    }

                    #endregion

                    #region Doctor Selected Skils

                    if (!string.IsNullOrEmpty(model.DoctorSkills))
                    {
                        var skills = model.DoctorSkills.Split(',').ToList();

                        foreach (var item in skills)
                        {
                            var skill = new DoctorsSkils
                            {
                                DoctorId = newDoctor.Id,
                                DoctorSkil = item
                            };
                            await _doctorRepository.AddDoctorSelectedSkilsWithoutSaveChanges(skill);
                        }
                    }

                    #endregion

                    #region Update Methods

                    await _doctorRepository.AddDoctorsInfo(manageDoctorsInfoViewModel);

                    #endregion
                }
            }

            #endregion

            return AddOrEditDoctorInfoResult.Success;
        }

        public async Task<Doctor?> GetDoctorByUserId(ulong userId)
        {
            return await _doctorRepository.GetDoctorByUserId(userId);
        }

        public async Task<DoctorInterestsViewModel> FillDoctorInterestViewModelFromDoctorPanel(ulong userId)
        {
            DoctorInterestsViewModel model = new DoctorInterestsViewModel();

            #region Get Dotor Interests List 

            model.DoctorInterests = await GetDoctorInterestsInfo();

            #endregion

            #region Get Doctor Selected Interests 

            var doctor = await GetDoctorByUserId(userId);

            model.DoctorSelectedInterests = await _doctorRepository.GetDoctorSelectedInterests(doctor.Id);

            #endregion

            return model;
        }

        //Fill List OF Doctors Speciality
        public async Task<List<ListOfSpecialityViewModel>?> FillListOFDoctorsSpeciality(ulong doctorId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(doctorId);
            if (doctor == null) return null;

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(doctorId);
            if (doctorOffice == null) return null;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return null;

            #endregion

            #region Get List Of Specialities

            var specialities = await _specialityRepository.GetListOfSpecialities();
            if (specialities == null) return null;

            #endregion

            #region Get List Of Doctor's Specialities

            var doctorSpecialities = await _specialityRepository.GetListOfDoctorSpecialities(doctor.Id);

            #endregion

            #region Fill View Model 

            var ListOfSpecialityViewModel = new List<ListOfSpecialityViewModel>();

            foreach (var speciality in specialities)
            {
                var reutnItems = new ListOfSpecialityViewModel();

                reutnItems.SpecialtiyInfo = speciality;

                if (doctorSpecialities != null && doctorSpecialities.Any() && doctorSpecialities.Contains(speciality.SpecialityId))
                {
                    reutnItems.SelectedFromDoctor = true;
                }
                else
                {
                    reutnItems.SelectedFromDoctor = false;
                }

                ListOfSpecialityViewModel.Add(reutnItems);
            }

            #endregion

            return ListOfSpecialityViewModel;
        }

        public async Task<List<DoctorsInterestInfo>> GetDoctorInterestsInfo()
        {
            return await _doctorRepository.GetDoctorInterestsInfo();
        }

        public async Task<DoctorSelectedInterestResult> AddDoctorSelectedInterest(ulong interestId, ulong userId)
        {
            #region Gett Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return DoctorSelectedInterestResult.Faild;

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (doctorOffice == null) return DoctorSelectedInterestResult.Faild;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return DoctorSelectedInterestResult.Faild;

            #endregion

            #region Is Exist interest For Doctor

            if (await _doctorRepository.IsExistInterestForDoctor(interestId, doctor.Id))
            {
                return DoctorSelectedInterestResult.ItemIsExist;
            }

            #endregion

            #region Is Exist Interest By Id

            if (!await _doctorRepository.IsExistInterestById(interestId))
            {
                return DoctorSelectedInterestResult.Faild;
            }

            #endregion

            #region If Interest Is Family Doctor 

            //If Select Family Doctor That Doctor Must Have Address And Location 

            #region Get Doctor Locations And Address

            var workAddress = await _workAddress.GetLastWorkAddressByUserId(doctorOffice.OwnerId);

            //Doctor Selected Family Doctor And Not Insert Office Location And Address
            if (workAddress == null && interestId == 3)
            {
                return DoctorSelectedInterestResult.YouMustInsertLocationAndAddress;
            }

            #endregion

            #endregion

            #region Fill Entity

            DoctorsSelectedInterests model = new DoctorsSelectedInterests
            {
                DoctorId = doctor.Id,
                InterestId = interestId
            };

            #endregion

            #region Add Method

            await _doctorRepository.AddDoctorSelectedInterest(model);

            #endregion

            #region Update Doctor Office State 

            //Update Doctor Office State 
            doctorOffice.OrganizationInfoState = OrganizationInfoState.WatingForConfirm;

            await _organizationService.UpdateOrganization(doctorOffice);

            #endregion

            return DoctorSelectedInterestResult.Success;
        }

        public async Task<DoctorSelectedInterestResult> DeleteDoctorSelectedInterestDoctorPanel(ulong interestId, ulong userId)
        {
            #region Get Doctor

            var doctor = await GetDoctorByUserId(userId);
            if (doctor == null) return DoctorSelectedInterestResult.Faild;

            #endregion

            #region Get Interest 

            var interest = await _doctorRepository.GetDoctorSelectedInterestByDoctorIdAndInetestId(interestId, doctor.Id);
            if (interest == null) return DoctorSelectedInterestResult.ItemNotExist;

            #endregion

            #region Get Doctor Selected Interest

            var selectedItem = await _doctorRepository.GetDoctorSelectedInterestByDoctorIdAndInetestId(interestId, doctor.Id);
            if (selectedItem == null) return DoctorSelectedInterestResult.ItemNotExist;

            #endregion

            #region Remove item

            await _doctorRepository.DeleteDoctoreSelectedInterest(selectedItem);

            #endregion

            return DoctorSelectedInterestResult.Success;
        }

        //Add Exist User To The Doctor Organization 
        public async Task<bool> AddExistUserToTheDoctorOrganization(ulong userId, ulong doctorId)
        {
            #region Check Is Exist Any User By This User Id

            var user = await _userService.GetUserById(userId);
            if (user == null) return false;

            #endregion

            #region Check That Has User Any Organization 

            var userOrganization = await _organizationService.GetOrganizationByUserId(userId);
            if (userOrganization != null) return false;

            #endregion

            #region Get Current Doctor Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctorId);
            if (organization == null) return false;

            #endregion

            #region Add User To The Doctor Organization 

            #region Add New Organization Member

            OrganizationMember member = new OrganizationMember()
            {
                UserId = user.Id,
                OrganizationId = organization.Id
            };

            await _organizationService.AddOrganizationMember(member);

            #endregion

            #region Add User Role

            UserRole userRole = new UserRole()
            {
                RoleId = 5,
                UserId = user.Id,
            };

            await _userService.AddUserRole(userRole);

            #endregion

            #endregion

            return true;
        }

        //Send Request For Send SMS From Doctor Panel To Admin 
        public async Task<SendRequestOfSMSFromDoctorsToThePatientResult> SendRequestForSendSMSFromDoctorPanelToAdmin(SendSMSToPatientViewModel model)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(model.DoctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
            }

            #endregion

            #region Get Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

            #endregion

            #region Model State Validation 

            if (model == null || model.PatientId.Count() == 0 || !model.PatientId.Any())
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
            }

            if (string.IsNullOrEmpty(model.SMSBody))
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
            }

            //Check Patients Id That Exist In Doctor Population
            foreach (var item in model.PatientId)
            {
                if (!await _userService.IsExistUserById(item))
                {
                    return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
                }
            }

            #endregion

            #region Check Doctor Send SMS Count

            //Get Count Of SMS For Send
            int smsCount = ((model.SMSBody.Count() / 70) +1) * model.PatientId.Count;

            //Get Doctor Free SMS Count
            var doctorFreeSMSCount = await _doctorRepository.GetDoctorFreeSMSCountByDoctorId(doctor.Id);
            if (doctorFreeSMSCount == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

            //Check Incoming SMS Right Now
            if (smsCount > doctorFreeSMSCount)
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage;
            }

            //Insert Free SMS From Doctor 
            if (smsCount <= doctorFreeSMSCount)
            {
                #region Create SMS 

                //Create Main Request
                SendRequestOfSMSFromDoctorsToThePatient mainRequest = new SendRequestOfSMSFromDoctorsToThePatient()
                {
                    CreateDate = DateTime.Now,
                    DoctorUserId = organization.OwnerId,
                    IsDelete = false,
                    SendSMSFromDoctorState = Domain.Enums.SendSMS.FromDoctors.SendSMSFromDoctorState.WaitingForConfirm,
                    SMSText = model.SMSBody,
                };

                #endregion

                //Add Request To The Data Base 
                await _doctorRepository.AddSendRequestOfSMSFromDoctorsToThePatient(mainRequest);

                #region Create SMS Detail 

                foreach (var userId in model.PatientId)
                {
                    SendRequestOfSMSFromDoctorsToThePatientDetail detailRequest = new SendRequestOfSMSFromDoctorsToThePatientDetail()
                    {
                        CreateDate = DateTime.Now,
                        UserId = userId,
                        SendRequestOfSMSFromDoctorsToThePatientId = mainRequest.Id
                    };

                    //Add Request Detail To The Data Base
                    await _doctorRepository.AddSendRequestOfSMSFromDoctorsToThePatientDetailToTheDataBase(detailRequest);
                }

                #endregion

                #region Reduce Percentage Doctor Free SMS Count

                await _doctorRepository.ReduceDoctorFreeSMSPercentageWithoutSaveChanges(doctor.Id, smsCount);

                #endregion

                await _doctorRepository.SaveChanges();
            }

            #endregion

            return SendRequestOfSMSFromDoctorsToThePatientResult.RequestSentSuccesfully;
        }

        //Send Request For Send SMS From Doctor Panel To Admin 
        public async Task<SendRequestOfSMSFromDoctorsToThePatientResult> SendRequestForSendSMSFromDoctorPanelToAdmin(SendSMSToPatientDetailDoctorPanelViewModel model)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(model.DoctorUserId);
            if (organization == null || organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
            }

            #endregion

            #region Get Doctor

            var doctor = await _doctorRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

            #endregion

            #region Model State Validation 

            if (string.IsNullOrEmpty(model.SMSBody))
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;
            }

            #endregion

            #region Check Doctor Send SMS Count

            //Get Doctor Free SMS Count
            var doctorFreeSMSCount = await _doctorRepository.GetDoctorFreeSMSCountByDoctorId(doctor.Id);
            if (doctorFreeSMSCount == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

            //Get Count Of Doctor Free SMS Sent 
            var countOFDoctorFreeSentSMS = await _doctorRepository.GetCountOfDoctorFreeSMSSent(organization.OwnerId);

            if (countOFDoctorFreeSentSMS.HasValue && countOFDoctorFreeSentSMS.Value >= doctorFreeSMSCount)
            {
                return SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage;
            }

            //Insert Free SMS From Doctor 
            if (countOFDoctorFreeSentSMS.HasValue && countOFDoctorFreeSentSMS.Value <= doctorFreeSMSCount)
            {
                #region Get Request For Send SMS From Doctor

                var request = await _doctorRepository.GetRequestForSendSMSFromDoctorToPatientByRequestId(model.RequestId);
                if (request == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

                var requestDetail = await _doctorRepository.GetRequestDetailForSendSMSFromDoctorToPatientByRequestId(request.Id);
                if (requestDetail == null) return SendRequestOfSMSFromDoctorsToThePatientResult.WrongInformation;

                #endregion

                //Check Incoming SMS Right Now
                if (requestDetail.Count > doctorFreeSMSCount)
                {
                    return SendRequestOfSMSFromDoctorsToThePatientResult.HigherThanDoctorFreePercentage;
                }

                #region Update SMS 

                request.SendSMSFromDoctorState = Domain.Enums.SendSMS.FromDoctors.SendSMSFromDoctorState.WaitingForConfirm;

                #endregion

                //Add Request To The Data Base 
                await _doctorRepository.UpdateRequestForSendSMSFromDoctorToPatient(request);

                #region Reduce Percentage Doctor Free SMS Count

                await _doctorRepository.ReduceDoctorFreeSMSPercentageWithoutSaveChanges(doctor.Id, requestDetail.Count());

                #endregion

                await _doctorRepository.SaveChanges();
            }

            #endregion

            return SendRequestOfSMSFromDoctorsToThePatientResult.RequestSentSuccesfully;
        }

        #endregion

        #region Admin Side

        //Manage Request For Send SMS From Doctor To Patient Admin Side 
        public async Task<bool> ManageRequestForSendSMSFromDoctorToPatientAdminSide(ShowRequestForSendSMSDetailAdminSideViewModel model)
        {
            #region Get Request For Send SMS From Doctor

            var request = await _doctorRepository.GetRequestForSendSMSFromDoctorToPatientByRequestId(model.RequestId);
            if (request == null) return false;

            #endregion

            #region Get Request Detail

            var requestDetail = await _doctorRepository.GetRequestDetailForSendSMSFromDoctorToPatientByRequestId(request.Id);
            if (requestDetail == null) return false;

            #endregion

            #region Get Doctor As User

            User doctorAsUser = await _userService.GetUserById(request.DoctorUserId);
            if (doctorAsUser == null) return false;

            #endregion

            #region Change Request State 

            request.SendSMSFromDoctorState = model.SendSMSFromDoctorState;
            request.DeclineDescription = model.RejectDescription;

            //Update Request 
            await _doctorRepository.UpdateRequestForSendSMSFromDoctorToPatient(request);

            #endregion

            #region Send SMS Or Not 

            if (model.SendSMSFromDoctorState == Domain.Enums.SendSMS.FromDoctors.SendSMSFromDoctorState.AcceptAndSent)
            {
                #region Send SMS To Doctor 

                var message = Messages.SendSMSToTheDoctorForAcceptHisSendSMSRequest(DateTime.Now.ToShamsi());

                //Send SMS To The Doctor
                var res = await _smsservice.SendSimpleSMS(doctorAsUser.Mobile, message);

                #endregion

                foreach (var user in requestDetail)
                {
                    var patient = await _userService.GetUserById(user.UserId);

                    if (patient != null)
                    {
                        //Send SMS
                        var result = await _smsservice.SendSimpleSMS(patient.Mobile, Messages.SendSMSFromDoctorToThePatient(model.SMSBody));
                    }
                }
            }
            if (model.SendSMSFromDoctorState == Domain.Enums.SendSMS.FromDoctors.SendSMSFromDoctorState.Decline)
            {
                //Get Doctor By Doctor User Id
                var doctor = await _doctorRepository.GetDoctorByUserId(request.DoctorUserId);
                if (doctor == null) return false;

                #region Reduce Percentage Doctor Free SMS Count

                await _doctorRepository.AddDoctorSMSPercentageWithoutSaveChanges(doctor.Id, requestDetail.Count());

                #endregion

                await _doctorRepository.SaveChanges();

                if (!string.IsNullOrEmpty(model.RejectDescription))
                {
                    #region Send SMS To Doctor 

                    var message = Messages.SendSMSToTheDoctorForRejectHisSendSMSRequest(model.RejectDescription);

                    //Send SMS To The Doctor
                    var res = await _smsservice.SendSimpleSMS(doctorAsUser.Mobile, message);

                    #endregion
                }
            }

            #endregion

            return true;
        }

        //Get Request For Send SMS From Doctor To Patient By RequestId
        public async Task<ShowRequestForSendSMSDetailAdminSideViewModel?> FillShowRequestForSendSMSDetailViewModel(ulong requestId)
        {
            #region Get Request For Send SMS From Doctor

            var request = await _doctorRepository.GetRequestForSendSMSFromDoctorToPatientByRequestId(requestId);
            if (request == null) return null;

            #endregion

            #region Fill Instance

            ShowRequestForSendSMSDetailAdminSideViewModel returnModel = new ShowRequestForSendSMSDetailAdminSideViewModel()
            {
                RejectDescription = request.DeclineDescription,
                RequestId = request.Id,
                SendSMSFromDoctorState = request.SendSMSFromDoctorState,
                Users = await _doctorRepository.GetListUserThatDoctorWantToSendThemSMS(requestId),
                SMSBody = request.SMSText
            };

            #endregion

            return returnModel;
        }

        //List Of Request For Send SMS From Doctors To Doctors Admin Side
        public async Task<List<RequestForSendSMSFromDoctorsToTheUsersAdminSideViewModel>?> ListOfRequestForSendSMSFromDoctorsToDoctorsAdminSide()
        {
            return await _doctorRepository.ListOfRequestForSendSMSFromDoctorsToDoctorsAdminSide();
        }

        //Count Of Users In Doctors Population Covered
        public async Task<CountOfUsersInDoctorsPopulationCovered> FillCountOfUsersInDoctorsPopulationCovered()
        {
            #region Create Instance

            CountOfUsersInDoctorsPopulationCovered model = new CountOfUsersInDoctorsPopulationCovered();

            #endregion

            //Count Of All Users
            var usersWithoutDoctors = await _userRepositoryDapper.GetListOfUsersWithoutDoctors();
            model.CountOfAllUsers = usersWithoutDoctors.Count();

            //Count Of Accepted Family Doctor Requests
            model.CountOfUsersWithDoctorFamily = await _familyDoctorService.CountOfAcceptedFamilyDoctorRequests();

            //Count Of Awaiting Family Doctor Requests
            model.CountOfUsersWaitingForAcceptFromFamilyDoctors = await _familyDoctorService.CountOfAwaitingFamilyDoctorRequests();

            //Count OF Users Witout Family Doctor Request
            model.CountOfUsersWithoutFamilyDoctors = model.CountOfAllUsers - (model.CountOfUsersWithDoctorFamily + model.CountOfUsersWaitingForAcceptFromFamilyDoctors);

            return model;
        }

        //Count Of All Doctors 
        public async Task<int> CountOfAllDoctors()
        {
            var doctors = await _doctorRepository.GetListOfAcceptedDoctors();
            return doctors.Count();
        }

        //List Of Doctors Population Covered Count Detail
        public async Task<List<ListOfDoctorsPopulationCoveredCountDetailViewModel>> ListOfDoctorsPopulationCoveredCountDetail()
        {
            //make a main instance
            List<ListOfDoctorsPopulationCoveredCountDetailViewModel> model = new List<ListOfDoctorsPopulationCoveredCountDetailViewModel>();

            #region Doctors

            var doctors = await _doctorRepository.GetListOfAcceptedDoctors();

            foreach (var item in doctors)
            {
                //make instance 
                ListOfDoctorsPopulationCoveredCountDetailViewModel subMain = new ListOfDoctorsPopulationCoveredCountDetailViewModel();

                subMain.Doctor = item;

                var doctorActivePopulation = await _doctorRepository.GetDoctorActivePopulationCoveredCount(item.Id);
                subMain.ActiveUsersCount = doctorActivePopulation.Count();

                subMain.UsersPopulationCoveredCount = await _doctorRepository.GetUsersPopulationCountWithRangeOfUserIds(doctorActivePopulation);

                model.Add(subMain);
            }

            #endregion

            return model;
        }

        //Get Diabet Consultant Resumes By UserId Admin Side
        public async Task<List<DiabetConsultantsResume>?> GetDiabetConsultanResumesByUserIdAdminSide(ulong userId)
        {
            return await _doctorRepository.GetDoctorDiabetConsultantResumesByDoctorUserId(userId);
        }

        //Get Blood Pressure Consultant Resumes By UserId Admin Side
        public async Task<List<BloodPressureConsultantResume>?> GetBloodPressureConsultanResumesByUserIdAdminSide(ulong userId)
        {
            return await _doctorRepository.GetDoctorBloodPressureConsultantResumesByDoctorUserId(userId);
        }

        //List Of Arrival Excel Files Show In Admin Side 
        public async Task<List<ListOfArrivalExcelFiles>> FillListOfArrivalExcelFilesAdminSideViewModel()
        {
            #region Fill Model 

            //Main Instance
            List<ListOfArrivalExcelFiles> model = new List<ListOfArrivalExcelFiles>();

            //Get List Of Requests For Excel Files
            var listOFRequests = await _doctorRepository.GetLastestRequestForUplaodExcelFile();

            foreach (var request in listOFRequests)
            {
                model.Add(new ListOfArrivalExcelFiles()
                {
                    ExcelFile = request,
                    User = await _userService.GetUserById(request.DoctorId)
                });
            }

            #endregion

            return model;
        }

        // Fill Request For Upload Excel File Detail Admin Side View Model
        public async Task<RequestForUploadExcelFileDetailAdminSideViewModel?> FillRequestForUploadExcelFileDetailAdminSideViewModel(ulong requestId)
        {
            #region Get Request Excel File By Id 

            var request = await _doctorRepository.GetRequestExcelFileById(requestId);
            if (request == null) return null;

            #endregion

            #region Get User By User Id 

            var user = await _userService.GetUserById(request.DoctorId);
            if (user == null) return null;

            #endregion

            #region Fill Model 

            RequestForUploadExcelFileDetailAdminSideViewModel model = new RequestForUploadExcelFileDetailAdminSideViewModel()
            {
                ExcelFile = request.ExcelFile,
                User = user,
                IsPending = request.IsPending,
                requestId = request.Id
            };

            #endregion

            return model;
        }

        public async Task<Doctor?> GetDoctorById(ulong doctorId)
        {
            return await _doctorRepository.GetDoctorById(doctorId);
        }

        //Count Of Accepted Doctors
        public async Task<int?> CountOfAcceptedDoctors()
        {
            return await _doctorRepository.CountOfAcceptedDoctors();
        }

        //Count Of Decline Doctors
        public async Task<int?> CountOfDeclineDoctors()
        {
            return await _doctorRepository.CountOfDeclineDoctors();
        }

        //Count Of Waiting Doctors
        public async Task<int?> CountOfWaitingDoctors()
        {
            return await _doctorRepository.CountOfWaitingDoctors();
        }

        //Count Of New Register Doctors
        public async Task<int?> CountOfRegisterDoctors()
        {
            return await _doctorRepository.CountOfRegisterDoctors();
        }

        //Count Of Deleted Doctors
        public async Task<int?> CountOfDeletedDoctors()
        {
            return await _doctorRepository.CountOfDeletedDoctors();
        }

        //Filter List Of Doctors From Admin Panel
        public async Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter)
        {
            #region Fill Return Model 

            var model = await _doctorRepository.FilterDoctorsInfoAdminSide(filter);

            //List Of Accepted Doctors
            model.CountOfAcceptedDoctors = await CountOfAcceptedDoctors();

            //List Of Decline Doctors
            model.CountOfDeclineDoctors = await CountOfDeclineDoctors();

            //List Of Waiting Info Doctors
            model.CountOfWaitingDoctors = await CountOfWaitingDoctors();

            //List Of New Register Doctors
            model.CountOfNewRegisterDoctors = await CountOfRegisterDoctors();

            //List Of Deleted Doctors
            model.CountOfDeletedDoctors = await CountOfDeletedDoctors();

            #endregion

            return await _doctorRepository.FilterDoctorsInfoAdminSide(filter);
        }

        //List Of Doctors For Export Excel File 
        public async Task<List<ListOfDoctorsInfoForExportExcelFileViewModel>> ListOfDoctorsForExportExcelFile(ListOfDoctorsInfoForExportExcelFileViewModel filter)
        {
            return await _doctorRepository.ListOfDoctorsForExportExcelFile(filter);
        }

        //Get List Of Doctors Name
        public async Task<List<string>?> GetListOfDoctorsName()
        {
            return await _doctorRepository.GetListOfDoctorsName();
        }

        public async Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId)
        {
            return await _doctorRepository.GetDoctorsInfoById(doctorInfoId);
        }

        //Decline Doctor Information By One Click 
        public async Task<bool> DeclineDoctorInformationByOneClick(ulong userId)
        {
            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (doctorOffice == null) return false;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return false;

            #endregion

            #region Decline Doctor Office 

            doctorOffice.OrganizationInfoState = OrganizationInfoState.Rejected;
            doctorOffice.RejectDescription = "اطلاعات پذیرفته نشده است.";

            //Update Method 
            await _organizationService.UpdateOrganization(doctorOffice);

            #endregion

            return true;
        }

        public async Task<DoctorsInfoDetailViewModel?> FillDoctorsInfoDetailViewModel(ulong doctorInfoId)
        {
            #region Get Doctor Info

            //Get Doctor Info By Id
            var info = await _doctorRepository.GetDoctorsInfoByDoctorId(doctorInfoId);

            if (info == null) return null;

            #endregion

            #region Get Doctor Info

            var doctor = await GetDoctorById(info.DoctorId);

            if (doctor == null) return null;

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(doctor.UserId);
            if (doctorOffice == null) return null;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return null;

            #endregion

            #region Get Doctor Skill By Doctor Id

            var doctorSkills = await _doctorRepository.GetListOfDoctorSkillsByDoctorId(info.DoctorId);

            #endregion

            #region Fill View Model

            DoctorsInfoDetailViewModel model = new DoctorsInfoDetailViewModel()
            {
                UserId = doctor.UserId,
                NationalCode = info.NationalCode,
                MedicalSystemCode = info.MedicalSystemCode,
                Education = info.Education,
                Specialty = info.Specialty,
                MediacalFile = info.MediacalFile,
                RejectDescription = doctorOffice.RejectDescription,
                DoctorsInfosType = doctorOffice.OrganizationInfoState,
                Id = info.Id,
                DoctorId = doctor.Id,
                Gender = info.Gender,
                DoctorsInterests = await _doctorRepository.GetDoctorSelectedInterests(doctor.Id),
                GeneralPhone = info.GeneralPhone,
                ClinicPhone = info.ClinicPhone,
                DoctorSkills = string.Join(",", doctorSkills.Select(p => p.DoctorSkil).ToList()),
                CountOFFreeSMSForDoctors = info.CountOFFreeSMSForDoctors,
                DoctorTilteName = info.DoctorTilteName
            };

            #endregion

            #region Get Doctor Work Addresses

            model.WorkAddresses = await _workAddress.GetUserWorkAddressesByUserId(doctor.UserId);

            #endregion

            #region Get Doctor Selected Specialities

            var doctorSelectedSpecialitiesIds = await _specialityRepository.GetListOfDoctorSpecialities(doctorInfoId);

            List<DoctorFAM.Domain.Entities.Speciality.Speciality> spcs = new List<DoctorFAM.Domain.Entities.Speciality.Speciality>();

            if (doctorSelectedSpecialitiesIds != null && doctorSelectedSpecialitiesIds.Any())
            {
                foreach (var item in doctorSelectedSpecialitiesIds)
                {
                    var seletedspeciality = await _specialityRepository.GetSpecialityById(item);

                    if (seletedspeciality != null)
                    {
                        spcs.Add(seletedspeciality);
                    }
                }
            }

            model.DoctorsSelectedSpecialities = spcs;

            #endregion

            #region Get Doctor Reservation Tariff By doctor UserId

            var reservationTariff = await GetDoctorReservationTariffByDoctorUserId(doctorOffice.OwnerId);

            if (reservationTariff != null)
            {
                model.InPersonReservationTariffForDoctorPopulationCovered = reservationTariff.InPersonReservationTariffForDoctorPopulationCovered;
                model.OnlineReservationTariffForDoctorPopulationCovered = reservationTariff.OnlineReservationTariffForDoctorPopulationCovered;
                model.InPersonReservationTariffForAnonymousPersons = reservationTariff.InPersonReservationTariffForAnonymousPersons;
                model.OnlineReservationTariffForAnonymousPersons = reservationTariff.OnlineReservationTariffForAnonymousPersons;
                model.DoctorReservationAlert = reservationTariff?.DoctorReservationAlert;
            }
            else
            {
                model.InPersonReservationTariffForDoctorPopulationCovered = null;
                model.OnlineReservationTariffForDoctorPopulationCovered = null;
                model.InPersonReservationTariffForAnonymousPersons = null;
                model.OnlineReservationTariffForAnonymousPersons = null;
                model.DoctorReservationAlert = null;
            }

            #endregion

            return model;
        }

        public async Task<EditDoctorInfoResult> EditDoctorInfoAdminSide(DoctorsInfoDetailViewModel model, IFormFile? MediacalFile)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(model.UserId);

            if (user == null) return EditDoctorInfoResult.faild;

            if (string.IsNullOrEmpty(model.NationalCode))
            {
                return EditDoctorInfoResult.NationalId;
            }

            if (!string.IsNullOrEmpty(model.NationalCode) && !await _userService.IsValidNationalIdForUserEditByAdmin(model.NationalCode, user.Id))
            {
                return EditDoctorInfoResult.NationalId;
            }

            #endregion

            #region Get Doctor Info By Id

            //Get Doctor Info By Id
            var info = await _doctorRepository.GetDoctorsInfoById(model.Id);

            if (info == null) return EditDoctorInfoResult.faild;

            #endregion

            #region Get Doctor By Id 

            var doctor = await GetDoctorById(model.DoctorId);

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetDoctorOrganizationByUserId(doctor.UserId);
            if (doctorOffice == null) return EditDoctorInfoResult.faild;
            if (doctorOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return EditDoctorInfoResult.faild;

            #endregion

            #region Update Doctor 

            doctorOffice.OrganizationInfoState = model.DoctorsInfosType;
            doctorOffice.RejectDescription = model.RejectDescription;

            if (model.DoctorsInfosType == OrganizationInfoState.Accepted)
            {
                doctorOffice.RejectDescription = null;
            }

            await _organizationService.UpdateOrganization(doctorOffice);

            #endregion

            #region Edit Doctor Info 

            #region Edit Properties

            info.MedicalSystemCode = model.MedicalSystemCode;
            info.Specialty = model.Specialty;
            info.Education = model.Education;
            info.NationalCode = model.NationalCode;
            info.Gender = model.Gender;
            info.GeneralPhone = model.GeneralPhone;
            info.ClinicPhone = model.ClinicPhone;
            info.CountOFFreeSMSForDoctors = model.CountOFFreeSMSForDoctors;
            info.DoctorTilteName = model.DoctorTilteName;

            #endregion

            #region Update User

            user.NationalId = model.NationalCode.SanitizeText();
            user.ExtraPhoneNumber = model.GeneralPhone.SanitizeText();

            await _userService.UpdateUser(user);

            #endregion

            #region Doctor Selected Skils

            var doctorSkills = await GetListOfDoctorSkillsByDoctorId(doctor.Id);

            if (doctorSkills.Any())
            {
                await _doctorRepository.RemoveDoctorSkills(doctorSkills);
            }

            if (!string.IsNullOrEmpty(model.DoctorSkills))
            {
                var skills = model.DoctorSkills.Split(',').ToList();

                foreach (var item in skills)
                {
                    var skill = new DoctorsSkils
                    {
                        DoctorId = doctor.Id,
                        DoctorSkil = item
                    };
                    await _doctorRepository.AddDoctorSelectedSkilsWithoutSaveChanges(skill);
                }
            }

            #endregion

            #region Edit Medical File 

            if (MediacalFile != null)
            {
                if (!string.IsNullOrEmpty(info.MediacalFile))
                {
                    info.MediacalFile.DeleteImage(PathTools.MediacalFilePathServer, PathTools.MediacalFilePathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                info.MediacalFile = imageName;
            }

            #endregion

            #region Update Method

            await _doctorRepository.UpdateDoctorsInfo(info);

            #endregion

            #region Edit Doctor Reservation Tariff

            if (model.InPersonReservationTariffForDoctorPopulationCovered.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForDoctorPopulationCovered(model.InPersonReservationTariffForDoctorPopulationCovered.Value))
            {
                return EditDoctorInfoResult.InpersonReservationPopluationCoveredLessThanSiteShare;
            }

            if (model.OnlineReservationTariffForDoctorPopulationCovered.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForDoctorPopulationCovered(model.OnlineReservationTariffForDoctorPopulationCovered.Value))
            {
                return EditDoctorInfoResult.OnlineReservationPopluationCoveredLessThanSiteShare;
            }

            if (model.InPersonReservationTariffForAnonymousPersons.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldInPersonReservationTariffForAnonymousPersons(model.InPersonReservationTariffForAnonymousPersons.Value))
            {
                return EditDoctorInfoResult.InpersonReservationAnonymousePersoneLessThanSiteShare;
            }

            if (model.OnlineReservationTariffForAnonymousPersons.HasValue && await _siteSetting.CheckDoctorInsertedTarrifBySiteInFieldOnlineReservationTariffForAnonymousPersons(model.OnlineReservationTariffForAnonymousPersons.Value))
            {
                return EditDoctorInfoResult.OnlineReservationAnonymousePersoneLessThanSiteShare;
            }

            //Get Doctor Reservation Tariff
            var reservation = await GetDoctorReservationTariffByDoctorUserId(doctorOffice.OwnerId);
            if (reservation != null)
            {
                reservation.InPersonReservationTariffForDoctorPopulationCovered = model.InPersonReservationTariffForDoctorPopulationCovered.Value;
                reservation.OnlineReservationTariffForDoctorPopulationCovered = model.OnlineReservationTariffForDoctorPopulationCovered.Value;
                reservation.OnlineReservationTariffForAnonymousPersons = model.OnlineReservationTariffForAnonymousPersons.Value;
                reservation.InPersonReservationTariffForAnonymousPersons = model.InPersonReservationTariffForAnonymousPersons.Value;

                //Update Reservation Data 
                await _doctorRepository.UpdateDoctorReservationTariffs(reservation);
            }

            #endregion

            #endregion

            return EditDoctorInfoResult.success;
        }

        #endregion

        #region Site Side 

        //Get List Of All Doctors
        public async Task<List<ListOfAllDoctorsViewModel>> ListOfDoctors()
        {
            return await _doctorRepository.ListOfDoctors();
        }

        //Fill Doctor Page In Reservation Page 
        public async Task<DoctorPageInReservationViewModel?> FillDoctorPageDetailInReservationPage(ulong userId)
        {
            #region Get Doctor By User Id

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return null;

            #endregion

            #region Validate Doctor 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;
            if (organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Get Doctor Personal Info 

            var doctorPersonalInfo = await _doctorRepository.GetDoctorsInfoByDoctorId(doctor.Id);
            if (doctorPersonalInfo == null) return null;

            #endregion

            #region Fill Model 

            DoctorPageInReservationViewModel model = new DoctorPageInReservationViewModel()
            {
                UserId = userId,
                Username = doctor.User.Username,
                UserAvatar = doctor.User.Avatar,
                Education = doctorPersonalInfo.Education,
                Specialist = doctorPersonalInfo.Specialty,
                GeneralPhone = doctorPersonalInfo.GeneralPhone, 
                ClinicPhone = doctorPersonalInfo.ClinicPhone
            };

            #endregion

            #region Get User Office Address

            var workAddress = await _workAddress.GetUserWorkAddressById(userId);

            if (workAddress != null)
            {
                var country = await _locationRepository.GetLocationById(workAddress.CountryId);
                if (country == null) return null;

                var state = await _locationRepository.GetLocationById(workAddress.StateId);
                if (state == null) return null;

                var city = await _locationRepository.GetLocationById(workAddress.CityId);
                if (city == null) return null;

                model.CountryName = country.UniqueName;
                model.StateName = state.UniqueName;
                model.CityName = city.UniqueName;
                model.WorkAddress = workAddress.Address;
            }

            #endregion

            #region Get Resume By Id

            var resume = await _resumeService.GetResumeByUserId(organization.OwnerId);
            if (resume != null)
            {
                model.Resume = resume;
            }

            #endregion

            #region Fill Resume Model 

            if (resume != null)
            {
                #region Fill User Property 

                var user = await _userService.GetUserById(resume.UserId);
                if (user == null) return null;

                model.User = user;

                #endregion

                #region Fill About Me 

                var aboutMe = await _resumeService.GetUserAboutMeResumeByResumeId(resume.Id);

                //Create New Instance 
                model.ResumeAboutMeSitePanelViewModel = new ResumeAboutMeSitePanelViewModel()
                {
                    AboutMeId = ((aboutMe == null) ? null : aboutMe.Id),
                    Text = ((aboutMe == null) ? null : aboutMe.AboutMeText),
                    ResumeId = resume.Id,
                };

                #endregion

                #region Fill Education 

                var education = await _resumeService.GetEducationResumeByResumeId(resume.Id);

                var returnEducation = new List<EducationResumeInSitePanelViewModel>();

                //Create New Instance
                if (education != null && education.Any())
                {
                    foreach (var item in education)
                    {
                        EducationResumeInSitePanelViewModel ed = (new EducationResumeInSitePanelViewModel()
                        {
                            CityName = ((string.IsNullOrEmpty(item.CityName)) ? null : item.CityName),
                            CountryName = ((string.IsNullOrEmpty(item.CountryName)) ? null : item.CountryName),
                            EndDate = ((item.EndDate == null) ? null : item.EndDate),
                            FieldOfStudy = ((string.IsNullOrEmpty(item.FieldOfStudy)) ? null : item.FieldOfStudy),
                            Orientation = ((string.IsNullOrEmpty(item.Orientation)) ? null : item.Orientation),
                            StartDate = ((item.StartDate == null) ? null : item.StartDate),
                            UnivercityName = ((string.IsNullOrEmpty(item.UnivercityName)) ? null : item.UnivercityName),
                            CreateDate = item.CreateDate,
                            Id = item.Id,
                        });

                        returnEducation.Add(ed);
                    }
                }

                model.EducationResume = returnEducation;

                #endregion

                #region Fill Work Address

                var workHistory = await _resumeService.GetWorkHistoryResumeByResumeId(resume.Id);

                var returnWorkHistory = new List<WorkHistoryResumeInSitePanelViewModel>();

                //Create New Instance
                if (workHistory != null && workHistory.Any())
                {
                    foreach (var item in workHistory)
                    {
                        WorkHistoryResumeInSitePanelViewModel work = (new WorkHistoryResumeInSitePanelViewModel()
                        {
                            WorkAddress = ((string.IsNullOrEmpty(item.WorkAddress)) ? null : item.WorkAddress),
                            JobPosition = ((string.IsNullOrEmpty(item.JobPosition)) ? null : item.JobPosition),
                            EndDate = ((item.EndDate == null) ? null : item.EndDate),
                            StartDate = ((item.StartDate == null) ? null : item.StartDate),
                            Id = item.Id,
                        });

                        returnWorkHistory.Add(work);
                    }
                }

                model.WorkHistoryResume = returnWorkHistory;

                #endregion

                #region Fill Honor

                var honor = await _resumeService.GetHonorResumeByResumeId(resume.Id);

                var returnHonor = new List<HonorResumeInSitePanelViewModel>();

                //Create New Instance
                if (honor != null && honor.Any())
                {
                    foreach (var item in honor)
                    {
                        HonorResumeInSitePanelViewModel hr = (new HonorResumeInSitePanelViewModel()
                        {
                            HonorTitle = ((string.IsNullOrEmpty(item.HonorTitle)) ? null : item.HonorTitle),
                            ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                            Description = ((string.IsNullOrEmpty(item.Description)) ? null : item.Description),
                            HonorDate = item.HonorDate,
                            Id = item.Id,
                        });

                        returnHonor.Add(hr);
                    }
                }

                model.HonorResume = returnHonor;

                #endregion

                #region Fill Service

                var service = await _resumeService.GetServiceResumeByResumeId(resume.Id);

                var returnService = new List<ServiceResumeInSitePanelViewModel>();

                //Create New Instance
                if (service != null && service.Any())
                {
                    foreach (var item in service)
                    {
                        ServiceResumeInSitePanelViewModel sr = (new ServiceResumeInSitePanelViewModel()
                        {
                            ServiceTitle = ((string.IsNullOrEmpty(item.ServiceTitle)) ? null : item.ServiceTitle),
                            Id = item.Id,
                        });

                        returnService.Add(sr);
                    }
                }

                model.ServiceResume = returnService;

                #endregion

                #region Fill Working Address

                var workingAddress = await _resumeService.GetWorkingAddressResumeByResumeId(resume.Id);

                var returnWorkingAddress = new List<WorkingAddressResumeInSitePanelViewModel>();

                //Create New Instance
                if (workingAddress != null && workingAddress.Any())
                {
                    foreach (var item in workingAddress)
                    {
                        WorkingAddressResumeInSitePanelViewModel wr = (new WorkingAddressResumeInSitePanelViewModel()
                        {
                            WorkingAddress = ((string.IsNullOrEmpty(item.WorkingAddress)) ? null : item.WorkingAddress),
                            WorkingAddressTitle = ((string.IsNullOrEmpty(item.WorkingAddressTitle)) ? null : item.WorkingAddressTitle),
                            Days = ((string.IsNullOrEmpty(item.Days)) ? null : item.Days),
                            Times = ((string.IsNullOrEmpty(item.Times)) ? null : item.Times),
                            Id = item.Id,
                        });

                        returnWorkingAddress.Add(wr);
                    }
                }

                model.WorkingAddressResume = returnWorkingAddress;

                #endregion

                #region Fill Certificate

                var certificate = await _resumeService.GetCertificateResumeByResumeId(resume.Id);

                var returnCertificate = new List<CertificateResumeInSitePanelViewModel>();

                //Create New Instance
                if (certificate != null && certificate.Any())
                {
                    foreach (var item in certificate)
                    {
                        CertificateResumeInSitePanelViewModel cr = (new CertificateResumeInSitePanelViewModel()
                        {
                            CertificateTitle = ((string.IsNullOrEmpty(item.CertificateTitle)) ? null : item.CertificateTitle),
                            ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                            ExporterRefrence = ((string.IsNullOrEmpty(item.ExporterRefrence)) ? null : item.ExporterRefrence),
                            Id = item.Id,
                        });

                        returnCertificate.Add(cr);
                    }
                }

                model.CertificateResume = returnCertificate;

                #endregion

                #region Fill Gallery

                var gallery = await _resumeService.GetGalleryResumeByResumeId(resume.Id);

                var returnGallery = new List<GalleryResumeInSitePanelViewModel>();

                //Create New Instance
                if (gallery != null && gallery.Any())
                {
                    foreach (var item in gallery)
                    {
                        GalleryResumeInSitePanelViewModel gal = (new GalleryResumeInSitePanelViewModel()
                        {
                            Title = ((string.IsNullOrEmpty(item.Title)) ? null : item.Title),
                            ImageName = ((string.IsNullOrEmpty(item.ImageName)) ? null : item.ImageName),
                            Id = item.Id,
                        });

                        returnGallery.Add(gal);
                    }
                }

                model.GalleryResume = returnGallery;

                #endregion
            }

            #endregion

            return model;
        }

        //Fill Doctor Reservation Detail For Show Site Side View Model
        public async Task<ShowDoctorReservationDetailViewModel?> FillDoctorReservationDetailForShowSiteSide(ulong userId, string? loggedDateTime)
        {
            #region Get Doctor By User Id

            var doctor = await _doctorRepository.GetDoctorByUserId(userId);
            if (doctor == null) return null;

            #endregion

            #region Validate Doctor 

            var organization = await _organizationService.GetOrganizationByUserId(userId);
            if (organization == null) return null;
            if (organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Get Doctor Personal Info 

            var doctorPersonalInfo = await _doctorRepository.GetDoctorsInfoByDoctorId(doctor.Id);
            if (doctorPersonalInfo == null) return null;

            #endregion

            #region Fill Model 

            ShowDoctorReservationDetailViewModel model = new ShowDoctorReservationDetailViewModel()
            {
                UserId = userId,
                LoggedDateTime = loggedDateTime,
                DoctorReservationDate = ((!string.IsNullOrEmpty(loggedDateTime) ? await _reservationService.GetDoctorReservationDateByReservationDateAndUserId(loggedDateTime, userId) : null)),
                DoctorReservationDateTimes = ((!string.IsNullOrEmpty(loggedDateTime) ? await _reservationService.GetDoctorReservationDateByReservationDateTimeAndUserId(loggedDateTime, userId) : null)),
                ListOfReservationDateAndReservationDateTime = await _reservationService.GetListOfDoctorReservationDateAndDoctorReservationDateTimeForShowSiteSide(organization.OwnerId),
                DoctorReservationAlert = await _reservationService.GetDoctorReservationAlertByDoctorUserId(organization.OwnerId)
            };

            DoctorPageInReservationViewModel childModel = new DoctorPageInReservationViewModel()
            {
                UserId = userId,
                Username = doctor.User.Username,
                UserAvatar = doctor.User.Avatar,
                Education = doctorPersonalInfo.Education,
                Specialist = doctorPersonalInfo.Specialty,
            };

            model.DoctorPageInReservationViewModel = childModel;

            #endregion

            return model;
        }

        //Get Doctro For Send Notification For Take Reservation Notification 
        public async Task<string?> GetDoctroForSendNotificationForTakeReservationNotification(ulong reservationDateTimeId)
        {
            #region Get Reservation Date Time By Id

            var reservationDateTime = await _reservationService.GetDoctorReservationDateTimeById(reservationDateTimeId);
            if (reservationDateTime == null) return null;

            #endregion

            return reservationDateTime.DoctorReservationDate.UserId.ToString();
        }

        //Get List Of Doctors With Diabet Speciality
        public async Task<List<Doctor>?> FilterDoctorsWithDiabetSpecialitySiteSide(FilterDoctorsWithDiabetSpecialitySiteSideViewModel filter)
        {
            return await _doctorRepository.FilterDoctorsWithDiabetSpecialitySiteSide(filter);
        }

        //Get List Of Doctors With Blood Pressure Speciality
        public async Task<List<Doctor>?> FilterDoctorsWithBloodPressureSpecialitySiteSide(FilterDoctorsWithBloodPressureSpecialitySiteSideViewModel filter)
        {
            return await _doctorRepository.FilterDoctorsWithBloodPressureSpecialitySiteSide(filter);
        }

        //Get Doctr Name With PArt Of Name
        public async Task<List<string>?> GetListOfDoctorsName(string doctorNamePart)
        {
            //Get List Of Doctors Name 
            var doctorsNames = await _doctorRepository.GetListOfDoctorsName();

            //New Instance Of Return Moldel
            List<string>? returnModel = new List<string>();

            foreach (var doctorName in doctorsNames)
            {
                if (doctorName.Contains(doctorNamePart))
                {
                    returnModel.Add(doctorName);
                }
            }

            return returnModel;
        }

        //Process Reservation Tariff For Pay From User
        public async Task<int?> ProcessReservationTariffForPayFromUser(ulong doctorUserId, ulong userId, DoctorReservationType DoctorReservationType)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetOrganizationByUserId(doctorUserId);
            if (doctorOffice == null) return null;
            if (doctorOffice.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Get Doctor Reservation Tariff

            var reservationTariff = await GetDoctorReservationTariffByDoctorUserId(doctorOffice.OwnerId);
            if (reservationTariff == null) return null;

            #endregion

            #region Check Doctor Population Covered 

            var populationCovered = await _familyDoctorService.GetUserSelectedFamilyDoctorByUserAndDoctorId(userId, doctorOffice.OwnerId);

            //If User Is In Doctor Population Covered 
            if (populationCovered != null && populationCovered.IsUserInDoctorPopulationCoveredOutOfDoctorFAM)
            {
                //If Reservation Type Is In Person 
                if (DoctorReservationType == DoctorReservationType.Reserved)
                {
                    return reservationTariff.InPersonReservationTariffForDoctorPopulationCovered;
                }

                //If Reservation Type Is Online 
                if (DoctorReservationType == DoctorReservationType.Onile || DoctorReservationType == DoctorReservationType.BothOnlineAndReserved)
                {
                    return reservationTariff.OnlineReservationTariffForDoctorPopulationCovered;
                }
            }

            else
            {
                //If Reservation Type Is In Person
                if (DoctorReservationType == DoctorReservationType.Reserved)
                {
                    return reservationTariff.InPersonReservationTariffForAnonymousPersons;
                }

                //If Reservation Type Is Online 
                if (DoctorReservationType == DoctorReservationType.Onile || DoctorReservationType == DoctorReservationType.BothOnlineAndReserved)
                {
                    return reservationTariff.OnlineReservationTariffForAnonymousPersons;
                }
            }

            #endregion

            return null;
        }

        //Process Reservation Tariff For Pay From User And Is User In Doctor Population Covered Or Not
        public async Task<ValueTuple<int,bool,bool>> ProcessReservationTariffForPayFromUserAndIsUserInDoctorPopulationCoveredOrNot(ulong doctorUserId, ulong userId, DoctorReservationType DoctorReservationType)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(userId);
            if (user == null) return ValueTuple.Create(0,false,false);

            #endregion

            #region Get Current Doctor Office

            var doctorOffice = await _organizationService.GetOrganizationByUserId(doctorUserId);
            if (doctorOffice == null) return ValueTuple.Create(0, false, false);
            if (doctorOffice.OrganizationInfoState != OrganizationInfoState.Accepted) return ValueTuple.Create(0, false, false);

            #endregion

            #region Get Doctor Reservation Tariff

            var reservationTariff = await GetDoctorReservationTariffByDoctorUserId(doctorOffice.OwnerId);
            if (reservationTariff == null) return ValueTuple.Create(0, false, false);

            #endregion

            #region Check Doctor Population Covered 

            var populationCovered = await _familyDoctorService.GetUserSelectedFamilyDoctorByUserAndDoctorId(userId, doctorOffice.OwnerId);

            //If User Is In Doctor Population Covered 
            if (populationCovered != null && populationCovered.IsUserInDoctorPopulationCoveredOutOfDoctorFAM)
            {
                //If Reservation Type Is In Person 
                if (DoctorReservationType == DoctorReservationType.Reserved)
                {
                    return ValueTuple.Create(reservationTariff.InPersonReservationTariffForDoctorPopulationCovered, true , true);
                }

                //If Reservation Type Is Online 
                if (DoctorReservationType == DoctorReservationType.Onile || DoctorReservationType == DoctorReservationType.BothOnlineAndReserved)
                {
                    return ValueTuple.Create(reservationTariff.OnlineReservationTariffForDoctorPopulationCovered, true, true);
                }
            }

            else
            {
                //If Reservation Type Is In Person
                if (DoctorReservationType == DoctorReservationType.Reserved)
                {
                    return ValueTuple.Create(reservationTariff.InPersonReservationTariffForAnonymousPersons, false , true);
                }

                //If Reservation Type Is Online 
                if (DoctorReservationType == DoctorReservationType.Onile || DoctorReservationType == DoctorReservationType.BothOnlineAndReserved)
                {
                    return ValueTuple.Create(reservationTariff.OnlineReservationTariffForAnonymousPersons, false , true);
                }
            }

            #endregion

            return ValueTuple.Create(0, false , false); 
        }

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        public async Task<List<Doctor?>> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter)
        {
            return await _doctorRepository.FilterFamilyDoctorUserPanelSide(filter);
        }

        //Get List Of Doctors With Diabet Consultant Interests
        public async Task<List<Doctor>?> FilterDiabetConsultantsSiteSide(FilterDiabetConsultantsSiteSideViewModel filter)
        {
            return await _doctorRepository.FilterDiabetConsultantsSiteSide(filter);
        }

        //Get List Of Doctors With Blood Pressure Consultant Interests
        public async Task<List<Doctor>?> FilterBloodPressureConsultantsSiteSide(FilterBloodPressureConsultantsSiteSideViewModel filter)
        {
            return await _doctorRepository.FilterBloodPressureConsultantsSiteSide(filter);
        }

        //Fill Doctor Family Reservation Information Detail View Model
        public async Task<ShowDoctorInformationDetailViewModel?> FillShowDoctorInformationDetailViewModel(ulong doctorId)
        {
            #region Get Doctor By Doctor Id

            var doctor = await GetDoctorById(doctorId);
            if (doctor == null) return null;

            #endregion

            #region Check Doctor Validation 

            #region Organization Validation 

            var organization = await _organizationService.GetDoctorOrganizationByUserId(doctor.UserId);
            if (organization == null) return null;
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

            #endregion

            #region Validation Doctor Interest

            var getDoctorInterest = await _doctorRepository.GetDoctorSelectedInterests(doctorId);
            if (!getDoctorInterest.Any(p => !p.IsDelete && p.InterestId == 3)) return null;

            #endregion

            #endregion

            #region Get Doctor Work Address 

            var workAddress = await _workAddress.GetLastWorkAddressByUserId(doctor.UserId);

            #endregion

            #region Get Doctor Personal Information 

            var doctorInfo = await _doctorRepository.GetDoctorsInfoByDoctorId(doctorId);
            if (doctorInfo == null) return null;

            #endregion

            #region Fill View Model 

            ShowDoctorInformationDetailViewModel model = new ShowDoctorInformationDetailViewModel()
            {
                DoctorsInfo = doctorInfo,
                User = doctor.User,
                WorkAddress = workAddress,
                WorkLocation = doctor.User.WorkAddress
            };

            #endregion

            return model;
        }

        #endregion
    }
}
