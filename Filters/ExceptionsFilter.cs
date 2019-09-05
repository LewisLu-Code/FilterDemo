using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FilterDemo.Filters
{
    public class ExceptionsFilter : IExceptionFilter
    {
        private readonly ILoggerFactory _loggerFactory;
        private readonly IHostingEnvironment _env;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public ExceptionsFilter(ILoggerFactory loggerFactory, IHostingEnvironment env,IModelMetadataProvider modelMetadataProvider)
        {
            _loggerFactory = loggerFactory;
            _env = env;
            _modelMetadataProvider = modelMetadataProvider;
        }
        public void OnException(ExceptionContext context)
        {
            var logger = _loggerFactory.CreateLogger(context.Exception.TargetSite.ReflectedType);
            logger.LogError(new EventId(context.Exception.HResult),
            context.Exception,
            context.Exception.Message);
            if (!_env.IsDevelopment())
            {
                return;
            }
            var result = new ViewResult { ViewName = "Error,Please Try Again" };
            //if (_errorMsg != "")
            //{
            //    result = new ViewResult { ViewName = _errorMsg };
            //}
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider,
                                                        context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            // TODO: Pass additional detailed data via ViewData
            context.Result = result;
           
        }
    }
}
