using DoctorFAM.Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Kavenegar.Core.Models;
using DoctorFAM.Application.StaticTools;

namespace DoctorFAM.Application.Services.Implementation
{
    public class SMSService : ISMSService
    {
        #region Ctor

        private readonly IConfiguration _configuration;

        public SMSService( IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

        public async Task<SendResult?> SendLookupSMS(string receptor, string token, string token2, string token3, string template)
        {
            var apikey = _configuration["kavenegar:apikey"];

            try
            {
                Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(apikey);

                var result = await api.VerifyLookup(receptor, token, token2, token3, template);

                return result;
            }
            catch (Kavenegar.Core.Exceptions.ApiException ex)
            {
                await ExeptionLog.LogError(ex);
            }
            catch (Kavenegar.Core.Exceptions.HttpException ex)
            {
                await ExeptionLog.LogError(ex);
            }

            return null;
        }

        public async Task<SendResult?> SendSimpleSMS(string receptor, string message)
        {
            Kavenegar.KavenegarApi api = new Kavenegar.KavenegarApi(_configuration["kavenegar:apikey"]);

            //var result = await api.Send("10008663", receptor, message);
            var result = await api.Send("90004034", receptor, message);

            return result;
        }
    }
}
