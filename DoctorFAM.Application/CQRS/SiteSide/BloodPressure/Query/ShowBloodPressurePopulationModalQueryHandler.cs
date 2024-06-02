using DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.BloodPressure;

namespace DoctorFAM.Application.CQRS.SiteSide.BloodPressure.Query;

public record ShowBloodPressurePopulationModalQueryHandler : IRequestHandler<ShowBloodPressurePopulationModalQuery, BloodPressurePopulationDTO>
{
    private readonly IBloodPressureQueryRepository _bloodPressureQueryRepository;
    private readonly IUserRepository _userRepository;

    public ShowBloodPressurePopulationModalQueryHandler(IBloodPressureQueryRepository bloodPressureQueryRepository,
                                                        IUserRepository userRepository)
    {
        _bloodPressureQueryRepository = bloodPressureQueryRepository;
        _userRepository = userRepository;
    }

    public async Task<BloodPressurePopulationDTO> Handle(ShowBloodPressurePopulationModalQuery request, CancellationToken cancellationToken)
    {
        var patientUserInformation = new BloodPressurePopulationDTO();

        if (request.UserId.HasValue && request.UserId != 0)
        {
            var user = await _userRepository.GetUserById(request.UserId.Value, cancellationToken);

            patientUserInformation.FirstName = user.FirstName;
            patientUserInformation.LastName = user.LastName;
            patientUserInformation.PhoneNumber = user.Mobile;
            patientUserInformation.NationalId = user.NationalId;
            patientUserInformation.UserId = user.Id;
        }

        return patientUserInformation;
    }
}
