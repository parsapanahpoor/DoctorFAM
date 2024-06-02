using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore.Diabet;
using DoctorFAM.Domain.ViewModels.Site.Diabet;

namespace DoctorFAM.Application.CQRS.SiteSide.Diabet.Queries;

public record ShowDiabetPopulationModalQueryHandler : IRequestHandler<ShowDiabetPopulationModalQuery, DiabetPopulationDTO>
{
    private readonly IDiabetQueryRepository _diabetQueryRepository;
    private readonly IUserRepository _userRepository;

    public ShowDiabetPopulationModalQueryHandler(IDiabetQueryRepository diabetQueryRepository ,
                                                 IUserRepository userRepository)
    {
        _diabetQueryRepository = diabetQueryRepository;
        _userRepository = userRepository;
    }

    public async Task<DiabetPopulationDTO> Handle(ShowDiabetPopulationModalQuery request, CancellationToken cancellationToken)
    {
        var patientUserInformation = new DiabetPopulationDTO();

        if (request.UserId.HasValue && request.UserId != 0)
        {
            var user = await _userRepository.GetUserById(request.UserId.Value , cancellationToken);

            patientUserInformation.FirstName = user.FirstName;
            patientUserInformation.LastName = user.LastName;
            patientUserInformation.PhoneNumber = user.Mobile;
            patientUserInformation.NationalId = user.NationalId;
            patientUserInformation.UserId = user.Id;
        }

         return patientUserInformation;
    }
}
