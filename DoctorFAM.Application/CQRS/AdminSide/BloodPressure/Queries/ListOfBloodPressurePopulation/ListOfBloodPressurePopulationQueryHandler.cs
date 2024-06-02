using DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;
using DoctorFAM.Domain.ViewModels.Admin.BloodPressure;

namespace DoctorFAM.Application.CQRS.AdminSide.BloodPressure.Queries.ListOfBloodPressurePopulation;

public record ListOfBloodPressurePopulationQueryHandler : IRequestHandler<ListOfBloodPressurePopulationQuery, List<ListOfBloodPressurePopulationDTO>>
{
    private readonly IBloodPressureQueryRepository _BloodPressureQueryRepository;

    public ListOfBloodPressurePopulationQueryHandler(IBloodPressureQueryRepository BloodPressureQueryRepository)
    {
        _BloodPressureQueryRepository = BloodPressureQueryRepository;
    }

    public async Task<List<ListOfBloodPressurePopulationDTO>> Handle(ListOfBloodPressurePopulationQuery request, CancellationToken cancellationToken)
    {
        return await _BloodPressureQueryRepository.ListOfBloodPressurePopulation(cancellationToken);
    }
}
