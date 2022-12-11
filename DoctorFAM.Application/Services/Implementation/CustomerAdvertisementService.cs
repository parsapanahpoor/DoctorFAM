using DoctorFAM.Application.Convertors;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Advertisement;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.CustomerAdvertisement;
using DoctorFAM.Domain.ViewModels.UserPanel.CustomerAdvertisement;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Implementation
{
    public class CustomerAdvertisementService : ICustomerAdvertisementService
    {
        #region Ctor

        private readonly ICustomerAdvertisementRepository _advertisement;

        private readonly IUserService _userService;

        public CustomerAdvertisementService(ICustomerAdvertisementRepository advertisement, IUserService userService)
        {
            _advertisement = advertisement;
            _userService = userService;
        }

        #endregion

        #region User Panel Side

        //Create Advertisement From User Panel 
        public async Task<bool> CreateAdvertisementFromUserPanel(CreateCustomerAdvertisementUserPanelViewModel model, IFormFile UserAvatar , ulong userId)
        {
            #region Get User By User ID

            var user = await _userService.GetUserById(userId);
            if (user == null) return false;

            #endregion

            #region Fill Entity

            CustomerAdvertisement advertisement = new CustomerAdvertisement()
            {
                CreateDate = DateTime.Now,
                UserId = userId,
                CustomerAdvertisementState = Domain.Enums.CustomerAdvertisement.CustomerAdvertisementState.WaitingForInitialInvoice,
                EndDate = null,
                IsDelete = false,
                LongDescription = ((string.IsNullOrEmpty(model.LongDescription) ? null : model.LongDescription.SanitizeText())),
                ShortDescription = ((string.IsNullOrEmpty(model.ShortDescription) ? null : model.ShortDescription.SanitizeText())),
                Priority = 0,
                ShowInfinit = false,
                StartDate = null,
                Title = model.Title.SanitizeText(),
                Username = model.Username.SanitizeText(),
                Price = null
            };

            #region Image 

            if (UserAvatar != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(UserAvatar.FileName);
                UserAvatar.AddImageToServer(imageName, PathTools.CustomerAdvertisementPathServer, 270, 270, PathTools.CustomerAdvertisementPathThumbServer);
                advertisement.Image = imageName;
            }

            #endregion

            //Add Advertisement To The Data Base 
            await _advertisement.AddAdvertisementToTheDataBase(advertisement);

            #endregion

            return true;
        }

        //Has User Any Advertisement 
        public async Task<bool> HasUserAnyAdvertisement(ulong userId)
        {
            #region Get User By Id

            var user = await _userService.GetUserById(userId);
            if (user == null) return false;

            #endregion

            return await _advertisement.HasUserAnyAdvertisement(user);
        }

        //List Of User Advertisements
        public async Task<List<CustomerAdvertisement>?> ListOfUserAdvertisements(ulong userId)
        {
            #region Get User By Id

            var user = await _userService.GetUserById(userId);
            if (user == null) return null;

            #endregion

            return await _advertisement.ListOfUserAdvertisements(userId);
        }

        //Get Customer Advertisement By Id 
        public async Task<CustomerAdvertisement?> GetCustomerAdvertisementById(ulong advertisementId)
        {
            return await _advertisement.GetCustomerAdvertisementById(advertisementId);
        }

        //Fill Customer Advertisement Detail View Model
        public async Task<CustomerAdvertisementDetailUserPanelViewModel?> FillCustomerAdvertisementDetailUserPanelViewModel(ulong advertisementId , ulong userId)
        {
            #region Get Advertisement By Id

            var advertisement = await _advertisement.GetCustomerAdvertisementById(advertisementId);
            if (advertisement == null) return null;
            if (advertisement.UserId != userId) return null;

            #endregion

            #region Get User 

            var user = await _userService.GetUserById(advertisement.UserId);
            if (user == null) return null;

            #endregion

            #region Fill Model 

            CustomerAdvertisementDetailUserPanelViewModel model = new CustomerAdvertisementDetailUserPanelViewModel()
            {
                AdvertisementId = advertisement.Id,
                CustomerAdvertisementState = advertisement.CustomerAdvertisementState,
                EndDate = ((advertisement.EndDate == null) ? null : advertisement.EndDate.Value.ToShamsi()),
                Image = advertisement.Image,
                LongDescription = advertisement.LongDescription,
                Price = advertisement.Price,
                Priority = advertisement.Priority,
                ShortDescription = advertisement.ShortDescription,
                ShowInfinit = advertisement.ShowInfinit,
                StartDate = ((advertisement.StartDate == null) ? null : advertisement.StartDate.Value.ToShamsi()),
                Title = advertisement.Title,
            };

            #endregion

            return model;
        }

        #endregion

        #region Admin Side 

        //Fill List Of Customer Advertisement Admin Side View Model
        public async Task<List<ListOfCustomerAdvertisementAdminSideViewModel>> FillListOfCustomerAdvertisementAdminSideViewModel()
        {
            #region Get List Of Advertisements 

            var advertisements = await _advertisement.GetListOfAdvertisements();

            #endregion

            #region Make Instance

            List<ListOfCustomerAdvertisementAdminSideViewModel> model = new List<ListOfCustomerAdvertisementAdminSideViewModel>();

            if (advertisements != null && advertisements.Any())
            {
                foreach (var ads in advertisements)
                {
                    model.Add(new ListOfCustomerAdvertisementAdminSideViewModel()
                    {
                        CustomerAdvertisement = ads,
                        User = await _userService.GetUserById(ads.UserId)
                    });
                }
            }

            #endregion

            return model;
        }

        //Fill Customer Advertisement Detail View Model
        public async Task<CustomerAdvertisementDetailViewModel?> FillCustomerAdvertisementDetailViewModel(ulong advertisementId)
        {
            #region Get Advertisement By Id

            var advertisement = await _advertisement.GetCustomerAdvertisementById(advertisementId);
            if (advertisement == null) return null;

            #endregion

            #region Get User 

            var user = await _userService.GetUserById(advertisement.UserId);
            if (user == null) return null;

            #endregion

            #region Fill Model 

            CustomerAdvertisementDetailViewModel model = new CustomerAdvertisementDetailViewModel()
            {
                AdvertisementId = advertisement.Id,
                CustomerAdvertisementState = advertisement.CustomerAdvertisementState,
                EndDate = ((advertisement.EndDate == null) ? null : advertisement.EndDate.Value.ToShamsi()),
                Image = advertisement.Image,
                LongDescription = advertisement.LongDescription,
                Owner = user,
                Price = advertisement.Price ,
                Priority = advertisement.Priority ,
                ShortDescription = advertisement.ShortDescription,
                ShowInfinit = advertisement.ShowInfinit,
                StartDate = ((advertisement.StartDate == null) ? null : advertisement.StartDate.Value.ToShamsi()),
                Title = advertisement.Title,
            };

            #endregion

            return model;
        }

        //Update Customer Advertisement 
        public async Task<bool> UpdateCustomerAdvertisement(CustomerAdvertisementDetailViewModel model )
        {
            #region Get Advertisement By Id

            var advertisement = await _advertisement.GetCustomerAdvertisementById(model.AdvertisementId);
            if (advertisement == null) return false;

            #endregion

            #region Update Field 

            advertisement.Price = model.Price;
            advertisement.Priority = model.Priority;
            advertisement.ShowInfinit = model.ShowInfinit;
            advertisement.CustomerAdvertisementState = model.CustomerAdvertisementState;
            advertisement.StartDate = (string.IsNullOrEmpty(model.StartDate)) ? null : model.StartDate.ToMiladiDateTime();
            advertisement.EndDate = (string.IsNullOrEmpty(model.EndDate)) ? null : model.EndDate.ToMiladiDateTime();

            #endregion

            //Update Advertisement Field 
            await _advertisement.UpdateAdvertisementFields(advertisement);

            return true;
        }

        #endregion
    }
}
