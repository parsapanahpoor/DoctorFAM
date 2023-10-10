namespace DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;

public record DoctorsReservationTariffDoctorPanelSideViewModel
{
    #region properties

    public ulong DoctorUserId { get; set; }

    public int InPersonReservationTariffForDoctorPopulationCovered { get; set; }

    public int OnlineReservationTariffForDoctorPopulationCovered { get; set; }

    public int InPersonReservationTariffForAnonymousPersons { get; set; }

    public int OnlineReservationTariffForAnonymousPersons { get; set; }

    public string? DoctorReservationAlert { get; set; }

    #endregion
}

public enum DoctorsReservationTariffDoctorPanelSideViewModelResult
{
    success,
    failure,
    InpersonReservationPopluationCoveredLessThanSiteShare,
    OnlineReservationPopluationCoveredLessThanSiteShare,
    InpersonReservationAnonymousePersoneLessThanSiteShare,
    OnlineReservationAnonymousePersoneLessThanSiteShare
}
