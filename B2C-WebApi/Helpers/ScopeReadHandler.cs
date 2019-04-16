using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B2CWebApi.Helpers
{
    public class ScopeAuthHandler : AuthorizationHandler<ScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ScopeRequirement requirement)
        {           
            var scopes = context.User.FindFirst("http://schemas.microsoft.com/identity/claims/scope")?.Value;
            if (!string.IsNullOrEmpty(requirement.ScopeType) && scopes != null && scopes.Split(' ').Any(s => s.Equals(requirement.ScopeType)))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
