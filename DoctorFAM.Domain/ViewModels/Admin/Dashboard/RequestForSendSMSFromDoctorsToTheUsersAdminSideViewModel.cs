using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.Dashboard;

public class RequestForSendSMSFromDoctorsToTheUsersAdminSideViewModel
{
    #region properties

    public int CountOfSMS { get; set; }

    public ulong RequestId { get; set; }

    public DateTime CreateDate { get; set; }

    public DoctorUserInfoForShow DoctorUserInfoForShow { get; set; }

    #endregion
}

public class DoctorUserInfoForShow
{
    public string Username { get; set; }

    public string Mobile { get; set; }

    public string UserAvatar { get; set; }
}

