using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Filters
{
    public class SampleActionFilterAttribute : TypeFilterAttribute
    {
        public SampleActionFilterAttribute() : base(typeof(SampleActionFilterImpl))
        {
        }

        private  class SampleActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public SampleActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<SampleActionFilterAttribute>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                _logger.LogInformation("Business action starting...");
                // perform some business logic work

            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                // perform some business logic work
                _logger.LogInformation("Business action completed.");
            }

            //public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            //{
            //    _logger.LogWarning($"action filter is executing new ,context.modelstate:{context.ModelState.IsValid}");
            //    var executedContext = await next();
            //    _logger.LogWarning($"action filter is executed now,executedContext controller:{executedContext.Controller.ToString()}");
            //}
        }
    }
}
