using DoctorFAM.Domain.Enums.RequestType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.Request
{
    public class RequestViewModel
    {
        [Display(Name = "کد کاربر")]
        public ulong UserId { get; set; }

        [Display(Name = "نوع درخواست")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public RequestType RequestType { get; set; }

    }
}
