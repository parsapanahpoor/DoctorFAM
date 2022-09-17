using DoctorFAM.Domain.Enums.OnlineVisitRequest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.OnlineVisit
{
    public class OnlineVisitRquestDetailViewModel
    {
        #region properties

        public ulong RequestId { get; set; }

        public ulong PatientId { get; set; }

        public string? OnlineVisitRequestDescription { get; set; }

        public IFormFile? OnlineVisitRequestFile { get; set; }

        [Display(Name = "نوع درخواست")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public OnlineVisitRequestType OnlineVisitRequestType { get; set; }

        #endregion
    }
}
