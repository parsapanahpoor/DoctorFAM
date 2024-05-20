
using DoctorFAM.Application.Common.IUnitOfWork;
using DoctorFAM.Data.Repository.OrganizationRating;
using DoctorFAM.Domain.Entities.RatingAgg;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.Interfaces.EFCore.OrganizationRating;
using DoctorFAM.Domain.ViewModels.Site.Rating;
using System.Xml.Xsl;

namespace DoctorFAM.Application.CQRS.SiteSide.OrganizationRating.Command.AddDoctorReservationRatingPointCommand;

public record AddDoctorReservationRatingPointCommandHandler : IRequestHandler<AddDoctorReservationRatingPointCommand, bool>
{
    #region Ctor 

    private readonly IOrganizationRatingCommandRepostiory _organizationRatingCommandRepostiory;
    private readonly IOrganizationRatingQueryRepository _organizationRatingQueryRepository;
    private readonly IReservationRepository _reservationRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AddDoctorReservationRatingPointCommandHandler(IOrganizationRatingCommandRepostiory organizationRatingCommandRepostiory,
                                                         IOrganizationRatingQueryRepository organizationRatingQueryRepository,
                                                         IUnitOfWork unitOfWork,
                                                         IReservationRepository reservationRepository,
                                                         IUserRepository userRepository)
    {
        _organizationRatingCommandRepostiory = organizationRatingCommandRepostiory;
        _organizationRatingQueryRepository = organizationRatingQueryRepository;
        _unitOfWork = unitOfWork;
        _reservationRepository = reservationRepository;
        _userRepository = userRepository;
    }

    #endregion

    public async Task<bool> Handle(AddDoctorReservationRatingPointCommand request, CancellationToken cancellationToken)
    {
        #region Get Reservation By Id 

        var reservation = await _reservationRepository.GetReservationDateById(request.ReservationId);
        if (reservation == null) return false;

        var reservationTime = await _reservationRepository.GetDoctorReservationDateTimeById(request.ReservationDateTimeId);
        if (reservationTime == null || !reservationTime.PatientId.HasValue) return false;

        #endregion

        #region Get Patient Info 

        var patientUserInfo = await _userRepository.GetUserByMobile(request.MobileNumber);
        if (patientUserInfo == null || reservationTime.PatientId.Value != patientUserInfo.Id) return false;

        #endregion

        #region Doctor Reservation Rating

        //Is Exist any rated point from this patient for current doctor 
        if (await _organizationRatingQueryRepository
                    .IsExist_DoctorReservationRatingPoint_FromCurrentUser(reservation.Id,
                                                                          patientUserInfo.Id,
                                                                          reservation.UserId,
                                                                          cancellationToken)) return false;

        //Fill Organization Rate 
        OrganizationStart star = new OrganizationStart()
        {
            OperatorUserId = reservation.UserId,
            PatientUserId = patientUserInfo.Id,
            OrganizationStartEnum = Domain.Enums.Rating.OrganizationStartEnum.Reservation,
            ServiceRequestedId = reservation.Id,
            Star = request.StarPoint
        };

        await _organizationRatingCommandRepostiory.Add_OrganizationStart(star , cancellationToken);
        await _unitOfWork.SaveChangesAsync();

        //Calculate Operator Point
        var calculatedPoint = await _organizationRatingQueryRepository.Calculate_OperatorRatingPoint(reservation.UserId , cancellationToken);
        if (calculatedPoint == 0) return false;

        //Get Lastest doctor point 
        var doctorCurrentPoint = await _organizationRatingQueryRepository.Get_OrganizationStartPoint_ByOperatorUserId(reservation.UserId , cancellationToken);

        //Add the firs doctor rating point
        if (doctorCurrentPoint == null)
        {
            OrganizationStarPoint starPoint = new OrganizationStarPoint()
            {
                OperatorUserId = reservation.UserId,
                PointValue = calculatedPoint
            };

            await _organizationRatingCommandRepostiory.AddAsync(starPoint , cancellationToken);
            await _unitOfWork.SaveChangesAsync();
        }

        //Update the last doctor rating point
        else
        {
            doctorCurrentPoint.PointValue = calculatedPoint;

            _organizationRatingCommandRepostiory.Update(doctorCurrentPoint);
            await _unitOfWork.SaveChangesAsync();
        }

        #endregion

        return true;
    }
}
