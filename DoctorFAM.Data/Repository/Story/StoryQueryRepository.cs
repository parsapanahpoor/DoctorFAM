using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.Story;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Data.Repository.Story;

public class StoryQueryRepository : QueryGenericRepository<DoctorFAM.Domain.Entities.Story.Story>, IStoryQueryRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public StoryQueryRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion

    #region Site Side 

    public async Task<List<DoctorVideosDTO>> FillDoctorVideosDTO(ulong userId , CancellationToken token)
    {
        return await _context.Stories
                             .AsNoTracking()
                             .Where(p => !p.IsDelete &&
                                    p.UserId == userId)
                             .Select(p => new DoctorVideosDTO()
                             {
                                 CreateDate = p.CreateDate,
                                 Id = p.Id,
                                 VideoBanner = p.File,
                                 Description = p.Description,
                                 IsStory = true
                             })
                             .ToListAsync();
    }

    #endregion
}
