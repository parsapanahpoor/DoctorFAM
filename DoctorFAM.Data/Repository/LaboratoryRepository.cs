using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class LaboratoryRepository : ILaboratoryRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public LaboratoryRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Laboratory Side 

        //Fill Laboratory Side Bar Panel
        public async Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId)
        {
            #region Get Laboratory Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Labratory);

            #endregion

            LaboratorySideBarViewModel model = new LaboratorySideBarViewModel();

            #region Laboratory State 

            //If Laboratory Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.LaboratoryInfoState = "NewUser";

            //If Laboratory State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.LaboratoryInfoState = "WatingForConfirm";

            //If Laboratory State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.LaboratoryInfoState = "Rejected";

            //If Laboratory State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.LaboratoryInfoState = "Accepted";

            #endregion

            return model;
        }

        //Is Exist Any Laboratory By This User Id 
        public async Task<bool> IsExistAnyLaboratoryByUserId(ulong userId)
        {
            return await _context.Laboratory.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        //Add Laboratory To Data Base
        public async Task<ulong> AddLaboratory(Laboratory laboratory)
        {
            await _context.Laboratory.AddAsync(laboratory);
            await _context.SaveChangesAsync();

            return laboratory.Id;
        }

        #endregion
    }
}
