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
        [Display(Name = "در انتظار پر کردن اطلاعات از طرف کاربر")]
        WaitingForCompleteInformationFromUser,
        [Display(Name = "پرشدن اطلاعات از سمت کاربر و انتقال به درگاه بانکی")]
        TramsferringToTheBankingPortal,
        [Display(Name = "پرداخت شده ")]
        Paid,
        [Display(Name = "پرداخت نشده")]
        unpaid,
    }

    public enum RequestStateForFilterAdminSide
    {
        [Display(Name = "همه")]
        All,
        [Display(Name = "در انتظار پر کردن اطلاعات از طرف کاربر")]
        WaitingForCompleteInformationFromUser,
        [Display(Name = "پرشدن اطلاعات از سمت کاربر و انتقال به درگاه بانکی")]
        TramsferringToTheBankingPortal,
        [Display(Name = "پرداخت شده ")]
        Paid,
        [Display(Name = "پرداخت نشده")]
        unpaid,
    }

    public enum FilterRequestAdminSideOrder
    {
        [Display(Name = "تاریخ ثبت نام - نزولی")]
        CreateDate_Des,
        [Display(Name = "تاریخ ثبت نام - صعودی ")]
        CreateDate_Asc
    }
}
