using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Advertisement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore
{
    public interface ICustomerAdvertisementRepository
    {
        #region User Panel Side 

        //Add Advertisement To The Data Base 
        Task AddAdvertisementToTheDataBase(CustomerAdvertisement advertisement);

        //Has User Any Advertisement 
        Task<bool> HasUserAnyAdvertisement(User user);

        //List Of User Advertisements
        Task<List<CustomerAdvertisement>> ListOfUserAdvertisements(ulong userId);

        #endregion

        #region Admin Side 

        //Get List Of Advertisements
        Task<List<CustomerAdvertisement>?> GetListOfAdvertisements();

        //Get Customer Advertisement By Id 
        Task<CustomerAdvertisement?> GetCustomerAdvertisementById(ulong advertisementId);

        //Update Advertisement Fields
        Task UpdateAdvertisementFields(CustomerAdvertisement advertisement);

        #endregion
    }
}
