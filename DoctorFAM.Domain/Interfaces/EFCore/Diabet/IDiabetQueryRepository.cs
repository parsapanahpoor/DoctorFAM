namespace DoctorFAM.Domain.Interfaces.EFCore.Diabet;

public interface IDiabetQueryRepository
{
    Task<bool> IsExist_AnyUser_InDiabetPopulation_ByUserId(ulong userId);
}
