using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.HealthInformation;
using DoctorFAM.Domain.Entities.PriodicExamination;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Access;
using DoctorFAM.Domain.ViewModels.Admin.MedicalExamination;
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

        #endregion

        #region User Panel Side 



        #endregion

        #region Doctor Side 



        #endregion
    }
}
