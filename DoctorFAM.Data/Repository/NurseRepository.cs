using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Nurse.NurseSideBarInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class NurseRepository : INurseRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public NurseRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Nurse Side

        //Fill Nurse Side Bar Panel
        public async Task<NurseSideBarViewModel> GetNurseSideBarInfo(ulong userId)
        {
            #region Get Doctor Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Nurse);

            #endregion

            NurseSideBarViewModel model = new NurseSideBarViewModel();

            #region Nurse State 

            //If Nurse Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.NurseInfoState = "NewUser";

            //If Nurse State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.NurseInfoState = "WatingForConfirm";

            //If Nurse State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.NurseInfoState = "Rejected";

            //If Nurse State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.NurseInfoState = "Accepted";

            #endregion

            return model;
        }

        //Is Exist Any Nurse By This User Id 
        public async Task<bool> IsExistAnyNurseByUserId(ulong userId)
        {
            return await _context.Nurses.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        //Add Doctor To Data Base
        public async Task<ulong> AddNurse(Nurse nurse)
        {
            await _context.Nurses.AddAsync(nurse);
            await _context.SaveChangesAsync();

            return nurse.Id;
        }

        //Get Nurse By User Id
        public async Task<Nurse?> GetNurseByUserId(ulong userId)
        {
            return await _context.Nurses.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        //Get Nurse Information By User Id
        public async Task<NurseInfo?> GetNurseInformationByUserId(ulong userId)
        {
            return await _context.NurseInfo.Include(p => p.Nurse).FirstOrDefaultAsync(p => p.Nurse.UserId == userId && !p.IsDelete);
        }
        
        //Check Is Exist Nurse Info By User ID
        public async Task<bool> IsExistAnyNurseInfoByUserId(ulong userId)
        {
            return await _context.NurseInfo.Include(p => p.Nurse).AnyAsync(p => !p.IsDelete && p.Nurse.UserId == userId);
        }

        //Update Nurse Info 
        public async Task UpdateNurseInfo(NurseInfo nurseInfo)
        {
            _context.NurseInfo.Update(nurseInfo);
            await _context.SaveChangesAsync();
        }
        
        //Add Nurse Info
        public async Task AddNurseInfo(NurseInfo nurseInfo)
        {
            await _context.NurseInfo.AddAsync(nurseInfo);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
