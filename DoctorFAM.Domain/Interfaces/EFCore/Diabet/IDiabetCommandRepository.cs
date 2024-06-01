using DoctorFAM.Domain.Entities.Diabet;

namespace DoctorFAM.Domain.Interfaces.EFCore.Diabet;

public interface IDiabetCommandRepository 
{
    Task AddAsync(DiabetPopulation patient , CancellationToken cancellationToken);
}
