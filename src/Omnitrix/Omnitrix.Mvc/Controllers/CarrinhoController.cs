using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using HamburgaoDoGeorjao.Mvc.Services;
using RegrasDeNegocios.Entidades;
using HamburgaoDoGeorjao.Mvc.Models;

namespace HamburgaoDoGeorjao.Mvc.Controllers
{
    public class CarrinhoController : Controller
    {
        public IConfiguration Configuration { get; }

        private readonly HttpClient _httpClient;
        private readonly string HamburguerApiEndpoint;

        public CarrinhoController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            Configuration = configuration;
            HamburguerApiEndpoint = Configuration["HamburguerApiEndpoint"] + "/api/hamrburguer";
        }

        [HttpPost]
        public IActionResult AdicionarAoCarrinho(int hamburguerId)
        {
            string returnUrl = Request.Headers["Referer"].ToString();
            List<int> hamburguers = GetHamburguers(HttpContext);
            hamburguers.Add(hamburguerId);

            HttpContext.Session.SetString("Pedidos", JsonSerializer.Serialize(hamburguers.ToArray()));
            return Redirect(returnUrl);
        }

        public async Task<IActionResult> Index()
        {
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel();
            var ids = GetHamburguers(HttpContext);

            var idParameter = string.Join(",", ids);
            var endpointWithIds = $@"{HamburguerApiEndpoint}?ids={idParameter}";

            var hamburguers = await _httpClient.GetFromJsonAsync<Hamburguer[]>(endpointWithIds);
            carrinhoViewModel.ConvertHamburguers(hamburguers);

            return View(carrinhoViewModel);
        }

        public static List<int> GetHamburguers(HttpContext context)
        {
            List<int> hamburguers = new List<int>();
            var data = context.Session.GetString("Pedidos");

            if (!string.IsNullOrEmpty(data))
            {
               hamburguers.AddRange(JsonSerializer.Deserialize<int[]>(data));
            }
            return hamburguers;
        }
    }
}

