using DoctorFAM.Domain.ViewModels.Site.Specialists;

namespace DoctorFAM.Application.CQRS.SiteSide.Specialists.Queriesl;

public record FiltreDoctorsQuery : IRequest<List<DoctorInfo>>
{
    public FilterDoctorsDTO? FilterDoctorsDTO { get; set; }
}
