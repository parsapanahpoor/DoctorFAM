using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Laboratory
{
    public class HomeLaboratoryRequestDetail: BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? ExperimentTrakingCode { get; set; }

        public string? ExperimentPrescription { get; set; }

        [MaxLength(400, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        public string? ExperimentName { get; set; }

        public string? Description { get; set; }

        public string? ExperimentImage { get; set; }

        #endregion

        #region relations

        public Request Request { get; set; }

        #endregion
    }
}
