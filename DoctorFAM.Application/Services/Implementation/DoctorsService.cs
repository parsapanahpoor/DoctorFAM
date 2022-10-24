using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.DoctorPanel.ParsaSystem;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.Site.Reservation;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using SixLabors.ImageSharp.ColorSpaces;
using System.Collections.Generic;

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


        public DoctorsService(IDoctorsRepository doctorRepository, IUserService userService, IOrganizationService organizationService,
                                IWorkAddressService workAddress, ILocationRepository locationRepository, IReservationService reservationService , ISMSService smsservice)
        {
            _doctorRepository = doctorRepository;
            _userService = userService;
            _organizationService = organizationService;
            _workAddress = workAddress;
            _locationRepository = locationRepository;
            _reservationService = reservationService;
            _smsservice = smsservice;
        }

        #endregion

        #region Doctors Panel Side

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

            return await _doctorRepository.ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(id , organization.OwnerId);

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

        //List Of DOctor Parsa System Users
        public async Task<List<UserInsertedFromParsaSystem>?> ListOfDoctorParsaSystemUsers(ulong DoctorUserId)
        {
            #region Get Organization

            var organization = await _organizationService.GetDoctorOrganizationByUserId(DoctorUserId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
            {
                return null;
            }

            #endregion

            return await _doctorRepository.ListOfDoctorParsaSystemUsers(organization.OwnerId);
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

            var organization = await _organizationService.GetDoctorOrganizationByUserId(userId);
            if (organization.OrganizationInfoState != OrganizationInfoState.Accepted || organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice)
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
                };

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

        //Get List Of Doctor Skills By Doctor Id
        public async Task<List<DoctorsSkils>> GetListOfDoctorSkillsByDoctorId(ulong doctorId)
        {
            return await _doctorRepository.GetListOfDoctorSkillsByDoctorId(doctorId);
        }

        public async Task<AddOrEditDoctorInfoResult> AddOrEditDoctorInfoDoctorsPanel(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(model.UserId);

            if (user == null) return AddOrEditDoctorInfoResult.Faild;

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

                #region Update First Name And Last Name 

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;

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
                        ClinicPhone = model.ClinicPhone
                    };

                    #endregion

                    #region Update First Name And Last Name 

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

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
                        ClinicPhone = model.ClinicPhone
                    };

                    #endregion

                    #region Update First Name And Last Name 

                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;

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

#endregion

        #region Admin Side

        public async Task<Doctor?> GetDoctorById(ulong doctorId)
        {
            return await _doctorRepository.GetDoctorById(doctorId);
        }

        public async Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter)
        {
            return await _doctorRepository.FilterDoctorsInfoAdminSide(filter);
        }

        public async Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId)
        {
            return await _doctorRepository.GetDoctorsInfoById(doctorInfoId);
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
                DoctorSkills = string.Join(",", doctorSkills.Select(p => p.DoctorSkil).ToList())
            };

            #endregion

            #region Get Doctor Work Addresses

            model.WorkAddresses = await _workAddress.GetUserWorkAddressesByUserId(doctor.UserId);

            #endregion

            return model;
        }

        public async Task<EditDoctorInfoResult> EditDoctorInfoAdminSide(DoctorsInfoDetailViewModel model, IFormFile? MediacalFile)
        {
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
                DoctorReservationDateTimes = ((!string.IsNullOrEmpty(loggedDateTime) ? await _reservationService.GetDoctorReservationDateByReservationDateTimeAndUserId(loggedDateTime, userId) : null))
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

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        public async Task<List<Doctor?>> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter)
        {
            return await _doctorRepository.FilterFamilyDoctorUserPanelSide(filter);
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
