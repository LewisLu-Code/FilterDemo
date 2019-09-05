using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FilterDemo.Models;
using FilterDemo.Filters;

namespace FilterDemo.Controllers
{
    //[SampleActionFilter]
    public class HomeController : Controller
    {
        [ActionsFilter(Message = "Index",Order = 0)]
        //[ServiceFilter(typeof(ResourceFilter))]
        //[TypeFilter(typeof(ActionsFilter),Order =0)]
        public IActionResult Index()
        {
            return Content("<br />" + "Hello World!" + "<br />");
        }
        [ServiceFilter(typeof(AuthorizationFilter))]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
