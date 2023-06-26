using Microsoft.AspNetCore.Mvc;
using MvcTest.MathLibrary;
using MvcTest.Models;

namespace MvcTest.Controllers
{
    public class IntegerSpiralController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Generate(GenerateSpiralModel model)
        {
            if(model.Width > 500)
            {
                throw new Exception("Width too large");
            }
            var spiral = new IntegerSpiralViewModel(model.Width);
            ViewData.Model = spiral;
            return View();
        }
    }
}
