using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ResumeRepository : IResumeRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public ResumeRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region General Methods For All User

        //Get Resume By User Id 
        public async Task<Resume?> GetResumeByUserId(ulong userId)
        {
            return await _context.Resumes.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        //Add Resume To Data Base 
        public async Task CreateResume(Resume resume)
        {
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Doctor Panel 

        #endregion
    }
}
