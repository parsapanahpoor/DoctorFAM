using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.Entities.HealthInformation
{
    public class HealthInformationTag : BaseEntity
    {
        #region Property

        public ulong HealthInformationId { get; set; }

        [Display(Name = "تگ آگهی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string TagTitle { get; set; }

        #endregion

        #region Relation

        public HealthInformation HealthInformation { get; set; }

        #endregion
    }
}
