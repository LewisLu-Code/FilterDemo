using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Filters
{
    public class AuthorizationFilter : AuthorizeFilter
    {
        public override async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //url
            // {/ Home / Index}
            var url = context.HttpContext.Request.Path.Value;
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }

            var list = url.Split("/");
            if (list.Length <= 0 || url == "/" || url == "/Home/Index")
            {
                return;
            }
            var isau = context.HttpContext.User.Identity.IsAuthenticated;
            var name = context.HttpContext.User.Identity.Name;
            //var flag = IsHavePower(isau, name);
            var flag = IsHavePower(true, "Admin");
            if (flag.Item1 == 0)
            {
                context.Result = new RedirectResult("/Home/Index");
            }
            else
            {
                return;
            }
        }
        public static (int, string) IsHavePower(bool isau, string name)
        {
            if (isau == true) {
                //.. Verification logic
                return (1, "Pass");
            }
            else
            {
                return (0, "fail");
            }
        }
    }
}
