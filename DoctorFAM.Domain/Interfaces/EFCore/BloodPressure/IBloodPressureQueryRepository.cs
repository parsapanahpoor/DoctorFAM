namespace DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;

public interface IBloodPressureQueryRepository
{
    Task<bool> IsExist_AnyUser_InBloodPressurePopulation_ByUserId(ulong userId);
}
