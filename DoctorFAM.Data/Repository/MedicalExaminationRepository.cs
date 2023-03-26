using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.PeriodicTest;
using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.MedicalExamination;
using DoctorFAM.Domain.ViewModels.BackgroundTasks.PriodicTest;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Data.Repository
{
    public class MedicalExaminationRepository : IMedicalExaminationRepository
    {
        #region Ctor 

        private readonly DoctorFAMDbContext _context;

        public MedicalExaminationRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Admin Side 

        //Create Medical Examination 
        public async Task CreateMedicalExamination(DoctorFAM.Domain.Entities.PriodicExamination.MedicalExamination model)
        {
            await _context.MedicalExaminations.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Filter Medical Examination 
        public async Task<FilterMedicalExaminationAdminSideViewModel> FilterMedicalExamination(FilterMedicalExaminationAdminSideViewModel filter)
        {
            var query = _context.MedicalExaminations
                                .Where(s => !s.IsDelete).AsQueryable();

            #region Filter

            if (!string.IsNullOrEmpty(filter.MEdicalExaminationName))
            {
                query = query.Where(s => s.MedicalExaminationName.Contains(filter.MEdicalExaminationName));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Get Medical Examination By Id 
        public async Task<MedicalExamination?> GetMedicalExaminationById(ulong medicalExaminationId)
        {
            return await _context.MedicalExaminations.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == medicalExaminationId);
        }

        //Edit Medical Examination Admin Side 
        public async Task EditMedicalExaminationAdminSide(MedicalExamination model)
        {
            _context.MedicalExaminations.Update(model);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region User Panel Side 



        #endregion

        #region Site Side

        //Get List Of Medical Examinations
        public async Task<List<MedicalExamination>?> GetListOfMedicalExaminations()
        {
            return await _context.MedicalExaminations.Where(p => !p.IsDelete)
                                                .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get List Of Medical Examinations With Select List 
        public async Task<List<SelectListViewModel>> GetListOfMedicalExaminationsWithSelectList()
        {
            return await _context.MedicalExaminations.Where(s => !s.IsDelete)
                .Select(s => new SelectListViewModel
                {
                    Id = s.Id,
                    Title = s.MedicalExaminationName
                }).ToListAsync();
        }

        //Add Priodic Examination From Site 
        public async Task AddPriodicExaminationFromSite(PriodicPatientsExamination model)
        {
            await _context.PriodicPatientsExamination.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        //Get User Priodic Examination By User Id
        public async Task<List<PriodicPatientsExamination>?> GetUserPriodicExaminationByUserId(ulong userId)
        {
            return await _context.PriodicPatientsExamination.Include(p => p.MedicalExamination)
                            .Where(p => !p.IsDelete && p.UserId == userId).ToListAsync();
        }

        //Get Priodic Examination By Priodic Examination Id
        public async Task<PriodicPatientsExamination?> GetPriodicExaminationByPriodicExaminationId(ulong priodicExaminationId)
        {
            return await _context.PriodicPatientsExamination.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == priodicExaminationId);
        }

        //Update Priodic Examination
        public async Task UpdatePriodicExamination(PriodicPatientsExamination priodic)
        {
            _context.PriodicPatientsExamination.Update(priodic);
            await _context.SaveChangesAsync();
        }

        //Check That Current User Has Any Priodic Examination In This Week
        public async Task<List<PriodicPatientsExamination>?> CheckThatCurrentUserHasAnyPriodicExaminationInThisWeek(ulong userId)
        {
            return await _context.PriodicPatientsExamination.Include(p => p.MedicalExamination)
                                                   .Where(p => !p.IsDelete && p.UserId == userId && (
                                                    (p.NextExaminationDate.Year == DateTime.Now.Year && p.NextExaminationDate.DayOfYear >= DateTime.Now.DayOfYear && p.NextExaminationDate.DayOfYear - DateTime.Now.DayOfYear <= 7 && p.NextExaminationDate.DayOfYear - DateTime.Now.DayOfYear >= 0)
                                                    )).ToListAsync();
        }

        //Check That Current User Has Any Priodic Examination After Today
        public async Task<List<PriodicPatientsExamination>?> CheckThatCurrentUserHasAnyPriodicExaminationAfterToday(ulong userId)
        {
            return await _context.PriodicPatientsExamination.Include(p => p.MedicalExamination)
                                                   .Where(p => !p.IsDelete && p.UserId == userId && (
                                                    (p.NextExaminationDate >= DateTime.Now)
                                                    )).ToListAsync();
        }

        #endregion

        #region Doctor Side 



        #endregion

        #region Background Task

        //Get List Of User Medical Examination For Send SMS One Day Before
        public async Task<List<SendSMSForMedicalExaminationViewModel>> GetListOfUserMedicalExaminationForSendSMSOneDayBefore()
        {
            return await _context.PriodicPatientsExamination.Where(p => !p.IsDelete 
                                                          && p.NextExaminationDate.Year == DateTime.Now.Year
                                                          && p.NextExaminationDate.DayOfYear == DateTime.Now.AddDays(1).DayOfYear)
                                                          .Select(p => new SendSMSForMedicalExaminationViewModel()
                                                          {
                                                              MedicalExaminationId = p.Id,
                                                              MedicalExaminationName = _context.MedicalExaminations.Where(s => !s.IsDelete && s.Id == p.MedicalExaminationId).Select(s => s.MedicalExaminationName).FirstOrDefault(),
                                                              Mobile = _context.Users.Where(s => !s.IsDelete && s.Id == p.UserId).Select(s => s.Mobile).FirstOrDefault()
                                                          }).ToListAsync();
        }

        //Get User Selected Medical Examination By Id
        public async Task<PriodicPatientsExamination?> GetUserMedicalExaminationById(ulong id)
        {
            return await _context.PriodicPatientsExamination.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == id);
        }

        //Update User Medical Examination Without Save Changes
        public void UpdateUserMedicalExaminationWithoutSaveChanges(PriodicPatientsExamination model)
        {
            _context.PriodicPatientsExamination.Update(model);
        }

        //Save Chamges 
        public async Task Savechanges()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
