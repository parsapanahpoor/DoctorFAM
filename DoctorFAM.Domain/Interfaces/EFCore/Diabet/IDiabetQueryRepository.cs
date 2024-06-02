using DoctorFAM.Domain.ViewModels.Admin.Diabet;

namespace DoctorFAM.Domain.Interfaces.EFCore.Diabet;

public interface IDiabetQueryRepository
{
    Task<bool> IsExist_AnyUser_InDiabetPopulation_ByUserId(ulong userId);

    Task<List<ListOfDiabetPopulationDTO>> ListOfDiabetPopulation(CancellationToken cancellationToken);
}
