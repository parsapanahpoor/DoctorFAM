using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Site.OnlineVisit;

public record SelectShiftAndRedirectToBankDTO
{
    public int businessKey { get; set; }

    public ulong WorkShiftDateTimeId { get; set; }

    public ulong WorkShiftDateId { get; set; }

    public ulong UserId { get; set; }
}


public record SelectShiftAndRedirectToBankResult
{
    public SelectShiftAndRedirectToBankResultEnum Result { get; set; }

    public int OnlineVisitTariff { get; set; }
}

public enum SelectShiftAndRedirectToBankResultEnum
{
    Success,
    Faild,
    NotExistFreeTime,
    ProblemWithOnlineVisitTariff,
    UserIsNotExist
}