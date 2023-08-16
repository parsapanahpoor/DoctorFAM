#region Using

using DoctorFAM.Domain.Enums.Tourist;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Tourist.Token;

#endregion

public class ShowTokenInvoiceForTouristViewModle
{
    #region properties

    public int CountOfPeople { get; set; }

    public int CountOfToken { get; set; }

    public string Token { get; set; }

    public string? TokenLabel { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int Price { get; set; }

    public TouristTokenState TokenState { get; set; }

    public int PriceOfUnitToken { get; set; }

    public ulong TokenId { get; set; }

    #endregion
}
