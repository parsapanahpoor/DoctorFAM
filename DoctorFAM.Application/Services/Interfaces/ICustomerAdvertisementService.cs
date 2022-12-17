using DoctorFAM.Domain.Entities.Advertisement;
using DoctorFAM.Domain.ViewModels.Admin.CustomerAdvertisement;
using DoctorFAM.Domain.ViewModels.UserPanel.CustomerAdvertisement;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ICustomerAdvertisementService
    {
        #region User Panel Side 

        //Create Advertisement From User Panel 
        Task<bool> CreateAdvertisementFromUserPanel(CreateCustomerAdvertisementUserPanelViewModel model, IFormFile UserAvatar, ulong userId);

        //Has User Any Advertisement 
        Task<bool> HasUserAnyAdvertisement(ulong userId);

        //List Of User Advertisements
        Task<List<CustomerAdvertisement>?> ListOfUserAdvertisements(ulong userId);

        //Get Customer Advertisement By Id 
        Task<CustomerAdvertisement?> GetCustomerAdvertisementById(ulong advertisementId);

        //Fill Customer Advertisement Detail View Model
        Task<CustomerAdvertisementDetailUserPanelViewModel?> FillCustomerAdvertisementDetailUserPanelViewModel(ulong advertisementId, ulong userId);

        //Check Advertisement For Redirect To Bank Portal
        Task<bool> CheckAdvertisementForRedirectToBankPortal(ulong adsId, ulong userId, CustomerAdvertisement advertisement);

        //Update Advertisement State After Pay From Bank Portal
        Task UpdateAdvertisementStateAfterPayFromBankPortal(CustomerAdvertisement advertisement);

        //Pay Advertisement Price 
        Task<bool> PayAdvertisementPrice(ulong userId, int price, ulong? adsId);

        #endregion

        #region Admin Side 

        //Fill List Of Customer Advertisement Admin Side View Model
        Task<List<ListOfCustomerAdvertisementAdminSideViewModel>> FillListOfCustomerAdvertisementAdminSideViewModel();

        //Fill Customer Advertisement Detail View Model
        Task<CustomerAdvertisementDetailViewModel?> FillCustomerAdvertisementDetailViewModel(ulong advertisementId);

        //Update Customer Advertisement 
        Task<bool> UpdateCustomerAdvertisement(CustomerAdvertisementDetailViewModel model);

        #endregion
    }
}
