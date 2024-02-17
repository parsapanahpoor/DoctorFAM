using DoctorFAM.Domain.Entities.Story;

namespace DoctorFAM.Domain.Interfaces.EFCore.Story;

public interface IStoryCommandRepository
{
    #region General Methods

    Task AddAsync(Domain.Entities.Story.Story story, CancellationToken cancellationToken);

    #endregion
}
