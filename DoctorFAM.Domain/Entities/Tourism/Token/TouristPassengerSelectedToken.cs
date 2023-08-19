#region Using

using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Tourism.Token;

#endregion

public sealed class TouristPassengerSelectedToken : BaseEntity
{
    #region propeties

    public ulong TouristId { get; set; }

    public ulong PassengerId { get; set; }

    public ulong TokenId { get; set; }

    #endregion
}
