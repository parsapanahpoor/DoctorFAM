namespace DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;

public record CreateLocationDoctorPanelDTO
{
    #region propeties

    public string WorkAddress { get; set; }

    public ulong CountryId { get; set; }

    public ulong StateId { get; set; }

    public ulong CityId { get; set; }

    #endregion
}

public enum DeleteDoctorWorkAddressResult
{
    success,
    failure,
    LastRecord
}
