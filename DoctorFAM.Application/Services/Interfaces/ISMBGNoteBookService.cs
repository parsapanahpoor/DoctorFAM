using DoctorFAM.Domain.Enums.SMBG;
using DoctorFAM.Domain.ViewModels.Site.Diabet.SMBG_NoteBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ISMBGNoteBookService
    {
        #region Admin Side 

        //Fill Log For Usage Insulin Site Side View Model
        Task<LogForUsageInsulinSiteSideViewModel?> LogForUsageInsulinSiteSideViewModel(ulong userId, TimeOfUsageInsulinState timeOfUsageInsulinState);

        //Calculate Log Users A1C 
        Task<bool> CalculateLogUsersA1C(decimal a1c, ulong userId);

        //Fill List Of User A1C Site Side View Model 
        Task<List<ListOfUserA1CSiteSideViewModel>?> FillListOfUserA1CSiteSideViewModel(ulong userId);

        //Calculate Log For Long Effect Insulin Usage 
        Task<bool> CalculateLogForLongEffectInsulinUsage(ulong insulinId, int countOfUsage, ulong userId);

        //Add Usage Insulin Data To The Data Base
        Task<bool> AddUsageInsulinDataToTheDataBase(LogForUsageInsulinSiteSideViewModel model);

        //Fill Index SMBG Page View Model
        Task<IndexSMBGPageViewModel> FillIndexSMBGPageViewModel(ulong userId);

        #endregion
    }
}
