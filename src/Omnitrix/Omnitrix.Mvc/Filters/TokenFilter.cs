using Microsoft.AspNetCore.Mvc.Filters;

namespace HamburgaoDoGeorjao.Mvc.Filters
{
    public class AuthenticationTokenFilter : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
