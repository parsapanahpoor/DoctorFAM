namespace DoctorFAM.Web.HttpServices
{
    public static class HttpContextManager
    {
        public static string GetUserIP(this HttpContext context)
        {
            return context.Connection.RemoteIpAddress.ToString();
        }

        public static string GetUrlReferer(this HttpRequest request)
        {
            return request.Headers["Referer"].ToString();
        }
    }
}
