using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDemo.Policies
{
    public class CategoriaEmpleadoHandler : AuthorizationHandler<CategoriaEmpleadoRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            CategoriaEmpleadoRequirement requirement)
        {
            if (context.User.Claims.Any(x => x.Type == "CategoriaEmpleado"))
            {
                context.Succeed(requirement);
            }

            return Task.FromResult(0);
        }
    }
}
