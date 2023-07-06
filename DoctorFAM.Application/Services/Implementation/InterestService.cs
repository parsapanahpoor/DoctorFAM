#region Using

using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Admin.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Location;

namespace DoctorFAM.Application.Services.Implementation;

#endregion

public class InterestService : IInterestService
{
    #region Ctor

    private readonly IInterestRepository _interestRepository;

    public InterestService(IInterestRepository interestRepository)
    {
            _interestRepository = interestRepository;
    }

    #endregion

    #region Admin Side 

    public async Task<FilterInterestAdminSideViewModel> FilterInterest(FilterInterestAdminSideViewModel filter)
    {
        return await _interestRepository.FilterInterest(filter);
    }

    public async Task<CreateInterestResult> CreateInterest(CreateInterestViewModel interest)
    {
        #region Add Interest

        var mainInterest = new DoctorsInterest()
        {
            IsDelete = false,
            DoctorPanelSide = interest.DoctorPanel,
            ConsultantPanelSide = interest.ConsultantPanel,
        };

        var interestId = await _interestRepository.AddInterestToTheDataBase(mainInterest);

        #endregion

        #region Add InterestInfo

        var interestInfo = new List<DoctorsInterestInfo>();

        foreach (var culture in interest.InterestInfo)
        {
            var interestInfos = new DoctorsInterestInfo
            {
                InterestId = interestId,
                LanguageId = culture.Culture,
                Title = culture.Title.SanitizeText(),
                CreateDate = DateTime.Now,
            };

            interestInfo.Add(interestInfos);
        }

        await _interestRepository.AddInterestInfo(interestInfo);

        #endregion

        return CreateInterestResult.Success;
    }

    public async Task<EditInterestViewModel?> FillEditInterestViewModel(ulong interestId)
    {
        return await _interestRepository.FillEditInterestViewModel(interestId);
    }

    public async Task<DoctorsInterest?> GetInterestById(ulong interestId)
    {
        return await _interestRepository.GetInterestById(interestId);
    }

    public async Task<EditInterestResult> EditInterst(EditInterestViewModel interstViewModel)
    {
        #region Get Interest By Id

        var interest = await _interestRepository.GetInterestById(interstViewModel.Id);

        if (interest == null) return EditInterestResult.Fail;

        #endregion

        #region Update Interest

        interest.DoctorPanelSide = interstViewModel.DoctorPanelSide;
        interest.ConsultantPanelSide = interstViewModel.ConsultantPanelSide;

        //Update Method
        _interestRepository.UpdateInterestWithoutSavechanges(interest);

        #endregion

        #region Interest Info

        foreach (var interestInfo in interest.InterestInfo)
        {
            var updatedInfo = interstViewModel.InterestInfo.FirstOrDefault(p => p.Culture == interestInfo.LanguageId);

            if (updatedInfo != null)
            {
                interestInfo.Title = updatedInfo.Title.SanitizeText();
            }

            _interestRepository.UpdateInterestInfoWithoutSaveChanges(interestInfo);
        }

        #endregion

        await _interestRepository.SaveChanges();

        return EditInterestResult.Success;
    }

    public async Task<bool> DeleteInterest(ulong interestId)
    {
        //Get Interest By Id
        var interest = await _interestRepository.GetInterestById(interestId);
        if (interest == null) return false;

        //Delete Interest and Interest Info 
        await _interestRepository.DeleteInterest(interest);

        return true;
    }

    #endregion
}
