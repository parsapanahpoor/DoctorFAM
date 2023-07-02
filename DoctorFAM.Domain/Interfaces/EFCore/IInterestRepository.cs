#region Using

using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.ViewModels.Admin.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces.EFCore;

#endregion

public interface IInterestRepository 
{
    #region Admin Side

    Task<FilterInterestAdminSideViewModel> FilterInterest(FilterInterestAdminSideViewModel filter);

    //Add Interest To The Data Base 
    Task<ulong> AddInterestToTheDataBase(DoctorsInterest interest);

    //Add Interest Info
    Task AddInterestInfo(List<DoctorsInterestInfo> interestInfo);

    Task<EditInterestViewModel?> FillEditInterestViewModel(ulong interestId);

    Task<DoctorsInterest?> GetInterestById(ulong interestId);

    void UpdateInterestInfoWithoutSaveChanges(DoctorsInterestInfo interestInfo);

    //Save Changes
    Task SaveChanges();

    Task DeleteInterest(DoctorsInterest interest);

    #endregion
}
