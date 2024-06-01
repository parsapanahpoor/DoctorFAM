using DoctorFAM.Domain.Entities.BloodPressure;
using DoctorFAM.Domain.Entities.Diabet;

namespace DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;

public interface IBloodPressureCommandRepository
{
    Task AddAsync(BloodPressurePopulation bloodPressure, CancellationToken cancellationToken);
}
