using Microsoft.AspNetCore.Mvc;

namespace Omnitrix.Mvc.Controllers
{
    public class ClienteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
