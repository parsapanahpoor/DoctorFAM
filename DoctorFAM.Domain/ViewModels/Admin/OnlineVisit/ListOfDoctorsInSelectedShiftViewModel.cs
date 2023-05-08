using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.ViewModels.Admin.OnlineVisit;

public class ListOfDoctorsInSelectedShiftAdminSideViewModel
{
    #region properties

    public ulong DoctorReservationDateId { get; set; }

    public ulong WorkShiftId { get; set; }

    public string? WorkShiftInfo { get; set; }

    public DateTime? SelectedDateTime { get; set; }

    public DoctorsInfosInSelectedShiftAdminSide? DoctorUser { get; set; }

    public int CountOfReservedTimes { get; set; }

    public int CountOfFressTimes { get; set; }

    public int CountOFAllTimes { get; set; }

    #endregion
}


public class DoctorsInfosInSelectedShiftAdminSide
{
    #region properties

    public ulong UserId { get; set; }

    public string? UserAvatar { get; set; }

    public string Username { get; set; }

    public string Mobile { get; set; }

    #endregion
}