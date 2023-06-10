using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;

namespace YourAppNamespace.Middlewares
{
    public class AuthenticateMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticateMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                if (context.Request.Headers["Accept"] == "application/json")
                {
                    context.Response.StatusCode = 401; // Unauthorized
                    return;
                }

                await context.ChallengeAsync(); // Redirect to login
                return;
            }

            await _next(context);
        }
    }
}
