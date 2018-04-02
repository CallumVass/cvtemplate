using Microsoft.AspNetCore.Mvc;

namespace cvtemplate.Features.Secret
{
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}