using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.DoctorReservation;
using DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile;
using DoctorFAM.Domain.ViewModels.Supporter.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Supporter
{
    public class SuppoeterDashboardViewModel
    {
        #region properties

        public List<Request> LastestHomeVisitRequest { get; set; }

        public List<Request> LastestHomeNurseRequest { get; set; }

        public List<Request> LastestHomePatientTransportRequest { get; set; }

        public List<Request> LastestHomeLaboratoryRequest { get; set; }

        public List<Request> LastestHomePharmacyRequest { get; set; }

        public List<Request> LastestDeathCertificateRequest { get; set; }

        public List<Request> AllRecords { get; set; }

        public List<ListOfSelectedReservationsSupporterSideDTO> DoctorReservationDateTimes { get; set; }

        public List<Domain.Entities.Contact.Ticket> ListOfLastestTickets { get; set; }

        public List<ListOfArrivalExcelFiles> LatestRequestForUploadExcelFile { get; set; }

        public int CountOfTodayRegister { get; set; }

        public int CountOfWaitingForPaymentReservationRequests { get; set; }

        #endregion
    }
}
