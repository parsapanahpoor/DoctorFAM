using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Account;
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

        public static string GetUsername(this ClaimsPrincipal claimsPrincipal)
        {
            var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Name);

            return data.ToString();
        }

        public static string GetUsername(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;

            return user.GetUsername();
        }

        public static string GetUserAvatar(this User user)
        {
            if (!string.IsNullOrEmpty(user.Avatar))
            {
                return Path.Combine(PathTools.UserAvatarPathThumb, user.Avatar);
            }

            return PathTools.DefaultUserAvatar;
        }

        public static string GetUserAvatar(this string userAvatar)
        {
            if (!string.IsNullOrEmpty(userAvatar))
            {
                return Path.Combine(PathTools.UserAvatarPathThumb, userAvatar);
            }

            return PathTools.DefaultUserAvatar;
        }
    }
}
