using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Patient;
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
    public class RequestRepository : IRequestRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public RequestRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        #region Request 

        public async Task<bool> IsExistRequestByRequestId(ulong requestId)
        {
            return await _context.Requests.AnyAsync(p => p.Id == requestId && !p.IsDelete);
        }

        public async Task<Request?> GetRequestById(ulong requestId)
        {
            return await _context.Requests.FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
        }

        public async Task AddRequest(Request request)
        {
            await _context.Requests.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Patient Request Detail

        public async Task AddPatientRequestDetail(PaitientRequestDetail request)
        {
            await _context.PaitientRequestDetails.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        #endregion

        #endregion

        #region Admin

        #endregion
    }
}
