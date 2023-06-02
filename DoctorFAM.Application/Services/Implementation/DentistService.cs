#region Usings

using DoctorFAM.Domain.Interfaces.EFCore;


#endregion


namespace DoctorFAM.Application.Services.Implementation;

public class DentistService : IDentistService
{
	#region Ctor 

	private readonly IDentistRepoistory _dentistRepository;

	public DentistService(IDentistRepoistory dentistRepoistory)
	{
		_dentistRepository= dentistRepoistory;
	}

	#endregion

	#region Dentist Panel 



	#endregion
}
