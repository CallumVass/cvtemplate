﻿using Microsoft.AspNetCore.Mvc;

namespace cvtemplate.Features.Login
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}