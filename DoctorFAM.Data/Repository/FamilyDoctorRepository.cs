﻿using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.FamilyDoctor;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.DoctorPanel.PopulationCovered;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class FamilyDoctorRepository : IFamilyDoctorRepository
    {
        #region Ctor 

        private readonly DoctorFAMDbContext _context;

        public FamilyDoctorRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region User Panel

        //Is Exist Any Family Doctor For Patient
        public async Task<bool> IsExistAnyFamilyDoctorForPatient(ulong userId)
        {
            return await _context.UserSelectedFamilyDoctor.AnyAsync(p => !p.IsDelete && p.PatientId == userId && p.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted);
        }

        //Get User Selected Family Doctor 
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByUserId(ulong userId)
        {
            return await _context.UserSelectedFamilyDoctor
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.PatientId == userId);
        }

        //Get User Selected Family Doctor By Request Id
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByRequestId(ulong requestId)
        {
            return await _context.UserSelectedFamilyDoctor
                            .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == requestId);
        }

        //Add Family Doctor For This Patient 
        public async Task AddFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor)
        {
            await _context.UserSelectedFamilyDoctor.AddAsync(familyDoctor);
            await _context.SaveChangesAsync();
        }

        //Remove Family Doctor For This Patient 
        public async Task RemoveFamilyDoctorForThisPatient(UserSelectedFamilyDoctor familyDoctor)
        {
            familyDoctor.IsDelete = true;

            _context.UserSelectedFamilyDoctor.Update(familyDoctor);
            await _context.SaveChangesAsync();
        }

        //Get User Selected Family Doctor By Patient Id And Doctor Id With Accepted And Waiting State
        public async Task<UserSelectedFamilyDoctor?> GetUserSelectedFamilyDoctorByPatientIdAndDoctorIdWithAcceptedAndWaitingState(ulong userId , ulong doctorId)
        {
            return await _context.UserSelectedFamilyDoctor.FirstOrDefaultAsync(p => !p.IsDelete && p.DoctorId == doctorId && p.PatientId == userId
                                                             && p.FamilyDoctorRequestState != Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline);
        }

        //Update User Selected Family Doctor 
        public async Task UpdateUserSelectedFamilyDoctor(UserSelectedFamilyDoctor userSelectedFamilyDoctor)
        {
            _context.UserSelectedFamilyDoctor.Update(userSelectedFamilyDoctor);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Doctor Panel 

        //List Of Doctor Population Covered Users
        public async Task<ListOfDoctorPopulationCoveredViewModel> FilterDoctorPopulationCovered(ListOfDoctorPopulationCoveredViewModel filter)
        {
            #region Get organization 

            var doctorOffice = await _context.OrganizationMembers.Include(p => p.Organization)
                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.UserId);
            if (doctorOffice == null) return null;

            #endregion

            var query = _context.UserSelectedFamilyDoctor
                .Include(p => p.Patient)
                .ThenInclude(p=> p.PopulationCovered)
                .Where(s => !s.IsDelete && s.DoctorId == doctorOffice.Organization.OwnerId && s.FamilyDoctorRequestState != Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Decline)
                .OrderByDescending(s => s.CreateDate)
                .Select(p=> p.Patient)
                .AsQueryable();


            #region Filter

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.Mobile != null && EF.Functions.Like(s.Mobile, $"%{filter.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => s.Username.Contains(filter.Username));
            }

            if (!string.IsNullOrEmpty(filter.NationalId))
            {
                query = query.Where(s => s.NationalId.Contains(filter.NationalId));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }


        #endregion
    }
}
