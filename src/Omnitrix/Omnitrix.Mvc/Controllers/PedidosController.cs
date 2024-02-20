using Microsoft.AspNetCore.Mvc;
using RegrasDeNegocios.Entidades;
using HamburgaoDoGeorjao.Mvc.Services;

namespace HamburgaoDoGeorjao.Mvc.Controllers
{
    public class PedidosController : Controller
    {
        private const int pageSize = 10;

        public PedidosApiService PedidosApiService { get; }

        public PedidosController(PedidosApiService pedidosApiService)
        {
            PedidosApiService = pedidosApiService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            List<Pedido> pedidos = new List<Pedido>();
            pedidos.AddRange(await PedidosApiService.Get());

            int totalCount = pedidos.Count;
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (totalCount < (pageSize * (page - 1)))
            {
                page = 1;
            }
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            var pedidosDaPagina = pedidos.Skip(pageSize * (page - 1)).Take(pageSize).ToArray();

            return View(pedidosDaPagina);
        }

        // GET: PedidosController/Details/5
        public ActionResult Details(int id)
        {
            return View(new Pedido());
        }

        // GET: PedidosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PedidosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}