using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Request
{
    public enum RequestState
    {
        [Display(Name = "Waiting for information to be filled by the user")]
        WaitingForCompleteInformationFromUser,
        [Display(Name = "Filling information from the user's side and transfer to the bank portal")]
        TramsferringToTheBankingPortal,
        [Display(Name = "Paid and waiting to choose a doctor")]
        Paid,
        [Display(Name = "unpaid")]
        unpaid,
        [Display(Name = "Selected by a doctor")]
        SelectedFromDoctor,
        [Display(Name = "finalized")]
        Finalized,
        [Display(Name = "Waiting For Confirm From Destination")]
        WaitingForConfirmFromDestination,
        [Display(Name = "Confirm From Destination And Waiting For Issuance Of Draft Invoice")]
        ConfirmFromDestinationAndWaitingForIssuanceOfDraftInvoice,
        [Display(Name = "Awaiting The Payment Of The Invoice Amount")]
        AwaitingThePaymentOfTheInvoiceAmount,
        [Display(Name = "Preparing The Order")]
        PreparingTheOrder,
        [Display(Name = "Delivery To Courier And Sending")]
        DeliveryToCourierAndSending,
        [Display(Name = "Accept From Customer")]
        AcceptFromCustomer,
        [Display(Name = "Waiting For Accept From Customer")]
        WaitingForAcceptFromCustomer,
        [Display(Name = "Canceled Request")]
        Canceled
    }

    public enum RequestStateForFilterAdminSide
    {
        [Display(Name = "All")]
        All,
        [Display(Name = "Waiting for information to be filled by the user")]
        WaitingForCompleteInformationFromUser,
        [Display(Name = "Filling information from the user's side and transfer to the bank portal")]
        TramsferringToTheBankingPortal,
        [Display(Name = "Paid and waiting to choose a doctor")]
        Paid,
        [Display(Name = "unpaid")]
        unpaid,
        [Display(Name = "Selected by a doctor")]
        SelectedFromDoctor,
        [Display(Name = "finalized")]
        Finalized,
    }

    public enum FilterRequestAdminSideOrder
    {
        [Display(Name = "Register Date - Descending")]
        CreateDate_Des,
        [Display(Name = "Register Date - Ascending")]
        CreateDate_Asc
    }

    public enum FilterRequestOrder
    {
        [Display(Name = "Register Date - Descending")]
        CreateDate_Des,
        [Display(Name = "Register Date - Ascending")]
        CreateDate_Asc
    }

}
