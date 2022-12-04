using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Resume
{
    public class GalleryResume : BaseEntity
    {
        #region properties

        public ulong ResumeId { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }

        public string ImageName { get; set; }

        #endregion

        #region relation

        public Resume Resume { get; set; }

        #endregion
    }
}
