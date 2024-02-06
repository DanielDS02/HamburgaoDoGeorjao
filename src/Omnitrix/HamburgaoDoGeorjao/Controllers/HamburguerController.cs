using Microsoft.AspNetCore.Mvc;

namespace Omnitrix.Mvc.Controllers
{
    public class HamburguerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
