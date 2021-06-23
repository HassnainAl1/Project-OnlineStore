using System;
using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNet.Identity;

namespace OnlineStore.Helpers
{
    public static class IdentityHelperExtensions
    {
        /// <summary>Return the user role using the UserIdClaimType</summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetUserRole(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));
            return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.Role) : null;
        }


        /// <summary>Return the email role using the UserIdClaimType</summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetUserEmail(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));
            return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.Email) : null;
        }


        /// <summary>Return the Member since using the UserIdClaimType</summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetMemberSince(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));
            return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.DateOfBirth) : null;
        }

        /// <summary>Return the Member since using the UserIdClaimType</summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public static string GetUserImage(this IIdentity identity)
        {
            if (identity == null)
                throw new ArgumentNullException(nameof(identity));
            return identity is ClaimsIdentity identity1 ? identity1.FindFirstValue(ClaimTypes.Uri) : null;
        }
    }
}