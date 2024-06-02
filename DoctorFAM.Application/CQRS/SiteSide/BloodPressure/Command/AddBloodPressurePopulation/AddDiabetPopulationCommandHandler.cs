using DoctorFAM.Application.Common.IUnitOfWork;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.BloodPressure;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore.BloodPressure;

namespace DoctorFAM.Application.CQRS.SiteSide.BloodPressure.Commands.AddBloodPressurePopulation;

public record AddBloodPressurePopulationCommandHandler : 
              IRequestHandler<AddBloodPressurePopulationCommand, bool>
{
    private readonly IBloodPressureCommandRepository _bloodPressureCommandRepository;
    private readonly IBloodPressureQueryRepository _bloodPressureQueryRepository;
    private readonly IUserRepository _userService;
    private readonly IUnitOfWork _unitOfWork;
    private static readonly HttpClient client = new HttpClient();
    private readonly ISMSService _smsService;

    public AddBloodPressurePopulationCommandHandler(IBloodPressureCommandRepository bloodPressureCommandRepository,
                                                    IBloodPressureQueryRepository bloodPressureQueryRepository , 
                                                    IUserRepository userService,
                                                    IUnitOfWork unitOfWork,
                                                    ISMSService smsService)
    {
        _bloodPressureCommandRepository = bloodPressureCommandRepository;
        _bloodPressureQueryRepository = bloodPressureQueryRepository;
        _userService = userService;
        _unitOfWork = unitOfWork;
        _smsService = smsService;
    }

    public async Task<bool> Handle(AddBloodPressurePopulationCommand request, CancellationToken cancellationToken)
    {
        //If User is exist with incomming data
        if (request.command.UserId.HasValue && request.command.UserId.Value != 0)
        {
            var user = await _userService.GetUserById(request.command.UserId.Value, cancellationToken);
            if (user == null) return false;

            user.FirstName = request.command.FirstName;
            user.LastName = request.command.LastName;
            user.NationalId = request.command.NationalId;

            _userService.UpdateUserWithoutSaveChange(user);
        }

        //If User is not exist with incomming data
        else
        {
            if (!await _userService.IsExist_User_ByMobile(request.command.PhoneNumber.Trim()
                                                                                     .ToLower()
                                                                                     .SanitizeText()))
            {
                var user = new User()
                {
                    Password = PasswordHasher.EncodePasswordMd5(request.command.PhoneNumber.SanitizeText()),
                    FirstName = request.command.FirstName,
                    LastName = request.command.LastName,
                    NationalId = request.command.NationalId,
                    Username = request.command.PhoneNumber,
                    Mobile = request.command.PhoneNumber,
                    EmailActivationCode = CodeGenerator.GenerateUniqCode(),
                    MobileActivationCode = new Random().Next(10000, 999999).ToString(),
                    ExpireMobileSMSDateTime = DateTime.Now,
                    IsMobileConfirm = true,
                };

                await _userService.AddUser(user);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                request.command.UserId = user.Id;

                // Send Registeration SMS 
                var message = Messages.SendSMSForUserRegistrationAlert(request.command.PhoneNumber);
                //await _smsService.SendSimpleSMS(request.command.PhoneNumber, message);
            }
            else
            {
                var user = await _userService.GetUserByMobile(request.command.PhoneNumber.Trim().ToLower().SanitizeText());
                if (user != null) request.command.UserId = user.Id;
            }
        }

        if (await _bloodPressureQueryRepository.IsExist_AnyUser_InBloodPressurePopulation_ByUserId(request.command.UserId.Value)) 
                                        return false;

        //Add User to the BloodPressure population 
        var res = BloodPressurePopulation.Create(request.command.UserId.Value,
                                                 request.command.Gender,
                                                 request.command.Age);

        await _bloodPressureCommandRepository.AddAsync(res, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
