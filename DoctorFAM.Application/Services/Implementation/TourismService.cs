#region Usings

using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Migrations;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Tourism;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Tourist;
using DoctorFAM.Domain.ViewModels.Tourism.SiteSideBar;
using DoctorFAM.Domain.ViewModels.Tourism.TouristInfo;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class TourismService : ITourismService
{
	#region Ctor

	private readonly ITourismRepository _tourismRepository;
    private readonly IOrganizationService _organizationService;
    private readonly IWorkAddressService _workAddressService;
    private readonly IUserService _userService;

    public TourismService(ITourismRepository tourismRepository, IOrganizationService organizationService , WorkAddressService workAddressService
                            , IUserService userService)
    {
        _tourismRepository = tourismRepository;
        _organizationService = organizationService;
        _workAddressService = workAddressService;
        _userService = userService;
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

    //Is Exist Any Tourist By This User Id 
    public async Task<bool> IsExistAnyTouristByUserId(ulong userId)
    {
        return await _tourismRepository.IsExistAnyTouristByUserId(userId);
    }

    //Get Tourist Information By User Id
    public async Task<TourismInfo?> GetTouristInformationByUserId(ulong userId)
    {
        return await _tourismRepository.GetTouristInformationByUserId(userId);
    }

    //Fill Tourist Info View Model
    public async Task<ManageTouristInfoViewModel?> FillManageTouristInfoViewModel(ulong userId)
    {
        #region Check Is User Exist 

        var user = await _userService.GetUserById(userId);
        if (user == null) return null;

        #endregion

        #region Get Current Tourist Office

        var touristOffice = await _organizationService.GetTouristOrganizationByUserId(userId);
        if (touristOffice == null) return null;
        if (touristOffice.OrganizationType != Domain.Enums.Organization.OrganizationType.Tourism) return null;

        #endregion

        #region Get User Office Address

        var workAddress = await _workAddressService.GetUserWorkAddressById(userId);

        #endregion

        #region Exist Tourist Information

        //Is Exist Tourist Informations
        if (await IsExistAnyTouristByUserId(userId))
        {
            //Get Current Consultant Information
            var consultantInfo = await GetTouristInformationByUserId(userId);

            //Fill Model For return Value
            ManageTouristInfoViewModel model = new ManageTouristInfoViewModel()
            {
                UserId = userId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                TouristInfosType = touristOffice.OrganizationInfoState,
                Education = ((consultantInfo != null) ? consultantInfo.Education : null),
                NationalCode = ((consultantInfo != null) ? consultantInfo.NationalCode : "0"),
                RejectDescription = touristOffice.RejectDescription
            };

            //Fill Consultant Address
            if (workAddress != null)
            {
                model.WorkAddress = workAddress.Address;
                model.CountryId = workAddress.CountryId;
                model.StateId = workAddress.StateId;
                model.CityId = workAddress.CityId;
            }

            return model;
        }

        #endregion

        #region Not Exist Consultant Information

        else
        {
            //This Is First Time For Come in To This Action 
            ManageTouristInfoViewModel model = new ManageTouristInfoViewModel()
            {
                UserId = userId
            };

            return model;
        }

        #endregion

        return null;
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
