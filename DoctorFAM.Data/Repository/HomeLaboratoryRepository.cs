using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Laboratory;
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
    public class HomeLaboratoryRepository : IHomeLaboratoryRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomeLaboratoryRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        public async Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId)
        {
            return await _context.HomeLaboratoryRequestDetails.Where(p => !p.IsDelete && p.RequestId == requestId).ToListAsync();
        }

        public async Task AddLaboratoryRequest(HomeLaboratoryRequestDetail laboratory)
        {
            await _context.HomeLaboratoryRequestDetails.AddAsync(laboratory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestedLaboratory(HomeLaboratoryRequestDetail laboratory)
        {
            _context.HomeLaboratoryRequestDetails.Update(laboratory);
            await _context.SaveChangesAsync();
        }

        public async Task<HomeLaboratoryRequestDetail> GetRequestedLaboratoryById(ulong requesedLaboratoryId)
        {
            return await _context.HomeLaboratoryRequestDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == requesedLaboratoryId);
        }

        public async Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request)
        {
            await _context.PatientRequestDateTimeDetails.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
