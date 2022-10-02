using DoctorFAM.Domain.Entities.Laboratory;
using DoctorFAM.Domain.ViewModels.Laboratory.LaboratorySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface ILaboratoryRepository
    {
        #region Laboratory Side 

        //Fill Laboratory Side Bar Panel
        Task<LaboratorySideBarViewModel> GetLaboratorySideBarInfo(ulong userId);

        //Is Exist Any Laboratory By This User Id 
        Task<bool> IsExistAnyLaboratoryByUserId(ulong userId);

        //Add Laboratory To Data Base
        Task<ulong> AddLaboratory(Laboratory laboratory);

        #endregion
    }
}
