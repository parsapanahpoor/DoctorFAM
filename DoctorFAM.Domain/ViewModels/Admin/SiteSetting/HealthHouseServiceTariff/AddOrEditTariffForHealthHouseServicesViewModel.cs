﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Admin.SiteSetting.HealthHouseServiceTariff
{
    public class AddOrEditTariffForHealthHouseServicesViewModel
    {
        #region properties

        public ulong? Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Price { get; set; }

        public bool HomeVisit { get; set; }

        public bool HomeNurse { get; set; }

        public bool DeathCertificate { get; set; }

        #endregion
    }
}
