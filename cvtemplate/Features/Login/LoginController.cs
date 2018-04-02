﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace cvtemplate.Features.Login
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IMediator mediator;
        public LoginController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View(new LoginCommand());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginCommand command)
        {
            await this.mediator.Send(command);
            return RedirectToAction("Index", "Home");
        }
    }
}