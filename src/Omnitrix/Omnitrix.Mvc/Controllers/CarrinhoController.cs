using Microsoft.AspNetCore.Mvc;

namespace Omnitrix.Mvc.Controllers
{
    public class CarrinhoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
