using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Domain.ViewModels.Site.Story;

public record AddDoctorStoryDTO
{
    #region properties

    public string Description{ get; set; }

    public IFormFile? ImageFile { get; set; }

    public IFormFile? VideoFile { get; set; }

    #endregion
}
