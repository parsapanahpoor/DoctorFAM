#region Usings

namespace DoctorFAM.Domain.ViewModels.Site.OnlineVisit;

#endregion

public record AddTokenToOnlineVisitRequestSiteSideDTO
{
    #region propeties

    public int businessKey { get; set; }

    public ulong WorkShiftDateTimeId { get; set; }

    public ulong WorkShiftDateId { get; set; }

    public string token { get; set; }

    #endregion
}
