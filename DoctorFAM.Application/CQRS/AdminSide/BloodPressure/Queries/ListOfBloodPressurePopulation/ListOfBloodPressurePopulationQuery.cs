using DoctorFAM.Domain.ViewModels.Admin.BloodPressure;

namespace DoctorFAM.Application.CQRS.AdminSide.BloodPressure.Queries.ListOfBloodPressurePopulation;

public record ListOfBloodPressurePopulationQuery : IRequest<List<ListOfBloodPressurePopulationDTO>>;
