using DoctorFAM.Domain.Entities.SiteSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DoctorFAM.Domain.ViewModels.Site.DeathCertificate
{
    public class DeathCertificateRequestFeatureViewModel
    {
        #region propreties

        [Display(Name = "کد درخواست")]
        public ulong RequestId { get; set; }

        public List<TariffForHealthHouseServices>? ListOfTariffs { get; set; }

        public List<TariffForHealthHouseServices>? ListOfUserSelectedTAriff { get; set; }

        #endregion

    }
}
