namespace DoctorFAM.Domain.ViewModels.DoctorPanel.DoctorsInfo;

public record ListOfDoctorsLocationDTO
{
    #region properties

    public ulong Id { get; set; }

    public string? WorkAddress { get; set; }

    public string? CountryName{ get; set; }

    public string? CityName { get; set; }

    public string? StateName { get; set; }

    #endregion
}
