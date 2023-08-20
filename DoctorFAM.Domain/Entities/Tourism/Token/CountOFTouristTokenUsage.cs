using DoctorFAM.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Entities.Tourism.Token;

public class CountOfTouristTokenUsage : BaseEntity
{
    #region properties

    public ulong PassengerId { get; set; }

    public ulong PassengerUserId { get; set; }

    public ulong TokenId { get; set; }

    public string TimeOfUsage { get; set; }

    #endregion
}
