using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace YourAppNamespace.Middlewares
{
    public class AdminMiddleware
    {
        private readonly RequestDelegate _next;

        public AdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.User.Identity.IsAuthenticated || !IsAdmin(context.User))
            {
                context.Response.StatusCode = 403; // Forbidden
                return;
            }

            await _next(context);
        }

        private bool IsAdmin(System.Security.Claims.ClaimsPrincipal user)
        {
            // Implement your own logic to determine if the user is an admin
            // For example, check if the user has a specific role or claim
            // You can access user claims using user.FindFirst(ClaimType) method

            // Example logic:
            return user.HasClaim(c => c.Type == "Role" && c.Value == "Admin");
        }
    }
}
