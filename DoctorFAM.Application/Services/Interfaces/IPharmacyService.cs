using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IPharmacyService
    {
        #region Pharmacy Panel Side

        Task AddPharmacyForFirstTime(ulong userId);

        Task<bool> IsExistAnyPharmacyByUserId(ulong userId);

        Task<Pharmacy?> GetPharmacyByUserId(ulong userId);

        Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId);

        #endregion
    }
}
