using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.HttpManager
{
    public class JsonResponseStatus
    {
        public static JsonResult Success()
        {
            return new JsonResult(new { status = "Success" });
        }

        public static JsonResult Success(object returnData, string message = null)
        {
            return new JsonResult(new { status = "Success", data = returnData, message = message });
        }

        public static JsonResult NotFound()
        {
            return new JsonResult(new { status = "NotFound" });
        }

        public static JsonResult NotFound(object returnData, string message = null)
        {
            return new JsonResult(new { status = "NotFound", data = returnData, message = message });
        }

        public static JsonResult Error()
        {
            return new JsonResult(new { status = "Error" });
        }

        public static JsonResult Error(object returnData, string message = null)
        {
            return new JsonResult(new { status = "Error", data = returnData, message = message });
        }

        public static JsonResult Warning()
        {
            return new JsonResult(new { status = "Warning" });
        }

        public static JsonResult Warning(object returnData, string message = null)
        {
            return new JsonResult(new { status = "Warning", data = returnData, message = message });
        }

        public static JsonResult NotAuth()
        {
            return new JsonResult(new { status = "NotAuth" });
        }

        public static JsonResult NotAuth(object returnData, string message = null)
        {
            return new JsonResult(new { status = "NotAuth", data = returnData, message = message });
        }

        internal static IActionResult SendStatus(object success, string v, object p)
        {
            throw new NotImplementedException();
        }
    }
}
