using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Consultant
{
    public class ConsultantInfo : BaseEntity
    {
        #region properties

        public ulong ConsultantId { get; set; }

        public string NationalCode { get; set; }

        public string? Education { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion

        #region Relations

        public Consultant Consultant { get; set; }

        #endregion
    }
}
