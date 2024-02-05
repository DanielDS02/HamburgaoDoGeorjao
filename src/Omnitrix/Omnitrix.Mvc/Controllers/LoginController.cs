using Microsoft.AspNetCore.Mvc;

namespace Omnitrix.Mvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
