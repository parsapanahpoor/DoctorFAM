using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.StaticTools
{
    public static class PathTools
    {

        #region Site

        public static string SiteFarsiName = "DoctorFAM";
        public static string SiteAddress = "https://localhost:7286";

        public static readonly string SiteLogo = "/content/images/site/logo/main/";
        public static readonly string SiteLogoServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/site/logo/main/");

        public static readonly string DefaultSiteLogo = "/content/images/site/logo/default/logo.png";
        public static readonly string SiteLogoThumb = "/content/images/site/logo/thumb/";
        public static readonly string SiteLogoThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/site/logo/thumb/");

        public static readonly string EmailBanner = "/content/images/site/emailBanner/main/";
        public static readonly string EmailBannerServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/site/emailBanner/main/");

        public static readonly string EmailBannerThumb = "/content/images/site/emailBanner/thumb/";
        public static readonly string EmailBannerThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/site/emailBanner/thumb/");

        #endregion

        #region UserAvatar

        public static readonly string UserAvatarPath = "/content/images/user/main/";
        public static readonly string UserAvatarPathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/user/main/");

        public static readonly string UserAvatarPathThumb = "/content/images/user/thumb/";
        public static readonly string UserAvatarPathThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/user/thumb/");

        public static readonly string DefaultUserAvatar = "/content/images/user/DefaultAvatar.png";

        #endregion

        #region Ckeditor

        public static readonly string UploadCkEditorImagePath = "/content/upload/ckeditor/images/";
        public static readonly string UploadCkEditorImagePathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/upload/ckeditor/images/");

        #endregion

        #region Advertisement Image

        public static string DefaultAdvertisementimage = "/UploadedImages/DefaultImages/Default.png";

        public static string AdvertisementOriginimage = "/UploadedImages/AdvertisementImages/Origin/";
        public static string AdvertisementThumbimage = "/UploadedImages/AdvertisementImages/Thumb/";
        public static string AdvertisementimageServerOrigin = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedImages/AdvertisementImages/Origin/");
        public static string AdvertisementImageServerThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedImages/AdvertisementImages/Thumb/");
        public static string AdvertisementimageServerOriginThumb = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UploadedImages/AdvertisementImages/Thumb/");

        #endregion

    }
}
