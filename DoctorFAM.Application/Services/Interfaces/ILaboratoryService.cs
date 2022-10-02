using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface ILaboratoryService
    {
        #region Laboratory Side 

        //Fill Laboratory Side Bar Panel
        Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId);

        //Is Exist Any Laboratory By This User Id 
        Task<bool> IsExistAnyLaboratoryByUserId(ulong userId);

        //Add Laboratory For First Time Loging To Laboratory Panel 
        Task AddLaboratoryForFirstTime(ulong userId);

        #endregion
    }
}
