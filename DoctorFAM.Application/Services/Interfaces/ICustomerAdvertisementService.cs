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
