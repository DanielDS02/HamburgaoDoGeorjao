using RegrasDeNegocios.Entidades;

namespace HamburgaoDoGeorjao.Mvc.Services;

public class HamburguersApiService
{
    private readonly IConfiguration Configuration;
    private readonly HttpClient _httpClient;
    private readonly string HamburguerApiEndpoint;

    public HamburguersApiService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        Configuration = configuration;
        HamburguerApiEndpoint = Configuration["HamburguerApiEndpoint"] + "/api/hamburguer";
    }

    public async Task<Hamburguer[]> Get()
    {
        return await _httpClient.GetFromJsonAsync<Hamburguer[]>(HamburguerApiEndpoint);
    }

    public async Task<string> Create(Hamburguer hamburguer)
    {
        using (var response = await _httpClient.PostAsJsonAsync<Hamburguer>(HamburguerApiEndpoint, hamburguer))
        {
            if (response.IsSuccessStatusCode)
            {
                return string.Empty;
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}

public class PedidosApiService
{
    private readonly IConfiguration Configuration;
    private readonly HttpClient _httpClient;
    private readonly string PedidosApiEndpoint;

    public PedidosApiService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        Configuration = configuration;
        PedidosApiEndpoint = Configuration["PizzaApiEndpoint"] + "/api/pedidos";
    }

    public async Task<Pedido[]> Get()
    {
        return await _httpClient.GetFromJsonAsync<Pedido[]>(PedidosApiEndpoint);
    }

    public async Task<string> Create(Pedido pedido)
    {
        using (var response = await _httpClient.PostAsJsonAsync<Pedido>(PedidosApiEndpoint, pedido))
        {
            if (response.IsSuccessStatusCode)
            {
                return string.Empty;
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}

public class ClientesApiService
{
    private readonly IConfiguration Configuration;
    private readonly HttpClient _httpClient;
    private readonly string ClientesApiEndpoint;

    public ClientesApiService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        Configuration = configuration;
        ClientesApiEndpoint = Configuration["PizzaApiEndpoint"] + "/api/clientes";
    }

    public async Task<Cliente[]> Get()
    {
        return await _httpClient.GetFromJsonAsync<Cliente[]>(ClientesApiEndpoint);
    }

    public async Task<string> Create(Cliente cliente)
    {
        using (var response = await _httpClient.PostAsJsonAsync<Cliente>(ClientesApiEndpoint, cliente))
        {
            if (response.IsSuccessStatusCode)
            {
                return string.Empty;
            }
            return await response.Content.ReadAsStringAsync();
        }
    }
}

