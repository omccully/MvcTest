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
            ViewData["PropertiesDict"] = new Dictionary<string,string>()
            {
                { "Request.Host", Request.Host.ToString() },
                { "Request.Path", Request.Path.ToString() },
                { "Request.PathBase", Request.PathBase.ToString() },
                { "Request.Protocol", Request.Protocol.ToString() },
                { "Request.QueryString", Request.QueryString.ToString() },
                { "Request.Scheme", Request.Scheme.ToString() },
                { "Request.HttpContext.Connection.RemoteIpAddress", Request.HttpContext.Connection.RemoteIpAddress?.ToString() },
                { "Request.HttpContext.Connection.RemotePort", Request.HttpContext.Connection.RemotePort.ToString() },
            };  

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