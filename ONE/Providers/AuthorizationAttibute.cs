using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;

namespace ONE.Providers
{
    public class AuthorizationAttibute : System.Web.Http.AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext) {

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                // if is not login
                base.HandleUnauthorizedRequest(actionContext);
            }
            else {
                // if authorization faild
                actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}