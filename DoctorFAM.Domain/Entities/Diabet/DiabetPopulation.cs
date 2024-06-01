using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Gender;

namespace DoctorFAM.Domain.Entities.Diabet;

public sealed class DiabetPopulation : BaseEntity
{
    private DiabetPopulation(){}

    public ulong UserId { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }

    public static void Create(ulong userId , 
                              Gender gender , 
                              int age)
    {
        DiabetPopulation diabet = new DiabetPopulation()
        {
            UserId = userId,
            Gender = gender,
            Age = age
        };
    }
}
