using DoctorFAM.Domain.Enums.Gender;

namespace DoctorFAM.Domain.ViewModels.Admin.Diabet;

public record ListOfDiabetPopulationDTO
{
    public DiabetianPersonDTO? Person { get; set; }

    public int Age { get; set; }

    public Gender Gender { get; set; }
}

public record DiabetianPersonDTO
{
    public ulong UserId { get; set; }

    public string? Username { get; set; }

    public string? Mobile { get; set; }

    public string? NationalId { get; set; }
}