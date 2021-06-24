using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace OnlineStore.Helpers
{
    public static class IdentityHelperExtensions
    {
        ///// <summary>Return the user role using the UserIdClaimType</summary>
        ///// <param name="identity"></param>
        ///// <returns></returns>
        //public static string GetUserRole(this IIdentity identity)
        //{
        //    if (identity == null)
        //        throw new ArgumentNullException(nameof(identity));
        //    return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.Role) : null;
        //}


        ///// <summary>Return the email role using the UserIdClaimType</summary>
        ///// <param name="identity"></param>
        ///// <returns></returns>
        //public static string GetUserEmail(this IIdentity identity)
        //{
        //    if (identity == null)
        //        throw new ArgumentNullException(nameof(identity));
        //    return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.Email) : null;
        //}


        ///// <summary>Return the Member since using the UserIdClaimType</summary>
        ///// <param name="identity"></param>
        ///// <returns></returns>
        //public static string GetMemberSince(this IIdentity identity)
        //{
        //    if (identity == null)
        //        throw new ArgumentNullException(nameof(identity));
        //    return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.DateOfBirth) : null;
        //}

        ///// <summary>Return the Member since using the UserIdClaimType</summary>
        ///// <param name="identity"></param>
        ///// <returns></returns>
        //public static string GetUserImage(this IIdentity identity)
        //{
        //    if (identity == null)
        //        throw new ArgumentNullException(nameof(identity));
        //    return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.Uri) : null;
        //}

        public static void AddUpdateClaim(this IIdentity currentPrincipal, string key, string value)
        {
            var identity = currentPrincipal as ClaimsIdentity;
            if (identity == null)
                return;

            // check for existing claim and remove it
            var existingClaim = identity.FindFirst(key);
            if (existingClaim != null)
                identity.RemoveClaim(existingClaim);

            // add new claim
            identity.AddClaim(new Claim(key, value));
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.AuthenticationResponseGrant = new AuthenticationResponseGrant(new ClaimsPrincipal(identity), new AuthenticationProperties() { IsPersistent = true});
        }

        public static string GetClaimValue(this IIdentity currentPrincipal, string key)
        {
            var identity = currentPrincipal as ClaimsIdentity;
            if (identity == null)
                return null;

            var value = identity.FindFirstValue(key);
            return value;
        }
    }
}