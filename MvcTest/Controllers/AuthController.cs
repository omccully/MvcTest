using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Mvc;

namespace MvcTest.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult MicrosoftLogin()
        {
            var props = new AuthenticationProperties();

            props.RedirectUri = "/Auth/Success";
            return Challenge(props, MicrosoftAccountDefaults.AuthenticationScheme);
        }

        public IActionResult GoogleLogin()
        {
            var props = new AuthenticationProperties();
            props.RedirectUri = "/Auth/Success";
            return Challenge(props, GoogleDefaults.AuthenticationScheme);
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
