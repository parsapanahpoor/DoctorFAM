using DoctorFAM.Domain.ViewModels.Site.BloodPressure;

namespace DoctorFAM.Application.CQRS.SiteSide.BloodPressure.Query;

public record ShowBloodPressurePopulationModalQuery : IRequest<BloodPressurePopulationDTO>
{
    public ulong? UserId { get; set; }
}
