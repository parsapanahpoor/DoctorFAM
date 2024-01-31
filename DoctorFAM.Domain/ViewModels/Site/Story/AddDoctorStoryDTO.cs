using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Domain.ViewModels.Site.Story;

public record AddDoctorStoryDTO
{
    #region properties

    public string Description{ get; set; }

    public IFormFile StoryFile { get; set; }

    #endregion
}
