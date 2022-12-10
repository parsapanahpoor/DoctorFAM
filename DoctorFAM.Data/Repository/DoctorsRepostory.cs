using DoctorFAM.Data.DbContext;
using DoctorFAM.DataLayer.Entities;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.FamilyDoctor.ParsaSystem;
using DoctorFAM.Domain.Entities.FamilyDoctor.VIPSystem;
using DoctorFAM.Domain.Entities.Interest;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Patient;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Doctors.DoctorsInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.DosctorSideBarInfo;
using DoctorFAM.Domain.ViewModels.DoctorPanel.Employees;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.UserPanel.FamilyDoctor;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class DoctorsRepostory : IDoctorsRepository
    {
        #region Ctor

        public DoctorFAMDbContext _context;

        public DoctorsRepostory(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Doctors Panel Side

        //Create Request Excel File For Compelete From Admin 
        public async Task CreateRequestExcelFileForCompeleteFromAdmin(RequestForUploadExcelFileFromDoctorsToSite model)
        {
            await _context.RequestForUploadExcelFileFromDoctorsToSite.AddAsync(model) ;
            await _context.SaveChangesAsync();
        }

        //Get Doctor Lable Of Sickness By Doctor User Id 
        public async Task<List<DoctorsLabelsForVIPInsertedDoctor>?> GetDoctorLableOfSicknessByDoctorUserId(ulong doctorUserId)
        {
            return await _context.DoctorsLabelsForVIPInsertedDoctor.Where(p => !p.IsDelete && p.DoctorUserId == doctorUserId).ToListAsync();
        }

        //Get List Of VIP Inserted PAtient With Label Name
        public async Task<List<VIPUserInsertedFromDoctorSystem>?> GetListOfVIPInsertedPAtientWithLabelName(ulong labelId , ulong doctorUserId)
        {
            return await _context.LabelOfVIPDoctorInsertedPatient.Include(p => p.VIPUserInsertedFromDoctorSystem)
                        .Where(p => !p.IsDelete && p.VIPUserInsertedFromDoctorSystem.DoctorUserId == doctorUserId
                                    && p.DoctorsLabelsForVIPInsertedDoctorId == labelId)
                        .Select(p => p.VIPUserInsertedFromDoctorSystem).ToListAsync();
        }

        //Add Label Of Sickness To Vip Users That Income From Doctor System  
        public async Task AddLabelOfSicknessToVipUsersThatIncomeFromDoctorSystem(LabelOfVIPDoctorInsertedPatient label)
        {
            await _context.LabelOfVIPDoctorInsertedPatient.AddAsync(label);
            await _context.SaveChangesAsync();
        }

        //Get Label Of Sickness From VIP Users
        public async Task<List<string>> GetLabelOfSicknessFromVIPUsers(ulong incomeUserId)
        {
            return await _context.LabelOfVIPDoctorInsertedPatient.Include(p=> p.DoctorsLabelsForVIPInsertedDoctor).Where(p => !p.IsDelete && p.VIPUserInsertedFromDoctorSystemId == incomeUserId)
                                .Select(p => p.DoctorsLabelsForVIPInsertedDoctor.LabelName).ToListAsync();
        }

        //Show List Of SMS That Send From Doctor To Patient Incomes From Parsa System
        public async Task<List<LogForSendSMSToUsersIncomeFromParsa>?> ShowListOfSMSThatSendFromDoctorToPatientIncomesFromParsaSystem(ulong id, ulong doctorUserId)
        {
            return await _context.LogForSendSMSToUsersIncomeFromParsa.Where(p => !p.IsDelete && p.ParsaUserId == id && p.DoctorUserId == doctorUserId).ToListAsync();
        }

        //Show List Of SMS That Send From Doctor To VIP Patient Incomes From Parsa System
        public async Task<List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem>?> ShowListOfSMSThatSendFromDoctorToVIPPatientIncomesFromParsaSystem(ulong id)
        {
            return await _context.LogForSendSMSToVIPUsersIncomeFromDoctorSystem.Where(p => !p.IsDelete && p.VIPUserInsertedFromDoctorSystemId == id).ToListAsync();
        }

        //Add Log For Send SMS From Doctor To Users That Income From Parsa System Without SaveChanges
        public async Task AddLogForSendSMSFromDoctorToUsersThatIncomeFromParsaSystemWithoutSaveChanges(List<LogForSendSMSToUsersIncomeFromParsa> log)
        {
            await _context.LogForSendSMSToUsersIncomeFromParsa.AddRangeAsync(log);
        }

        //Add Log For Send SMS From Doctor To VIP Users That Income From Parsa System Without SaveChanges
        public async Task AddLogForSendSMSFromDoctorToVIPUsersThatIncomeFromParsaSystemWithoutSaveChanges(List<LogForSendSMSToVIPUsersIncomeFromDoctorSystem> log)
        {
            await _context.LogForSendSMSToVIPUsersIncomeFromDoctorSystem.AddRangeAsync(log);
        }

        //Is Exist Any User From Parsa System In Doctor Parsa System List
        public async Task<bool> IsExistAnyUserFromParsaSystemInDoctorParsaSystemList(ulong parsaSystemUserId, ulong doctorUserId)
        {
            return await _context.UserInsertedFromParsaSystems.AnyAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.Id == parsaSystemUserId);
        }

        //Is Exist Any User From VIP Parsa System In Doctor Parsa System List
        public async Task<bool> IsExistAnyVIPUserFromParsaSystemInDoctorParsaSystemList(ulong parsaSystemUserId, ulong doctorUserId)
        {
            return await _context.VIPUserInsertedFromDoctorSystem.AnyAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.Id == parsaSystemUserId);
        }

        //List Of DOctor Parsa System Users
        public async Task<List<UserInsertedFromParsaSystem>?> ListOfDoctorParsaSystemUsers(ulong DoctorUserId)
        {
            return await _context.UserInsertedFromParsaSystems.Where(p => !p.IsDelete && p.DoctorUserId == DoctorUserId)
                                                 .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //List Of DOctor VIP Parsa System Users
        public async Task<List<VIPUserInsertedFromDoctorSystem>?> ListOfDOctorVIPParsaSystemUsers(ulong DoctorUserId)
        {
            return await _context.VIPUserInsertedFromDoctorSystem.Where(p => !p.IsDelete && p.DoctorUserId == DoctorUserId)
                                                 .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //List Of DOctor VIP Parsa System UsersWith Sickness Label Id
        public async Task<List<VIPUserInsertedFromDoctorSystem>?> ListOfDOctorVIPParsaSystemUsers(ulong DoctorUserId , ulong sicknessLabelId)
        {
            return await _context.LabelOfVIPDoctorInsertedPatient.Include(p=> p.VIPUserInsertedFromDoctorSystem)
                                .Where(p => !p.IsDelete && p.VIPUserInsertedFromDoctorSystem.DoctorUserId == DoctorUserId && p.DoctorsLabelsForVIPInsertedDoctorId == sicknessLabelId )
                                                 .OrderByDescending(p => p.VIPUserInsertedFromDoctorSystem.CreateDate).Select(p=>p.VIPUserInsertedFromDoctorSystem).ToListAsync();
        }

        //Update Parsa System Record 
        public async Task UpdateParsaSystemRecord(UserInsertedFromParsaSystem parsa)
        {
            _context.UserInsertedFromParsaSystems.Update(parsa);
            await _context.SaveChangesAsync();
        }

        //Update VIP Parsa System Record 
        public async Task UpdateVIPParsaSystemRecord(VIPUserInsertedFromDoctorSystem parsaVIP)
        {
            _context.VIPUserInsertedFromDoctorSystem.Update(parsaVIP);
            await _context.SaveChangesAsync();
        }

        //Get User From Parsa Incoming List By User Id And Doctor User Id
        public async Task<UserInsertedFromParsaSystem?> GetUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId)
        {
            return await _context.UserInsertedFromParsaSystems.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == parsaUserId && p.DoctorUserId == doctorId);
        }

        //Get VIP User From Parsa Incoming List By User Id And Doctor User Id
        public async Task<VIPUserInsertedFromDoctorSystem?> GetVIPUserFromParsaIncomingListByUserIdAndDoctorUserId(ulong doctorId, ulong parsaUserId)
        {
            return await _context.VIPUserInsertedFromDoctorSystem.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == parsaUserId && p.DoctorUserId == doctorId);
        }

        //Is Exist Any User By This Mobile Number In Current Doctor Parsa System File 
        public async Task<bool> IsExistAnyUserByThisMobileNumberInCurrentDoctorParsaSystemFile(ulong doctorUserId, string mobileNumber)
        {
            return await _context.UserInsertedFromParsaSystems.AnyAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.PatientMobile == mobileNumber);
        }

        //Is Exist Any User VIP By This Mobile Number And NationalId In Current Doctor System File 
        public async Task<bool> IsExistAnyUserVIPByThisMobileNumberAndNationalIdInCurrentDoctorSystemFile(ulong doctorUserId, string mobileNumber, string NationalId)
        {
            return await _context.VIPUserInsertedFromDoctorSystem.AnyAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.PatientMobile == mobileNumber && p.PatientNationalId == NationalId);
        }

        //Is Exist Any User VIP By This Id In Current Doctor System File 
        public async Task<bool> IsExistAnyUserVIPByThisIdInCurrentDoctorSystemFile(ulong doctorUserId, ulong vipUserId)
        {
            return await _context.VIPUserInsertedFromDoctorSystem.AnyAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.Id == vipUserId);
        }

        //Get Label By Doctor User Id And Label Name 
        public async Task<DoctorsLabelsForVIPInsertedDoctor?> GetLabelByDoctorUserIdAndLabelName(string labelName , ulong doctorUserId)
        {
            return await _context.DoctorsLabelsForVIPInsertedDoctor.FirstOrDefaultAsync(p => !p.IsDelete && p.LabelName == labelName && p.DoctorUserId == doctorUserId);
        }

        //Add New Label Of Sickness To The Existing Users 
        public async Task AddNewLabelOfSicknessToTheExistingUsers(ulong doctorUserId, string mobileNumber, string NationalId, string label)
        {
            var user = await _context.VIPUserInsertedFromDoctorSystem.FirstOrDefaultAsync(p => !p.IsDelete && p.DoctorUserId == doctorUserId && p.PatientMobile == mobileNumber && p.PatientNationalId == NationalId);

            var doctorLabel = await GetLabelByDoctorUserIdAndLabelName(label , doctorUserId);

            if (user != null)
            {
                //Add Label For This Doctor 
                if (doctorLabel == null)
                {
                    DoctorsLabelsForVIPInsertedDoctor DoctorsLabelsForVIPInsertedDoctor = new DoctorsLabelsForVIPInsertedDoctor()
                    {
                        DoctorUserId = doctorUserId,
                        LabelName = label
                    };

                    await _context.DoctorsLabelsForVIPInsertedDoctor.AddRangeAsync(DoctorsLabelsForVIPInsertedDoctor);
                    await _context.SaveChangesAsync();

                    //Add Label Of Sickness To The User 
                    LabelOfVIPDoctorInsertedPatient model = new LabelOfVIPDoctorInsertedPatient()
                    {
                        DoctorsLabelsForVIPInsertedDoctorId = DoctorsLabelsForVIPInsertedDoctor.Id,
                        VIPUserInsertedFromDoctorSystemId = user.Id
                    };

                    await _context.LabelOfVIPDoctorInsertedPatient.AddAsync(model);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    //Add Label To The User
                    if (! await _context.LabelOfVIPDoctorInsertedPatient.AnyAsync(p => !p.IsDelete && p.DoctorsLabelsForVIPInsertedDoctorId == doctorLabel.Id && p.VIPUserInsertedFromDoctorSystemId == user.Id))
                    {
                        //Add Label Of Sickness To The User 
                        LabelOfVIPDoctorInsertedPatient model = new LabelOfVIPDoctorInsertedPatient()
                        {
                            DoctorsLabelsForVIPInsertedDoctorId = doctorLabel.Id,
                            VIPUserInsertedFromDoctorSystemId = user.Id
                        };

                        await _context.LabelOfVIPDoctorInsertedPatient.AddAsync(model);
                        await _context.SaveChangesAsync();
                    }
                }
            }
        }

        //Check That Is Exist User By Mobile In User Population Covered
        public async Task<bool> CheckThatIsExistUserByMobileInUserPopulationCovered(ulong doctorUserId, string userMobile)
        {
            return await _context.UserSelectedFamilyDoctor.Include(p => p.Patient)
                                    .AnyAsync(p => p.Patient.Mobile == userMobile && !p.IsDelete && p.DoctorId == doctorUserId
                                                && p.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted);
        }

        //Check That Is User Has Any Active Family Doctor 
        public async Task<bool> CheckThatIsUserHasAnyActiveFamilyDoctor(string userMobile)
        {
            return await _context.UserSelectedFamilyDoctor.Include(p => p.Patient)
                                    .AnyAsync(p => p.Patient.Mobile == userMobile && !p.IsDelete
                                                && p.FamilyDoctorRequestState == Domain.Enums.FamilyDoctor.FamilyDoctorRequestState.Accepted);
        }

        //Save Changes
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

        //Refres Patient From User Inserts Parsa System
        public async Task RefresPatientFromUserInsertsParsaSystemWithoutSaveChanges(UserInsertedFromParsaSystem user)
        {
            _context.UserInsertedFromParsaSystems.Update(user);
        }

        //Get List Of User That Comes From Parsa That Not Register To Doctor FAM
        public async Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatNotRegisterToDoctorFAM(ulong doctorId)
        {
            return await _context.UserInsertedFromParsaSystems.Where(p => !p.IsDelete && p.DoctorUserId == doctorId && !p.IsRegisteredUser).ToListAsync();
        }

        //Get List Of User That Comes From Parsa That Registered To Doctor FAM
        public async Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsaThatRegisteredToDoctorFAM(ulong doctorId)
        {
            return await _context.UserInsertedFromParsaSystems.Where(p => !p.IsDelete && p.DoctorUserId == doctorId && p.IsRegisteredUser).ToListAsync();
        }

        //Get List Of User That Comes From Parsa
        public async Task<List<UserInsertedFromParsaSystem>> GetListOfUserThatComesFromParsa(ulong doctorId)
        {
            return await _context.UserInsertedFromParsaSystems.Where(p => !p.IsDelete && p.DoctorUserId == doctorId).ToListAsync();
        }

        //Add Range Of User From Parsa System To The Data Base
        public async Task AddRangeOfUserFromParsaSystemToTheDataBase(List<UserInsertedFromParsaSystem> list)
        {
            await _context.UserInsertedFromParsaSystems.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }

        //Add Doctor Label For Inserted VIP Users
        public async Task AddDoctorLabelForInsertedVIPUsers(DoctorsLabelsForVIPInsertedDoctor label)
        {
            await _context.DoctorsLabelsForVIPInsertedDoctor.AddAsync(label);
            await _context.SaveChangesAsync();
        }

        //Add Range Of VIP User From Parsa System To The Data Base
        public async Task TaskAddRangeOfVIPUserFromParsaSystemToTheDataBase(List<VIPUserInsertedFromDoctorSystem> list)
        {
            await _context.VIPUserInsertedFromDoctorSystem.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }

        public async Task<FilterDoctorOfficeEmployeesViewmodel> FilterDoctorOfficeEmployees(FilterDoctorOfficeEmployeesViewmodel filter)
        {
            #region Get organization 

            var doctorOffice = await _context.OrganizationMembers.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == filter.userId);
            if (doctorOffice == null) return null;

            #endregion

            var query = _context.OrganizationMembers
                .Include(p => p.User)
                .Where(s => !s.IsDelete && s.OrganizationId == doctorOffice.OrganizationId)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();


            #region Filter

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                query = query.Where(s => s.User.Username.Contains(filter.Username));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<bool> IsExistAnyDoctorByUserId(ulong userId)
        {
            return await _context.Doctors.AnyAsync(p => p.UserId == userId && !p.IsDelete);
        }

        public async Task<bool> IsExistAnyDoctorInfoByUserId(ulong userId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).AnyAsync(p => !p.IsDelete && p.Doctor.UserId == userId);
        }

        //Fill Doctor Side Bar Panel 
        public async Task<DoctorSideBarViewModel> GetDoctorsSideBarInfo(ulong userId)
        {
            #region Get Doctor Office

            var OrganitionMember = await _context.OrganizationMembers.Include(p => p.Organization)
                                                .FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId && p.Organization.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice);


            #endregion

            DoctorSideBarViewModel model = new DoctorSideBarViewModel();

            #region Doctor State 

            //If Doctor Registers Now
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.JustRegister) model.DoctorInfoState = "NewUser";

            //If Doctor State Is WatingForConfirm
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.WatingForConfirm) model.DoctorInfoState = "WatingForConfirm";

            //If Doctor State Is Rejected
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Rejected) model.DoctorInfoState = "Rejected";

            //If Doctor State Is Accepted
            if (OrganitionMember.Organization.OrganizationInfoState == OrganizationInfoState.Accepted) model.DoctorInfoState = "Accepted";

            #endregion

            #region Get Doctors Interests

            var doctor = await GetDoctorByUserId(OrganitionMember.Organization.OwnerId);

            var doctorInterest = await _context.DoctorsSelectedInterests.Include(p => p.Interest).ThenInclude(p => p.InterestInfo).Where(p => !p.IsDelete && p.DoctorId == doctor.Id).ToListAsync();

            if (doctorInterest != null && doctorInterest.Any())
            {
                //Doctor Has HomeVisit Interest
                if (doctorInterest.Any(p => p.InterestId == 2)) model.HomeVisit = true;

                //Doctor Has Death Certificate Interest
                if (doctorInterest.Any(p => p.InterestId == 4)) model.DeathCertificate = true;

                //Doctor Has Family Doctor Interests
                if (doctorInterest.Any(p => p.InterestId == 3)) model.DoctorFamily = true;

                //Doctor Has Online Visit Interest
                if (doctorInterest.Any(p => p.InterestId == 1)) model.OnlineVisit = true;
            }

            #endregion

            return model;
        }

        public async Task<DoctorsInfo?> GetDoctorsInformationByUserId(ulong userId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).FirstOrDefaultAsync(p => p.Doctor.UserId == userId && !p.IsDelete);
        }

        public async Task UpdateDoctorsInfo(DoctorsInfo doctorsInfo)
        {
            _context.DoctorsInfos.Update(doctorsInfo);
            await _context.SaveChangesAsync();
        }

        //Get List Of Doctor Skills By Doctor Id
        public async Task<List<DoctorsSkils>> GetListOfDoctorSkillsByDoctorId(ulong doctorId)
        {
            return await _context.DoctorSkill.Where(p => p.DoctorId == doctorId && !p.IsDelete).ToListAsync();
        }

        //Add Doctor Selected Skils Without Save Changes
        public async Task AddDoctorSelectedSkilsWithoutSaveChanges(DoctorsSkils doctorsSkils)
        {
            await _context.DoctorSkill.AddAsync(doctorsSkils);
        }

        //Remove Doctor Skills
        public async Task RemoveDoctorSkills(List<DoctorsSkils> doctorSkill)
        {
            _context.DoctorSkill.RemoveRange(doctorSkill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDoctorState(Doctor doctor)
        {
            _context.Doctors.Update(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task AddDoctorsInfo(DoctorsInfo doctorsInfo)
        {
            await _context.DoctorsInfos.AddAsync(doctorsInfo);
            await _context.SaveChangesAsync();
        }

        public async Task<Doctor?> GetDoctorByUserId(ulong userId)
        {
            return await _context.Doctors.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == userId);
        }

        public async Task<Doctor?> GetDoctorById(ulong doctorId)
        {
            return await _context.Doctors.Include(p => p.User).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == doctorId);
        }

        public async Task<ulong> AddDoctor(Doctor doctor)
        {
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();

            return doctor.Id;
        }

        public async Task<List<DoctorsInterestInfo>> GetDoctorInterestsInfo()
        {
            return await _context.InterestInfos.Include(p => p.Interest).Where(p => !p.IsDelete).ToListAsync();
        }

        public async Task<List<DoctorsInterestInfo>> GetDoctorSelectedInterests(ulong doctorId)
        {
            var interest = await _context.DoctorsSelectedInterests.Include(p => p.Interest).ThenInclude(p => p.InterestInfo)
                                .Where(p => !p.IsDelete && p.DoctorId == doctorId).Select(p => p.Interest).ToListAsync();

            List<DoctorsInterestInfo> model = new List<DoctorsInterestInfo>();

            foreach (var item in interest)
            {
                foreach (var interestInfo in await _context.InterestInfos.Where(p => !p.IsDelete && p.InterestId == item.Id).ToListAsync())
                {
                    model.Add(interestInfo);
                }
            }

            return model;
        }

        public async Task AddDoctorSelectedInterest(DoctorsSelectedInterests doctorsSelectedInterests)
        {
            await _context.DoctorsSelectedInterests.AddAsync(doctorsSelectedInterests);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsExistInterestForDoctor(ulong interestId, ulong doctorId)
        {
            return await _context.DoctorsSelectedInterests.AnyAsync(p => !p.IsDelete && p.DoctorId == doctorId && p.InterestId == interestId);
        }

        public async Task<bool> IsExistInterestById(ulong interestId)
        {
            return await _context.Interests.AnyAsync(p => !p.IsDelete && p.Id == interestId);
        }

        public async Task DeleteDoctoreSelectedInterest(DoctorsSelectedInterests item)
        {
            _context.DoctorsSelectedInterests.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<DoctorsSelectedInterests?> GetDoctorSelectedInterestByDoctorIdAndInetestId(ulong interestId, ulong doctorId)
        {
            return await _context.DoctorsSelectedInterests.FirstOrDefaultAsync(p => !p.IsDelete && p.InterestId == interestId &&
            p.DoctorId == doctorId);
        }

        public async Task<DoctorsSelectedInterests?> GetDoctorSelectedInterestByDoctorIdAndInterestId(ulong interestId, ulong doctorId)
        {
            return await _context.DoctorsSelectedInterests.FirstOrDefaultAsync(p => p.InterestId == interestId && p.DoctorId == doctorId && !p.IsDelete);
        }

        #endregion

        #region Admin Side

        //Get Lastest Request For Uplaod Excel File
        public async Task<List<RequestForUploadExcelFileFromDoctorsToSite>> GetLastestRequestForUplaodExcelFile()
        {
            return await _context.RequestForUploadExcelFileFromDoctorsToSite.Where(p => !p.IsDelete)
                            .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        public async Task<ListOfDoctorsInfoViewModel> FilterDoctorsInfoAdminSide(ListOfDoctorsInfoViewModel filter)
        {
            var query = _context.Organizations
                .Where(s => !s.IsDelete && s.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice)
                .Include(p => p.User)
                .OrderByDescending(s => s.CreateDate)
                .AsQueryable();

            #region State

            switch (filter.DoctorsState)
            {
                case DoctorsState.All:
                    break;

                case DoctorsState.Accepted:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Accepted);
                    break;

                case DoctorsState.WaitingForConfirm:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.WatingForConfirm);
                    break;

                case DoctorsState.Rejected:
                    query = query.Where(p => p.OrganizationInfoState == OrganizationInfoState.Rejected);
                    break;
            }

            #endregion

            #region Filter

            if (!string.IsNullOrEmpty(filter.Email))
            {
                query = query.Where(s => EF.Functions.Like(s.User.Email, $"%{filter.Email}%"));
            }

            if (!string.IsNullOrEmpty(filter.Mobile))
            {
                query = query.Where(s => s.User.Mobile != null && EF.Functions.Like(s.User.Mobile, $"%{filter.Mobile}%"));
            }

            if (!string.IsNullOrEmpty(filter.FullName))
            {
                query = query.Where(s => s.User.Username.Contains(filter.FullName));
            }

            if (!string.IsNullOrEmpty(filter.NationalCode))
            {
                query = query.Where(s => s.User.NationalId.Contains(filter.NationalCode));
            }

            #endregion

            await filter.Paging(query);

            return filter;
        }

        public async Task<DoctorsInfo?> GetDoctorsInfoById(ulong doctorInfoId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).FirstOrDefaultAsync(p => !p.IsDelete && p.Id == doctorInfoId);
        }

        public async Task<DoctorsInfo?> GetDoctorsInfoByDoctorId(ulong doctorId)
        {
            return await _context.DoctorsInfos.Include(p => p.Doctor).FirstOrDefaultAsync(p => !p.IsDelete && p.DoctorId == doctorId);
        }

        #endregion

        #region Site Side 

        //Get List Of All Doctors
        public async Task<List<ListOfAllDoctorsViewModel>> ListOfDoctors()
        {
            //Get List Of Doctors
            var doctors = await _context.Doctors.Include(p => p.User).Include(p => p.DoctorsInfos)
                .Where(p => !p.IsDelete).ToListAsync();

            List<ListOfAllDoctorsViewModel> model = new List<ListOfAllDoctorsViewModel>();

            foreach (var item in doctors)
            {
                if (await _context.Organizations.AnyAsync(p => !p.IsDelete && p.OrganizationType == Domain.Enums.Organization.OrganizationType.DoctorOffice
                                                                        && p.OrganizationInfoState == OrganizationInfoState.Accepted && p.OwnerId == item.UserId))
                {
                    ListOfAllDoctorsViewModel modelChild = new ListOfAllDoctorsViewModel()
                    {
                        UserId = item.UserId,
                        Username = item.User.Username,
                        UserAvatar = item.User.Avatar,
                        Education = item.DoctorsInfos.Education,
                        Specialist = item.DoctorsInfos.Specialty,
                        ClinicPhone = item.DoctorsInfos.ClinicPhone,
                        GeneralPhone = item.DoctorsInfos.GeneralPhone
                    };

                    model.Add(modelChild);
                }
            }

            return model;
        }

        #endregion

        #region User Panel Side 

        //Get List Of Doctors With Family Doctor Interests
        public async Task<List<Doctor>?> FilterFamilyDoctorUserPanelSide(FilterFamilyDoctorUserPanelSideViewModel filter)
        {
            var query = await _context.DoctorsSelectedInterests
                    .Include(p => p.Doctor)
                    .ThenInclude(p => p.DoctorsInfos)
                    .Include(p => p.Doctor)
                    .ThenInclude(p => p.User)
                    .Where(s => !s.IsDelete && s.InterestId == 3)
                    .OrderByDescending(s => s.CreateDate)
                    .Select(p => p.Doctor)
                    .ToListAsync();

            var model = new List<Doctor>();

            foreach (var item in query)
            {
                if (await _context.Organizations.FirstOrDefaultAsync(p => !p.IsDelete && p.OwnerId == item.UserId && p.OrganizationInfoState == OrganizationInfoState.Accepted) != null)
                {
                    model.Add(item);
                }
            }

            #region Filter

            if (filter.Gender.HasValue)
            {
                if (filter.Gender.Value == 0)
                {
                    model = model.Where(p => !p.IsDelete && p.DoctorsInfos.Gender == Domain.Enums.Gender.Gender.Male).ToList();
                }
                if (filter.Gender.Value == 1)
                {
                    model = model.Where(p => !p.IsDelete && p.DoctorsInfos.Gender == Domain.Enums.Gender.Gender.Female).ToList();
                }
            }

            if (!string.IsNullOrEmpty(filter.Username))
            {
                model = model.Where(s => s.User.Username.Contains(filter.Username)).ToList();
            }

            if (filter.CountryId.HasValue)
            {
                List<Doctor?> CountryModel = new List<Doctor?>();

                foreach (var item in model.Select(p => p.UserId))
                {
                    var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CountryId == filter.CountryId.Value);

                    if (address != null)
                    {
                        CountryModel.Add(await _context.DoctorsSelectedInterests
                                             .Include(p => p.Doctor).ThenInclude(p => p.User)
                                                .Where(s => !s.IsDelete && s.Doctor.UserId == address.UserId).Select(p => p.Doctor).FirstOrDefaultAsync());
                    }
                }

                model = CountryModel;
            }

            if (filter.StateId.HasValue)
            {
                List<Doctor?> StateModel = new List<Doctor?>();

                foreach (var item in query.Select(p => p.UserId))
                {
                    var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.StateId == filter.StateId.Value);

                    if (address != null)
                    {
                        StateModel.Add(await _context.DoctorsSelectedInterests
                                             .Include(p => p.Doctor).ThenInclude(p => p.User)
                                                .Where(s => !s.IsDelete && s.Doctor.UserId == address.UserId).Select(p => p.Doctor).FirstOrDefaultAsync());
                    }
                }

                model = StateModel;
            }

            if (filter.CityId.HasValue)
            {
                List<Doctor?> CityModel = new List<Doctor?>();

                foreach (var item in query.Select(p => p.UserId))
                {
                    var address = await _context.WorkAddresses.FirstOrDefaultAsync(p => !p.IsDelete && p.UserId == item && p.CityId == filter.CityId.Value);

                    if (address != null)
                    {
                        CityModel.Add(await _context.DoctorsSelectedInterests
                                             .Include(p => p.Doctor).ThenInclude(p => p.User)
                                                .Where(s => !s.IsDelete && s.Doctor.UserId == address.UserId).Select(p => p.Doctor).FirstOrDefaultAsync());
                    }
                }

                model = CityModel;
            }

            #endregion

            return model;
        }



        #endregion
    }
}
