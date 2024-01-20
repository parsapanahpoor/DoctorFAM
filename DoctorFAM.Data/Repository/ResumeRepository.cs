using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Resume;
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

        //Update Resume 
        public async Task UpdateResume(Resume resume)
        {
            _context.Resumes.Update(resume);
            await _context.SaveChangesAsync();
        }

        //Get Resume By User Id 
        public async Task<Resume?> GetResumeByUserId(ulong userId)
        {
            return await _context.Resumes
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        //Add Resume To Data Base 
        public async Task CreateResume(Resume resume)
        {
            await _context.Resumes.AddAsync(resume);
            await _context.SaveChangesAsync();
        }

        //Add Resume To Data Base 
        public async Task AddResume(Resume resume , CancellationToken cancellationToken)
        {
            await _context.Resumes.AddAsync(resume);
        }

        //Get User About Me Resume By Resume Id
        public async Task<ResumeAboutMe?> GetUserAboutMeResumeByResumeId(ulong resumeId)
        {
            return await _context.ResumeAboutMe.FirstOrDefaultAsync(p => !p.IsDelete & p.ResumeId == resumeId);
        }

        //Get Resume By Id
        public async Task<Resume?> GetResuemById(ulong resumeId)
        {
            return await _context.Resumes.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == resumeId);
        }

        //Create About Me 
        public async Task CreateAboutMe(ResumeAboutMe model)
        {
            await _context.ResumeAboutMe.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Add About Me 
        public async Task AddAboutMe(ResumeAboutMe model , CancellationToken cancellation)
        {
            await _context.ResumeAboutMe.AddAsync(model);
        }

        //Update About Me Resume 
        public async Task UpdateAboutMeResume(ResumeAboutMe model)
        {
            _context.ResumeAboutMe.Update(model);
            await _context.SaveChangesAsync();
        }

        //Update About Me Resume 
        public void UpdateAboutMeResumeWithoutSaveChange(ResumeAboutMe model)
        {
            _context.ResumeAboutMe.Update(model);
        }

        //Change Resume State To The Waiting State  
        public async Task ChangeResumeStateToTheWaitingState(Resume resume)
        {
            resume.ResumeState = Domain.Enums.ResumeState.ResumeState.WaitingForConfirm;

            _context.Resumes.Update(resume);
            await _context.SaveChangesAsync();
        }

        //Get Education Resume By User Id
        public async Task<List<EducationResume>?> GetEducationResumeByUserId(ulong resumeId)
        {
            return await _context.EducationResume.Where(p => !p.IsDelete && p.ResumeId == resumeId).ToListAsync();
        }

        //Create Education Resume 
        public async Task CreateEducationResume(EducationResume model)
        {
            await _context.EducationResume.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Get Education By Id
        public async Task<EducationResume?> GetEducationById(ulong educationId)
        {
            return await _context.EducationResume.FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == educationId);
        }

        //Update Education 
        public async Task UpdateEducation(EducationResume education)
        {
            _context.EducationResume.Update(education);
            await _context.SaveChangesAsync();
        }

        //Get Work History Resume By User Id
        public async Task<List<WorkHistoryResume>?> GetWorkHistoryResumeByUserId(ulong resumeId)
        {
            return await _context.WorkHistoryResume.Where(p => !p.IsDelete && p.ResumeId == resumeId)
                                                        .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get Honor Resume By User Id
        public async Task<List<Honors>?> GetHonorResumeByUserId(ulong resumeId)
        {
            return await _context.Honors.Where(p => !p.IsDelete && p.ResumeId == resumeId)
                                                        .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get Gallery Resume By User Id
        public async Task<List<GalleryResume>?> GetGalleryResumeByUserId(ulong resumeId)
        {
            return await _context.GalleryResume.Where(p => !p.IsDelete && p.ResumeId == resumeId)   
                                                        .OrderByDescending(p=> p.CreateDate).ToListAsync();
        }

        //Get Certificate Resume By User Id
        public async Task<List<CertificateResume>?> GetCertificateResumeByUserId(ulong resumeId)
        {
            return await _context.CertificateResume.Where(p => !p.IsDelete && p.ResumeId == resumeId)
                                                        .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get Service Resume By User Id
        public async Task<List<ServiceResume>?> GetServiceResumeByUserId(ulong resumeId)
        {
            return await _context.ServiceResume.Where(p => !p.IsDelete && p.ResumeId == resumeId)
                                                        .OrderByDescending(p => p.CreateDate).ToListAsync();

        }

        //Get Working Address Resume By User Id
        public async Task<List<WorkingAddressResume>?> GetWorkingAddressResumeByUserId(ulong resumeId)
        {
            return await _context.WorkingAddressResume.Where(p => !p.IsDelete && p.ResumeId == resumeId)
                                                         .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Create Work History Resume 
        public async Task CreateWorkHistoryResume(WorkHistoryResume model)
        {
            await _context.WorkHistoryResume.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Create Service Resume 
        public async Task CreateServiceResume(ServiceResume model)
        {
            await _context.ServiceResume.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Create Working Address Resume 
        public async Task CreateWorkingAddressResume(WorkingAddressResume model)
        {
            await _context.WorkingAddressResume.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Create Honor Resume 
        public async Task CreateHonorResume(Honors model)
        {
            await _context.Honors.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Create Gallery Resume 
        public async Task CreateGalleryResume(GalleryResume model)
        {
            await _context.GalleryResume.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Create Certificate Resume 
        public async Task CreateCertificateResume(CertificateResume model)
        {
            await _context.CertificateResume.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Get Work History By Id
        public async Task<WorkHistoryResume?> GetWorkHistoryById(ulong workHistoryId)
        {
            return await _context.WorkHistoryResume.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == workHistoryId);
        }

        //Get Service By Id
        public async Task<ServiceResume?> GetServiceById(ulong serviceId)
        {
            return await _context.ServiceResume.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == serviceId);
        }

        //Get Working Address By Id
        public async Task<WorkingAddressResume?> GetWorkingAddressById(ulong serviceId)
        {
            return await _context.WorkingAddressResume.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == serviceId);
        }

        //Get Honor By Id
        public async Task<Honors?> GetHonotById(ulong honorId)
        {
            return await _context.Honors.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == honorId);
        }

        //Get Gallery By Id
        public async Task<GalleryResume?> GetGalleryById(ulong galleryId)
        {
            return await _context.GalleryResume.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == galleryId);
        }

        //Get Certificate By Id
        public async Task<CertificateResume?> GetCertificateById(ulong certificateId)
        {
            return await _context.CertificateResume.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == certificateId);
        }

        //Update Work History 
        public async Task UpdateWorkHistory(WorkHistoryResume workHistory)
        {
            _context.WorkHistoryResume.Update(workHistory);
            await _context.SaveChangesAsync();
        }

        //Update Service 
        public async Task UpdateService(ServiceResume service)
        {
            _context.ServiceResume.Update(service);
            await _context.SaveChangesAsync();
        }

        //Update Working Address 
        public async Task UpdateWorkingAddress(WorkingAddressResume address)
        {
            _context.WorkingAddressResume.Update(address);
            await _context.SaveChangesAsync();
        }

        //Update Honor 
        public async Task UpdateHonor(Honors honor)
        {
            _context.Honors.Update(honor);
            await _context.SaveChangesAsync();
        }

        //Update Gallery 
        public async Task UpdateGallery(GalleryResume gallery)
        {
            _context.GalleryResume.Update(gallery);
            await _context.SaveChangesAsync();
        }

        //Update Certificate 
        public async Task UpdateCertificate(CertificateResume certificate)
        {
            _context.CertificateResume.Update(certificate);
            await _context.SaveChangesAsync();
        }

        //Get User Gallery By Resume Id 
        public async Task<List<GalleryResume>> GetUserGalleryByResumeId(ulong resumeId)
        {
            return await _context.GalleryResume.Where(p => !p.IsDelete && p.ResumeId == resumeId).ToListAsync(); 
        }

        #endregion

        #region Doctor Panel 



        #endregion

        #region Admin Side 

        //List Of Doctors That Has Send Resume Admin Side 
        public async Task<List<Resume>> ListOfDoctorsThatHasSendResume()
        {
            return await _context.Resumes.Include(p => p.User).Where(p => !p.IsDelete)
                                                                    .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        #endregion
    }
}
