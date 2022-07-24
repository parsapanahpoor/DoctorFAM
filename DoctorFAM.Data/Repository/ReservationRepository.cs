using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.Enums.DoctorReservation;
using DoctorFAM.Domain.Enums.Request;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Appointment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        private readonly IOrganizationRepository _organizationRepository;

        private readonly IDoctorsRepository _doctorRepository;

        public ReservationRepository(DoctorFAMDbContext context, IOrganizationRepository organizationRepository, IDoctorsRepository doctorRepository)
        {
            _context = context;
            _organizationRepository = organizationRepository;
            _doctorRepository = doctorRepository;
        }

        #endregion

        #region Doctor Panel

        //This Is Filter For Reservation Date From Today 
        public async Task<FilterAppointmentViewModel?> FilterDoctorReservationDateSide(FilterAppointmentViewModel filter)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
            if (organization == null) return null;

            #endregion

            #region Check Doctor Is Valid

            var doctor = await _doctorRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return null;

            #endregion

            var query = _context.DoctorReservationDates
                .Include(p => p.DoctorReservationDateTimes)
                .Where(s => !s.IsDelete && s.UserId == organization.OwnerId && s.ReservationDate.DayOfYear >= DateTime.Now.DayOfYear)
                .OrderBy(s => s.ReservationDate)
                .AsQueryable();

            #region Status

            switch (filter.FilterRequestOrder)
            {
                case FilterRequestOrder.CreateDate_Des:
                    break;
                case FilterRequestOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            switch (filter.FilterReservationOrder)
            {
                case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                    break;

                case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.ReservationDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.FromDate))
            {
                var spliteDate = filter.FromDate.Split('/');
                int year = int.Parse(spliteDate[0]);
                int month = int.Parse(spliteDate[1]);
                int day = int.Parse(spliteDate[2]);
                DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

                query = query.Where(s => s.ReservationDate >= fromDate);
            }

            if (!string.IsNullOrEmpty(filter.ToDate))
            {
                var spliteDate = filter.ToDate.Split('/');
                int year = int.Parse(spliteDate[0]);
                int month = int.Parse(spliteDate[1]);
                int day = int.Parse(spliteDate[2]);
                DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

                query = query.Where(s => s.ReservationDate <= toDate);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        //This Is History Of All Records That In Reservation Date By User Id  
        public async Task<FilterAppointmentViewModel?> FiltrDoctorReservationDateHistory(FilterAppointmentViewModel filter)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
            if (organization == null) return null;

            #endregion

            #region Check Doctor Is Valid

            var doctor = await _doctorRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return null;

            #endregion


            var query = _context.DoctorReservationDates
                .Include(p => p.DoctorReservationDateTimes)
                .Where(s => !s.IsDelete && s.UserId == organization.OwnerId)
                .OrderByDescending(s => s.ReservationDate)
                .AsQueryable();

            #region Status

            switch (filter.FilterRequestOrder)
            {
                case FilterRequestOrder.CreateDate_Des:
                    break;
                case FilterRequestOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            switch (filter.FilterReservationOrder)
            {
                case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Des:
                    break;

                case Domain.Enums.DoctorReservation.FilterReservationOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.ReservationDate);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.FromDate))
            {
                var spliteDate = filter.FromDate.Split('/');
                int year = int.Parse(spliteDate[0]);
                int month = int.Parse(spliteDate[1]);
                int day = int.Parse(spliteDate[2]);
                DateTime fromDate = new DateTime(year, month, day, new PersianCalendar());

                query = query.Where(s => s.ReservationDate >= fromDate);
            }

            if (!string.IsNullOrEmpty(filter.ToDate))
            {
                var spliteDate = filter.ToDate.Split('/');
                int year = int.Parse(spliteDate[0]);
                int month = int.Parse(spliteDate[1]);
                int day = int.Parse(spliteDate[2]);
                DateTime toDate = new DateTime(year, month, day, new PersianCalendar());

                query = query.Where(s => s.ReservationDate <= toDate);
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task AddDoctorReservationDate(DoctorReservationDate doctorReservationDate)
        {
            await _context.DoctorReservationDates.AddAsync(doctorReservationDate);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DoctorReservationDateTime>?> GetListOfReservationDateTimesByReservationDateId(ulong reservationDateId)
        {
            return await _context.DoctorReservationDateTimes.Where(p => !p.IsDelete && p.DoctorReservationDateId == reservationDateId).ToListAsync();
        }

        public async Task<FilterReservationDateTimeDoctorPAnel?> FilterReservationDateTimeDoctorSide(FilterReservationDateTimeDoctorPAnel filter)
        {
            #region Get Owner Organization By EmployeeId 

            var organization = await _organizationRepository.GetOrganizationByUserId(filter.UserId);
            if (organization == null) return null;

            #endregion

            #region Check Doctor Is Valid

            var doctor = await _doctorRepository.GetDoctorByUserId(organization.OwnerId);
            if (doctor == null) return null;

            #endregion


            var query = _context.DoctorReservationDateTimes
                .Include(p => p.DoctorReservationDate)
                .Where(s => !s.IsDelete && s.DoctorReservationDate.UserId == organization.OwnerId && s.DoctorReservationDateId == filter.ReservationDateId)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region Status

            switch (filter.FilterRequestOrder)
            {
                case FilterRequestOrder.CreateDate_Des:
                    break;
                case FilterRequestOrder.CreateDate_Asc:
                    query = query.OrderBy(p => p.CreateDate);
                    break;
            }

            switch (filter.FilterDoctorReservationState)
            {
                case FilterDoctorReservationState.All:
                    break;
                case FilterDoctorReservationState.Reserved:
                    query = query.Where(p=> p.DoctorReservationState == DoctorReservationState.Reserved);
                    break;
                case FilterDoctorReservationState.NotReserved:
                    query = query.Where(p => p.DoctorReservationState == DoctorReservationState.NotReserved);
                    break;
                case FilterDoctorReservationState.WaitingForComplete:
                    query = query.Where(p => p.DoctorReservationState == DoctorReservationState.WaitingForComplete);
                    break;
            }

            switch (filter.FilterDoctorReservationType)
            {
                case FilterDoctorReservationType.All:
                    break;
                case FilterDoctorReservationType.Onile:
                    query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Onile);
                    break;
                case FilterDoctorReservationType.Reserved:
                    query = query.Where(p => p.DoctorReservationType == DoctorReservationType.Reserved);
                    break;
            }

            #endregion


            #region Filter



            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<DoctorReservationDate?> GetReservationDateById(ulong reservationDateId)
        {
            return await _context.DoctorReservationDates.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == reservationDateId);
        }

        public async Task UpdateReservationDate(DoctorReservationDate date)
        {
            _context.DoctorReservationDates.Update(date);
            await _context.SaveChangesAsync();
        }

        public async Task AddReservationDateTime(DoctorReservationDateTime dateTime)
        {
            await _context.DoctorReservationDateTimes.AddAsync(dateTime);
            await _context.SaveChangesAsync();
        }

        public async Task<DoctorReservationDateTime?> GetDoctorReservationDateTimeById(ulong reservationDateTimeId)
        {
            return await _context.DoctorReservationDateTimes.Include(p=> p.DoctorReservationDate).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == reservationDateTimeId);
        }

        public async Task UpdateReservationDateTime(DoctorReservationDateTime reservationDateTime)
        {
            _context.DoctorReservationDateTimes.Update(reservationDateTime);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
