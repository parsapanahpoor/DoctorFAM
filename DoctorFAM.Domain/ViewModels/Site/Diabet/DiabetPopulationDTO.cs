using DoctorFAM.Domain.Enums.Gender;
using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.ViewModels.Site.Diabet;

public record DiabetPopulationDTO
{
    public ulong? UserId { get; set; }

    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Please Enter {0}")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Please Enter {0}")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please Enter {0}")]
    public string? NationalId { get; set; }

    [Required(ErrorMessage = "Please Enter {0}")]
    [RegularExpression(@"^[0-9]*$", ErrorMessage = "The information entered is not valid.")]
    public int Age { get; set; }

    public Gender Gender { get; set; }
}
