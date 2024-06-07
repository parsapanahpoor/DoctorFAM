#region Usings

using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Enums.DoctorTitleName;
using DoctorFAM.Domain.Enums.Gender;
using DoctorFAM.Domain.ViewModels.Common;

namespace DoctorFAM.Domain.ViewModels.Site.Specialists;

#endregion

public class ListOfSpecialistsSiteSideViewModel
{
	#region properties

	public DoctorSpecialistUserInfoViewModel? DoctorUserInfo { get; set; }

	#endregion
}

public class DoctorSpecialistUserInfoViewModel
{
	#region properties

	public ulong UserId { get; set; }

	public string Username { get; set; }

	public string UserAvatar { get; set; }

    public string? CityName { get; set; }

    public DoctorTilteName DoctorTilteName { get; set; }

    public DoctorsInfo doctorsInfo { get; set; }

    public int DoctorStars { get; set; }

    #endregion
}

public class ListOfDoctorIdAndDoctorUserId
{
    public ulong DoctorUserId{ get; set; }
    public ulong DoctorId { get; set; }
}

public class FilterSpecialistDoctorsSiteSideViewModel : BasePaging<Specialist>
{
    #region properties

    public ulong? CountryId { get; set; }

    public ulong? StateId { get; set; }

    public ulong? CityId { get; set; }

    public string? Username { get; set; }

    public int? Gender { get; set; }

    public ulong? GeneralSpecialityId { get; set; }

    public bool? IsContactPartyWithFamilyDoctors { get; set; }

    public ulong? specificId { get; set; }

    #endregion
}

public class Specialist
{
    #region properties

    public ulong UserId { get; set; }

    public ulong DoctorId { get; set; }

    public string Username { get; set; }

    public string? UserAvatar { get; set; }

    public string? SpecialityName { get; set; }

    public bool PartyToTheContractWithTheFamilyDoctor { get; set; }

    public Gender Gender { get; set; }

    public string? Specialty { get; set; }

    public string? Education { get; set; }

    public DoctorTilteName DoctorTitleName { get; set; }

    #endregion
}
