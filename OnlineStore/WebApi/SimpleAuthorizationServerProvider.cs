using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Models;
using System.Web.Http;

namespace WebApi
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); //   
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var db = new OnlineStoreDBEntities())
            {
                if (db != null)
                {
                    var cart = db.Carts;
                    var user = db.Users;
                    if (user != null)
                    {
                        if (!string.IsNullOrEmpty(user.Where(u => u.Email == context.UserName && u.Password == context.Password).FirstOrDefault().Email))
                        {
                            identity.AddClaim(new Claim("Age", "16"));

                            var props = new Microsoft.Owin.Security.AuthenticationProperties(new Dictionary<string, string>
                            {
                                {
                                    "userdisplayname", 
                                    context.UserName
                                },
                                {
                                     "role", "admin"
                                }
                             });

                            var ticket = new AuthenticationTicket(identity, props);
                            context.Validated(ticket);
                        }
                        else
                        {
                            context.SetError("invalid_grant", "Provided username and password is incorrect");
                            context.Rejected();
                        }
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();
                }
                return;
            }
        }
    }
}