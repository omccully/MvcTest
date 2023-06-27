using Microsoft.AspNetCore.Mvc;
using MvcTest.MathLibrary;
using MvcTest.Models;
using System.Reflection;

namespace MvcTest.Controllers
{
    public class IntegerSpiralController : Controller
    {
        public IActionResult Index(int width=0, bool clockwise=false)
        {
            var pageVm = new IntegerSpiralPageViewModel()
            {

            };
            if(width != 0)
            {
                if(width > 500)
                {
                    pageVm.ErrorMessage = "Width too large";
                }
                else if(width % 2 == 0)
                {
                    pageVm.ErrorMessage = "Width must be odd";
                }
                else
                {
                    var spiral = new IntegerSpiralViewModel(width, clockwise);
                    pageVm.Spiral = spiral;
                }
            }

            ViewData.Model = pageVm;
            return View();
        }
    }
}
