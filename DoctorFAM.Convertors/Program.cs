
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
            CurrentContext _cuurentContext = new CurrentContext();

            // Patient And Population Covered
            await ConvertInsuranceFieldFromPopulationCoveredTable(_cuurentContext);
            await ConvertInsuranceFieldFromInsuranceTable(_cuurentContext);

            await _cuurentContext.DisposeAsync();
        }

        static async Task ConvertInsuranceFieldFromPopulationCoveredTable(CurrentContext _cuurentContext)
        {
            try
            {
                //Get Population Covered
                var populationCovered = await _cuurentContext.PopulationCovered.ToListAsync();

                foreach (var item in populationCovered)
                {
                    item.InsuranceId = (((ulong)item.InsuranceType) == 0) ? 5 : ((ulong)item.InsuranceType);

                    //Update Item
                    _cuurentContext.PopulationCovered.Update(item);
                }

                //Save Changes 
                await _cuurentContext.SaveChangesAsync();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Convert Insurance Id From Population Covered Table");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static async Task ConvertInsuranceFieldFromInsuranceTable(CurrentContext _cuurentContext)
        {
            try
            {
                //Get Patient Covered
                var patient = await _cuurentContext.Patients.ToListAsync();

                foreach (var item in patient)
                {
                    item.InsuranceId = (((ulong)item.InsuranceType) == 0) ? 5 : ((ulong)item.InsuranceType);

                    //Update Item
                    _cuurentContext.Patients.Update(item);
                }

                //Save Changes 
                await _cuurentContext.SaveChangesAsync();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Convert Insurance Id From Patient Table");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}