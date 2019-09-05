using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilterDemo.Filters
{
    public class SampleAsyncPageFilter : IPageFilter
    {
        private readonly ILogger _logger;
        public SampleAsyncPageFilter(ILogger logger)
        {
            _logger = logger;
        }

        //public async Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        //{
        //    //_logger.LogDebug("Global OnPageHandlerSelectionAsync called.");
        //    await Task.CompletedTask;
        //}

        //public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,PageHandlerExecutionDelegate next)
        //{
        //    //_logger.LogDebug("Global OnPageHandlerExecutionAsync called.");
        //    await next.Invoke();
        //}
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            //_logger.LogDebug("Global sync OnPageHandlerSelected called.");
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            //_logger.LogDebug("Global sync PageHandlerExecutingContext called.");
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            //_logger.LogDebug("Global sync OnPageHandlerExecuted called.");
        }
    }
}
