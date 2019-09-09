using PM.BusinessLayer;
using PM.BusinessLayer.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PortfolioManager.Filters
{
    public class TokenValidatorAttribute: AuthorizationFilterAttribute
    {
       public override void OnAuthorization(HttpActionContext actionContext)
        {

            string token = actionContext.Request.Headers.Authorization.Parameter;
            if(ValidateToken(token))
            {
                return;
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage()
                {
                    ReasonPhrase = "Token is Invalid!",
                    StatusCode = System.Net.HttpStatusCode.Unauthorized,
                    
                };
            }
        }

        protected bool ValidateToken(string token)
        {
            bool userOps = new UserOperations().ValidateToken(token);
            return userOps;
        }
    }
}