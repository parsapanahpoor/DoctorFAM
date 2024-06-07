using DoctorFAM.Application.CQRS.SiteSide.Specialists.Queriesl;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Specialists;

namespace DoctorFAM.Application.CQRS.SiteSide.Specialists.Queries;

public record FiltreDoctorsQueryHandler : IRequestHandler<FiltreDoctorsQuery, List<DoctorInfo>>
{
    #region Ctor

    private readonly IDoctorsRepository _doctorRepository;

    public FiltreDoctorsQueryHandler(IDoctorsRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    #endregion

    public async Task<List<DoctorInfo>?> Handle(FiltreDoctorsQuery request, CancellationToken cancellationToken)
    {
        return await _doctorRepository.FilterDoctorsSiteSide(request.FilterDoctorsDTO , cancellationToken);
    }
}
