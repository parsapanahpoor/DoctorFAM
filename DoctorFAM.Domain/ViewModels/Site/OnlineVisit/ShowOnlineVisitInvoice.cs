#region Usings

using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.OnlineVisit;
using DoctorFAM.Domain.Entities.Tourism.Token;
using System.Diagnostics;

namespace DoctorFAM.Domain.ViewModels.Site.OnlineVisit;

#endregion

public class ShowOnlineVisitInvoice
{
    #region properties

    public int OnlineVisitTariff { get; set; }

    public string OnlineVisitWorkShiftTime { get; set; }

    public DateTime RequestDateTime { get; set; }

    public User User { get; set; }

    public ulong WorkShiftDateTimeId { get; set; }

    public int businessKey { get; set; }

    public ulong WorkShiftDateId { get; set; }

    public TouristToken Token { get; set; }

    #endregion
}
