using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using ONE.Models;
using One.DbService.Infrastructure;
using One.DbAccess;
using One.DbService.Services;

namespace ONE.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // I have validate the client token
            context.Validated();
        }
        //public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        //{
        //     if (context.OwinContext.Request.Method == "OPTIONS" && context.IsTokenEndpoint)
        //    {
        //        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "POST" });
        //        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new[] { "accept", "authorization", "content-type" });
        //        context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });
        //        context.OwinContext.Response.StatusCode = 200;
        //        context.RequestCompleted();

        //        return Task.FromResult<object>(null);
        //    }

        //    return base.MatchEndpoint(context);
        //}
        // user can access grand resources
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var loginService = new UserAuthonticationService(new UnitOfWork(new SchoolContext(), One.Bo.Utility.Enums.ERunType.Debug));
             
            try
            {
                var response = loginService.Login(context.UserName, context.Password);
                identity.AddClaims(new List<Claim>() {
                    new Claim(ClaimTypes.Role, response.Role.ToString()),
                    new Claim(ClaimTypes.Name, context.UserName)
                });
                context.Validated(identity);
            }
            catch (ArgumentException) {
                context.SetError("invalied username or password");
            }
            catch (Exception e)
            {
                throw;
            }
        }
         
    }
}