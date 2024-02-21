using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegrasDeNegocios.Entidades;
using HamburgaoDoGeorjao.Mvc.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HamburgaoDoGeorjao.Mvc.Controllers
{
    public class HamburguerController : Controller
    {
        [Authorize(Roles = "simples")]
        public class HamburguersController : Controller
        {
            public HamburguersViewModel HamburguersViewModel { get; set; }
            public IConfiguration Configuration { get; }

            private readonly HttpClient _httpClient;
            private readonly string HamburguerApiEndpoint;

            public HamburguersController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
            {
                _httpClient = httpClientFactory.CreateClient();
                Configuration = configuration;
                HamburguerApiEndpoint = Configuration["HamburguerApiEndpoint"] + "/api/hamburguer";
            }


            public async Task<IActionResult> IndexAsync()
            {
                HamburguersViewModel hamburguerViewModel = new HamburguersViewModel();

                var hamburguers = await _httpClient.GetFromJsonAsync<Hamburguer[]>(HamburguerApiEndpoint);

                hamburguerViewModel.Hamburguers.AddRange(hamburguers);
                return View(hamburguerViewModel);
            }
        }
    }
}
