using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HomePharmacyRepository : IHomePharmacyRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomePharmacyRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        public async Task<List<HomePharmacyRequestDetail>> GetHomePharmacyRequestDetailByRequestId(ulong requestId)
        {
            return await _context.HomePharmacyRequestDetails.Where(p => !p.IsDelete && p.RequestId == requestId).ToListAsync();
        }

        public async Task AddDrugRequest(HomePharmacyRequestDetail drug)
        {
            await _context.HomePharmacyRequestDetails.AddAsync(drug);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestedDrug(HomePharmacyRequestDetail drug)
        {
            _context.HomePharmacyRequestDetails.Update(drug);
            await _context.SaveChangesAsync();
        }

        public async Task<HomePharmacyRequestDetail> GetRequestedDrugById(ulong requesedDrugId)
        {
            return await _context.HomePharmacyRequestDetails.FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == requesedDrugId);
        }

        public async Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request)
        {
            await _context.PatientRequestDateTimeDetails.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
