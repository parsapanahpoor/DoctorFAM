using DoctorFAM.Domain.Enums.Gender;

namespace DoctorFAM.Domain.ViewModels.Admin.BloodPressure;

public record ListOfBloodPressurePopulationDTO
{
    public BloodPressureianPersonDTO? Person { get; set; }

    public int Age { get; set; }

    public Gender Gender { get; set; }
}

public record BloodPressureianPersonDTO
{
    public ulong UserId { get; set; }

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    public string? NationalId { get; set; }
}