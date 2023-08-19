#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token;

#endregion

public class TouristTokenPaymentResult
{
    #region properties

    public ulong TokenId { get; set; }

    public ulong TouristId { get; set; }

    public int Price { get; set; }

    public bool Result { get; set; }

    public ulong TouristOwnerId { get; set; }

    #endregion
}
