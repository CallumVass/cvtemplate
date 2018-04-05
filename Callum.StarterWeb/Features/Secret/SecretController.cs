using Microsoft.AspNetCore.Mvc;

namespace Callum.StarterWeb.Features.Secret
{
    public class SecretController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}