using DoctorFAM.Application.Common.IUnitOfWork;
using DoctorFAM.Application.Generators;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Implementation;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Diabet;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore.Diabet;
using Microsoft.Win32;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Numeric;

namespace DoctorFAM.Application.CQRS.SiteSide.Diabet.Commands.AddDiabetPopulation;

public record AddDiabetPopulationCommandHandler : IRequestHandler<AddDiabetPopulationCommand, bool>
{
    private readonly IDiabetCommandRepository _diabetCommandRepository;
    private readonly IDiabetQueryRepository _diabetQueryRepository;
    private readonly IUserRepository _userService;
    private readonly IUnitOfWork _unitOfWork;
    private static readonly HttpClient client = new HttpClient();
    private readonly ISMSService _smsService;

    public AddDiabetPopulationCommandHandler(IDiabetCommandRepository diabetCommandRepository,
                                             IDiabetQueryRepository diabetQueryRepository
                                             IUserRepository userService,
                                             IUnitOfWork unitOfWork,
                                             ISMSService smsService)
    {
        _diabetCommandRepository = diabetCommandRepository;
        _diabetQueryRepository = diabetQueryRepository;
        _userService = userService;
        _unitOfWork = unitOfWork;
        _smsService = smsService;
    }

    public async Task<bool> Handle(AddDiabetPopulationCommand request, CancellationToken cancellationToken)
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
                await _smsService.SendSimpleSMS(request.command.PhoneNumber, message);
            }
            else
            {
                var user = await _userService.GetUserByMobile(request.command.PhoneNumber.Trim().ToLower().SanitizeText());
                if (user != null) request.command.UserId = user.Id;
            }

        }

        if (await _diabetQueryRepository.IsExist_AnyUser_InDiabetPopulation_ByUserId(request.command.UserId.Value)) 
                                        return false;

        //Add User to the diabet population 
        var res = DiabetPopulation.Create(request.command.UserId.Value,
                                          request.command.Gender,
                                          request.command.Age);

        await _diabetCommandRepository.AddAsync(res, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return true;
    }
}
