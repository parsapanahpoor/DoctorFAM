using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.ViewModels.Pharmacy.PharmacySideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IPharmacyRepository
    {
        #region General Methods

        Task<ulong> AddPharmacy(Pharmacy pharmacy);

        Task<bool> IsExistAnyPharmacyByUserId(ulong userId);

        Task<Pharmacy?> GetPharmacyByUserId(ulong userId);

        Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId);

        #endregion
    }
}
