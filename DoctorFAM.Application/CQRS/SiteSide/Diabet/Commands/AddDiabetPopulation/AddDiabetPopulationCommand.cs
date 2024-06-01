using DoctorFAM.Domain.ViewModels.Site.Diabet;
using System.Windows.Input;

namespace DoctorFAM.Application.CQRS.SiteSide.Diabet.Commands.AddDiabetPopulation;

public record AddDiabetPopulationCommand : IRequest<bool>
{
    public DiabetPopulationDTO command { get; set; }
}
