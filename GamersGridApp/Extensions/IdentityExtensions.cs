using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace GamersGridApp.Extensions
{
    public static class IdentityExtensions
    {
        public static string GetGGUserId( this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserId");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}