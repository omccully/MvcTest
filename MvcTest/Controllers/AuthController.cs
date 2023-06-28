using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MvcTest.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            var props = new AuthenticationProperties();
            props.RedirectUri = "/Auth/Success";

            return Challenge(props);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
