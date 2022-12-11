using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Enums.CustomerAdvertisement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.CustomerAdvertisement
{
    public class CustomerAdvertisementDetailViewModel
    {
        #region properties

        public ulong AdvertisementId { get; set; }

        public User Owner { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        public CustomerAdvertisementState CustomerAdvertisementState { get; set; }

        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? Price { get; set; }

        public string Image { get; set; }

        public int Priority { get; set; }

        public string? StartDate { get; set; }

        public string? EndDate { get; set; }

        public bool ShowInfinit { get; set; }

        #endregion

    }
}
