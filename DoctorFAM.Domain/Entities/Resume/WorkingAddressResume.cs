using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Resume
{
    public class WorkingAddressResume : BaseEntity
    {
        #region properties

        public ulong ResumeId { get; set; }

        public string WorkingAddress { get; set; }

        [MaxLength(300)]
        public string WorkingAddressTitle { get; set; }

        [MaxLength(500)]
        public string Days { get; set; }

        [MaxLength(300)]
        public string Times { get; set; }

        #endregion

        #region relation

        public Resume Resume { get; set; }

        #endregion
    }
}
