using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.DoctorPanel.OnlineVisit;

public class OnlineVisitDoctorAndPatientInformationsDoctorPanelSideViewModel
{
    #region properties

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public OnlineVisitPatientInformationDoctorPanelSideViewModel? Patient { get; set; }

    #endregion
}

public class OnlineVisitPatientInformationDoctorPanelSideViewModel
{
    #region proeprties

    public ulong UserId { get; set; }

    public string? UserAvatar { get; set; }

    public string Mobile { get; set; }

    public string Username { get; set; }

    #endregion
}
