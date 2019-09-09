using PortfolioManager.ErrorResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PortfolioManager.Filters
{
    public class ModelFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
           // base.OnActionExecuting(actionContext);

            if(!actionContext.ModelState.IsValid)
            {
                var parameter = actionContext.ModelState.Keys.FirstOrDefault().Split('.');

                actionContext.Response= ErrorGenerator.GenerateError(actionContext.Request,  parameter.Last(), ErrorCodes.InvalidInputs).Response;
                
            }
            
        }
    }
}