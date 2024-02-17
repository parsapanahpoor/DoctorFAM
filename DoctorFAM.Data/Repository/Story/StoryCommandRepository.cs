using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore.Story;

namespace DoctorFAM.Data.Repository.Story;

public class StoryCommandRepository : CommandGenericRepository<DoctorFAM.Domain.Entities.Story.Story>, IStoryCommandRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public StoryCommandRepository(DoctorFAMDbContext context) : base(context)
    {
        _context = context;
    }

    #endregion
}
