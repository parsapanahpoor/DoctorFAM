using DoctorFAM.Domain.Entities.Pharmacy;
using DoctorFAM.Domain.ViewModels.Admin.Pharmacy;
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

        //Add Pharmacy Info To Data Base 
        Task AddPharmacyInfo(PharmacyInfo pharmacyInfo);

        //Add Pharmacy To Data Base 
        Task<ulong> AddPharmacy(Pharmacy pharmacy);

        //Is Exist Any Pharmacy By This Current User Id 
        Task<bool> IsExistAnyPharmacyByUserId(ulong userId);

        //Check Is Exist Any Pharmacy Information By This Current User Id
        Task<bool> IsExistAnyPharmacyInfoByUserId(ulong userId);

        //Get Pharmacy Informations By User Id
        Task<PharmacyInfo?> GetPharmacyInformationByUserId(ulong userId);

        //Update Pharmacy Personal Infomations 
        Task UpdatePharmacyInfo(PharmacyInfo pharmacyInfo);

        //Get Pharmacy By User Id 
        Task<Pharmacy?> GetPharmacyByUserId(ulong userId);

        //Get Pharmacy State And Interest For Change Styles In Pharmacy Side Bar 
        Task<PharmacySideBarViewModel> GetPharmacySideBarInfo(ulong userId);

        //Filter Pharmacys Informations In Admin Panels 
        Task<ListOfPharmacyInfoViewModel> FilterPharmacyInfoAdminSide(ListOfPharmacyInfoViewModel filter);

        #endregion
    }
}
