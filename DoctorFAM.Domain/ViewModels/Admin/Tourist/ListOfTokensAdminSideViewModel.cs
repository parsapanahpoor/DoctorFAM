#region Using

using DoctorFAM.Domain.Enums.Tourist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Tourist;

#endregion

public class ListOfTokensAdminSideViewModel
{
    #region properties

    public ulong TokenId { get; set; }

    public string TokenCode { get; set; }

    public string? TokenLabel { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CountOfPassengers { get; set; }

    public TouristTokenState TouristTokenState { get; set; }

    #endregion
}
