using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Results;
using System.Net;

namespace PortfolioManager.ErrorResponse
{
    public static class ErrorGenerator
    {

        public static ResponseMessageResult GenerateError(HttpRequestMessage request,string paramaeter,ErrorCodes errorCode)
        {
            //log the request
            //generate Error code

            var res= request.CreateResponse(HttpStatusCode.BadRequest, "Invalid parameter "+ paramaeter);

            
            return new ResponseMessageResult(res);
        }
    }
}