using Microsoft.AspNetCore.Authentication;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using HamburgaoDoGeorjao.Mvc.Models;
using RegrasDeNegocios.Entidades;
using HamburgaoDoGeorjao.Mvc.Filters;

namespace HamburgaoDoGeorjao.Mvc.Controllers
{
    [AuthenticationTokenFilter]
    public class LoginController : Controller
    {
        public const string TOKEN_KEY = "JwtCookie";
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string ClienteApiEndpoint;

        public LoginController(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClient = httpClientFactory.CreateClient();
            ClienteApiEndpoint = configuration["PizzaApiEndpoint"] + "/api/cliente";
        }

        [HttpGet]
        public IActionResult Index()
        {

            // If user is already authenticated, redirect to another page
            if (User.Identity.IsAuthenticated)
            {
                var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (role.Value == "simples")
                {
                    return RedirectToAction("Index", "Pizzas");
                }
                if (role.Value == "manager")
                {
                    return RedirectToAction("Index", "Admin");
                }
            }

            return View(new Login());
        }

        public async Task<IActionResult> Logout()
        {
            // Sign out the user
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Redirect to the login page or another page after logout
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("email,password")] Login login)
        {
            if (ModelState.IsValid is false)
            {
                return View(login);
            }
            var tokenString = string.Empty;
            tokenString = await Autenticar(login, tokenString);
            // Validate and decode the JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadToken(tokenString) as JwtSecurityToken;

            if (token != null)
            {

                // Extract claims from the JWT token
                var jwtClaims = token.Claims.ToList();
                var nameClaim = jwtClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

                if (nameClaim == null)
                {
                    nameClaim = jwtClaims.FirstOrDefault(c => c.Type.Contains("name"));

                    jwtClaims.Add(new Claim(ClaimTypes.Name, nameClaim.Value));
                }

                var roleClaim = jwtClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                if (roleClaim == null)
                {
                    roleClaim = jwtClaims.FirstOrDefault(c => c.Type.Contains("role"));

                    jwtClaims.Add(new Claim(ClaimTypes.Role, roleClaim.Value));
                }


                // Create claims identity
                var claimsIdentity = new ClaimsIdentity(jwtClaims, JwtBearerDefaults.AuthenticationScheme);

                // Create claims principal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Set the JWT token as a cookie
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Set to true if using HTTPS
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddHours(1) // Set the expiration time as needed
                };

                Response.Cookies.Append(TOKEN_KEY, tokenString, cookieOptions);

                var authProperties = new AuthenticationProperties
                {
                    // You can set additional properties if needed
                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                    IsPersistent = true,
                };

                // Sign in the user with the combined claims
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);

                // Redirect to another page or return success
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Problema com api de autenticação.");
                return View(login);
            }
        }

        private async Task<string> Autenticar(Login login, string tokenString)
        {
            string Email = login.email;
            string Password = login.password;

            // Make a request to your authentication API to validate user credentials
            var apiEndpoint = _configuration["AuthenticationApiEndpoint"];
            var requestBody = $"{{\"email\": \"{Email}\", \"password\": \"{Password}\"}}";
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            using (var response = await _httpClient.PostAsync(apiEndpoint, content))
            {

                if (response.IsSuccessStatusCode)
                {
                    // Read the token from the API response
                    tokenString = await response.Content.ReadAsStringAsync();
                }
            }

            return tokenString;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Error = string.Empty;
            return View(new ClienteCreate());
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Email,Password,Nome,ConfirmPassword")] ClienteCreate cliente)
        {
            ViewBag.Error = string.Empty;
            if (ModelState.IsValid is false)
            {
                return View(cliente);
            }
            var userId = Guid.NewGuid();

            var apiEndpoint = _configuration["AuthenticationUsersApiEndpoint"];
            var content = new StringContent("{\r\n  " +
                "\"id\": \"" + userId + "\",\r\n  \"" +
                "email\": \"" + cliente.Email + "\",\r\n  \"" +
                "userName\": \"" + cliente.Nome + "\",\r\n  \"" +
                "password\": \"" + cliente.Password + "\",\r\n  \"" +
                "role\": \"simples\",\r\n  \"" +
                "confirmPassword\": \"" + cliente.ConfirmPassword + "\"\r\n}", null, "application/json");

            var response = await _httpClient.PostAsync(apiEndpoint, content);
            if (response.IsSuccessStatusCode)
            {
                Cliente clienteApi = new Cliente()
                {
                    Nome = cliente.Nome,
                    UserId = userId,
                };
                using (response = await _httpClient.PostAsJsonAsync<Cliente>(ClienteApiEndpoint, clienteApi))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            ViewBag.Error = response.Content;
            return View();
        }
        public IActionResult Denied()
        {
            return View();
        }
    }
}
