using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Resume
{
    public class ResumeAboutMe : BaseEntity
    {
        #region properties

        public ulong ResumeId { get; set; }

        public string AboutMeText { get; set; }

        public string? BannerImage { get; set; }

        #endregion

        #region relation

        public Resume Resume { get; set; }

        #endregion
    }
}
