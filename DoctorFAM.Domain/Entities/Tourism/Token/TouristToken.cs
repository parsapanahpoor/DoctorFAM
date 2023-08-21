using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Tourist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Tourism.Token
{
    public sealed class TouristToken : BaseEntity
    {
        #region properties

        public ulong TouristId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Token { get; set; }

        [MaxLength(300)]
        public string TokenLabel { get; set; }

        public TouristTokenState TouristTokenState { get; set; }

        #endregion
    }
}
