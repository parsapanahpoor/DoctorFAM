#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;

#endregion

namespace DoctorFAM.Data.Repository;

public class TourismRepository : ITourismRepository
{
    #region Ctor

    private readonly DoctorFAMDbContext _context;

    public TourismRepository(DoctorFAMDbContext context)
    {
            _context = context;
    }

    #endregion

    #region Tourism Panel 



    #endregion
}
