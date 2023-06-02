#region Usings

using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Interfaces.EFCore;


#endregion

namespace DoctorFAM.Data.Repository;

public class DentistRepoistory : IDentistRepoistory
{
	#region Ctor

	private readonly DoctorFAMDbContext _context;

	public DentistRepoistory(DoctorFAMDbContext context)
	{
		_context= context;
	}

	#endregion

	#region Dentist Panel 



	#endregion
}
