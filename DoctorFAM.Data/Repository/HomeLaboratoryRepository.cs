using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.Requests;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomeLabratory;
using DoctorFAM.Domain.ViewModels.Admin.HealthHouse.HomePharmacy;
using DoctorFAM.Domain.ViewModels.Laboratory.HomeLaboratory;
using DoctorFAM.Domain.ViewModels.UserPanel.HealthHouse.HomeLaboratory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class HomeLaboratoryRepository : IHomeLaboratoryRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public HomeLaboratoryRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Site Side

        //Get Activated And Home Laboratories Interests LAboratories For Send Correct Notification For Arrival Home Laboratories Request 
        public async Task<List<string?>> GetActivatedAndHomeLaboratoriesInterestLaboratories(ulong countryId, ulong stateId, ulong cityId)
        {
            #region Get Laboratories   

            var users = await _context.Laboratory.Where(p => !p.IsDelete).Select(p => p.UserId).ToListAsync();
                                
            if (users == null) return null;

            #endregion

            #region Check User Work Addresses 

            //Initial Model Of String 
            List<string?> returnValue = new List<string?>();

            foreach (var item in users)
            {
                //Check Laboratories Location By Country Id && State Id && CityId
                var checkLocation = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.CityId == cityId && p.CountryId == countryId && p.StateId == stateId
                                                              && p.UserId == item);

                if (checkLocation != null)
                {
                    //Check Laboratories Is Activated
                    var activated = await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == checkLocation.UserId
                                            && p.OrganizationType == Domain.Enums.Organization.OrganizationType.Labratory && p.OrganizationInfoState == Domain.Entities.Doctors.OrganizationInfoState.Accepted);

                    if (activated != null)
                    {
                        returnValue.Add(activated.OwnerId.ToString());
                    }
                }
            }

            #endregion

            return returnValue;
        }

        public async Task<List<HomeLaboratoryRequestDetail>> GetHomeLaboratoryRequestDetailByRequestId(ulong requestId)
        {
            return await _context.HomeLaboratoryRequestDetails.Where(p => !p.IsDelete && p.RequestId == requestId).ToListAsync();
        }

        public async Task AddLaboratoryRequest(HomeLaboratoryRequestDetail laboratory)
        {
            await _context.HomeLaboratoryRequestDetails.AddAsync(laboratory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRequestedLaboratory(HomeLaboratoryRequestDetail laboratory)
        {
            _context.HomeLaboratoryRequestDetails.Update(laboratory);
            await _context.SaveChangesAsync();
        }

        public async Task<HomeLaboratoryRequestDetail> GetRequestedLaboratoryById(ulong requesedLaboratoryId)
        {
            return await _context.HomeLaboratoryRequestDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == requesedLaboratoryId);
        }

        public async Task AddPatientRequestDateTimeDetail(PatientRequestDateTimeDetail request)
        {
            await _context.PatientRequestDateTimeDetails.AddAsync(request);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region Admin Side

        public async Task<FilterHomeLabratoryViewModel> FilterHomeLabratory(FilterHomeLabratoryViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeLab)
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

        public async Task<Request?> GetRquestForHomeLabratoryById(ulong requestId)
        {
            return await _context.Requests.Include(p => p.User).Include(p => p.Patient).Include(p => p.PaitientRequestDetails)
                            .FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
        }

        public async Task<Patient?> GetPatientByRequestId(ulong requestId)
        {
            return await _context.Patients.Include(p=> p.Insurance).FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        public async Task<PaitientRequestDetail?> GetRequestPatientDetailByRequestId(ulong requestId)
        {
            return await _context.PaitientRequestDetails.FirstOrDefaultAsync(p => p.RequestId == requestId && !p.IsDelete);
        }

        public async Task<PatientRequestDateTimeDetail?> GetRequestDateTimeDetailByRequestDetailId(ulong requestDetailId)
        {
            return await _context.PatientRequestDateTimeDetails.FirstOrDefaultAsync(p => !p.IsDelete && p.RequestId == requestDetailId);
        }

        public async Task<List<RequestedLabratoryAdminSideViewModel>?> GetRequestLabratoryByRequestId(ulong requestId)
        {
            return await _context.HomeLaboratoryRequestDetails.Where(p => p.RequestId == requestId && !p.IsDelete)
                                    .Select(p => new RequestedLabratoryAdminSideViewModel
                                    {
                                        Description = p.Description,
                                        ExperimentImage = p.ExperimentImage,
                                        ExperimentName = p.ExperimentName,
                                        ExperimentPrescription = p.ExperimentPrescription,
                                        ExperimentTrakingCode = p.ExperimentTrakingCode,
                                    }).ToListAsync();
        }

        #endregion

        #region User Panel 

        //Get Home Laboratory Request Detail Price By Request Id
        public async Task<HomeLaboratoryRequestPrice?> GetHomeLaboratoryRequestPriceByRequestId(ulong requestId)
        {
            return await _context.HomeLaboratoryRequestPrice.AsNoTracking()
                                    .Where(p => !p.IsDelete && p.HomeLaboratoryRequestId == requestId)
                                        .FirstOrDefaultAsync();
        }

        public async Task<ListOfHomeLaboratoryUserPanelSideViewModel> ListOfUserHomeLaboratoryRequest(ListOfHomeLaboratoryUserPanelSideViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.Patient)
             .Include(p=> p.PatientRequestDateTimeDetails)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeLab && s.UserId == filter.UserId)
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            await filter.Paging(query);

            return filter;
        }

        #endregion

        #region Laboratory Side

        //Get Home Laboratory Request ById
        public async Task<Request?> GetHomeLaboratoryRequestById(ulong requestId)
        {
            return await _context.Requests.FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
        }

        //Get Home Laboratory Request ById With As No Tracking
        public async Task<Request?> GetHomeLaboratoryRequestByIdWithAsNoTracking(ulong requestId)
        {
            return await _context.Requests.AsNoTracking()
                                             .FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
        }

        //Get Home Laboratory Request Detail Price By Orgenization OwnerId and Request Id
        public async Task<HomeLaboratoryRequestPrice?> GetHomeLaboratoryRequestPriceByOrgenizationOwnerIdandRequestId(ulong requestId ,  ulong organizationOwnerId )
        {
            return await _context.HomeLaboratoryRequestPrice.AsNoTracking()
                                    .Where(p => !p.IsDelete && p.LaboratoryOwnerId == organizationOwnerId && p.HomeLaboratoryRequestId == requestId)
                                        .FirstOrDefaultAsync();
        }

        //Add Home Laboratory Request Price Without Save Changes
        public async Task AddHomeLaboratoryRequestPriceWithoutSaveChanges(HomeLaboratoryRequestPrice requestPrice)
        {
            await _context.HomeLaboratoryRequestPrice.AddAsync(requestPrice);
        }

        //Add Home Laboratory Request Price Without Save Changes
        public async Task AddHomeLaboratoryRequestPrice(HomeLaboratoryRequestPrice requestPrice)
        {
            await _context.HomeLaboratoryRequestPrice.AddAsync(requestPrice);
            await _context.SaveChangesAsync();
        }

        //Update Home Laboratory Request Price Without
        public async Task EditHomeLaboratoryRequestPrice(HomeLaboratoryRequestPrice requestPrice)
        {
            _context.HomeLaboratoryRequestPrice.Update(requestPrice);
            await _context.SaveChangesAsync();
        }

        //Is Exist Any Price For Request From Current Laboratory
        public async Task<bool> IsExistAnyPriceForRequestFromCurrentLaboratory(ulong requestId , ulong laboratoryOwnerUserId)
        {
            return await _context.HomeLaboratoryRequestPrice.AnyAsync(p => !p.IsDelete && p.HomeLaboratoryRequestId == requestId
                                                                            && p.LaboratoryOwnerId == laboratoryOwnerUserId);
        }

        //Get Home Laboratory Request Price By Id
        public async Task<HomeLaboratoryRequestPrice?> GetHomeLaboratoryRequestPriceById(ulong homelaboratoryRequestPriceId, ulong laboratoryOwnerUserId)
        {
            return await _context.HomeLaboratoryRequestPrice.AsNoTracking()
                                            .FirstOrDefaultAsync(p => !p.IsDelete && p.Id == homelaboratoryRequestPriceId && p.LaboratoryOwnerId == laboratoryOwnerUserId);
                                            
        }

        //Update Home Laboratory Request 
        public void UpdateHomeLaboratoryRequest(Request request)
        {
            _context.Requests.Update(request);
        }

        //Save Changes
        public async Task Savechanges()
        {
            await _context.SaveChangesAsync();
        }

        //Update Request For Awaiting For Confirm From Patient
        public async Task UpdateRequestForAwaitingForConfirmFromPatient(ulong requestId)
        {
            var request = await _context.Requests.FirstOrDefaultAsync(p => p.Id == requestId && !p.IsDelete);
                                             
            request.RequestState = RequestState.AwaitingForConfirmInvoiceFromPatient;
            
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();
        }

        //Filter List Of Your Home Laboratory Request Laboratory Side
        public async Task<FilterListOfHomeLaboratoryRequestViewModel> FilterListOfYourHomeLaboratoryRequestLaboratorySide(FilterListOfHomeLaboratoryRequestViewModel filter)
        {
            var query = _context.Requests
             .Include(p => p.PatientRequestDateTimeDetails)
             .Include(p => p.Patient)
             .Include(p => p.User)
             .Include(p => p.PaitientRequestDetails)
             .Where(s => !s.IsDelete && s.RequestType == Domain.Enums.RequestType.RequestType.HomeLab && s.OperationId == filter.LaboratoryOwnerId )                    
             .OrderByDescending(s => s.CreateDate)
             .AsQueryable();

            #region Status

            switch (filter.FilterRequestLaboratorySideOrder)
            {
                case FilterRequestAdminSideOrder.CreateDate_Des:
                    break;
                case FilterRequestAdminSideOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Username, $"%{filter.Username}%"));
            }

            if (!string.IsNullOrEmpty(filter.FirstName))
            {
                query = query.Where(s => EF.Functions.Like(s.User.FirstName, $"%{filter.FirstName}%"));
            }

            if (!string.IsNullOrEmpty(filter.LastName))
            {
                query = query.Where(s => EF.Functions.Like(s.User.LastName, $"%{filter.LastName}%"));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        #endregion
    }
}
