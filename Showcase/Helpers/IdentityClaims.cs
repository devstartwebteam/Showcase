using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Microsoft.Owin.Security;

namespace Showcase.Helpers
{
    public static class IdentityClaims
    {
        public static string GetAuthorId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("AuthorId");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string Token(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("Token");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string RefreshToken(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("RefreshToken");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string TokenExpiration(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("TokenExpiration");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string Email(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("Email");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string ClassId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("ClassId");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string PackageId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("PackageId");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static int? PeriodId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("PeriodId");
            return (claim != null) ? Convert.ToInt32(claim.Value) : (int?) null;
        }

        public static int ActiveStep(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("ActiveStep");
            return (claim != null) ? Convert.ToInt32(claim.Value) : 2;
        }

        /// <summary>
        /// Group number identity claim
        /// </summary>
        /// <param name="identity"></param>
        /// <returns>Facets Group Number such as G0012434</returns>
        public static string GroupNumber(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("GroupNumber");
            return (claim != null) ? claim.Value : string.Empty;
        }

        /// <summary>
        /// Subscriber number identity claim
        /// </summary>
        /// <param name="identity"></param>
        /// <returns>Facets Subscriber Number such</returns>
        public static string SubscriberNumber(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("SubscriberNumber");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string EnrollLink(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("EnrollLink");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string StudentOrEmployeeNumber(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("StudentOrEmployeeNumber");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static bool IsTestUser(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity) identity).FindFirst("IsTestUser");
            // Test for null to avoid issues during local testing
            return (claim != null) && Convert.ToBoolean(claim.Value);
        }

        public static void AddUpdateClaim(this IPrincipal currentPrincipal, string key, string value)
        {
            var identity = currentPrincipal.Identity as ClaimsIdentity;
            if (identity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            // add new claim
            identity.AddClaim(new Claim(key, value));
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.AuthenticationResponseGrant =
                new AuthenticationResponseGrant(new ClaimsPrincipal(identity),
                    new AuthenticationProperties() {IsPersistent = true});
        }
    }
}