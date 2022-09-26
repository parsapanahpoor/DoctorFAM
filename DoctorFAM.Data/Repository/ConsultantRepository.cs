using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Entities.Nurse;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Admin.Doctor;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ConsultantRepository :IConsultantRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public ConsultantRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Consultant Panel Side 

        //Fill Consultant Side Bar Panel
        public async Task<ConsultantSideBarViewModel> GetConsultantSideBarInfo(ulong userId)
        {
            #region Get Doctor Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant);

            #endregion

            ConsultantSideBarViewModel model = new ConsultantSideBarViewModel();

            #region Consultant State 

            //If Consultant Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.ConsultantInfoState = "NewUser";

            //If Consultant State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.ConsultantInfoState = "WatingForConfirm";

            //If Consultant State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.ConsultantInfoState = "Rejected";

            //If Consultant State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.ConsultantInfoState = "Accepted";

            #endregion

            return model;
        }

        //Is Exist Any Consultant By This User Id 
        public async Task<bool> IsExistAnyConsultantByUserId(ulong userId)
        {
            return await _context.consultant.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        //Add Consultant To Data Base
        public async Task<ulong> AddConsultant(Consultant consultant)
        {
            await _context.consultant.AddAsync(consultant);
            await _context.SaveChangesAsync();

            return consultant.Id;
        }

        //Get Consultant By User Id
        public async Task<Consultant?> GetConsultantByUserId(ulong userId)
        {
            return await _context.consultant.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        //Get Consultant Information By User Id
        public async Task<ConsultantInfo?> GetConsultantInformationByUserId(ulong userId)
        {
            return await _context.ConsultantInfos.Include(p => p.Consultant).FirstOrDefaultAsync(p => p.Consultant.UserId == userId && !p.IsDelete);
        }

        //Check Is Exist Consultant Info By User ID
        public async Task<bool> IsExistAnyConsultantInfoByUserId(ulong userId)
        {
            return await _context.ConsultantInfos.Include(p => p.Consultant).AnyAsync(p => !p.IsDelete && p.Consultant.UserId == userId);
        }

        //Update Consultant Info 
        public async Task UpdateConsultantInfo(ConsultantInfo consultantInfo)
        {
            _context.ConsultantInfos.Update(consultantInfo);
            await _context.SaveChangesAsync();
        }

        //Add Consultant Info
        public async Task AddConsultantInfo(ConsultantInfo consultantInfo)
        {
            await _context.ConsultantInfos.AddAsync(consultantInfo);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side 

        //Filter Consultant Info Admin Side
        public async Task<ListOfConsultantInfoViewModel> FilterConsultantInfoAdminSide(ListOfConsultantInfoViewModel filter)
        {
            var query = _context.Organizations
                .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.Consultant)
                .Include(p => p.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.ConsultantState)
            {
                case ConsultantState.All:
                    break;
                case ConsultantState.Accepted:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                    break;
                case ConsultantState.WaitingForConfirm:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                    break;
                case ConsultantState.Rejected:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Rejected);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.Email}%"));
            }

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(s => s.User.Username.Contains(filter.FullName));
            }

            if (!string.IsNullOrEmpty(filter.NationalCode))
            {
                query = query.Where(s => s.User.NationalId.Contains(filter.NationalCode));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //Get Consultant Info By Nurse Id
        public async Task<ConsultantInfo?> GetConsultantInfoByConsultantId(ulong consultantId)
        {
            return await _context.ConsultantInfos.Include(p => p.Consultant).FirstOrDefaultAsync(p => !p.IsDelete && p.ConsultantId == consultantId);
        }

        //Get Consultant By Consultant Id
        public async Task<Consultant?> GetConsultantById(ulong consultantId)
        {
            return await _context.consultant.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == consultantId);
        }

        //Get Consultant Info By Nurse Info Id
        public async Task<ConsultantInfo?> GetConsultantInfoById(ulong consultantInfoId)
        {
            return await _context.ConsultantInfos.Include(p => p.Consultant).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == consultantInfoId);
        }

        #endregion

        #region User Panel Side 

        //Get User Selected Consultant 
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedConsultantByUserId(ulong userId)
        {
            return await _context.UserSelectedFamilyDoctor
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.PatientId == userId);
        }

        #endregion
    }
}
