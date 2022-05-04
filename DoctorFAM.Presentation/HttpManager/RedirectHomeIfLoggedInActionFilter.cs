using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DoctorFAM.Web.HttpManager
{
    public class RedirectHomeIfLoggedInActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                if (context.Controller is Controller controller)
                {
                    context.HttpContext.Response.Redirect("/");
                }
            }
        }
    }
}
