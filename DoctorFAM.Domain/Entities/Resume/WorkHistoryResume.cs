using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Resume
{
    public class WorkHistoryResume : BaseEntity
    {
        #region properties

        public ulong ResumeId { get; set; }

        [MaxLength(300)]
        public string? WorkAddress { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [MaxLength(300)]
        public string? JobPosition { get; set; }

        [MaxLength(300)]
        public string? CountryName { get; set; }

        [MaxLength(300)]
        public string? CityName { get; set; }

        #endregion

        #region properties

        public Resume Resume { get; set; }

        #endregion
    }
}
