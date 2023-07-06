#region Using

using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces;

#endregion

public interface IInterestService
{
    #region Admin Side

    Task<FilterInterestAdminSideViewModel> FilterInterest(FilterInterestAdminSideViewModel filter);

    Task<CreateInterestResult> CreateInterest(CreateInterestViewModel interest);

    Task<EditInterestViewModel?> FillEditInterestViewModel(ulong interestId);

    Task<DoctorsInterest?> GetInterestById(ulong interestId);

    Task<EditInterestResult> EditInterst(EditInterestViewModel interstViewModel);

    Task<bool> DeleteInterest(ulong interestId);

    #endregion
}
