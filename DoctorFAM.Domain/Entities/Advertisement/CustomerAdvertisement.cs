using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.CustomerAdvertisement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Advertisement
{
    public class CustomerAdvertisement : BaseEntity
    {
        #region properties

        public ulong UserId { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? ShortDescription { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        public string? MyProperty { get; set; }

        public CustomerAdvertisementState CustomerAdvertisementState { get; set; }

        public string Image { get; set; }

        public bool Priority { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool ShowInfinit { get; set; }

        #endregion
    }
}
