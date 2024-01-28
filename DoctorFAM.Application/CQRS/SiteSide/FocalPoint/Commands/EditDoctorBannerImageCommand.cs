using Microsoft.AspNetCore.Http;
namespace DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Commands;

public class EditDoctorBannerImageCommand : IRequest<bool>
{
    public ulong UserId { get; set; }

    public IFormFile Picture { get; set; }
}
