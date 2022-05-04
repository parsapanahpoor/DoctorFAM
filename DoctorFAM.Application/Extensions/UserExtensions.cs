using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;


namespace DoctorFAM.Application.Extensions
{
    public static class UserExtensions
    {
        public static ulong GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);

            return ulong.Parse(data.Value);
        }

        public static ulong GetUserId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;

            return user.GetUserId();
        }
    }
}
