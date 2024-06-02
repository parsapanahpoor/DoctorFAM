using DoctorFAM.Domain.ViewModels.Admin.Diabet;

namespace DoctorFAM.Application.CQRS.AdminSide.Diabet.Queries.ListOfDiabetPopulation;

public record ListOfDiabetPopulationQuery : IRequest<List<ListOfDiabetPopulationDTO>>;
