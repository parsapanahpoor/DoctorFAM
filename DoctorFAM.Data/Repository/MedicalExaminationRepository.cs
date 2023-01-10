using DoctorFAM.Data.DbContext;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Access;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
using DoctorFAM.Domain.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _context.MedicalExaminations.Where(p=> !p.IsDelete)
                                                .OrderByDescending(p=> p.CreateDate).ToListAsync();          
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

        #endregion

        #region Doctor Side 



        #endregion
    }
}
