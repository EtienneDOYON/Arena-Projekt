using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Core.Identity.Services.Classes
{
    public static class DataObtainingService
    {
        public static string GetClaim(this HttpContext context, string name)
        {
            var identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
                return identity.FindFirst(name)?.Value;

            return null;
        }

        public static int GetClaimAsInt(this HttpContext context, string name)
        {
            int.TryParse(context.GetClaim(name), out var result);
            return result;
        }
    }
}
