using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;

public class OnlineVisitDoctorAndPatientInformationsAdminPanelSideViewModel
{
    #region properties

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public OnlineVisitPatientInformationAdminPanelSideViewModel? Patient { get; set; }

    #endregion
}

public class OnlineVisitPatientInformationAdminPanelSideViewModel
{
    #region proeprties

    public ulong UserId { get; set; }

    public string? UserAvatar { get; set; }

    public string Mobile { get; set; }

    public string Username { get; set; }

    #endregion
}
