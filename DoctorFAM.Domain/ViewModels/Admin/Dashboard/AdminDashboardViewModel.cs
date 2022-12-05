//using DoctorFAM.Domain.Entities.Advertisement;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.CooperationRequest;
using DoctorFAM.Domain.Entities.DoctorReservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Dashboard
{
    public class AdminDashboardViewModel
    {
        #region properties

        public List<Request> LastestHomeVisitRequest { get; set; }

        public List<Request> LastestHomeNurseRequest { get; set; }

        public List<Request> LastestHomePatientTransportRequest { get; set; }

        public List<Request> LastestHomeLaboratoryRequest { get; set; }

        public List<Request> LastestHomePharmacyRequest { get; set; }

        public List<Request> LastestDeathCertificateRequest { get; set; }
        
        public List<Request> AllRecords { get; set; }

        public List<DoctorReservationDateTime> DoctorReservationDateTimes { get; set; }

        public List<Domain.Entities.Contact.Ticket> ListOfLastestTickets { get; set; }

        public List<CooperationRequest> CooperationRequests { get; set; }

        public List<Entities.HealthInformation.HealthInformation> LastestIncomingTVFAM { get; set; }

        public List<Entities.HealthInformation.HealthInformation> LastestIncomingRadioFAM { get; set; }

        public List<Domain.Entities.Resume.Resume> LastestArrivalResumes { get; set; }

        #endregion
    }
}
