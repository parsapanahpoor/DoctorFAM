using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Site.Rating;

namespace DoctorFAM.Application.CQRS.SiteSide.OrganizationRating.Query.DoctorReservationRating;

public record DoctorReservationRatingQueryHandler : IRequestHandler<DoctorReservationRatingQuery, ShowRatingFormForPatientDTO>
{
    #region Ctor

    private readonly IReservationRepository _reservationRepository;
    private readonly IUserRepository _userRepository;

    public DoctorReservationRatingQueryHandler(IReservationRepository reservationRepository,
                                               IUserRepository userRepository)
    {
        _reservationRepository = reservationRepository;
        _userRepository = userRepository;
    }

    #endregion

    public async Task<ShowRatingFormForPatientDTO?> Handle(DoctorReservationRatingQuery request, CancellationToken cancellationToken)
    {
        #region Validation 

        if (!request.UserId.HasValue && string.IsNullOrEmpty(request.MobileNumber)) return null;

        #endregion

        ShowRatingFormForPatientDTO model = new ShowRatingFormForPatientDTO();

        #region Get Reservation By Id 

        var reservationTime = await _reservationRepository.GetDoctorReservationDateTimeById(request.ReservationId);
        if (reservationTime == null || !reservationTime.PatientId.HasValue) return null;

        var reservation = await _reservationRepository.GetReservationDateById(reservationTime.DoctorReservationDateId);
        if (reservation == null) return null;

        ShowRatingFormForPatientDTO_ReservationInfo reservationInfo = new()
        {
            ReservationDate = reservation.ReservationDate,
            ReservationDateStartTime = reservationTime.StartTime,
            ReservationId = reservation.Id,
            ReservationDateTimeId = reservationTime.Id
        };

        model.ReservationInfo = reservationInfo;

        #endregion

        #region Get Patient Info 

        if (request.UserId.HasValue)
        {
            var patientUserInfo = await _userRepository.GetUserById(request.UserId.Value, cancellationToken);
            if (patientUserInfo == null || reservationTime.PatientId.Value != request.UserId.Value) return null;

            model.PatientMobile = patientUserInfo.Mobile;
        }
        if (!string.IsNullOrEmpty(request.MobileNumber))
        {
            var patientUserInfo = await _userRepository.GetUserByMobile(request.MobileNumber);
            if (patientUserInfo == null || reservationTime.PatientId.Value != patientUserInfo.Id) return null;

            model.PatientMobile = patientUserInfo.Mobile;
        }

        #endregion

        #region Doctor Info 

        var doctorUser = await _userRepository.GetUserById(reservation.UserId, cancellationToken);
        if (doctorUser == null) return null;

        ShowRatingFormForPatientDTO_DoctorProfile doctorUserInfo = new ShowRatingFormForPatientDTO_DoctorProfile()
        {
            DoctorAvatar = doctorUser.Avatar,
            DoctorUserId = doctorUser.Id,
            DoctorUsername = doctorUser.Username
        };

        model.DoctorInfo = doctorUserInfo;

        #endregion

        return model;
    }
}
