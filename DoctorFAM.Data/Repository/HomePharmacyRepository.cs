using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HomePharmacyRepository : IHomePharmacyRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomePharmacyRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        public async Task<List<HomePharmacyRequestDetail>> GetHomePharmacyRequestDetailByRequestId(ulong requestId)
        {
            return await _context.HomePharmacyRequestDetails.Where(p => !p.IsDelete && p.RequestId == requestId).ToListAsync();
        }

        public async Task AddDrugRequest(HomePharmacyRequestDetail drug)
        {
            await _context.HomePharmacyRequestDetails.AddAsync(drug);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestedDrug(HomePharmacyRequestDetail drug)
        {
            _context.HomePharmacyRequestDetails.Update(drug);
            await _context.SaveChangesAsync();
        }

        public async Task<HomePharmacyRequestDetail> GetRequestedDrugById(ulong requesedDrugId)
        {
            return await _context.HomePharmacyRequestDetails.FirstOrDefaultAsync(p=> !p.IsDelete && p.Id == requesedDrugId);
        }

        public async Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request)
        {
            await _context.PatientRequestDateTimeDetails.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        //Get Activated And Home Pharmacy Interests Pharmacy For Send Correct Notification For Arrival Home Pharmacy Request 
        public async Task<List<string?>> GetActivatedAndHomePharamcyInterestPharmacy(ulong countryId , ulong stateId , ulong cityId)
        {
            #region Get Home Pharmacy Interests Pharmacys  

            var users = await _context.PharmacySelectedInterests.Include(p=> p.Pharmacy)
                                .Where(p => !p.IsDelete && p.InterestId == 1).Select(p => p.Pharmacy.UserId).ToListAsync();
            if (users == null) return null;

            #endregion

            #region Check User Work Addresses 

            //Initial Model Of String 
            List<string?> returnValue = new List<string?>();

            foreach (var item in users)
            {
                //Check Pharmacy Location By Country Id && State Id && CityId
                var checkLocation = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.CityId == cityId && p.CountryId == countryId && p.StateId == stateId
                                                              && p.UserId == item );

                if (checkLocation != null)
                {
                    //Check Pharmacy Is Activated
                    var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == checkLocation.UserId
                                            && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Pharmacy && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

                    if (activated != null)
                    {
                        returnValue.Add(activated.OwnerId.ToString());
                    }
                }
            }

            #endregion

            return returnValue;
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomePharmacyViewModel> FilterHomePharmacy(FilterHomePharmacyViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeDrog)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            #region Status

            switch (filter.RequestState)
            {
                case RequestStateForFilterAdminSide.All:
                    break;
                case RequestStateForFilterAdminSide.TramsferringToTheBankingPortal:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.TramsferringToTheBankingPortal);
                    break;
                case RequestStateForFilterAdminSide.Paid:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.Paid);
                    break;
                case RequestStateForFilterAdminSide.WaitingForCompleteInformationFromUser:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.WaitingForCompleteInformationFromUser);
                    break;
                case RequestStateForFilterAdminSide.unpaid:
                    query = query.Where(s => s.RequestState == Domain.Enums.Request.RequestState.unpaid);
                    break;
            }

            switch (filter.FilterRequestAdminSideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.UserEmail))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.UserEmail}%"));
            }

            if (!string.IsNullOrEmpty(filter.UserMobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.UserMobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<Request?> GetRquestForHomePharmacyById(ulong requestId)
        {
            return await _context.Requests.Include(p => p.User).Include(p => p.Patient).Include(p => p.PaitientRequestDetails)
                            .FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _context.PaitientRequestDetails.FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        public async Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestId)
        {
            return await _context.PatientRequestDateTimeDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == requestId);
        }

        public async Task<List<RequestedDrugsAdminSideViewModel>?> GetRequestDrugsByRequestId(ulong requestId)
        {
            return await _context.HomePharmacyRequestDetails.Where(p=> p.RequestId == requestId && !p.IsDelete)
                                    .Select(p=> new RequestedDrugsAdminSideViewModel
                                    {
                                        Description = p.Description,
                                        DrugCount = p.DrugCount,
                                        DrugName = p.DrugName,
                                        DrugPrescription = p.DrugPrescription,
                                        DrugTrakingCode = p.DrugTrakingCode,
                                        DrugImage = p.DrugImage,
                                    }).ToListAsync();
        }

        #endregion
    }
}
