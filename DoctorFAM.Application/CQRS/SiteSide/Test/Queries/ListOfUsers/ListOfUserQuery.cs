namespace DoctorFAM.Application.CQRS.SiteSide.Test.Queries.ListOfUsers;

public record ListOfUserQuery : IRequest<List<DoctorFAM.Domain.Entities.Account.User>>;
