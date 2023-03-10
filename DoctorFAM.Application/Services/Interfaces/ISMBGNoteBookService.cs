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

        //Calculate Log Users A1C 
        Task<bool> CalculateLogUsersA1C(decimal a1c, ulong userId);

        //Fill Index SMBG Page View Model
        Task<IndexSMBGPageViewModel> FillIndexSMBGPageViewModel(ulong userId);

        #endregion
    }
}
