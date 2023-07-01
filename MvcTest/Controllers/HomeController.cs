﻿using Microsoft.AspNetCore.Mvc;
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
            var request = Request;
            ViewData["UserEndpoint"] = Request.HttpContext.Connection.RemoteIpAddress + 
                ":" + Request.HttpContext.Connection.RemotePort;

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