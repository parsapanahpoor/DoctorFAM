using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Products
{
    public enum ProductsState
    {
        [Display(Name = "در انتظار برسی")]
        WaitingForConfirm,

        [Display(Name = "پذیرفته شده ")]
        Accept,

        [Display(Name = "رد شده ")]
        Reject
    }

    public enum ProductSaleType
    {
        [Display(Name = "فروش بسته ای ")]
        Packed,
        [Display(Name = "فروش تکی محصول  ")]
        Single
    }

    public enum ProductsStateForFilterInPanel
    {
        WaitingForConfirm,
        Accept,
        Reject,
        All
    }

    public enum ProductSaleTypeForFilterInPanel
    {
        Packed,
        Single,
        All
    }

    public enum FilterProductOrder
    {
        [Display(Name = "تاریخ ثبت نام - نزولی")]
        CreateDate_Des,
        [Display(Name = "تاریخ ثبت نام - صعودی ")]
        CreateDate_Asc
    }
}
