using DoctorFAM.Domain.ViewModels.Site.Diabet;
namespace DoctorFAM.Application.CQRS.SiteSide.Diabet.Queries;

public record ShowDiabetPopulationModalQuery : IRequest<DiabetPopulationDTO>
{
    public ulong? UserId { get; set; }
}
