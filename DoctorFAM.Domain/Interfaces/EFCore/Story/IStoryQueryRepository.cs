using DoctorFAM.Domain.ViewModels.Site.Doctor;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Domain.Interfaces.EFCore.Story;

public interface IStoryQueryRepository
{
    #region Site Side 

    Task<List<DoctorVideosDTO>> FillDoctorVideosDTO(ulong userId, CancellationToken token);

    #endregion
}
