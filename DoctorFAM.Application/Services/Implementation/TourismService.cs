#region Usings

using DoctorFAM.Application.Services.Interfaces;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class TourismService : ITourismService
{
	#region Ctor

	private readonly ITourismService _tourismService;

    public TourismService(ITourismService tourismService)
    {
            _tourismService = tourismService;
    }

    #endregion

    #region Tourism Panel Side 



    #endregion
}
