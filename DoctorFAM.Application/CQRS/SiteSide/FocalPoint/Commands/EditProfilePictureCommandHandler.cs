
using DoctorFAM.Application.Common.IUnitOfWork;
using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Data.Repository;
using DoctorFAM.Domain.Entities.Doctors;
using DoctorFAM.Domain.Entities.Organization;
using DoctorFAM.Domain.Entities.Resume;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.Site.Doctor.Resume;

namespace DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Commands;

public record EditProfilePictureCommandHandler : IRequestHandler<EditProfilePictureCommand, bool>
{
    #region Ctor

    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IDoctorsRepository _doctorsRepository;
    private readonly IResumeRepository _resumeRepository;
    private readonly IOrganizationRepository _organizationRepository;

    public EditProfilePictureCommandHandler(IUnitOfWork unitOfWork,
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

    public async Task<bool> Handle(EditProfilePictureCommand request, CancellationToken cancellationToken)
    {
        #region Get User By UserId

        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        if (user == null) return false;

        #endregion

        #region Edit User Info

        if (request.Picture != null)
        {
            if (!string.IsNullOrEmpty(user.Avatar))
            {
                user.Avatar.DeleteImage(PathTools.UserAvatarPathServer, PathTools.UserAvatarPathThumbServer);
            }

            var imageName = CodeGenerator.GenerateUniqCode() + Path.GetExtension(request.Picture.FileName);
            request.Picture.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 270, 270, PathTools.UserAvatarPathThumbServer);
            user.Avatar = imageName;
        }

        _userRepository.UpdateUserWithoutSaveChange(user);
        await _unitOfWork.SaveChangesAsync();

        #endregion

        return true;
    }
}
