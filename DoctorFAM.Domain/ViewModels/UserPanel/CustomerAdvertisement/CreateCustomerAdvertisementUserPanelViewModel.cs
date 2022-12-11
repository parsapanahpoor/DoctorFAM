using DoctorFAM.Domain.Enums.CustomerAdvertisement;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.UserPanel.CustomerAdvertisement
{
    public class CreateCustomerAdvertisementUserPanelViewModel 
    {
        #region properties

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Username { get; set; }

        [Required(ErrorMessage = "این فیلد الزامی است .")]
        [MaxLength(300, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string Title { get; set; }

        [MaxLength(500, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? ShortDescription { get; set; }

        public string? LongDescription { get; set; }

        #endregion
    }
}
