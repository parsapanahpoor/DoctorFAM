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

        public static string SiteFarsiName = "داکتر فم";
        public static string SiteAddress = "https://localhost:44322";

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

        #region Drug Prescription

        public static readonly string DrugPrescriptionPath = "/content/images/DrugPrescription/main/";
        public static readonly string DrugPrescriptionPathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/DrugPrescription/main/");

        public static readonly string DrugPrescriptionPathThumb = "/content/images/DrugPrescription/thumb/";
        public static readonly string DrugPrescriptionPathThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/DrugPrescription/thumb/");

        #endregion

        #region Online Visit Request File

        public static readonly string OnlineVisitRequestFilePath = "/content/images/OnlineVisitRequestFile/main/";
        public static readonly string OnlineVisitRequestFilePathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/OnlineVisitRequestFile/main/");

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

        #region Doctor Information

        public static readonly string DefaultMediacalFile = "/content/images/MediacalFile/DefaultMediacalFile.png";

        public static readonly string MediacalFilePath = "/content/images/MediacalFile/main/";
        public static readonly string MediacalFilePathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/MediacalFile/main/");

        public static readonly string MediacalFilePathThumb = "/content/images/MediacalFile/thumb/";
        public static readonly string MediacalFilePathThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/MediacalFile/thumb/");

        #endregion

        #region Lab Prescription

        public static readonly string LabPrescriptionPath = "/content/images/LabPrescription/main/";
        public static readonly string LabPrescriptionPathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/LabPrescription/main/");

        public static readonly string LabPrescriptionPathThumb = "/content/images/LabPrescription/thumb/";
        public static readonly string LabPrescriptionPathThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/LabPrescription/thumb/");

        #endregion

        #region Products

        public static readonly string ProductsPath = "/content/images/Products/main/";
        public static readonly string ProductsPathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/Products/main/");

        public static readonly string ProductsPathThumb = "/content/images/Products/thumb/";
        public static readonly string ProductsPathThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/Products/thumb/");

        public static readonly string DefaultProductAvatar = "/content/images/Products/DefaultProducts.jpg";

        #endregion

        #region Product Gallery

        public static readonly string ProductsGalleryPath = "/content/images/Products/Gallery/main/";
        public static readonly string ProductsGalleryPathServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/Products/Gallery/main/");

        public static readonly string ProductsGalleryPathThumb = "/content/images/Products/Gallery/thumb/";
        public static readonly string ProductsGalleryPathThumbServer = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/content/images/Products/Gallery/thumb/");

        #endregion
    }
}
