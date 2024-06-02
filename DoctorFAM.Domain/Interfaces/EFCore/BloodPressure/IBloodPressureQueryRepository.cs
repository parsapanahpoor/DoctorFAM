using DoctorFAM.Domain.ViewModels.Admin.BloodPressure;

namespace DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;

public interface IBloodPressureQueryRepository
{
    Task<bool> IsExist_AnyUser_InBloodPressurePopulation_ByUserId(ulong userId);
    Task<List<ListOfBloodPressurePopulationDTO>> ListOfBloodPressurePopulation(CancellationToken cancellationToken);
}
