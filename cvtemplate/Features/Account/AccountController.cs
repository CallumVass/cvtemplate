using Microsoft.AspNetCore.Mvc;

namespace cvtemplate.Features.Account
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}