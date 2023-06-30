using Microsoft.AspNetCore.Mvc;
using MvcTest.Models;
using System.Diagnostics;

namespace MvcTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Debug()
        {
            //string headers = String.Empty;
            //foreach (var kvp in Request.Headers)
            //    headers += kvp.Key + "=" + kvp.Value + Environment.NewLine;
            ViewData["HeadersDebug"] = Request.Headers;
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}