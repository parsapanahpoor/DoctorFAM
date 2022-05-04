using System.Globalization;

namespace DoctorFAM.Web.Culture
{
    public class CultureItem
    {
        public string CultureKey { get; set; }
        public string Title { get; set; }
        public string Direction { get; set; }
        public bool IsRtl { get; set; }
    }

    public static class ApplicationCultures
    {
        public static List<CultureItem> CultureItems { get; set; } = new List<CultureItem>
        {
            new CultureItem{CultureKey = "fa-IR",Title="فارسی",Direction = "rtl",IsRtl = true},
            new CultureItem{CultureKey = "en-US",Title="English",Direction = "ltr",IsRtl = false},
            new CultureItem{CultureKey = "tr-TR",Title="Turkish",Direction = "ltr",IsRtl = false},
            new CultureItem{CultureKey = "ar-SA",Title="Arabic",Direction = "rtl",IsRtl = true},
        };

        public static CultureItem GetCurrentCulture()
        {
            var key = CultureInfo.CurrentCulture.Name;
            var culture = CultureItems.SingleOrDefault(s => s.CultureKey == key);
            return culture;
        }

        public static string GetLanguageCode()
        {
            var key = CultureInfo.CurrentCulture.Name;
            return key.Split("-")[0];
        }

        public static List<CultureItem> GetAllCultureItems()
        {
            return CultureItems;
        }
    }
}
