using DoctorFAM.Domain.Interfaces.EFCore.Diabet;
using DoctorFAM.Domain.ViewModels.Admin.Diabet;

namespace DoctorFAM.Application.CQRS.AdminSide.Diabet.Queries.ListOfDiabetPopulation;

public record ListOfDiabetPopulationQueryHandler : IRequestHandler<ListOfDiabetPopulationQuery, List<ListOfDiabetPopulationDTO>>
{
    private readonly IDiabetQueryRepository _diabetQueryRepository;

    public ListOfDiabetPopulationQueryHandler(IDiabetQueryRepository diabetQueryRepository)
    {
        _diabetQueryRepository = diabetQueryRepository;
    }

    public async Task<List<ListOfDiabetPopulationDTO>> Handle(ListOfDiabetPopulationQuery request, CancellationToken cancellationToken)
    {
        return await _diabetQueryRepository.ListOfDiabetPopulation(cancellationToken);
    }
}
