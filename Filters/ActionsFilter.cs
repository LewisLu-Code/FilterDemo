using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Filters
{
    public class ActionsFilter: ActionFilterAttribute
    {
        public string Message { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var c = filterContext.Controller.ToString();
            string[] split = c.Split(".");
            var controller = split[2];
            if (controller == "HomeController")
            {
                base.OnActionExecuting(filterContext);
                filterContext.HttpContext.Response.WriteAsync("<br />" + "HomeController ActionsFilter OnActionExecuting Work:" + Message + "<br />");
            }
            base.OnActionExecuting(filterContext);
            filterContext.HttpContext.Response.WriteAsync("<br />" + "ActionsFilter OnActionExecuting Work:" + Message + "<br />");
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            filterContext.HttpContext.Response.WriteAsync("<br />" + "ActionsFilter OnActionExecuted Work:" + Message + "<br />");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
            filterContext.HttpContext.Response.WriteAsync("<br />" + "Filter OnResultExecuting Work:" + Message + "<br />");
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
            filterContext.HttpContext.Response.WriteAsync("<br />" + "Filter OnResultExecuted Work:" + Message + "<br />");
        }
    }
}
