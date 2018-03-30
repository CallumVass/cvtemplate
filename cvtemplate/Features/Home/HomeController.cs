using Microsoft.AspNetCore.Mvc;

namespace cvtemplate.Features.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}