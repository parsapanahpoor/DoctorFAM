﻿using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.PopulationCovered;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.PopulationCovered;
using DoctorFAM.Domain.ViewModels.UserPanel.PopulationCovered;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class PopulationCoveredService : IPopulationCoveredService
    {
        #region Ctor

        private readonly IPopulationCoveredRepository _populationCovered;

        private readonly IUserService _userService;

        public PopulationCoveredService(IPopulationCoveredRepository populationCovered , IUserService userService)
        {
            _populationCovered = populationCovered;
            _userService = userService;
        }

        #endregion

        #region Admin Side

        public async Task<FilterPopulationCoveredAdminViewModel> FilterPopulationCoveredAdmin(FilterPopulationCoveredAdminViewModel filter)
        {
            return await _populationCovered.FilterPopulationCoveredAdmin(filter);
        }

        public async Task<EditPopulationCoveredAdminViewModel> FillEditPopulationCoveredAdminViewModel(ulong populationId)
        {
            #region Get population 

            var population = await _populationCovered.GetPopulationCoveredById(populationId);
            if (population == null) return null;

            #endregion

            #region Get User By Id 

            var user = await _userService.GetUserById(population.UserId);
            if (user == null) return null;

            #endregion

            #region Fill View Model 

            EditPopulationCoveredAdminViewModel model = new EditPopulationCoveredAdminViewModel
            {
                Age = population.Age,
                UserId = population.UserId,
                Gender = population.Gender,
                Id = populationId,
                InsuranceType = population.InsuranceType,
                LastName = population.PatientLastName,
                NationalId = population.NationalId,
                Name = population.PatientName,
                Username = user.Username,
                Mobile = user.Mobile,
                Ratio = population.Ratio,
                BirthDay = population.BirthDay.ToShamsi()
            };

            #endregion

            return model;
        }

        public async Task<EditPopulationCoveredAdminResult> EditPopulationCoveredAdmin(EditPopulationCoveredAdminViewModel model)
        {
            #region Model State Validation 

            var population = await _populationCovered.GetPopulationCoveredById(model.Id);

            if (population == null) return EditPopulationCoveredAdminResult.Faild;

            #endregion

            #region Update Fields

            population.Age = model.Age;
            population.Gender = model.Gender;
            population.NationalId = model.NationalId;
            population.PatientName = model.Name.SanitizeText();
            population.PatientLastName = model.LastName.SanitizeText();
            population.InsuranceType = model.InsuranceType;
            population.Ratio = model.Ratio;
            population.BirthDay = model.BirthDay.ToMiladiDateTime();

            #endregion

            #region Update Method

            await _populationCovered.UpdatePopulationCovered(population);

            #endregion

            return EditPopulationCoveredAdminResult.Success;
        }

        public async Task<bool> DeletePopulationCoveredAdminSide(ulong id)
        {
            #region Get Population Covered 

            var population = await _populationCovered.GetPopulationCoveredById(id);
            if (population == null) return false;

            #endregion

            #region Delete Population Covered

            population.IsDelete = true;

            await _populationCovered.UpdatePopulationCovered(population);

            #endregion

            return true;
        }

        #endregion

        #region User Panel Side

        public async Task<CreatePopulationCoveredUserPanelResult> CreatePopulationCoveredUserPanel(CreatePopulationCoveredUserPanelViewModel model)
        {
            #region Model State Validation

            if (model.UserId == null) return CreatePopulationCoveredUserPanelResult.Faild;

            if (!await _userService.IsExistUserById(model.UserId.Value)) return CreatePopulationCoveredUserPanelResult.Faild;

            #endregion

            #region Fill Entity

            PopulationCovered populationCovered = new PopulationCovered()
            {
                UserId = model.UserId.Value,
                Age = model.Age,
                CreateDate = DateTime.Now,
                Gender = model.Gender,
                InsuranceType = model.InsuranceType,
                IsDelete = false,
                PatientLastName = model.LastName.SanitizeText(),
                PatientName = model.Name.SanitizeText(),
                NationalId = model.NationalId,
                Ratio = model.Ratio,
            };

            #region BirthDay

            var birthDay = model.BirthDay.ToMiladiDateTime();
            populationCovered.BirthDay = birthDay;

            #endregion

            #endregion

            #region Add Method

            await _populationCovered.AddPopulationCovered(populationCovered);

            #endregion

            return CreatePopulationCoveredUserPanelResult.Success;
        }

        public async Task<FilterPopulationCoveredUserViewModel> FilterPopulationCoveredUser(FilterPopulationCoveredUserViewModel filter)
        {
            return await _populationCovered.FilterPopulationCoveredUser(filter);
        }

        public async Task<EditPopulationCoveredUserPanelViewModel> FillEditPopulationCoveredUserPanelViewModel(ulong populationId , ulong userId)
        {
            #region Get population 

            var population = await _populationCovered.GetPopulationCoveredById(populationId);
            if (population == null) return null;
            if (population.UserId != userId) return null;

            #endregion

            #region Fill View Model 

            EditPopulationCoveredUserPanelViewModel model = new EditPopulationCoveredUserPanelViewModel
            {
                UserId=userId,
                Age = population.Age,
                Gender = population.Gender,
                Id = populationId,
                InsuranceType=population.InsuranceType,
                LastName = population.PatientLastName,
                NationalId = population.NationalId,
                Name = population.PatientName,
                Ratio = population.Ratio,
                BirthDay = population.BirthDay.ToShamsi()
            };

            #endregion

            return model;
        }

        public async Task<EditPopulationCoveredUserPanelResult> EditPopulationCoveredUserPanel(EditPopulationCoveredUserPanelViewModel model)
        {
            #region Model State Validation 

            var population = await _populationCovered.GetPopulationCoveredById(model.Id);
            
            if (population == null) return EditPopulationCoveredUserPanelResult.Faild;

            if (population.UserId != model.UserId) return EditPopulationCoveredUserPanelResult.Faild;

            #endregion

            #region Update Fields

            population.Age = model.Age;
            population.Gender = model.Gender;
            population.NationalId = model.NationalId;
            population.PatientName = model.Name.SanitizeText();
            population.PatientLastName = model.LastName.SanitizeText();
            population.InsuranceType = model.InsuranceType;
            population.Ratio = model.Ratio;
            population.BirthDay = model.BirthDay.ToMiladiDateTime();

            #endregion

            #region Update Method

            await _populationCovered.UpdatePopulationCovered(population);

            #endregion

            return EditPopulationCoveredUserPanelResult.Success;
        }

        public async Task<bool> DeletepopulationUserSide(ulong id, ulong userId)
        {
            #region Get Population 

            var population = await _populationCovered.GetPopulationCoveredById(id);

            if (population == null) return false;

            if (population.UserId != userId) return false;

            #endregion

            #region Update Population 

            population.IsDelete = true;

            await _populationCovered.UpdatePopulationCovered(population);

            #endregion

            return true;
        }

        #endregion

        #region Site Side 

        public async Task<List<PopulationCovered>> GetUserPopulation(ulong userId)
        {
            return await _populationCovered.GetUserPopulation(userId);
        }

        #endregion
    }
}