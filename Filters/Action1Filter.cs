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
    public class Action1Filter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action Executing");
            string methodType = context.HttpContext.Request.Method;
            if (methodType.ToUpper().Equals("POST") || methodType.ToUpper().Equals("PUT"))
            {
                if (!context.ModelState.IsValid)
                {
                    var modelState = context.ModelState.FirstOrDefault(f => f.Value.Errors.Any());

                    string errorMsg = modelState.Value.Errors.First().ErrorMessage;

                    //throw new ExceptionsFilter(errorMsg);
                    context.Result = new BadRequestObjectResult(context.ModelState);
                }
                // Your errors
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action Executed");
        }
    }
}
