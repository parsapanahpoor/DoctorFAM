#region Using

using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DoctorFAM.Domain.ViewModels.Site.Reservation
{
    public class ReservationFactorSiteSideViewModel
    {
        #region properties

        public ulong PatientUserId  { get; set; }

        public ulong ReservationDateTimeId { get; set; }

        public ulong DoctorUserId { get; set; }

        public string PatientUsername{ get; set; }

        public string PatientMobile { get; set; }

        public string DoctorUsername{ get; set; }

        public WorkAddress? DoctorAddress{ get; set; }

        public List<DoctorsSkils?> DoctorSpeciality { get; set; }

        public string? DoctorSpecialities { get; set; }

        public string DoctorMobile{ get; set; }

        public DateTime ReservationDate { get; set; }

        public string ReservationDateTime { get; set; }

        public int ReservationPrice { get; set; }

        public string RefId { get; set; }

        public string PatientNationalId { get; set; }

        public LogForAnotherPatient? AnotherPatientSiteSide { get; set; }

        #endregion
    }
}
