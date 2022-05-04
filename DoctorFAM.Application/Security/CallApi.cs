using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoctorFAM.Application.Security
{
    public static class ApiMethods
    {
        public static T? CallApi<T>(string apiUrl, object value) where T : new()
        {
            using var client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();

            var json = JsonConvert.SerializeObject(value);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var w = client.PostAsync(apiUrl, content);
            w.Wait();

            HttpResponseMessage response = w.Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync();
                result.Wait();
                return JsonConvert.DeserializeObject<T>(result.Result);
            }

            return new T();
        }
    }
}
