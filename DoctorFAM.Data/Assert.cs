namespace DoctorFAM.Data;

public class Assert
{
    public static void NotNull<T>(T obj, string name)
        where T : class
    {
        if (obj is null)
            throw new ArgumentNullException($"{name} : {typeof(T)} entity cannot be null");

    }

    public static void NotNull<T>(T? obj, string name)
        where T : struct
    {
        if (!obj.HasValue)
            throw new ArgumentNullException($"{name} : {typeof(T)} entity cannot be null");

    }
}
