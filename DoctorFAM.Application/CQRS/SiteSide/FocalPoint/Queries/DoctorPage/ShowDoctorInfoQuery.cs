using DoctorFAM.Domain.ViewModels.Site.Doctor;
namespace DoctorFAM.Application.CQRS.SiteSide.FocalPoint.Queries.DoctorPage;

public record ShowDoctorInfoQuery(ulong userId, string name) : IRequest<DoctorPageInReservationViewModel>;
