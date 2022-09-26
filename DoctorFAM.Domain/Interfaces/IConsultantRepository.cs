using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Interfaces
{
    public interface IConsultantRepository
    {
        #region Consultant Panel

        //Fill Consultant Side Bar Panel
        Task<ConsultantSideBarViewModel> GetConsultantSideBarInfo(ulong userId);

        //Is Exist Any Consultant By This User Id 
        Task<bool> IsExistAnyConsultantByUserId(ulong userId);

        //Add Consultant To Data Base
        Task<ulong> AddConsultant(Consultant consultant);

        //Get Consultant By User Id
        Task<Consultant?> GetConsultantByUserId(ulong userId);

        //Get Consultant Information By User Id
        Task<ConsultantInfo?> GetConsultantInformationByUserId(ulong userId);

        //Check Is Exist Consultant Info By User ID
        Task<bool> IsExistAnyConsultantInfoByUserId(ulong userId);

        //Update Consultant Info 
        Task UpdateConsultantInfo(ConsultantInfo consultantInfo);

        //Add Consultant Info
        Task AddConsultantInfo(ConsultantInfo consultantInfo);

        //Filter Consultant Info Admin Side
        Task<ListOfConsultantInfoViewModel> FilterConsultantInfoAdminSide(ListOfConsultantInfoViewModel filter);

        #endregion

        #region Admin Side 

        //Get Consultant Info By Nurse Id
        Task<ConsultantInfo?> GetConsultantInfoByConsultantId(ulong consultantId);

        //Get Consultant By Consultant Id
        Task<Consultant?> GetConsultantById(ulong consultantId);

        //Get Consultant Info By Nurse Info Id
        Task<ConsultantInfo?> GetConsultantInfoById(ulong consultantInfoId);

        #endregion
    }
}
