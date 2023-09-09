﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Notification
{
    public enum SupporterNotificationText
    {
        [Display(Name = "Request For Home Pharmacy")]
        HomePharmacyCreateFromUser,
        [Display(Name = "Approval of the request from the pharmacy")]
        ApprovalOfTheRequestFromThePharmacy,
        [Display(Name = "Approval of the request from the Laboratory")]
        ApprovalOfTheRequestFromTheLaboratory,
        [Display(Name = "Providing an invoice from the pharmacy")]
        ProvidingAnInvoiceFromThePharmacy,
        [Display(Name = "Accept Invoice From Customer")]
        AcceptInvoiceFromCustomer,
        [Display(Name = "Delivery by courier")]
        DeliveryByCourier,
        [Display(Name = "Received by the customer")]
        ReceivedByTheCustomer,
        [Display(Name = "Take Reservation")]
        TakeReservation,
        [Display(Name = "Family Home Request")]
        FamilyHomeRequest,
        [Display(Name = "Online Visit")]
        OnlineVisitRequest,
        [Display(Name = "New Arrival Online Visit Message")]
        NewArrivalOnlineVisitMessage,
        [Display(Name = "New Arrival Consultant Message")]
        NewArrivalConsultantMessage,
        [Display(Name = "Nurse Information Insert")]
        NurseInformationInsert,
        [Display(Name = "New Home Nurse Request")]
        NewHomeNurseRequest,
        [Display(Name = "Accept Home Nurse Request")]
        AcceptHomeNurseRequest,
        [Display(Name = "Consultant Information Insert")]
        ConsultantInformationInsert,
        [Display(Name = "Consultant Request")]
        ConsultantRequest,
        [Display(Name = "HomeVisitRequest")]
        HomeVisitRequest,
        [Display(Name = "AcceptHomeVisitRequestFromDoctor")]
        AcceptHomeVisitRequestFromDoctor,
        [Display(Name = "AcceptHomeVisitRequestFromUser")]
        AcceptHomeVisitRequestFromUser,
        [Display(Name = "DeclineHomeVisitRequestFromUser")]
        DeclineHomeVisitRequestFromUser,
        [Display(Name = "Cancel Home Visit Request")]
        CancelHomeVisitRequest,
        [Display(Name = "New Arrival Death Certificate Request")]
        NewArrivalDeathCertificateRequest,
        [Display(Name = "AcceptDeathCertificateRequestFromDoctor")]
        AcceptDeathCertificateRequestFromDoctor,
        [Display(Name = "Laboratory Information Insert")]
        LaboratoryInformationInsert,
        [Display(Name = "درخواست آزمایشگاه درمنزل")]
        NewArrivalHomeLaboratoryRequest,
        [Display(Name = "ایجاد توکن گردشگری")]
        TouristTokenPaid
    }
}
