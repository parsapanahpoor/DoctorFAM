using DoctorFAM.Domain.ViewModels.Site.BloodPressure;
using System.Windows.Input;

namespace DoctorFAM.Application.CQRS.SiteSide.BloodPressure.Commands.AddBloodPressurePopulation;

public record AddBloodPressurePopulationCommand : IRequest<bool>
{
    public BloodPressurePopulationDTO command { get; set; }
}
