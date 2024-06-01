using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums.Gender;

namespace DoctorFAM.Domain.Entities.BloodPressure;

public sealed class BloodPressurePopulation : BaseEntity
{
    private BloodPressurePopulation(){}

    public ulong UserId { get; set; }
    public Gender Gender { get; set; }
    public int Age { get; set; }

    public static BloodPressurePopulation Create(ulong userId , 
                                                 Gender gender , 
                                                 int age)
    {
        BloodPressurePopulation bloodPressure = new BloodPressurePopulation()
        {
            UserId = userId,
            Gender = gender,
            Age = age
        };

        return bloodPressure;
    }
}
