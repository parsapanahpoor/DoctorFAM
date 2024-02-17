using DoctorFAM.Domain.ViewModels.Site.Story;
using Microsoft.AspNetCore.Http;

namespace DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Commands;

public class AddDoctorStoryCommand : IRequest<AddDoctorStoryResultDTO>
{
    public ulong DoctorUserId { get; set; }

    public string Description { get; set; }

    public IFormFile? ImageFile { get; set; }

    public IFormFile? VideoFile { get; set; }
}

public class AddDoctorStoryResultDTO
{
    public string Username { get; set; }

    public bool Result { get; set; }
}
