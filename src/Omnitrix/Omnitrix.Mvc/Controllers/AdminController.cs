using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegrasDeNegocios.Entidades;
using HamburgaoDoGeorjao.Mvc.Services;

namespace HamburgaoDoGeorjao.Mvc.Controllers
{
    [Authorize(Roles = "manager")]
    public class AdminController : Controller
    {
        public HamburguersApiService HamburguerApiService { get; }
        public IConfiguration Configuration { get; }

        private readonly HttpClient _httpClient;
        private readonly string HamburguerApiEndpoint;
        private readonly string ClienteApiEndpoint;

        private const int pageSize = 10;

        public AdminController(HamburguersApiService hamburguerApiService, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            HamburguerApiService = hamburguerApiService;
            Configuration = configuration;
            HamburguerApiEndpoint = Configuration["HamburguerApiEndpoint"] + "/api/hambuguer";
            ClienteApiEndpoint = configuration["HamburguerApiEndpoint"] + "/api/cliente";
        }


        public async Task<IActionResult> IndexAsync(int page = 1)
        {
            List<Hamburguer> hamburguers = new List<Hamburguer>();
            hamburguers.AddRange(await HamburguerApiService.Get());

            int totalCount = hamburguers.Count;
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (totalCount < (pageSize * (page - 1)))
            {
                page = 1;
            }
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            var hamburguersDaPagina = hamburguers.Skip(pageSize * (page - 1)).Take(pageSize).ToArray();

            return View(hamburguersDaPagina);
        }

        public async Task<IActionResult> Clientes(int page = 1)
        {


            List<Cliente> clientes = [.. await _httpClient.GetFromJsonAsync<Cliente[]>(ClienteApiEndpoint)];

            for (int i = 0; i < 100; i++)
            {
                clientes.Add(new Cliente() { Id = i, Nome = $"Exemplo {i}" });
            }

            int totalCount = clientes.Count;
            int totalPages = (int)Math.Ceiling((double)totalCount / pageSize);

            if (totalCount < (pageSize * (page - 1)))
            {
                page = 1;
            }
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;
            var clientesDaPagina = clientes.Skip(pageSize * (page - 1)).Take(pageSize).ToArray();

            return View(clientesDaPagina);
        }

    }
}

