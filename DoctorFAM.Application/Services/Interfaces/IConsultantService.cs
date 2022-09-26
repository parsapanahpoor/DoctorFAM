using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Domain.Entities.Consultant;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.ViewModels.Admin.Consultant;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantInfo;
using DoctorFAM.Domain.ViewModels.Consultant.ConsultantSideBar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Services.Interfaces
{
    public interface IConsultantService
    {
        #region Consultant Panel Side 

        //Fill Consultant Side Bar Panel
        Task<ConsultantSideBarViewModel> GetConsultantSideBarInfo(ulong userId);

        //Is Exist Any Consultant By This User Id 
        Task<bool> IsExistAnyConsultantByUserId(ulong userId);

        //Add Consultant For First Time Loging To Consultant Panel 
        Task AddConsultantForFirstTime(ulong userId);

        //Get Consultant By User Id
        Task<Consultant?> GetConsultantByUserId(ulong userId);

        //Fill Consultant Info View Model
        Task<ManageConsultantInfoViewModel?> FillManageConsultantInfoViewModel(ulong userId);

        //Check Is Exist Consultant Info By User ID
        Task<bool> IsExistAnyConsultantInfoByUserId(ulong userId);

        //Add Or Edit Consultant Info From Consultant Panel
        Task<AddOrEditConsultantInfoResult> AddOrEditConsultantInfoNursePanel(ManageConsultantInfoViewModel model);

        //Filter Consultant Info Admin Side
        Task<ListOfConsultantInfoViewModel> FilterConsultantInfoAdminSide(ListOfConsultantInfoViewModel filter);

        #endregion

        #region Admin  Side 

        //Get Consultant Info By Nurse Id
        Task<ConsultantInfo?> GetConsultantInfoByConsultantId(ulong consultantId);

        //Get Consultant By Consultant Id
        Task<Consultant?> GetConsultantById(ulong consultantId);

        //Fill Consultant Info Detail ViewModel
        Task<ConsultantInfoDetailViewModel?> FillConsultantInfoDetailViewModel(ulong ConsultantId);

        //Edit Consultant Info From Admin Panel
        Task<EditConsultantInfoResult> EditConsultantInfoAdminSide(ConsultantInfoDetailViewModel model);

        #endregion
    }
}
