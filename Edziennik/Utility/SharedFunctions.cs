using System.Security.Claims;

namespace Edziennik.Utility
{
    public static class SharedFunctions
    {
        public static Claim getClaim(ClaimsPrincipal User)
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim;
        }
    }
}
