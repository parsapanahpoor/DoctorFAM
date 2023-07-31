#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Tourism.SiteSideBar;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class TourismService : ITourismService
{
	#region Ctor

	private readonly ITourismRepository _tourismRepository;
    private readonly IOrganizationService _organizationService;
    private readonly IWorkAddressService _workAddressService;

    public TourismService(ITourismRepository tourismRepository, IOrganizationService organizationService , WorkAddressService workAddressService)
    {
        _tourismRepository = tourismRepository;
        _organizationService = organizationService;
        _workAddressService = workAddressService;

    }

    #endregion

    #region Tourism Panel Side 

    //Is Exist Any Tourism By This User Id 
    public async Task<bool> IsExistAnyTourismByUserId(ulong userId)
    {
        return await _tourismRepository.IsExistAnyTourismByUserId(userId);
    }

    //Add Tourism For First Time Loging To Tourism Panel 
    public async Task AddTourismForFirstTime(ulong userId)
    {
        #region Tourism Entity

        #region Fill Tourism Model

        Tourism tourism = new Tourism()
        {
            UserId = userId,
            CreateDate = DateTime.Now,
            IsDelete = false,
        };

        #endregion

        #region Add Methods 

        await _tourismRepository.AddTourisms(tourism);

        #endregion

        #endregion

        #region Organization Entity

        #region Fill Organization Model

        Organization organization = new Organization()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            OrganizationInfoState = OrganizationInfoState.JustRegister,
            OrganizationType = Domain.Enums.Organization.OrganizationType.Tourism,
            OwnerId = userId,
        };

        #endregion

        #region Add Method

        var organizationId = await _organizationService.AddOrganizationWithReturnId(organization);

        #endregion

        #endregion

        #region Organization Member

        #region Fill Model 

        OrganizationMember member = new OrganizationMember()
        {
            CreateDate = DateTime.Now,
            IsDelete = false,
            OrganizationId = organizationId,
            UserId = userId
        };

        #endregion

        #region Add Organization Member

        await _organizationService.AddOrganizationMember(member);

        #endregion

        #endregion
    }

    //Fill Tourism Side Bar Panel
    public async Task<TourismSideBarViewModel> GetTourismSideBarInfo(ulong userId)
    {
        return await _tourismRepository.GetTourismSideBarInfo(userId);
    }

    #endregion

    #region Admin Side

    //Filter Tourist Info Admin Side
    public async Task<ListOfTouristInfoViewModel> FilterListOfTouristInfoViewModel(ListOfTouristInfoViewModel filter)
    {
        return await _tourismRepository.FilterListOfTouristInfoViewModel(filter);
    }

    //Get Tourist By User Id
    public async Task<Tourism?> GetTouristByUserId(ulong userId)
    {
        return await _tourismRepository.GetTouristByUserId(userId);
    }

    //Get TouristInfo Info By Tourist Id
    public async Task<TourismInfo?> GetTouristInfoByTouristId(ulong TouristId)
    {
        return await _tourismRepository.GetTouristInfoByTouristId(TouristId);
    }

    //Get Tourist By Tourist Id
    public async Task<Tourism?> GetTouristById(ulong TouristId)
    {
        return await _tourismRepository.GetTouristById(TouristId);
    }

    //Fill Tourist Info Detail ViewModel
    public async Task<TouristInfoDetailAdminSideViewModel?> FillTouristInfoDetailAdminSideViewModel(ulong touristId)
    {
        #region Get Tourist Info

        //Get Tourist Info By Id
        var info = await _tourismRepository.GetTouristInfoByTouristId(touristId);
        if (info == null) return null;

        #endregion

        #region Get Tourist Info

        var Tourist = await GetTouristById(info.TourismId);
        if (Tourist == null) return null;

        #endregion

        #region Get Current Tourist Office

        var TouristOffice = await _organizationService.GetTouristOrganizationByUserId(Tourist.UserId);
        if (TouristOffice == null) return null;
        if (TouristOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Tourism) return null;

        #endregion

        #region Fill View Model

        TouristInfoDetailAdminSideViewModel model = new TouristInfoDetailAdminSideViewModel()
        {
            UserId = Tourist.UserId,
            NationalCode = info.NationalCode,
            Education = info.Education,
            RejectDescription = TouristOffice.RejectDescription,
            TouristInfosType = TouristOffice.OrganizationInfoState,
            Id = info.Id,
            TouristId = Tourist.Id,
        };

        #endregion

        #region Get Tourist Work Addresses

        model.WorkAddresses = await _workAddressService.GetUserWorkAddressesByUserId(Tourist.UserId);

        #endregion

        return model;
    }

    //Edit Tourist Info From Admin Panel
    public async Task<EditTouristInfoResult> EditTouristInfoAdminSide(TouristInfoDetailAdminSideViewModel model)
    {
        #region Get Tourist Info By Id

        //Get Tourist Info By Id
        var info = await _tourismRepository.GetTouristInfoByTouristId(model.Id);
        if (info == null) return EditTouristInfoResult.faild;

        #endregion

        #region Get Tourist By Id 

        var Tourist = await GetTouristById(model.TouristId);
        if (Tourist == null) return EditTouristInfoResult.faild;

        #endregion

        #region Get Current Tourist Office

        var TouristOffice = await _organizationService.GetTouristOrganizationByUserId(Tourist.UserId);
        if (TouristOffice == null) return EditTouristInfoResult.faild;
        if (TouristOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Labratory) return EditTouristInfoResult.faild;

        #endregion

        #region Update Tourist 

        TouristOffice.OrganizationInfoState = model.TouristInfosType;
        TouristOffice.RejectDescription = model.RejectDescription;

        if (model.TouristInfosType == OrganizationInfoState.Accepted)
        {
            TouristOffice.RejectDescription = null;
        }

        await _organizationService.UpdateOrganization(TouristOffice);

        #endregion

        #region Edit Tourist Info 

        #region Edit Properties

        info.Education = model.Education;
        info.NationalCode = model.NationalCode;

        #endregion

        #region Update Method

        await _tourismRepository.UpdateTouristInfo(info);

        #endregion

        #endregion

        return EditTouristInfoResult.success;
    }

    #endregion

}
