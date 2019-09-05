using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FilterDemo.Data;
using FilterDemo.Models;
using FilterDemo.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterDemo.Pages.ProjectItems
{
    public class IndexModel : PageModel
    {
        private readonly FilterDemo.Data.ManagementContext _context;
        private readonly ILogger _logger;

        public IndexModel(FilterDemo.Data.ManagementContext context,ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<ProjectItem> ProjectItem { get; set; }
        public string Message { get; set; }


        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public async Task OnGetAsync()
        {
            //ProjectItem = await _context.ProjectItems.ToListAsync();
            Message = "Your Index page.";
            _logger.LogDebug("Index/OnGet");
            await Task.CompletedTask;
        }

        public override void OnPageHandlerSelected(
                                    PageHandlerSelectedContext context)
        {
            //_logger.LogDebug("IndexModel/OnPageHandlerSelected");
        }

        public override void OnPageHandlerExecuting(
                                    PageHandlerExecutingContext context)
        {
            Message = "Message set in handler executing";
            _logger.LogDebug("IndexModel/OnPageHandlerExecuting");
        }


        public override void OnPageHandlerExecuted(
                                    PageHandlerExecutedContext context)
        {
            _logger.LogDebug("IndexModel/OnPageHandlerExecuted");
        }

    }
}
