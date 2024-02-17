using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.WorkAddress;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Doctor;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Certificate;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Education;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Gallery;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Honor;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.Service;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkHistory;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume.WorkingAddress;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.Interfaces.EFCore.Story;

namespace DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Queries.DoctorPage;

public record ShowDoctorInfoQueryHandler : IRequestHandler<ShowDoctorInfoQuery, DoctorPageInReservationViewModel>
{
    #region Ctor

    private readonly IDoctorsRepository _doctorsRepository;
    private readonly IOrganizationRepository _organizationRepository;
    private readonly IWorkAddressRepository _workAddressRepository;
    private readonly ILocationRepository _locationRepository;
    private readonly IResumeService _resumeService;
    private readonly IResumeRepository _resumeRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHealthInformationRepository _healthInformationRepository;
    private readonly IStoryQueryRepository _storyQueryRepository;

    public ShowDoctorInfoQueryHandler(IDoctorsRepository doctorsRepository ,
                                      IOrganizationRepository organizationRepository ,
                                      IWorkAddressRepository workAddressRepository ,
                                      ILocationRepository locationRepository ,
                                      IResumeService resumeService , 
                                      IUserRepository userRepository ,
                                      IResumeRepository resumeRepository ,
                                      IHealthInformationRepository healthInformationRepository , 
                                      IStoryQueryRepository storyQueryRepository)
    {
        _doctorsRepository = doctorsRepository;
        _storyQueryRepository = storyQueryRepository;
        _healthInformationRepository = healthInformationRepository;
        _organizationRepository = organizationRepository;
        _workAddressRepository = workAddressRepository;
        _locationRepository = locationRepository;
        _resumeService = resumeService;
        _userRepository = userRepository;
        _resumeRepository = resumeRepository;
    }

    #endregion

    public async Task<DoctorPageInReservationViewModel?> Handle(ShowDoctorInfoQuery request, CancellationToken cancellationToken)
    {
        #region Get Doctor By User Id

        var doctor = await _doctorsRepository.GetDoctorByUserId(request.userId);
        if (doctor == null) return null;

        #endregion

        #region Fill User Property 

        var user = await _userRepository.GetUserById(request.userId, cancellationToken);
        if (user == null) return null;

        #endregion

        #region Validate Doctor 

        var organization = await _organizationRepository.GetOrganizationByUserId(request.userId);
        if (organization == null) return null;
        if (organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return null;
        if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return null;

        #endregion

        #region Get Doctor Personal Info 

        var doctorPersonalInfo = await _doctorsRepository.GetDoctorsInfoByDoctorId(doctor.Id);
        if (doctorPersonalInfo == null) return null;

        #endregion

        #region Fill Model 

        DoctorPageInReservationViewModel model = new DoctorPageInReservationViewModel()
        {
            UserId = request.userId,
            Username = doctor.User.Username,
            UserAvatar = doctor.User.Avatar,
            Education = doctorPersonalInfo.Education,
            Specialist = doctorPersonalInfo.Specialty,
            GeneralPhone = doctorPersonalInfo.GeneralPhone,
            ClinicPhone = doctorPersonalInfo.ClinicPhone,
            User = user,
        };

        #endregion

        #region Get User Office Address

        var workAddress = await _workAddressRepository.GetUserWorkAddressById(request.userId);

        if (workAddress != null)
        {
            var country = await _locationRepository.GetLocationById(workAddress.CountryId);
            if (country == null) return null;

            var state = await _locationRepository.GetLocationById(workAddress.StateId);
            if (state == null) return null;

            var city = await _locationRepository.GetLocationById(workAddress.CityId);
            if (city == null) return null;

            model.CountryName = country.UniqueName;
            model.StateName = state.UniqueName;
            model.CityName = city.UniqueName;
            model.WorkAddress = workAddress.Address;
        }

        #endregion

        #region Get Resume By Id

        var resume = await _resumeService.GetResumeByUserId(organization.OwnerId);
        if (resume != null)
        {
            model.Resume = resume;
        }

        #endregion

        #region Fill Resume Model 

        if (resume != null)
        {
            #region Fill About Me 

            var aboutMe = await _resumeRepository.GetUserAboutMeResumeByResumeId(resume.Id);

            //Create New Instance 
            model.ResumeAboutMeSitePanelViewModel = new ResumeAboutMeSitePanelViewModel()
            {
                AboutMeId = ((aboutMe == null) ? null : aboutMe.Id),
                Text = ((aboutMe == null) ? null : aboutMe.AboutMeText),
                ResumeId = resume.Id,
                BannerImage = ((aboutMe == null) ? null : aboutMe.BannerImage),
            };

            #endregion

            #region Fill Education 

            var education = await _resumeRepository.GetEducationResumeByUserId(resume.Id);

            var returnEducation = new List<EducationResumeInSitePanelViewModel>();

            //Create New Instance
            if (education != null && education.Any())
            {
                foreach (var item in education)
                {
                    EducationResumeInSitePanelViewModel ed = (new EducationResumeInSitePanelViewModel()
                    {
                        CityName = ((string.IsNullOrEmpty(item.CityName)) ? null : item.CityName),
                        CountryName = ((string.IsNullOrEmpty(item.CountryName)) ? null : item.CountryName),
                        EndDate = ((item.EndDate == null) ? null : item.EndDate),
                        FieldOfStudy = ((string.IsNullOrEmpty(item.FieldOfStudy)) ? null : item.FieldOfStudy),
                        Orientation = ((string.IsNullOrEmpty(item.Orientation)) ? null : item.Orientation),
                        StartDate = ((item.StartDate == null) ? null : item.StartDate),
                        UnivercityName = ((string.IsNullOrEmpty(item.UnivercityName)) ? null : item.UnivercityName),
                        CreateDate = item.CreateDate,
                        Id = item.Id,
                    });

                    returnEducation.Add(ed);
                }
            }

            model.EducationResume = returnEducation;

            #endregion

            #region Fill Work Address

            var workHistory = await _resumeRepository.GetWorkHistoryResumeByUserId(resume.Id);

            var returnWorkHistory = new List<WorkHistoryResumeInSitePanelViewModel>();

            //Create New Instance
            if (workHistory != null && workHistory.Any())
            {
                foreach (var item in workHistory)
                {
                    WorkHistoryResumeInSitePanelViewModel work = (new WorkHistoryResumeInSitePanelViewModel()
                    {
                        WorkAddress = ((string.IsNullOrEmpty(item.WorkAddress)) ? null : item.WorkAddress),
                        JobPosition = ((string.IsNullOrEmpty(item.JobPosition)) ? null : item.JobPosition),
                        EndDate = ((item.EndDate == null) ? null : item.EndDate),
                        StartDate = ((item.StartDate == null) ? null : item.StartDate),
                        Id = item.Id,
                    });

                    returnWorkHistory.Add(work);
                }
            }

            model.WorkHistoryResume = returnWorkHistory;

            #endregion

            #region Fill Honor

            var honor = await _resumeRepository.GetHonorResumeByUserId(resume.Id);

            var returnHonor = new List<HonorResumeInSitePanelViewModel>();

            //Create New Instance
            if (honor != null && honor.Any())
            {
                foreach (var item in honor)
                {
                    HonorResumeInSitePanelViewModel hr = (new HonorResumeInSitePanelViewModel()
                    {
                        HonorTitle = item.HonorTitle,
                        ImageName = item.ImageName,
                        Description = ((string.IsNullOrEmpty(item.Description)) ? null : item.Description),
                        HonorDate = item.HonorDate,
                        Id = item.Id,
                    });

                    returnHonor.Add(hr);
                }
            }

            model.HonorResume = returnHonor;

            #endregion

            #region Fill Service

            var service = await _resumeRepository.GetServiceResumeByUserId(resume.Id);

            var returnService = new List<ServiceResumeInSitePanelViewModel>();

            //Create New Instance
            if (service != null && service.Any())
            {
                foreach (var item in service)
                {
                    ServiceResumeInSitePanelViewModel sr = (new ServiceResumeInSitePanelViewModel()
                    {
                        ServiceTitle = item.ServiceTitle,
                        Id = item.Id,
                    });

                    returnService.Add(sr);
                }
            }

            model.ServiceResume = returnService;

            #endregion

            #region Fill Working Address

            var workingAddress = await _resumeRepository.GetWorkingAddressResumeByUserId(resume.Id);

            var returnWorkingAddress = new List<WorkingAddressResumeInSitePanelViewModel>();

            //Create New Instance
            if (workingAddress != null && workingAddress.Any())
            {
                foreach (var item in workingAddress)
                {
                    WorkingAddressResumeInSitePanelViewModel wr = (new WorkingAddressResumeInSitePanelViewModel()
                    {
                        WorkingAddress = item.WorkingAddress,
                        WorkingAddressTitle = item.WorkingAddressTitle,
                        Days = item.Days,
                        Times = item.Times,
                        Id = item.Id,
                    });

                    returnWorkingAddress.Add(wr);
                }
            }

            model.WorkingAddressResume = returnWorkingAddress;

            #endregion

            #region Fill Certificate

            var certificate = await _resumeRepository.GetCertificateResumeByUserId(resume.Id);

            var returnCertificate = new List<CertificateResumeInSitePanelViewModel>();

            //Create New Instance
            if (certificate != null && certificate.Any())
            {
                foreach (var item in certificate)
                {
                    CertificateResumeInSitePanelViewModel cr = (new CertificateResumeInSitePanelViewModel()
                    {
                        CertificateTitle = item.CertificateTitle,
                        ImageName = item.ImageName,
                        ExporterRefrence = item.ExporterRefrence,
                        Id = item.Id,
                    });

                    returnCertificate.Add(cr);
                }
            }

            model.CertificateResume = returnCertificate;

            #endregion

            #region Fill Gallery

            var gallery = await _resumeRepository.GetGalleryResumeByUserId(resume.Id);

            var returnGallery = new List<GalleryResumeInSitePanelViewModel>();

            //Create New Instance
            if (gallery != null && gallery.Any())
            {
                foreach (var item in gallery)
                {
                    GalleryResumeInSitePanelViewModel gal = (new GalleryResumeInSitePanelViewModel()
                    {
                        Title = item.Title,
                        ImageName = item.ImageName,
                        Id = item.Id,
                    });

                    returnGallery.Add(gal);
                }
            }

            model.GalleryResume = returnGallery;

            #endregion
        }

        #endregion

        #region Doctor Videos

        var doctorVideos = new List<DoctorVideosDTO>();

        var stories = await _storyQueryRepository.FillDoctorVideosDTO(user.Id , cancellationToken);
        if (stories != null && stories.Any())
        {
            doctorVideos.AddRange(stories);
        }

        var healthInformations = await _healthInformationRepository.FillDoctorVideosDTO(user.Id , cancellationToken);
        if (healthInformations != null && healthInformations.Any())
        {
            doctorVideos.AddRange(healthInformations);
        }

        model.DoctorVideos = doctorVideos.OrderByDescending(p=> p.CreateDate).ToList();

        #endregion

        return model;
    }
}