using DoctorFAM.Domain.Entities.Common;

namespace DoctorFAM.Domain.Entities.Diabet;

public sealed class DiabetPopulation : BaseEntity
{
    private DiabetPopulation(){}

    public ulong UserId { get; set; }

    public static void Create(ulong userId)
    {
        DiabetPopulation diabet = new DiabetPopulation()
        {
            UserId = userId,
        };
    }
}
