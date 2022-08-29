using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Pharmacy
{
    public class HomePharmacyRequestDetail : BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugTrakingCode { get; set; }

        public string? DrugPrescription { get; set; }

        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugName { get; set; }

        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? DrugCount { get; set; }

        public string? Description { get; set; }

        public string? DrugImage { get; set; }

        #endregion

        #region relations

        public Request Request { get; set; }

        public ICollection<HomePharmacyRequestDetailPrice>  HomePharmacyRequestDetailPrices{ get; set; }

        #endregion
    }
}
