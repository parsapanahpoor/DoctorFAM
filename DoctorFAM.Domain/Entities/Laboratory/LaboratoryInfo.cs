using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Entities.Laboratory
{
    public class LaboratoryInfo : BaseEntity
    {
        #region properties

        public ulong LaboratoryId { get; set; }

        public string NationalCode { get; set; }

        public string? Education { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "تعداد پیامک رایگان برای ارسال از آزمایشگاه به بیماران")]
        public int CountOFFreeSMSForLaboratory { get; set; }

        #endregion

        #region ralation 

        public Laboratory Laboratory { get; set; }

        #endregion
    }
}
