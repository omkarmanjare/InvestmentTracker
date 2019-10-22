using PM.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PortfolioManager.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string authHeaders = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(actionContext.Request.Headers.Authorization.Parameter));
            if (AuthenticateUserNamePassword(authHeaders.Split(':')))
            {
                return;
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage()
                {
                    ReasonPhrase = "Unauthorised!",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized
                };
            }
        }

        private bool  AuthenticateUserNamePassword(string[] authParameters)
        {           
            var result = new UserOperations().AuthenticateUser(authParameters[0], authParameters[1]);
            return result.IsUserAuthenticated;
        }
    }
}