using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.Extensions
{
    public static class PrintPropertyNameAndValue
    {
        public static void Print<T>(this T obj)
        {
            Type t = obj.GetType();
            Console.WriteLine($"Print   {t.Name}  class");
            var prop = t.GetProperties();
            foreach (var property in prop)
            {
                Console.WriteLine($"{property.Name} : {property.GetValue(obj)}");
            }
            Console.WriteLine("_________________________________________");
        }
    }
}
