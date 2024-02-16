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

            //private List<PizzaModel> ObterPizzas()
            //{
            //    //// Lógica para obter dados de pizzas do seu sistema
            //    //// Pode ser de um banco de dados, serviço, etc.
            //    //// Aqui estou usando dados fictícios para ilustrar
            //    //return new List<Pizza>
            //    //{
            //    //    new Pizza { Id = 1, Sabor = "Margherita", TamanhoDePizza = "Média", Descricao = "Pizza clássica com molho de tomate, queijo e manjericão.", Valor = 20.99, ImageUrl = "/images/margherita.jpg", Quantity = 0 },
            //    //    new Pizza { ID = 2, Sabor = "Pepperoni", TamanhoDePizza = "Grande", Descricao = "Pizza com pepperoni, queijo e molho de tomate.", Valor = 23.99, ImageUrl = "/images/pepperoni.jpg", Quantity = 0 },
            //    //    // Adicione mais pizzas conforme necessário
            //    //};
            //}

            public async Task<IActionResult> IndexAsync()
            {
                HamburguersViewModel hamburguerViewModel = new HamburguersViewModel();

                var pizzas = await _httpClient.GetFromJsonAsync<Hamburguer[]>(HamburguerApiEndpoint);

                hamburguerViewModel.Hamburguers.AddRange(pizzas);
                return View(hamburguerViewModel);
            }
        }
    }
}
