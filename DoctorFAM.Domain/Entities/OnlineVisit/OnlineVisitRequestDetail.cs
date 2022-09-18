using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.OnlineVisitRequest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Entities.OnlineVisit
{
    public class OnlineVisitRequestDetail : BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        public string? OnlineVisitRequestDescription { get; set; }

        public string? OnlineVisitRequestFile { get; set; }

        [Display(Name = "نوع درخواست")]
        [Required(ErrorMessage = "لطفا{0} را وارد نمایید...")]
        public OnlineVisitRequestType OnlineVisitRequestType { get; set; }

        #endregion

        #region realtions

        public Request Request { get; set; }

        #endregion
    }
}
