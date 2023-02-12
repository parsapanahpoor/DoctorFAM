
using DoctorFAM.Convertors.Context;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;

namespace DoctorFAM.Convertors
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Remove All Data From New Context
            await RemoveAllData();

            OldContext oldContext = new OldContext();
            NewContext newContext = new NewContext();

            // users
            await ConvertUsers(oldContext, newContext);
            await oldContext.DisposeAsync();
            await newContext.DisposeAsync();
        }

        static async Task RemoveAllData()
        {
            NewContext context = new NewContext();

            context.RemoveRange(context.Users);
            await context.SaveChangesAsync();

            Console.WriteLine("Removed All Entities From New Context");
        }

        static async Task ConvertUsers(OldContext oldContext, NewContext newContext)
        {
            try
            {
                List<User> entities = new List<User>();

                var lastUsers = await oldContext.Users.ToListAsync();

                foreach (var user in lastUsers)
                {
                    entities.Add(user);
                }

                await newContext.Users.AddRangeAsync(entities);
                await newContext.SaveChangesAsync();

                Console.WriteLine("Convert Users");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}