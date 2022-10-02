using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Laboratory
{
    public class LaboratoryInfo : BaseEntity
    {
        #region properties

        public ulong LaboratoryId { get; set; }

        public int NationalCode { get; set; }

        public string? Education { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        #endregion

        #region ralation 

        public Laboratory Laboratory { get; set; }

        #endregion
    }
}
