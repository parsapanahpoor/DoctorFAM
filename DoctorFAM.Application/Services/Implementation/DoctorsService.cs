using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class DoctorsService : IDoctorsService
    {
        #region Ctor

        public IDoctorsRepository _doctorRepository;

        public IUserService _userService;

        public DoctorsService(IDoctorsRepository doctorRepository , IUserService userService)
        {
            _doctorRepository = doctorRepository;
            _userService = userService;
        }

        #endregion

        #region Doctors Panel Side

        public async Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId)
        {
            return await _doctorRepository.IsExistAnyDoctorInfoByUserId(userId);
        }

        public async Task<string> GetDoctorsInfosState(ulong userId)
        {
            return await _doctorRepository.GetDoctorsInfosState(userId);
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
                    DoctorsInfosType = doctorInfo.DoctorsInfosType,
                    Education = doctorInfo.Education,
                    MediacalFile = doctorInfo.MediacalFile,
                    MedicalSystemCode = doctorInfo.MedicalSystemCode,
                    NationalCode = doctorInfo.NationalCode,
                    RejectDescription = doctorInfo.RejectDescription,
                    Specialty = doctorInfo.Specialty
                };

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

        public async Task<AddOrEditDoctorInfoResult> AddOrEditDoctorInfoDoctorsPanel(ManageDoctorsInfoViewModel model, IFormFile? MediacalFile)
        {
            #region Get User By User Id

            var user = await _userService.GetUserById(model.UserId);

            if (user == null) return AddOrEditDoctorInfoResult.Faild;

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
                info.DoctorsInfosType = DoctorsInfosType.WatingForConfirm;

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

                #region Update Methods

                await _doctorRepository.UpdateDoctorsInfo(info);

                #endregion
            }

            #endregion

            #region Add Info

            if (existInfo == false)
            {
                #region Fill View Model

                DoctorsInfo manageDoctorsInfoViewModel = new DoctorsInfo()
                {
                    DoctorsInfosType = DoctorsInfosType.WatingForConfirm,
                    UserId = model.UserId,
                    Education = model.Education.SanitizeText(),
                    MedicalSystemCode = model.MedicalSystemCode,
                    NationalCode = model.NationalCode,
                    Specialty = model.Specialty.SanitizeText(),
                };

                #endregion

                #region Medical File 

                if (MediacalFile != null)
                {
                    var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(MediacalFile.FileName);
                    MediacalFile.AddImageToServer(imageName, PathTools.MediacalFilePathServer, 270, 270, PathTools.MediacalFilePathThumbServer);
                    manageDoctorsInfoViewModel.MediacalFile = imageName;
                }

                #endregion

                #region Update Methods

                await _doctorRepository.AddDoctorsInfo(manageDoctorsInfoViewModel);

                #endregion

            }

            #endregion

            return AddOrEditDoctorInfoResult.Success;
        }

        #endregion

        #region Admin Side

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
            var info = await _doctorRepository.GetDoctorsInfoById(doctorInfoId);

            if (info == null) return null;

            #endregion

            #region Fill View Model

            DoctorsInfoDetailViewModel model = new DoctorsInfoDetailViewModel()
            {
                UserId = info.UserId,
                NationalCode = info.NationalCode,
                MedicalSystemCode = info.MedicalSystemCode,
                Education = info.Education,
                Specialty = info.Specialty,
                MediacalFile = info.MediacalFile,
                RejectDescription = info.RejectDescription,
                DoctorsInfosType = info.DoctorsInfosType,
                Id = info.Id,
            };

            #endregion

            return model;
        }

        public async Task<EditDoctorInfoResult> EditDoctorInfoAdminSide(DoctorsInfoDetailViewModel model, IFormFile? MediacalFile)
        {
            #region Get Doctor Info By Id

            //Get Doctor Info By Id
            var info = await _doctorRepository.GetDoctorsInfoById(model.Id);

            if(info == null) return EditDoctorInfoResult.faild;

            #endregion

            #region Edit Doctor Info 

            #region Edit Properties

            info.MedicalSystemCode = model.MedicalSystemCode;
            info.RejectDescription = model.RejectDescription;
            info.DoctorsInfosType = model.DoctorsInfosType;
            info.Specialty = model.Specialty;
            info.Education = model.Education;
            info.NationalCode = model.NationalCode;

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
    }
}
