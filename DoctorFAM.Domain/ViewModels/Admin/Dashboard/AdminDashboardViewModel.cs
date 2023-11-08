using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.CooperationRequest;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.ViewModels.Admin.IncomingExcelFile;
using DoctorFAM.Domain.ViewModels.Admin.Reservation;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public List<ListOfSelectedReservationsAdminSideDTO> ListOfIncomingTodayReservationDateTime { get; set; }

        public List<ListOfSelectedReservationsAdminSideDTO> ListOfTodayReservationDateTime { get; set; }

        public List<Domain.Entities.Contact.Ticket> ListOfLastestTickets { get; set; }

        public List<CooperationRequest> CooperationRequests { get; set; }

        public List<Entities.HealthInformation.HealthInformation> LastestIncomingTVFAM { get; set; }

        public List<Entities.HealthInformation.HealthInformation> LastestIncomingRadioFAM { get; set; }

        public List<Domain.Entities.Resume.Resume> LastestArrivalResumes { get; set; }

        public List<ListOfArrivalExcelFiles> LatestRequestForUploadExcelFile{ get; set; }

        public List<DoctorFAM.Domain.Entities.Advertisement.CustomerAdvertisement> LastestCustomerAdvertisements { get; set; }

        public List<Organization> ListOfWaitingForAcceptInformationsDoctors { get; set; }

        public List<RequestForSendSMSFromDoctorsToTheUsersAdminSideViewModel>? RequestForSendSMSFromDoctorsToTheUsersAdminSideViewModel { get; set; }

        public int CountOfTodayRegister { get; set; }

        public int CountOfWaitingForPaymentReservationRequests { get; set; }

        #endregion
    }
}
