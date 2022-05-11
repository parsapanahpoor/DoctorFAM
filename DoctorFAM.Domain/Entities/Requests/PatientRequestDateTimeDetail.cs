using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Requests
{
    public class PatientRequestDateTimeDetail : BaseEntity
    {
        #region properties

        public ulong RequestId { get; set; }

        [Required]
        public DateTime SendDate { get; set; }

        [Required]
        public int StartTime { get; set; }

        [Required]
        public int EndTime { get; set; }

        #endregion

        #region relations

        public Request Requests { get; set; }

        #endregion
    }
}
