using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Advertisement;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public  class CustomerAdvertisementRepository : ICustomerAdvertisementRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public CustomerAdvertisementRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region User Panel Side

        //Add Advertisement To The Data Base 
        public async Task AddAdvertisementToTheDataBase(CustomerAdvertisement advertisement)
        {
            await _context.CustomerAdvertisement.AddAsync(advertisement);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side 

        //Get List Of Advertisements
        public async Task<List<CustomerAdvertisement>?> GetListOfAdvertisements()
        {
            return await _context.CustomerAdvertisement.Where(p => !p.IsDelete).OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get Customer Advertisement By Id 
        public async Task<CustomerAdvertisement?> GetCustomerAdvertisementById(ulong advertisementId)
        {
            return await _context.CustomerAdvertisement.FirstOrDefaultAsync(p=> !p.IsDelete);
        }

        //Update Advertisement Fields
        public async Task UpdateAdvertisementFields(CustomerAdvertisement advertisement)
        {
            _context.CustomerAdvertisement.Update(advertisement);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
