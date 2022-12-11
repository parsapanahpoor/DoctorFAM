using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.CustomerAdvertisement
{
    public enum CustomerAdvertisementState
    {
        [Display(Name = "درانتظار برسی ادمین")]
        WaitingForInitialInvoice,

        [Display(Name = "درانتظار پرداخت مشتری")]
        WaitingForPayment,

        [Display(Name = "پرداخت شده")]
        Paied,

        [Display(Name = "درخواست رد شده")]
        Decline
    }
}
