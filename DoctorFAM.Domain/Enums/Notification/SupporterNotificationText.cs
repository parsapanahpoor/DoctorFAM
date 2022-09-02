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
        [Display(Name = "Providing an invoice from the pharmacy")]
        ProvidingAnInvoiceFromThePharmacy,
        [Display(Name ="Accept Invoice From Customer")]
        AcceptInvoiceFromCustomer,
        [Display(Name = "Delivery by courier")]
        DeliveryByCourier,
        [Display(Name = "Received by the customer")]
        ReceivedByTheCustomer
    }
}
