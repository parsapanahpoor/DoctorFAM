#region Using

using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Tourism.Token;

#endregion

public sealed class CountOFTouristTokenUsage : BaseEntity
{
    #region properties

    public ulong TokenId { get; set; }

    public string DimeOfUsage { get; set; }

    public ulong UserId { get; set; }

    #endregion
}
