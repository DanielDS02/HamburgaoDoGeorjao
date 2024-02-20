using HamburgaoDoGeorjao.Mvc.Controllers;
using System.Net;
using System.Globalization;
using System.Net.NetworkInformation;

namespace HamburgaoDoGeorjao.Mvc.Middleware
{
    public class ValidarTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidarTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                context.Request.Cookies.TryGetValue(LoginController.TOKEN_KEY, out var token);


                if (token == null)
                {
                    
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    await context.Response.WriteAsync("Token invalido");
                    return;
                }
            }
            
            await _next(context);
        }
    }
}
