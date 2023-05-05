using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.CompilerServices;

namespace Labs.Filters
{
    public class Authorization : ActionFilterAttribute
    {
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string actionName = context.HttpContext.Request.RouteValues["action"].ToString();
            string controllerName = context.HttpContext.Request.RouteValues["controller"].ToString();
            // check in database if user has permatission 
            return base.OnActionExecutionAsync(context, next);      
        }
    }
}
