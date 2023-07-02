using System.Security.Claims;
using System.Security.Principal;

namespace MvcTest.Library
{
    public static class IdentityHelper
    {
        public static string? TryGetEmail(this IIdentity identity)
        {
            // for diagnostic/display purposes. not to be relied on.
            // there probably is a better way to do this
            if(identity is ClaimsIdentity claimsIdentity)
            {
                return claimsIdentity.Claims.FirstOrDefault(c => c.Value.Contains("@"))?.Value;
            }
            return null;
        }
    }
}
