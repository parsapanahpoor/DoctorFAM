
using DoctorFAM.Application.Common.IUnitOfWork;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;

namespace DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Commands;

public record EditDoctorBannerImageCommandHandler : IRequestHandler<EditDoctorBannerImageCommand, bool>
{
    #region Ctor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IDoctorsRepository _doctorsRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly IOrganizationRepository _organizationRepository;

    public EditDoctorBannerImageCommandHandler(IUnitOfWork unitOfWork,
                                            IUserRepository userRepository,
                                            IDoctorsRepository doctorsRepository,
                                            IResumeRepository resumeRepository,
                                            IOrganizationRepository organizationRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _doctorsRepository = doctorsRepository;
        _resumeRepository = resumeRepository;
        _organizationRepository = organizationRepository;
    }

    #endregion

    public async Task<bool> Handle(EditDoctorBannerImageCommand request, CancellationToken cancellationToken)
    {
        #region Get User By UserId

        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        if (user == null) return false;

        #endregion

        #region Get Doctor By User Id

        var doctor = await _doctorsRepository.GetDoctorByUserId(user.Id);
        if (doctor == null) return false;

        #endregion

        #region Validate Doctor 

        var organization = await _organizationRepository.GetOrganizationByUserId(user.Id);
        if (organization == null) return false;
        if (organization.OrganizationType != Domain.Enums.Organization.OrganizationType.DoctorOffice) return false;
        if (organization.OrganizationInfoState != OrganizationInfoState.Accepted) return false;

        #endregion

        #region Get Resume By Id

        var resume = await _resumeRepository.GetResumeByUserId(organization.OwnerId);
        if (resume == null)
        {
            //Add Resume For The First Time For give it id 
            Resume newResume = new Resume()
            {
                ResumeState = Domain.Enums.ResumeState.ResumeState.Accepted,
                UserId = organization.OwnerId,
            };
            await _resumeRepository.AddResume(newResume, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            //Add About Me Resume To the Data Base
            ResumeAboutMe resumeAboutMe = new ResumeAboutMe()
            {
                AboutMeText = "وارد نشده",
                ResumeId = newResume.Id,
            };

            #region Edit Doctor Banner Image

            if (request.Picture != null)
            {
                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(request.Picture.FileName);
                request.Picture.AddImageToServer(imageName, PathTools.DoctorBannerImagePathServer, 270, 270, PathTools.DoctorBannerImagePathThumbServer);
                resumeAboutMe.BannerImage = imageName;
            }

            #endregion

            await _resumeRepository.AddAboutMe(resumeAboutMe, cancellationToken);
            await _unitOfWork.SaveChangesAsync();
        }

        else
        {
            var aboutMe = await _resumeRepository.GetUserAboutMeResumeByResumeId(resume.Id);
            if (aboutMe == null) return false;

            if (request.Picture != null)
            {
                if (!string.IsNullOrEmpty(aboutMe.BannerImage))
                {
                    aboutMe.BannerImage.DeleteImage(PathTools.DoctorBannerImagePathServer, PathTools.DoctorBannerImagePathThumbServer);
                }

                var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(request.Picture.FileName);
                request.Picture.AddImageToServer(imageName, PathTools.DoctorBannerImagePathServer, 270, 270, PathTools.DoctorBannerImagePathThumbServer);
                aboutMe.BannerImage = imageName;
            }

            _resumeRepository.UpdateAboutMeResumeWithoutSaveChange(aboutMe);
            await _unitOfWork.SaveChangesAsync();
        }

        #endregion

        return true;
    }
}
