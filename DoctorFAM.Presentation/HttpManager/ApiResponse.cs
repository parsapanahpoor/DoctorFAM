using Microsoft.AspNetCore.Mvc;

namespace DoctorFAM.Web.HttpManager
{
    public static class ApiResponse
    {
        public static JsonResult SetResponse(ApiResponseStatus status, object? data, string message = null)
        {
            return new JsonResult(new
            {
                status = Enum.GetName(status),
                data = data,
                message = message
            });
        }
    }
}
