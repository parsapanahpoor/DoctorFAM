using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.Tourist;

public sealed class TouristPassengersSelectToken : BaseEntity
{
    #region propeties

    public ulong  TouristId { get; set; }

    public ulong PassengersId { get; set; }

    public ulong TokenId { get; set; }

    #endregion
}
