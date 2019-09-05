using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Filters
{
    public class ResultFilter : IResultFilter
    {
        //IResultFilter and IAsyncResultFilter implementations are executed around the action result only when the action method (or action filters) complete successfully.
        //To create a result filter that surrounds the execution of all action results, implement either the IAlwaysRunResultFilter or the IAsyncAlwaysRunResultFilter interface.
        private ILogger _logger;
        public ResultFilter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<ResultFilter>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var headerName = "OnResultExecuting";
            //context.HttpContext.Response.Headers.Add(
            //    headerName, new string[] { "ResultExecutingSuccessfully" });
            _logger.LogInformation($"Header added: {headerName}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't add to headers here because response has started.
        }
    }
}
